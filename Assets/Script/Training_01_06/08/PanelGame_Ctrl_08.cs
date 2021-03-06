﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_08 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public PanelHoukoku_Ctrl_08 PHC;
	public GameObject PanelHoukoku;
	public Text TextOkane;
	public Text TextHosi5, TextHosi4, TextHosi3;
	public GameObject Gacha;
	public GameObject ImageHosi5, ImageHosi4, ImageHosi3;
	public GameCtrl_ClearCheck_08 GCC;

    public GameObject[] anim;

	int okane;
	int hosi5char_kazu, hosi4char_kazu, hosi3char_kazu;

	const int SYOKIOKANE = 1000;


	Color gachacolor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Awake () {
		//GCC.set_clearflg (false);
	}
		
	void OnEnable () {
		okane = SYOKIOKANE;
		//TextOkane.text = "€" + okane;

		hosi5char_kazu = 0;
		hosi4char_kazu = 0;
		hosi3char_kazu = 0;
		/*
		TextHosi5.text = "×" + hosi5char;
		TextHosi4.text = "×" + hosi4char;
		TextHosi3.text = "×" + hosi3char;
		*/
		hyouzi ();
	}

	public void Gacha_hiku()
	{
		//int rand;

        GetComponent<Animator>().SetBool("IsAnim", true);

		//rand = Random.Range (1, 10);

		//if (rand == 1) {
		//	gacha_kekka_hyouzi (5);
		//} else if ((1 < rand) && (rand <= 4)) {
		//	gacha_kekka_hyouzi (4);
		//} else if ((4 < rand) && (rand <= 10)) {
		//	gacha_kekka_hyouzi (3);
		//}
		//hyouzi ();

		//if (okane <= 0) {
		//	image_char_false ();
		//	PHC.huseikai ();
		//	return;
		//}
       
		//gacha_hyouzi_hihyouzi (0f);
	}

    public void CharaGacha()
    {
        int rand;
        rand = Random.Range(1, 10);

        if (rand == 1)
        {
            gacha_kekka_hyouzi(5);
        }
        else if ((1 < rand) && (rand <= 4))
        {
            gacha_kekka_hyouzi(4);
        }
        else if ((4 < rand) && (rand <= 10))
        {
            gacha_kekka_hyouzi(3);
        }
        hyouzi();

        if (okane <= 0)
        {
            image_char_false();
            PHC.huseikai();
            return;
        }
    }

	void gacha_kekka_hyouzi (int hosi)
	{
		if (hosi == 5) {
			ImageHosi5.SetActive(true);
		} else if (hosi == 4) {
			ImageHosi4.SetActive(true);
		} else if (hosi == 3) {
			ImageHosi3.SetActive(true);
		}
    }

    public void FlgOFF()
    {
        GetComponent<Animator>().SetBool("IsAnim", false);
    }

    public void gacha_char_tap (int hosi)
	{
		if (hosi == 5) {
			hosi5char_kazu++;
		} else if (hosi == 4) {
			hosi4char_kazu++;
		} else if (hosi == 3) {
			hosi3char_kazu++;
		}
		image_char_false ();
		okane -= 100;
		hyouzi ();

		gacha_hyouzi_hihyouzi (1f);
	}

	void hyouzi ()
	{
		TextOkane.text = "€" + okane;
		TextHosi5.text = "×" + hosi5char_kazu;
		TextHosi4.text = "×" + hosi4char_kazu;
		TextHosi3.text = "×" + hosi3char_kazu;
	}

	void gacha_hyouzi_hihyouzi(float f)
	{
		gachacolor = Gacha.GetComponent<Image>().color;
		Gacha.GetComponent<Image>().color = new Color (gachacolor.r, gachacolor.g, gachacolor.b, f);
	}

	bool image_char_false()
	{
		bool ret = false;
		if ((ImageHosi3.activeSelf) || (ImageHosi4.activeSelf) || (ImageHosi5.activeSelf)) {
			ImageHosi5.SetActive(false);
			ImageHosi4.SetActive(false);
			ImageHosi3.SetActive(false);
			ret = true;
		}
		return ret;
	}
		
	public void Houkoku_Button()
	{
		//GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
		image_char_false ();
		PanelHoukoku.SetActive (true);
	}

	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus) {
			gacha_hyouzi_hihyouzi (1f);
			if (image_char_false () == true) {
				GCC.set_clearflg (true);
			}
			//Debug.Log("applicationWillResignActive or onPause");
		} else {
			//Debug.Log("applicationDidBecomeActive or onResume");
		}
	}
}
