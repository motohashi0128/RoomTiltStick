using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Dest", 5f);
	}
	
	void Dest()
    {
        Destroy(this.gameObject);

    }
}
