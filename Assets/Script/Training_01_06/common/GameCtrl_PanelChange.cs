using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCtrl_PanelChange : MonoBehaviour {

	public enum panel {
		Crosschan,
		Game,
		Houkoku
	}

	public GameObject PanelCrossChan;
	public GameObject PanelGame;
	public GameObject PanelHoukoku;
	public GameObject FadeInOut;

    public GameObject[] hideObjs;
    bool isHideFlg = false;

	//GameObject PanelOld = null;
	bool panelold_flg = false;
	GameObject PanelNew = null;
	float alpha = 0f;

	float fos;
	float fis;

	// Use this for initialization
	void Start () {
		FadeInOut.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		//if (PanelOld != null) {
		if (panelold_flg == true) {
			alpha = alpha + fos;
			if (alpha >= 1f) {
				//PanelOld.SetActive (false);
				oldpanel_noactive ();
//				PanelOld = null;
				panelold_flg = false;
                //				Debug.Log ("hoge");
                if (hideObjs != null && isHideFlg == true)
                {
                    for (int i = 0; i < hideObjs.Length; i++)
                    {
                        hideObjs[i].SetActive(true);
                    }
                }
            }
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
		} else if (PanelNew != null) {
			alpha = alpha - fis;
			if (alpha <= 0f) {
				PanelNew.SetActive (true);
                if (hideObjs != null && isHideFlg == false)
                {
                    for (int i = 0; i < hideObjs.Length; i++)
                    {
                        hideObjs[i].SetActive(false);
                    }
                }
                PanelNew = null;
//				Debug.Log ("moge");
			}
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
//			PanelNew.SetActive (true);
//			PanelNew = null;
		}
	}

	public void change_panel(panel p, float fadeout_speed, float fadein_speed)
	{
		fos = fadeout_speed;
		fis = fadein_speed;
		change_panel_common (p);
	}

	public void change_panel(panel p)
	{
		fos = 0.12f;
		fis = 0.12f;
		change_panel_common (p);
	}

	void change_panel_common(panel p)
	{
		alpha = 0f;
		if (PanelCrossChan.activeSelf == true) {
			//PanelCrossChan.SetActive (false);
//			PanelOld = PanelCrossChan;
			panelold_flg = true;
		} else if (PanelGame.activeSelf == true) {
			//PanelGame.SetActive (false);
//			PanelOld = PanelGame;
			panelold_flg = true;
		} else if (PanelHoukoku.activeSelf == true) {
			//PanelHoukoku.SetActive (false);
//			PanelOld = PanelHoukoku;
			panelold_flg = true;
		} else {
			alpha = 1f;
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
//			PanelOld = null;
			panelold_flg = false;
		}

		/* FadeOutなし */
		if (fos == 1f) {
			//PanelOld.SetActive (false);
			oldpanel_noactive();
			alpha = 1f;
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
//			PanelOld = null;
			panelold_flg = false;
		}

		switch (p) {
		case panel.Crosschan:
			//PanelCrossChan.SetActive (true);
			PanelNew = PanelCrossChan;
                // 中身があれば実行(背景を表示)
                if(hideObjs != null)
                {
                    isHideFlg = true;
                    //for(int i = 0; i < hideObjs.Length; i++)
                    //{
                    //    hideObjs[i].SetActive(true);
                    //}
                }
			break;
		case panel.Game:
			//PanelGame.SetActive (true);
			PanelNew = PanelGame;
                // 中身があれば実行(背景を表示)
                if (hideObjs != null)
                {
                    isHideFlg = false;
                    //for (int i = 0; i < hideObjs.Length; i++)
                    //{
                    //    hideObjs[i].SetActive(false);
                    //}
                }
                break;
		case panel.Houkoku:
			//PanelHoukoku.SetActive (true);
			PanelNew = PanelHoukoku;
			break;
		default:
			Debug.Log ("change_panel error");
			break;
		}
	}

	void oldpanel_noactive()
	{
		PanelCrossChan.SetActive (false);
		PanelGame.SetActive (false);
		PanelHoukoku.SetActive (false);
	}
}
