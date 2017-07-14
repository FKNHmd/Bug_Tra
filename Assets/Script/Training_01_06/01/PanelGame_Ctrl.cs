using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl : MonoBehaviour {

	public InputField DummyInput;
	public GameObject ImageOn;
	public GameObject ImageOff;

	public GameCtrl_PanelChange GP;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	void OnEnable () {
		ImageOff.SetActive (true);
		ImageOn.SetActive (false);
		StartCoroutine (ActInput());
	}

	IEnumerator ActInput()
	{
		yield return new WaitForSecondsRealtime (1.0f);
		DummyInput.ActivateInputField ();
	}

	public void InputChange()
	{
		if (DummyInput.text == "q") {
			ImageOff.SetActive (true);
			ImageOn.SetActive (false);
		} else if (DummyInput.text == "") {
			/* 空白は何もしない */
		} else {
			ImageOn.SetActive (true);
			ImageOff.SetActive (false);
		}

		DummyInput.text = "";
	}
		
	public void Houkoku_Button()
	{
		GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
	}
}
