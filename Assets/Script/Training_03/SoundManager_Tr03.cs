using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_Tr03 : MonoBehaviour {

    // 音を呼び出す
    public GameObject[] SE,BGM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SEOnPlay(int num)
    {
        SE[num].GetComponent<AudioSource>().Play();
    }
    public void BGMOnPlay(int num)
    {
        BGM[num].GetComponent<AudioSource>().Play();
    }
}
