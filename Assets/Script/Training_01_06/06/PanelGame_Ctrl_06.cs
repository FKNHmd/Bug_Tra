using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_06 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelCrossChan_Ctrl PCC;
	public Text TextNokoriByou;
	public Text TextCount;
	public GameObject ImageCrash;

	int count;
	float nokori;
	float oldtime, newtime, deltatime;
	bool clear_flg;

    float hintTime = 0;

    public HintManager _HintMar;

	// Use this for initialization
	void Start () {


    }

    void OnEnable () {
		count = 0;
		nokori = 11;
		TextCount.text = "" + count;
		TextNokoriByou.text = "" + (int)nokori;
		oldtime = Time.time;
		clear_flg = false;

		hintTime = 0;

		string naiyou = "頑張ってボタン連打してね！";
		_HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
	}
	
	// Update is called once per frame
	void Update () {
		nokori -= Time.deltaTime;
		TextNokoriByou.text = "" + (int)nokori;

		if ((nokori <= 0) && (clear_flg == false)) {
			string daimei, section, syousai;

			GP.change_panel (GameCtrl_PanelChange.panel.Crosschan, 1f, 0.12f);

			daimei = "残念だったね。。";
			section = "・次回からはこんな観点で挑戦してね！";
			syousai = "ちょっと頑張りが足りないみたい。頑張って連打してみて！それでもバグが発生しなかったら、人差し指と中指で交互にボタンタップするといいかもだよ！";
			PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Syobon, PanelCrossChan_Ctrl.crosschan_button.Game, "リトライ");

		}

        // ヒントの生成
        hintTime += Time.deltaTime;
        if(hintTime > 7)
        {
            string[] naiyou ={
                "もっと早く連打してみて！",
                "ふぁいとー！",
                "連打！連打！連打！",
                "GO!GO!GO!",
                "がんばれー！",
            };
            _HintMar.HintParent(naiyou[Random.Range(0,naiyou.Length)], 5, HintManager.FaceState.ManmenEgao);
            hintTime = 0;
        }
    }

	public void countup()
	{
		newtime = Time.time;
		deltatime = newtime - oldtime;
		Debug.Log (deltatime);
		oldtime = newtime;

		if (deltatime < 0.07f) {
			clear_flg = true;
			StartCoroutine (crash_gizi ());
		}

		count++;
		TextCount.text = "" + count;
	}

	IEnumerator crash_gizi()
	{
		string daimei, section, syousai;

		ImageCrash.SetActive (true);
		yield return new WaitForSeconds(7f);
		ImageCrash.SetActive (false);

		GP.change_panel (GameCtrl_PanelChange.panel.Crosschan, 1f, 0.08f);
		daimei = "クリアおめでとう～♪";
		section = "　・今回の不具合は";
		syousai = "ボタンを速く連打するとアプリがクラッシュしちゃうバグだよ！\nクラッシュとは、アプリが突然異常終了することだよ。今回は疑似的なクラッシュだけどね！\n開発中のアプリは結構発生するんだけど、とても重大なバグなので本番のQAではリリース前に絶対見つけてね！";
		PCC.set_crosschan (daimei, section, syousai, PanelCrossChan_Ctrl.crosschan_gazou.Niko, PanelCrossChan_Ctrl.crosschan_button.Select);
		/* セレクト画面でClear表示 */
		PlayerPrefs.SetInt ("ClearStat6", 1);
	}
}
