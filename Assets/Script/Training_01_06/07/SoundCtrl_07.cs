using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtrl_07 : MonoBehaviour {

	public AudioSource m1;
	public AudioSource m2;
	public AudioSource m3;
	public GameObject Image_Logo;

	int s;
	AudioSource m;
	bool saisei_flg;

	// Use this for initialization
	void Start () {
		m = m1;
		saisei_flg = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (saisei_flg == true) {
			Image_Logo.transform.Rotate (new Vector3(0f,0f,3f));
		}
	}

	public void change_sound(int value)
	{
		m.Stop ();
		saisei_flg = false;

		switch (value){
		case 0:
			m = m1;
			break;
		case 1:
			m = m2;
			break;
		case 2:
			m = m3;
			break;
		default:
			break;
		}
	}

	public void play_button()
	{
		m.Play ();
		saisei_flg = true;
	}

	public void teisi_button()
	{
		m.Stop ();
		saisei_flg = false;
	}

	public void itiziteisi_button()
	{
		m.Pause ();
		saisei_flg = false;
	}

	public void valume_button()
	{
	}

	public void mute_button()
	{

	}
}
