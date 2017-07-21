using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_04 : MonoBehaviour {
    public InputField namae;
    public InputField namae2;
    public InputField syoukai;
    public InputField hanei;
    public InputField hanei2;
    public GameCtrl_PanelChange GP;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void OnEnable () {
	}
    public void nyuryoku_Button()
    {
        hanei.text = namae.text + " " + namae2.text;
        hanei2.text = syoukai.text;
    }

    public void Houkoku_Button()
	{
		GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
	}
}
