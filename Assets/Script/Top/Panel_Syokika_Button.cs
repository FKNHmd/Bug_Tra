using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Syokika_Button : MonoBehaviour {
	public void syokika () 
	{
		PlayerPrefs.DeleteAll ();
		this.gameObject.SetActive (false);
	}
}
