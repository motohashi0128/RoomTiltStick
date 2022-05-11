using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour {
    
    [SerializeField]
    Transform goggle;
    [SerializeField]
    Transform tracker_temae;
    [SerializeField]
    Transform tracker_oku;
    [SerializeField]
    GameObject room;
    [SerializeField]
    float speed = 20;


    Vector3 [] trackingPos,preTrackingPos;
    Vector3 dif;

    float count;
    int state;

    // Use this for initialization
    void Start () {
        trackingPos = new Vector3[3];
        preTrackingPos = new Vector3[3];
        trackingPos[0] = goggle.position;
        trackingPos[1] = tracker_temae.position;
        trackingPos[2] = preTrackingPos[2] = tracker_oku.position;
        dif = Vector3.zero;
        StartCoroutine("RoomRotate");
        state = 0;
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        Debug.Log("dif: " + dif + " tpos: " + tracker_oku.position + " pTpos: " + preTrackingPos[2]);
        if (state == 0)
            return;
        if(state==1)
            trackingPos[2] = preTrackingPos[2] = tracker_oku.position;
        if (state==2)
        {

            dif = (tracker_oku.transform.position - preTrackingPos[2]) * speed;
            room.transform.Rotate(new Vector3(dif.z, dif.y, dif.x));

            preTrackingPos[2] = tracker_oku.transform.position;
        }

    }

    IEnumerator RoomRotate()
    {
        yield return new WaitForSeconds(1f);
        state = 1;
        yield return new WaitForSeconds(1f);
        state = 2;
    }
}
