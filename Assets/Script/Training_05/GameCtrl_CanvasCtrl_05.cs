using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl_CanvasCtrl_05 : MonoBehaviour {

	public GameObject CCC;
    public GameObject gamePanel;
    public GameCtrl_PanelChange GP;
    public GameManager_05 gameMar;


    public void CanvasCrossChanONOFF (bool onoff)
	{
		CCC.SetActive (onoff);
        gamePanel.SetActive(onoff);

    }

    public void Start_Button()
    {
        gamePanel.SetActive(true);
                gameMar.GameInitilize();
        GP.change_panel(GameCtrl_PanelChange.panel.Game);
    }
}
