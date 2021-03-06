﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundCtrl_07 : MonoBehaviour {

	public AudioSource m1;
	public AudioSource m2;
	public AudioSource m3;
	public GameObject Image_Logo;

	public Dropdown d;

	int s;
	AudioSource m;
	//bool saisei_flg;

	// Use this for initialization
	void Start () {
		m = m1;
	}
	
	// Update is called once per frame
	void Update () {
		if (m.isPlaying) {
			Image_Logo.transform.Rotate (new Vector3(0f,0f,-3f));
		}
	}

	public void change_sound(int value)
	{
		m.Stop ();

		switch (d.value){
		case 0:
			m = m1;
			Debug.Log ("0");
			break;
		case 1:
			m = m2;
			Debug.Log ("1");
			break;
		case 2:
			m = m3;
			Debug.Log ("2");
			break;
		default:
			break;
		}
	}

	public void play_button()
	{
		m.Play ();
	}

	public void teisi_button()
	{
		//m.Stop ();
	}

	public void itiziteisi_button()
	{
		m.Pause ();
	}

	public void valume_button()
	{
		m.mute = false;
	}

	public void mute_button()
	{
		m.mute = true;
	}
}
