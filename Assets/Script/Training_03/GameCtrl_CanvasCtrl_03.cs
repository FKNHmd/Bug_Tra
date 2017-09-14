using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl_CanvasCtrl_03 : MonoBehaviour {

	public GameObject CCC;
    public GameObject gamePanel;
    public GameCtrl_PanelChange GP;
    public GameManager_03 gameMar;


    public void CanvasCrossChanONOFF (bool onoff)
	{
		CCC.SetActive (onoff);
        gamePanel.SetActive(onoff);

    }

    public void Start_Button()
    {
        gameMar.GameInitilize();
        GP.change_panel(GameCtrl_PanelChange.panel.Game);
    }
}
