using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_03 : MonoBehaviour
{
    // メインカメラの取得
    Camera mainCamera;
    // 弾のプレハブ
    public GameObject bullet;
    // 出現させるターゲット
    public GameObject enemy;
    // テキストのオブジェクト
    public GameObject scoreText, gameTimeObj;
    // スコアの数
    public int scoreNum;
    // スコアを格納
    [SerializeField]
    List<int> scoreRank = new List<int>();
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
    bool isSetFlg = true;
    // バグが発生したかを判断
    public bool isBugSET = false;
    // バグ報告ボタンを押下され、バグを探しているかを判断
    public bool isBugCheck = false;

    // 発生したバグの内容
    public string bagText;

    // ゲームのUI切り替え(最初にONに設定し、呼び出せるようにする)
    bool isGameFlg = false;
    public GameObject UI_Title, UI_Game, UI_Result;
    // ゲーム開始までの時間
    int startCount = 3;
    float startTime;
    // ゲーム中の時間
    int gameCount = 10;
    float gameTime;

    // エラーメッセージ
    public GameObject errorObject;
    // 敵が破壊された際のエフェクト
    public GameObject boxEffect;

    // ゲームクリアした際に表示するメッセージ
    public GameObject gameClaer;

    // 参照スクリプト
    FadeManager _SceneMar;

    public enum GameState
    {
        TITLE,
        GAME,
        RESULT,
    }
    public GameState GAMESTATE;


    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _SceneMar = GameObject.Find("SceneManager").GetComponent<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 0.1f;
        StateManager();
        BugCheck();
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
                        mainCamera.transform.position =
                            GameObject.Find("TitleBack").transform.position;
                        mainCamera.transform.eulerAngles = Vector3.zero;
                        UI_Title.SetActive(true);
                        UI_Game.SetActive(false);
                        UI_Result.SetActive(false);
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
                        mainCamera.transform.position = new Vector3(0, 5, 0);
                        mainCamera.transform.eulerAngles = Vector3.zero;
                        // ターゲットがゲーム上に存在する場合は消す
                        List<GameObject> enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
                        if (enemys.Count > 0)
                        {
                            for (int i = 0; i < enemys.Count; i++)
                            {
                                Destroy(enemys[i]);
                            }
                            enemys.Clear();
                        }
                        UI_Title.SetActive(false);
                        UI_Game.SetActive(true);
                        UI_Result.SetActive(false);
                        startTime = 0;
                        startCount = 2;
                        scoreNum = 0;
                        gameCount = 2;
                        gameTime = 0;
                        isBugSET = false;

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
                            enemy.transform.eulerAngles = new Vector3(0, Random.Range(-40, 40), 0);
                            createTime = 0;

                            // ひとまずランダムでバグを発生させる------------------------------------------------------------------------------
                            if (scoreNum > 1000)
                            {
                                isBugSET = true;
                            }
                        }
                        CameraMove();
                        // ゲーム中の時間を表示
                        gameTime += Time.deltaTime;
                        gameCount = Mathf.CeilToInt(20 - gameTime);
                        gameTimeObj.GetComponent<Text>().text = "" + gameCount;
                        // 終了判定
                        if (gameCount < 1)
                        {
                            isSetFlg = true;
                            GAMESTATE = GameState.RESULT;
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
            case GameState.RESULT:
                {
                    // 最初だけ呼び出す(主に初期化など)
                    if (isSetFlg)
                    {
                        isGameFlg = false;
                        UI_Title.SetActive(false);
                        UI_Game.SetActive(false);
                        UI_Result.SetActive(true);
                        // 現在のスコアを反映
                        GameObject.Find("NowScore").GetComponent<Text>().text = "SCORE:" + scoreNum;
                        // スコアを保存して降順にする
                        scoreRank.Add(scoreNum);
                        scoreRank.Sort();   //昇順
                        scoreRank.Reverse();//格納してる順番を逆にする 
                                            // ランキングに反映
                        Transform[] rankText = GameObject.Find("ScoreRank").GetComponentsInChildren<Transform>();

                        for (int i = 0; i < 3; i++)
                        {
                            if (scoreRank.Count < i + 1)
                            {
                                rankText[i + 1].GetComponent<Text>().text = (i + 1) + "番:----";
                            }
                            else
                            {
                                rankText[i + 1].GetComponent<Text>().text = (i + 1) + "番:" + scoreRank[i];
                            }
                        }
                        // 最後にフラグを切って処理しないようにする
                        isSetFlg = false;
                    }
                    // ひとまずランダムでバグを発生させる------------------------------------------------------------------------------
                    if (isBugSET && !isBugCheck)
                    {
                        scoreNum += 1;
                        GameObject.Find("NowScore").GetComponent<Text>().text = "SCORE:" + scoreNum;
                    }
                    break;
                }
        }
    }
    // カメラの回転と玉の発射
    void CameraMove()
    {
        // バグチェック中は機能させない
        if (!isBugCheck)
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

    // バグを見つけた際の処理
    void BugCheck()
    {
        if (isBugCheck)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = GameObject.Find("UICamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // レイを飛ばして当たれば判定
                if (hit.collider != null)
                {
                    // 当たったのがバグの画像、かつバグがセット中であればゲームクリアー
                    if (hit.collider.name == "BugImage" &&
                        isBugSET)
                    {
                        // ゲームクリアー
                        gameClaer.SetActive(true);
                    }
                }
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
    // タイトル画面
    public void TitleMenu()
    {
        isSetFlg = true;
        GAMESTATE = GameState.TITLE;
    }
    // ベストスコアを表示
    public void BestScore()
    {
        // スコアを保存して降順にする
        scoreRank.Sort();   //昇順
        scoreRank.Reverse();//格納してる順番を逆にする 
                            // ランキングに反映
        Transform[] rankText = GameObject.Find("ScoreRank").GetComponentsInChildren<Transform>();

        for (int i = 0; i < 3; i++)
        {
            if (scoreRank.Count < i + 1)
            {
                rankText[i + 1].GetComponent<Text>().text = (i + 1) + "番:----";
            }
            else
            {
                rankText[i + 1].GetComponent<Text>().text = (i + 1) + "番:" + scoreRank[i];
            }
        }
        //ErrorMessage();
    }
    // ステージセレクトに戻る
    public void StageSelectScene()
    {
        Time.timeScale = 1;
        _SceneMar.LoadLevel("Game_Select", 0.5f);
    }
    // エラー
    public void ErrorMessage()
    {
        if (errorObject.activeSelf)
        {
            errorObject.SetActive(false);

        }
        else
        {
            errorObject.SetActive(true);

        }
    }
}
