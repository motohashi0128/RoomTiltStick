using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PerspectiveController : MonoBehaviour {
    public GameObject camcon;
    public GameObject head;

    private float dist = 1;
    private CameraController cc;
    [SerializeField]
    private bool debugMode = true;
	// Use this for initialization
	void Start () {
        cc = camcon.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 headPos = head.transform.position;
        Vector3 newPosA = new Vector3(headPos.x, headPos.y, headPos.z-1);
        cc.setViewpointPosition(newPosA);
        //cc.setViewpoint(newPosA, Quaternion.Euler(new Vector3(hmdRot.x , hmdRot.y, hmdRot.z+roomRot.z)));
        //Debug.Log(roomRot + hmdRot);
    }
}
