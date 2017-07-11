using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTyuu : MonoBehaviour {

	public InputField DummyInput;
	public GameObject ImageOn;
	public GameObject ImageOff;

	// Use this for initialization
	void Start () {
		//ImageOff.SetActive (true);
		//ImageOn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//DummyInput.ActivateInputField ();
		//StartCoroutine (ActInput());
	}
		
	void OnEnable () {
		ImageOff.SetActive (true);
		ImageOn.SetActive (false);
		StartCoroutine (ActInput());
		//DummyInput.ActivateInputField ();
		//Debug.Log ("hoge");
	}

	IEnumerator ActInput()
	{
		yield return new WaitForSecondsRealtime (2.0f);
		DummyInput.ActivateInputField ();
	}

	public void InputChange()
	{
		if ((DummyInput.text == "q") || (DummyInput.text == "")) {
			ImageOff.SetActive (true);
			ImageOn.SetActive (false);
		} else {
			ImageOn.SetActive (true);
			ImageOff.SetActive (false);
		}

		StartCoroutine (NullChar());
	}

	IEnumerator NullChar()
	{
		yield return new WaitForSecondsRealtime (5.0f);
		DummyInput.text = "";
	}
}
