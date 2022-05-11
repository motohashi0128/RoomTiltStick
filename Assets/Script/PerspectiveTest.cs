using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PerspectiveTest : MonoBehaviour {
    public GameObject camcon;
    public GameObject cam;
    public GameObject ava;
    public GameObject head;
    public GameObject room;
    public GameObject neck;
    private float dist = 1;
    private CameraController cc;

    // Use this for initialization
    void Start () {
        cc = camcon.GetComponent<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 hmdPos = InputTracking.GetLocalPosition(XRNode.Head);
        Vector3 avaPos = ava.transform.position;
        Vector3 headPos = head.transform.position;

        Vector3 newPos = new Vector3(hmdPos.x, hmdPos.y, hmdPos.z - 1);
        Vector3 hmdRot = InputTracking.GetLocalRotation(XRNode.Head).eulerAngles;
        Vector3 neckRot = neck.transform.rotation.eulerAngles;
        Vector3 headRot = head.transform.rotation.eulerAngles;
        Vector3 roomRot = ava.transform.localRotation.eulerAngles;
        Vector3 newPosA = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z);
        //cc.setViewpointPosition(newPosA);
        cc.setViewpointPosition(newPosA);
        Debug.Log(roomRot + hmdRot);
    }
}
