using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_RendaMukou : MonoBehaviour {
	public Button bt;
	void OnEnable () {
		bt.enabled = true;
	}

	public void NoButtonActivate ()
	{
		bt.enabled = false;
	}
}
