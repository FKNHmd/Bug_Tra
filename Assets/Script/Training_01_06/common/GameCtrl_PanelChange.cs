using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl_PanelChange : MonoBehaviour {

	public enum panel {
		Crosschan,
		Game,
		Houkoku
	}

	public GameObject PanelCrossChan;
	public GameObject PanelGame;
	public GameObject PanelHoukoku;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void change_panel(panel p)
	{
		PanelCrossChan.SetActive (false);
		PanelGame.SetActive (false);
		PanelHoukoku.SetActive (false);

		switch (p) {
		case panel.Crosschan:
			PanelCrossChan.SetActive (true);
			break;
		case panel.Game:
			PanelGame.SetActive (true);
			break;
		case panel.Houkoku:
			PanelHoukoku.SetActive (true);
			break;
		default:
			Debug.Log ("change_panel error");
			break;
		}
	}
}
