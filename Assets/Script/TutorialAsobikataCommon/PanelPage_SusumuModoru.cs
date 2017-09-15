using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPage_SusumuModoru : MonoBehaviour {

	int page;
	int endpage;
	GameObject[] gobj = new GameObject[20];

	// Use this for initialization
	void Start () {
		syokika ();
	}

	void OnEnable () {
		page = 1;
		if (gobj [0] != null) {
			page_activate (page);
		}
	}

	void syokika () {
		string str;
		page = 1;

		for (int i = 0; i < 20; i++) {
			str = "PanelPage" + (i + 1);
			gobj[i] = GameObject.Find (str);
			if (gobj [i] == null) {
				endpage = i;
				break;
			}
		}
		page_activate (page);
	}

	void page_activate (int n)
	{
		for (int i = 0; i < endpage; i++) {
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
		if (page >= endpage) {
			page = endpage;
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
