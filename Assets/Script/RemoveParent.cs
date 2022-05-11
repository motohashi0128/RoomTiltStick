using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour {
    public GameObject NParent;
    public GameObject InstCubes;
	// Use this for initialization
	void Start () {
        Invoke("Rem", 3);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void Rem()
    {
        //transform.parent = null;
        transform.parent = NParent.transform;
        Instantiate(InstCubes, new Vector3(0.61f, 1.299f, -2.502f), Quaternion.identity);
        InstCubes.transform.DetachChildren();
    }
}
