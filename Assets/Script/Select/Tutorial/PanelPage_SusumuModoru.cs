using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPage_SusumuModoru : MonoBehaviour {

	int page;
	GameObject[] gobj = new GameObject[10];

	// Use this for initialization
	void Start () {
		string str;
		page = 1;

		for (int i = 0; i < 10; i++) {
			str = "PanelPage" + (i + 1);
			gobj[i] = GameObject.Find (str);
		}
		page_activate (page);
	}

	void page_activate (int n)
	{
		for (int i = 0; i < 10; i++) {
			if (i == (n - 1)) {
				gobj[i].SetActive (true);
			} else {
				gobj[i].SetActive (false);
			}
		}
	}

	public void susumu ()
	{
		page++;
		if (page >= 10) {
			page = 10;
		}
		page_activate (page);
	}

	public void modoru ()
	{
		page--;
		if (page <= 1) {
			page = 1;
		}
		page_activate (page);
	}
}
