using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCrossChan_Ctrl : MonoBehaviour {

	public Text Text_Daimei;
	public Text Text_Section;
	public Text Text_Syousai;

	public GameObject ImageCrossChan1;
	public GameObject ImageCrossChan2;
	public GameObject ImageCrossChan3;

	public GameObject ButtonGame;
	public GameObject ButtonSelect;

	public enum crosschan_gazou {
		Normal,
		Niko,
		Syobon
	}

	public enum crosschan_button {
		Game,
		Select
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void set_crosschan(string daimei, string section, string syousai, crosschan_gazou g, crosschan_button b)
	{
		Text_Daimei.text = daimei;
		Text_Section.text = section;
		Text_Syousai.text = syousai;

		ImageCrossChan1.SetActive (false);
		ImageCrossChan2.SetActive (false);
		ImageCrossChan3.SetActive (false);
		switch (g) {
		case crosschan_gazou.Normal:
			ImageCrossChan1.SetActive (true);
			break;
		case crosschan_gazou.Niko:
			ImageCrossChan2.SetActive (true);
			break;
		case crosschan_gazou.Syobon:
			ImageCrossChan3.SetActive (true);
			break;
		default:
			Debug.Log("set_crosschan erroe");
			break;
		}

		ButtonGame.SetActive (false);
		ButtonSelect.SetActive (false);
		switch (b) {
		case crosschan_button.Game:
			ButtonGame.SetActive (true);
			break;
		case crosschan_button.Select:
			ButtonSelect.SetActive (true);
			break;
		default:
			Debug.Log("set_crosschan erroe");
			break;
		}
	}
}
