using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsobikataMgr_OpenClose : MonoBehaviour {
	GameObject gobj;
	// Use this for initialization
	void Start () {
		gobj = GameObject.Find ("Canvas Asobikata");
		AsobikataClose ();
	}
	
	public void AsobikataOpen ()
	{
		gobj.SetActive (true);
	}

	public void AsobikataClose ()
	{
		gobj.SetActive (false);
	}
}
