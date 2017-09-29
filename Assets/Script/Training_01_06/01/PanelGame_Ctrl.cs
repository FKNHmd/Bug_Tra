using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl : MonoBehaviour {

	public InputField DummyInput;
	public GameObject ImageOn;
	public GameObject ImageOff;
	public GameCtrl_PanelChange GP;
	public GameObject PanelHoukoku;

	bool on_flg;
	float on_byou;
	float oldtime, newtime, deltatime;
    int nyuuryokusuu;
    float lasthint_byou;
    bool lasthint_flg;
    int nyuuryoku_q;

    //HintMgr_01 hm01;

    HintManager _HintMar;

	// Use this for initialization
	void Start () {
        _HintMar = GameObject.Find("HintObject").GetComponent<HintManager>();
        string naiyou = "キーボードで文字を\n入力すると蛍が光るよ！";
        _HintMar.HintParent(naiyou, 5,HintManager.FaceState.Egao);
    }
	
	// Update is called once per frame
	void Update () {
		/* １秒だけ点灯 */
		if (on_flg == true) {
			on_byou += Time.deltaTime;
			if (on_byou < 1f) {
			} else {
				on_byou = 0f;
				on_flg = false;
				image_off ();
			}
		}

        if (lasthint_flg == true)
        {
            lasthint_byou += Time.deltaTime;
            if (lasthint_byou > 15f)
            {
                string naiyou = "画面右上の「バグ報告」ボタンを押して\nどの文字で蛍が光らないか教えよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.ManmenEgao);
                lasthint_byou = 0;
				lasthint_flg = false;
            }
        }
    }
		
	void OnEnable () {
		ImageOff.SetActive (true);
		ImageOn.SetActive (false);
		StartCoroutine (ActInput());

		on_flg = false;
		on_byou = 0f;

        //hm01 = GameObject.Find ("HintMgr").GetComponent<HintMgr_01> ();

    }

	IEnumerator ActInput()
	{
		yield return new WaitForSecondsRealtime (1.0f);
		DummyInput.ActivateInputField ();
	}

	void image_on ()
	{
		ImageOn.SetActive (true);
		ImageOff.SetActive (false);
	}

	void image_off ()
	{
		ImageOff.SetActive (true);
		ImageOn.SetActive (false);
	}

	public void InputChange()
	{
        if (DummyInput.text == "q")
        {
            nyuuryoku_q++;
            /* ヒント用処理 */
            //hm01.CountUpNyuuryoku_q ();
            if (nyuuryoku_q == 3 && !lasthint_flg)
            {
                string naiyou = "あれ？ある文字を入力した時に\n蛍が光っていないよ？";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Syobon);
                // 3回の時に発生するので数を増やしておく
                nyuuryoku_q++;
                lasthint_flg = true;
            }
        }
        else if (DummyInput.text == "")
        {
            /* 空白は何もしない */
        }
        else
        {
            nyuuryokusuu++;
			on_byou = 0f;	//連続で文字入力した時の為
            image_on();
            on_flg = true;

            /* ヒント用処理 */
            //hm01.CountUpNyuuryokusuu ();
            if (nyuuryokusuu == 10)
            {
                string naiyou = "「ひらがな」「記号」「アルファベット」\nいろいろな文字を入力してみよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
            }
            if (nyuuryokusuu == 20)
            {
                string naiyou = "「アルファベット」を\n重点的に調べてみよう！";
                _HintMar.HintParent(naiyou, 5, HintManager.FaceState.Egao);
            }
        }

		DummyInput.text = "";
	}
		
	public void Houkoku_Button()
	{
		//GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
		PanelHoukoku.SetActive(true);
	}
}
