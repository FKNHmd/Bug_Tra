using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintMgr_01 : MonoBehaviour {

	bool[] hint_flg = new bool[5]; /* ヒント同時5個まで */
	int nyuuryokusuu;
	int nyuuryoku_q;
	float lasthint_byou;
	bool lasthint_flg;

	// Use this for initialization
	void Start () {
		Game_Start ();
	}
	
	// Update is called once per frame
	void Update () {
		/* qを３回入力の１5秒後に最後のヒント */
		if (lasthint_flg == true) {
			lasthint_byou += Time.deltaTime;
			if (lasthint_byou > 15f) {
				Hint_Start (Hint_Flg_Check (), "画面右上の「バグ報告」ボタンを押して\nどの文字で蛍が光らないか教えよう！");
				lasthint_flg = false;
			}
		}
	}

	public void Game_Start ()
	{
		syokika ();
		Hint_Start (0, "キーボードで文字を\n入力すると蛍が光るよ！");
	}

	void syokika ()
	{
		/* 初期化処理 */
		for (int i = 0; i < 5; i++) {
			hint_flg [i] = false;
		}
		nyuuryokusuu = 0;
		nyuuryoku_q = 0;
		lasthint_byou = 0f;
		lasthint_flg = false;
	}

	public void CountUpNyuuryokusuu ()
	{
		nyuuryokusuu++;

		if (nyuuryokusuu == 10) {
			Hint_Start (Hint_Flg_Check (), "「ひらがな」「記号」「アルファベット」\nいろいろな文字を入力してみよう！");
		}

		if (nyuuryokusuu == 20) {
			Hint_Start (Hint_Flg_Check (), "「アルファベット」を\n重点的に調べてみよう！");
		}
	}

	public void CountUpNyuuryoku_q ()
	{
		nyuuryoku_q++;

		if (nyuuryoku_q == 3) {
			Hint_Start (Hint_Flg_Check (), "あれ？ある文字を入力した時に\n蛍が光っていないよ？");
			lasthint_flg = true;
		}
	}

	int Hint_Flg_Check () {
		int ret = -1;
		for (int i = 0; i < 5; i++) {
			if (hint_flg [i] == false) {
				ret = i;
				break;
			} else {
				continue;
			}
		}
		return ret;
	}

	void Hint_Start (int n, string str)
	{
		GameObject gobj;
		string gobj_name;

		hint_flg [n] = true;

		gobj_name = "Panel_Hint" + n;
		gobj = GameObject.Find (gobj_name);
		gobj.transform.Find ("Text Hint").GetComponent<Text>().text = str;

		/* アニメションスタート */
	}

	public void Hint_End (int n)
	{
		hint_flg [n] = false;
	}
}
