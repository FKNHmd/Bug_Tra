using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_05 : MonoBehaviour
{

    public bool isBugCheck = false;
    bool isRota = true;

    public GameObject gameClaer, bugUI, stopUI;
    public PanelCrossChan_Ctrl PCC;


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        BugCheck();
    }

    // バグを見つけた際の処理
    void BugCheck()
    {
        if (isBugCheck)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // レイを飛ばして当たれば判定
                if (hit.collider != null)
                {
                    // 当たったのがバグの画像、かつバグがセット中であればゲームクリアー
                    if (hit.collider.name == "BugImage")
                    {
                        // ゲームクリアー
                        Time.timeScale = 1;
                        isRota = false;
                        gameClaer.SetActive(true);
                        Screen.orientation = ScreenOrientation.Portrait;
                        string daimei, section, syousai;
                        daimei = "クリアおめでとう～♪";
                        section = "・今回の不具合は";
                        syousai = "画面を回転したら黒い画像が現れる不具合だよ！\n消し忘れかな？";
                        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

                    }
                }
            }
        }
        if (isRota)
        {
        MenuRota();
        }
    }
    private void OnDisable()
    {
        // スマホの縦画面のみを許可
        Screen.orientation = ScreenOrientation.Portrait;
    }
    // 一時停止
    public void StopButton()
    {
        if (stopUI.activeSelf)
        {
            stopUI.SetActive(false);
            Time.timeScale = 1;
            MenuRota();
        }
        else
        {
            stopUI.SetActive(true);
            Time.timeScale = 0;
            // 縦画面に戻す
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
    void MenuRota()
    {
        // 自動回転可能にする
        Screen.orientation = ScreenOrientation.AutoRotation;
        //スマホの左側が下になります
        Screen.autorotateToLandscapeLeft = true;
        //スマホの右側が下になります
        Screen.autorotateToLandscapeRight = true;
        //スマホの下が下になります
        Screen.autorotateToPortrait = true;
        //スマホの上が上になります
        Screen.autorotateToPortraitUpsideDown = false;
    }
    // バグボタン
    public void BugCheckButton()
    {
        if (bugUI.activeSelf)
        {
            isBugCheck = false;
            bugUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isBugCheck = true;
            bugUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
