using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour {

    public bool debug = false;
    public Vector3 target = new Vector3(0f, 0f, 0f);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void setViewpoint(Vector3 targetPos, Quaternion targetRot)
    {
        //		Vector3 headPos = InputTracking.GetLocalPosition (VRNode.CenterEye);
        //		Quaternion headRot = InputTracking.GetLocalRotation (VRNode.Head);
        Vector3 headPos = InputTracking.GetLocalPosition(XRNode.Head);
        Quaternion headRot = InputTracking.GetLocalRotation(XRNode.Head);
        this.transform.rotation = targetRot;
        Quaternion headRoti = Quaternion.Inverse(headRot);
        this.transform.Rotate(headRoti.eulerAngles);
        this.transform.position = targetPos - this.transform.rotation * headPos;
    }
    public void setViewpointPosition(Vector3 targetPos)
    {
        Quaternion headRot = InputTracking.GetLocalRotation(XRNode.Head);
        setViewpoint(targetPos, headRot);
    }
    public void resetViewpoint()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    /*public void setViewJumpOut(Vector3 targetPos)
    {
        Vector3 headPos = InputTracking.GetLocalPosition(XRNode.Head);
        Quaternion headRot = InputTracking.GetLocalRotation(XRNode.Head);
        this.transform.LookAt(targetPos);
        this.transform.position = new Vector3(targetPos.x, targetPos.y - 0.25f, targetPos.z - 0.2f);

    }*/
}
