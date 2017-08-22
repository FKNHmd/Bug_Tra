using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl_CanvasCtrl_03 : MonoBehaviour {

	public GameObject CCC;

	public void CanvasCrossChanONOFF (bool onoff)
	{
		CCC.SetActive (onoff);
	}
}
