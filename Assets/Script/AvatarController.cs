using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AvatarController : MonoBehaviour {
    public GameObject Head;
    public GameObject camera;
    public GameObject camcon;
    public GameObject room;
    public Material[] avaMats;
    float dist;
    int state;
    Color[] col = new Color[9];
    float alpha;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < 9; i++)
        {
            col[i] = avaMats[i].color;
        }
        state = 0;
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 1.76f, camera.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 hmdPos = InputTracking.GetLocalPosition(XRNode.Head);

        transform.position = new Vector3(camera.transform.position.x + 1.76f * Mathf.Sin(Mathf.Deg2Rad * room.transform.localRotation.eulerAngles.z), camera.transform.position.y - 1.76f * Mathf.Cos(Mathf.Deg2Rad*room.transform.localRotation.eulerAngles.z), camera.transform.position.z + Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad*camera.transform.localRotation.eulerAngles.y)));
        camcon.transform.localPosition = new Vector3(0, 0, Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * camera.transform.localRotation.eulerAngles.y)));

        Head.transform.rotation = camera.transform.rotation;
        alpha = Mathf.Cos(Mathf.Deg2Rad* Mathf.Abs(camera.transform.localRotation.eulerAngles.y));
        for (int i = 0; i < 9; i++)
        {
            col[i].a = alpha;
            avaMats[i].color = col[i];
        }
        
		
	}
}
