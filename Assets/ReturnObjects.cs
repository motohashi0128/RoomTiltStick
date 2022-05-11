using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObjects : MonoBehaviour {
    public GameObject room;
    int state;
    [SerializeField]
    GameObject balls;
    [SerializeField]
    GameObject chairs;
    [SerializeField]
    Vector3[] ballsPos;
    [SerializeField]
    Vector3[] chairsPos;
    [SerializeField]
    Quaternion[] ballsRot;
    [SerializeField]
    Quaternion[] chairsRot;

    // Use this for initialization
    void Start () {
        int i = 0;
        state = 0;
		foreach(Transform child in balls.transform)
        {
            ballsPos[i] = child.localPosition;
            ballsRot[i] = child.localRotation;
            i++;
        }
        i = 0;
        foreach(Transform child in chairs.transform)
        {
            chairsPos[i] = child.localPosition;
            chairsRot[i] = child.localRotation;
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(state);
        if (state == 0)
        {
            if (room.transform.eulerAngles.z == 0)
            {
                Invoke("ResetObj", 2f);
                state = 1;
            }
        }
        else if(state == 1)
        {
            if(room.GetComponent<Rolling>().state == 2)
            {
                state = 0;
            }
        }
	}

    void ResetObj()
    {
        int i = 0;
        foreach(Transform child in balls.transform)
        {
            child.localPosition = ballsPos[i];
            child.localRotation = ballsRot[i];
            i++;
        }
        i = 0;
        foreach (Transform child in chairs.transform)
        {
            child.localPosition = chairsPos[i];
            child.localRotation = chairsRot[i];
            i++;
        }
    }
}
