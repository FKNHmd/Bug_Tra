﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // 地面に接したか判断
    public bool isGroundTouch = false;

    Rigidbody _rigid;

	// Use this for initialization
	void Start () {
        _rigid = transform.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 v = GetComponentInChildren<Rigidbody>().velocity;
        v = GetComponent<Rigidbody>().velocity;
        GetComponentInChildren<Rigidbody>().velocity = v;


    }

    void OnCollisionEnter(Collision coll)
    {

    }

}
