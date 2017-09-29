using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_05 : MonoBehaviour
{

    public bool isBugCheck = false;
    bool isCreateBug = false;
  public  bool isRota = false;

    public GameObject bugImage;
    public GameObject[] bugUI;
    public GameObject gameClaer, hiseikai;
    public PanelCrossChan_Ctrl PCC;
    public GameCtrl_PanelChange GP;
    public HintManager _HintMar;
    public GameObject hideObj;

    float hintTime = 0;
    float hint_DeltaTime = 0;
    bool hintFlg = false;
    float lasthint_byou;
    // Use this for initialization
    void Start()
    {
        string naiyou = "画面をスクロールして\n私の顔を動かしてみて！";
        _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
        hintTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hintFlg)
        {
            hint_DeltaTime += Time.deltaTime;
            if (hint_DeltaTime > hintTime)
            {
                if (hintTime == 10)
                {
                    string naiyou = "いろんな操作をしてバグを見つけよう！";
                    _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                    hintTime = 30;
                }
                else
                {
                    string naiyou = "画面上だけではなく端末全体で\nいろんな操作をしてみよう！";
                    _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                    hintFlg = true;
                }
            }
        }
        if(isCreateBug)
        {
            hintFlg = true;
            lasthint_byou += Time.deltaTime;
            if(lasthint_byou > 15)
            {
                string naiyou = "画面右上の「バグ報告」ボタンを押して、\n変な表示になっているところを教えよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                lasthint_byou = 0;
				isCreateBug = false;
            }
        }
        //BugCheck();
        if(Screen.width > Screen.height)
        {
            Vector3 pos = bugImage.transform.position;
            pos.x = Screen.width + (bugImage .GetComponent<RectTransform>().sizeDelta.x / 2);
            bugImage.transform.position = pos;
            isCreateBug = true;
        }
        else
        {
            Vector3 pos = bugImage.transform.position;
            pos.x = Screen.width * 2;
            bugImage.transform.position = pos;
        }
        if (isRota)
        {
            MenuRota();
        }
        // デバッグ用------------------------------------------------------+++++++++++++++++++++
        if (Input.GetKeyDown(KeyCode.A))
        {
            Seikai();
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Huseikai();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            isCreateBug = true;
        }
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
                        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);
                        // ゲームクリアー
                        isRota = false;
                        gameClaer.SetActive(true);
                        Screen.orientation = ScreenOrientation.Portrait;
                        string daimei, section, syousai;
                        daimei = "クリアおめでとう～♪";
                        section = "　・今回の不具合は";
                        syousai = "端末を横向きにしたら黒い画像が現れる不具合だよ！\n消し忘れかな？\n本番のQAでもあれ？って思ったことは遠慮せずに何でも報告しようね！\n";
                        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

                        /* セレクト画面でClear表示 */
                        PlayerPrefs.SetInt("ClearStat5", 1);
                    }
                    else
                    {
                        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);
                        // ゲームオーバーー
                        isRota = false;
                        gameClaer.SetActive(true);
                        Screen.orientation = ScreenOrientation.Portrait;
                        string daimei, section, syousai;
                        daimei = "残念だったね。。";
                        section = "・次回からはこんな観点で挑戦してね！";
                        syousai = "端末を横に回転してみると…?";
                        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");
                    }
                }
            }
        }
        if(isRota)
        {
            MenuRota();
        }
    }

    public void Seikai()
    {
        if (isCreateBug && isBugCheck)
        {
            hideObj.SetActive(false);
            isCreateBug = false;
            isBugCheck = false;
                        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);
            // ゲームクリアー
            isRota = false;
            gameClaer.SetActive(true);
            Screen.orientation = ScreenOrientation.Portrait;
            string daimei, section, syousai;
            daimei = "クリアおめでとう～♪";
            section = "　・今回の不具合は";
            syousai = "端末を横向きにしたら黒い画像が現れる不具合だよ！\n消し忘れかな？\n本番のQAでもあれ？って思ったことは遠慮せずに何でも報告しようね！\n";
            PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);

            /* セレクト画面でClear表示 */
            PlayerPrefs.SetInt("ClearStat5", 1);
        }
    }

    public void Huseikai()
    {
        hideObj.SetActive(false);

        isCreateBug = false;
        isBugCheck = false;
        GP.change_panel(GameCtrl_PanelChange.panel.Crosschan);
        // ゲームクリアー
        isRota = false;
        gameClaer.SetActive(true);
        Screen.orientation = ScreenOrientation.Portrait;
        string daimei, section, syousai;
        daimei = "残念だったね。。";
        section = "・次回からはこんな観点で挑戦してね！";
        syousai = "端末を横に回転してみると…?";
        PCC.set_crosschan(daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");

    }

    public void GameInitilize()
    {
        isRota = true;
        for(int i=0; i < bugUI.Length; i++)
        {
            bugUI[i].SetActive(false);
        }
        hiseikai.SetActive(false);

    }

    private void OnDisable()
    {
        // スマホの縦画面のみを許可
        Screen.orientation = ScreenOrientation.Portrait;
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
        if (bugUI[0].activeSelf)
        {
            isBugCheck = false;
            for (int i = 0; i < bugUI.Length; i++)
            {
                bugUI[i].SetActive(false);
            }
            hiseikai.SetActive(false);
        }
        else
        {
            isBugCheck = true;
            hiseikai.SetActive(true);
            for (int i = 0; i < bugUI.Length; i++)
            {
                bugUI[i].SetActive(true);
            }
        }
    }
}
