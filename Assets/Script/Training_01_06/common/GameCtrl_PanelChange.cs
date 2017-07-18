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

	GameObject PanelOld = null;
	GameObject PanelNew = null;
	float alpha = 0f;

	float fos;
	float fis;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (PanelOld != null) {
			alpha = alpha + fos;
			if (alpha >= 1f) {
				PanelOld.SetActive (false);
				PanelOld = null;
				Debug.Log ("hoge");
			}
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
		} else if (PanelNew != null) {
			alpha = alpha - fis;
			if (alpha <= 0f) {
				PanelNew.SetActive (true);
				PanelNew = null;
				Debug.Log ("moge");
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
		fos = 0.08f;
		fis = 0.08f;
		change_panel_common (p);
	}

	void change_panel_common(panel p)
	{
		alpha = 0f;
		if (PanelCrossChan.activeSelf == true) {
			//PanelCrossChan.SetActive (false);
			PanelOld = PanelCrossChan;
		} else if (PanelGame.activeSelf == true) {
			//PanelGame.SetActive (false);
			PanelOld = PanelGame;
		} else if (PanelHoukoku.activeSelf == true) {
			//PanelHoukoku.SetActive (false);
			PanelOld = PanelHoukoku;
		} else {
			alpha = 1f;
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
			PanelOld = null;
		}

		/* FadeOutなし */
		if (fos == 1f) {
			PanelOld.SetActive (false);
			alpha = 1f;
			FadeInOut.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
			PanelOld = null;
		}

		switch (p) {
		case panel.Crosschan:
			//PanelCrossChan.SetActive (true);
			PanelNew = PanelCrossChan;
			break;
		case panel.Game:
			//PanelGame.SetActive (true);
			PanelNew = PanelGame;
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
}
