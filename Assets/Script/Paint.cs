﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {
    public GameObject inc;
    GameObject incInst;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Instantiate(inc, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            incInst = Instantiate(inc, transform.position, transform.rotation);   
        }
    }
}
