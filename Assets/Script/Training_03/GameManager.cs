using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // メインカメラの取得
    Camera mainCamera;
    // 弾のプレハブ
    public GameObject bullet;
    // 出現させるターゲット
    public GameObject enemy;
    // テキストのオブジェクト
    public GameObject scoreText,gameTimeObj;
    // スコアの数
    public int scoreNum;
    // タップした座標
    public Vector3 mousePosition;
    Vector3 angle = new Vector3(0, 0, 0);
    // タップしている時間
    public float clickTime = 0;
    // 発射する際までに判定する数値
    float fireCount = 0.15f;
    // ターゲットを生成するスピード
    public float createCount;
    float createTime;

    // 1度だけ呼び出すフラグ
   public bool isSetFlg = true;

    // ゲームのUI切り替え(最初にONに設定し、呼び出せるようにする)
    bool isGameFlg = false;
    public GameObject UI_Title,UI_Game;
    // ゲーム開始までの時間
    int startCount = 3;
    float startTime;
    // ゲーム中の時間
    int gameCount = 10;
    float gameTime;

    // エラーメッセージ
    public GameObject errorObject;

    public enum GameState
    {
        TITLE,
        GAME,
    }
    public GameState GAMESTATE;


    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 0.1f;
        StateManager();
       
    }

    // ゲームとタイトルの切り替えを管理
    void StateManager()
    {
        switch (GAMESTATE)
        {
            case GameState.TITLE:
                {
                    // 最初だけ呼び出す(主に初期化など)
                    if (isSetFlg)
                    {
                        isGameFlg = false;
                        UI_Title.SetActive(true);
                        UI_Game.SetActive(false);
                        // 最後にフラグを切って処理しないようにする
                    isSetFlg = false;
                    }

                  
                    break;
                }
            case GameState.GAME:
                {
                    // 最初だけ呼び出す(主に初期化など)
                    if (isSetFlg)
                    {
                        isGameFlg = true;
                        UI_Title.SetActive(false);
                        UI_Game.SetActive(true);
                        startTime = 0;
                        startCount = 2;
                        scoreNum = 0;
                        gameCount = 2;
                        gameTime = 0;

                        // 最後にフラグを切って処理しないようにする
                        isSetFlg = false;
                    }

                    if (startCount < 1)
                    {
                        // ターゲットを生成
                        createTime += Time.deltaTime;
                        if (createCount < createTime)
                        {
                            GameObject createObj = Instantiate(enemy);
                            enemy.transform.position = new Vector3(Random.Range(-40, 40), 10, Random.Range(-40, 40));
                            createTime = 0;
                        }
                        CameraMove();
                        // ゲーム中の時間を表示
                        gameTime += Time.deltaTime;
                        gameCount = Mathf.CeilToInt(10 - gameTime);
                        gameTimeObj.GetComponent<Text>().text = "" + gameCount;
                        // 終了判定(今はステートをTITLEにしているが、後でリザルトにする)
                        if(gameCount < 1)
                        {
                            isSetFlg = true;
                            GAMESTATE = GameState.TITLE;
                        }
                    }
                    else
                    {
                        startTime += Time.deltaTime;
                        startCount = Mathf.CeilToInt(3 - startTime);
                        scoreText.GetComponent<Text>().text = "" + startCount;
                    }
                    break;
                }
        }
    }

    // カメラの回転と玉の発射
    void CameraMove()
    {
        /// クリック(タップ)した際に初期化とカメラの初期座標を取得
        /// クリック中はカメラを回転させる
        /// マウスを離した時間が一定以内(fireCount)なら弾を発射(離した箇所場所に弾が飛ぶ)
        /// タップした際にカメラが地味に動くので、fireCountの時間を超えたら動くようにする
        if (Input.GetMouseButtonDown(0))
        {
            // 初期化
            clickTime = 0;
            // クリック開始時にカメラの角度を保持(Z軸には回転させないため).
            angle = mainCamera.transform.localEulerAngles;
            mousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            clickTime += Time.deltaTime;
            if (clickTime > fireCount)
            {
                // マウスの移動量分カメラを回転させる(横回転のみなのでカメラの角度Y軸を更新)
                angle.y -= (Input.mousePosition.x - mousePosition.x) * 0.1f;
                mainCamera.gameObject.transform.localEulerAngles = angle;
                mousePosition = Input.mousePosition;
            }
            else
            {
                angle = mainCamera.transform.localEulerAngles;
                mousePosition = Input.mousePosition;
            }
        }
        if (clickTime < fireCount)
        {
            Fire();
        }
    }
    // 弾の発射処理
    void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // レイを飛ばして当たれば判定
            if (Physics.Raycast(ray, out hit) && hit.transform != null)
            {
                // エディタ上でRaycastの判定外に設定
                //if (hit.transform.tag != "Bullet")
                //{
                GameObject createObj = Instantiate(bullet);
                    createObj.transform.position = mainCamera.ScreenToWorldPoint(mainCamera.transform.position);
                    createObj.transform.LookAt(hit.point);
               // }
            }

        }
    }

    // ボタンの管理

    // ゲーム開始処理
    public void GameStart()
    {
        isSetFlg = true;
        GAMESTATE = GameState.GAME;
    }
    // ベストスコアを表示
    public void BestScore()
    {
        ErrorMessage();
    }
    // ステージセレクトに戻る
    public void StageSelectScene()
    {
        ErrorMessage();
    }
    // エラー
    void ErrorMessage()
    {
        errorObject.SetActive(true);
    }
    // 閉じる
    public void ErrorHide()
    {
        errorObject.SetActive(false);
    }
}
