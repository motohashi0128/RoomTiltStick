using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AvaterController : MonoBehaviour {
    [SerializeField]
    GameObject Cam;
    [SerializeField]
    GameObject Ava;
    [SerializeField]
    GameObject Head;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 hmdPos = InputTracking.GetLocalPosition(XRNode.Head);
        Ava.transform.localPosition =hmdPos - new Vector3(0, 1.758163f, -1f * Mathf.Cos(Mathf.Deg2Rad * Mathf.Abs(Cam.transform.localRotation.eulerAngles.y)));
        Head.transform.rotation = Cam.transform.rotation;
	}
}
