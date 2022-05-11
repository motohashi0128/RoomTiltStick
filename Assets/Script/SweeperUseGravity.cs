using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperUseGravity : MonoBehaviour {
    public GameObject Sweeper;
    public GameObject room;
    public GameObject tale;
    Vector3 talePos;
    Quaternion taleRot;
    int jointState;
    [SerializeField]
    float returnTime;
    // Use this for initialization
    void Start () {
        jointState = 0;
        this.GetComponent<Rigidbody>().isKinematic = true;
        talePos = tale.transform.localPosition;
        taleRot = tale.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(room.transform.localRotation.eulerAngles);
        if (jointState == 0)
        {
            CheckRolling();
        }
        else if (jointState == 1)
        {
            Sweeper.GetComponent<Valve.VR.SteamVR_TrackedObject>().enabled = false;
            Sweeper.transform.parent = tale.transform;
            tale.GetComponent<Rigidbody>().isKinematic = false;
            jointState = 2;
            //Invoke("returnTale", returnTime);
        }
        else if (jointState == 2)
        {
            if(room.GetComponent<Rolling>().state == 1)
            {
                returnTale();
            }
        }
        else if (jointState == 3)
        {
            if (Sweeper.transform.localRotation.eulerAngles.x < 330)
            {
                jointState = 0;
            }
        }
        
	}

    void CheckRolling()
    {
        if (room.GetComponent<Rolling>().state == 2)
        {
            if (Sweeper.transform.localRotation.eulerAngles.x >= 350)
            {
                jointState = 1;
            }
        }
    }

    void returnTale()
    {
        Sweeper.transform.parent = room.transform;
        Sweeper.GetComponent<Valve.VR.SteamVR_TrackedObject>().enabled = true;
        tale.GetComponent<Rigidbody>().isKinematic = true;
        tale.transform.localPosition = talePos;
        tale.transform.localRotation = taleRot;
        jointState = 3;
    }
}
