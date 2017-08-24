using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_02 : MonoBehaviour {

	public GameCtrl_PanelChange GP;
	public GameObject PanelHoukoku;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
		
	void OnEnable () {

	}
		
	public void Houkoku_Button()
	{
		//GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
		PanelHoukoku.SetActive(true);
	}
}
