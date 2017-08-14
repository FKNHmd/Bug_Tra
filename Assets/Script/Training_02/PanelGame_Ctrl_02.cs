using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame_Ctrl_02 : MonoBehaviour {

	public InputField DummyInput;
	public GameObject ImageOn;
	public GameObject ImageOff;
	public GameCtrl_PanelChange GP;

	bool on_flg;
	float on_byou;
	float oldtime, newtime, deltatime;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		/* １秒だけ点灯 */
		if (on_flg == true) {
			on_byou += Time.deltaTime;
			if (on_byou < 1f) {
			} else {
				on_byou = 0f;
				on_flg = false;
				image_off ();
			}
		}
	}
		
	void OnEnable () {
		ImageOff.SetActive (true);
		ImageOn.SetActive (false);
		StartCoroutine (ActInput());

		on_flg = false;
		on_byou = 0f;
	}

	IEnumerator ActInput()
	{
		yield return new WaitForSecondsRealtime (1.0f);
		DummyInput.ActivateInputField ();
	}

	void image_on ()
	{
		ImageOn.SetActive (true);
		ImageOff.SetActive (false);
	}

	void image_off ()
	{
		ImageOff.SetActive (true);
		ImageOn.SetActive (false);
	}

	public void InputChange()
	{
		if (DummyInput.text == "q") {

		} else if (DummyInput.text == "") {
			/* 空白は何もしない */
		} else {
			image_on ();
			on_flg = true;
		}

		DummyInput.text = "";
	}
		
	public void Houkoku_Button()
	{
		GP.change_panel (GameCtrl_PanelChange.panel.Houkoku);
	}
}
