using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

	public GameObject PanelStart;
	public GameObject PanelGame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Start_Button()
	{
		PanelStart.SetActive(false);
		PanelGame.SetActive(true);
	}
}
