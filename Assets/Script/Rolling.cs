using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour {
    public WiiBalanceBoardCliant wbbc;
    public GameObject Cube;
    public Material Wall;
    public Material sphere;
    public GameObject OSCObj;
    public GameObject flex;
    Color col,col2;
    public int state;
    public GameObject[] dummyWall;
    public GameObject WallCol;
    float firstTime;
    [SerializeField]
    float WeightAve;
    [SerializeField]
    float NowWeight;
    [SerializeField]
    float NowRot;
    [SerializeField]
    bool Mode;
    [SerializeField]
    float AveRight;
    [SerializeField]
    float AveLeft;
    [SerializeField]
    float Ratio;
    [SerializeField]
    float WeightOffset = 2f;
    [SerializeField]
    float rotspeed = 120f;
    [SerializeField]
    float ReverseOffset = 0.5f;
    [SerializeField]
    float GForce = 9.81f;
    [SerializeField]
    float warizan = 100f;
    float step;
    float t;
    [SerializeField]
    float f;
    [SerializeField]
    float OscSum;
    [SerializeField]
    float OscRot;
    [SerializeField]
    float firstSpeedL;
    [SerializeField]
    float firstSpeedR;
    [SerializeField]
    float appearAngle;
    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    GameObject circle;
    
    int CountForAve;
    int dummyState;
    
	// Use this for initialization
	void Start () {
        col = Wall.color;
        //col2 = sphere.color;
        state = 0;
        dummyState = 0;
        firstTime = 0;
        CountForAve = 0;
        //NowWeight = wbbc.recvBalanceBoardDatalist.balanceBoardData[0].weight;
        NowWeight = OSCObj.GetComponent<OSCManager>().Sum1;
        t = 0f;
        f = 0f;
        OscSum = OSCObj.GetComponent<OSCManager>().Sum3;
        particle.Pause();
        //circle.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        //NowWeight = wbbc.recvBalanceBoardDatalist.balanceBoardData[0].weight;
        NowWeight = OSCObj.GetComponent<OSCManager>().Sum1;
        Debug.Log(NowWeight);
        //AveRight = (wbbc.recvBalanceBoardDatalist.balanceBoardData[0].sensorLoad.TopRight + wbbc.recvBalanceBoardDatalist.balanceBoardData[0].sensorLoad.BottomRight) / 2;
        //AveLeft = (wbbc.recvBalanceBoardDatalist.balanceBoardData[0].sensorLoad.TopLeft + wbbc.recvBalanceBoardDatalist.balanceBoardData[0].sensorLoad.BottomLeft) / 2;
        Debug.Log("state: "+state);
        Debug.Log("dummyState: " + dummyState);
        //Ratio = AveRight / AveLeft;
        OscSum = OSCObj.GetComponent<OSCManager>().Sum3-0.05f;
        DummyWallOnOff();
        WallColAppear();
        if (state == 0)
        {
            WeightAverage();
            flex.GetComponent<NVIDIA.Flex.FlexSourceActor>().startSpeed = 1;
            //col2.a = 0;
        }
        else if (state == 1)
        {
            float t = (Cube.transform.rotation.eulerAngles.z - 90f)*Mathf.Deg2Rad;
            col.a = 1 * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.z);
            Wall.color = col;
            //col2.a = 0;
            //sphere.color = col2;
            //circle.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
            //t = (f - 90f) * Mathf.Deg2Rad;
            //Physics.gravity = new Vector3(Mathf.Cos(t),Mathf.Sin(t),0)*GForce;
            /*
            if (NowWeight > WeightAve + WeightOffset)
            */
            if(NowWeight>=0.01f)
            {
                 dummyState = 1;
                Cube.transform.Rotate(new Vector3(0, 0, -(NowWeight-WeightAve+WeightOffset)/warizan));
                //transform.Rotate(new Vector3(0, 0, (NowWeight-WeightAve+WeightOffset)/warizan));
                //flex.GetComponent<NVIDIA.Flex.FlexSourceActor>().startSpeed = 1+firstSpeedL*((NowWeight - WeightAve + WeightOffset)/warizan);
                transform.Rotate(new Vector3(0, 0, NowWeight*NowRot));
                Debug.Log("pushed : " + flex.GetComponent<NVIDIA.Flex.FlexSourceActor>().startSpeed);
                //f -= (NowWeight - WeightAve + WeightOffset) / warizan;
                if (transform.rotation.eulerAngles.z>90f)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                    state = 2;
                    particle.Play();
                }
            }
            /*
            else if (NowWeight < WeightAve + WeightOffset - ReverseOffset)
            */
            else if(NowWeight<0.01f)
            {

                dummyState = 0;
                flex.GetComponent<NVIDIA.Flex.FlexSourceActor>().startSpeed = 1;
                step = rotspeed * Time.deltaTime;

                //指定した方向にゆっくり回転する場合
                Cube.transform.rotation = Quaternion.RotateTowards(Cube.transform.rotation, Quaternion.Euler(0, 0f, 0), step);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0f, 0), step);
            }
        }
        else if(state == 2)
        {
            float t = (Cube.transform.rotation.eulerAngles.z - 90f) * Mathf.Deg2Rad;
            col.a = 1 * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.z);
            Wall.color = col;
            
            
            //t = (f - 90f) * Mathf.Deg2Rad;
            //Physics.gravity = new Vector3(Mathf.Cos(t),Mathf.Sin(t),0)*GForce;
            var emission = particle.emission;
            if (OscSum>0.01f)
            {
                dummyState = 1;
                Debug.Log("pushed");
                transform.Rotate(new Vector3(0, 0, -OscSum*OscRot));
                
                if (OscSum < 0)
                {
                    emission.rateOverTime = 0;
                }
                else
                {
                    emission.rateOverTime = OscSum*100;
                }
                //col2.a = OscSum*10;
                //circle.transform.localScale = new Vector3(0.5f+OscSum*15, 0.1f, 0.5f+OscSum*15);

                //f -= (NowWeight - WeightAve + WeightOffset) / warizan;
                Debug.Log(transform.rotation.eulerAngles.z);
                flex.GetComponent<NVIDIA.Flex.FlexSourceActor>().startSpeed = 1+OscSum*firstSpeedR;
                if (transform.rotation.eulerAngles.z < 0f|| (transform.rotation.eulerAngles.z<360&& transform.rotation.eulerAngles.z>270))
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0f));
                    state = 1;
                    particle.Stop();
                }
            }
            else if (OscSum <= 0.01f)
            {
                //col2.a = 0;
                //circle.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
                dummyState = 0;
                step = rotspeed * Time.deltaTime * 0.1f;
                flex.GetComponent<NVIDIA.Flex.FlexSourceActor>().startSpeed = 1;
                emission.rateOverTime = 0;
                //指定した方向にゆっくり回転する場合
                Cube.transform.rotation = Quaternion.RotateTowards(Cube.transform.rotation, Quaternion.Euler(0, 0f, 0), step);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0f, 90f), step);
            }
            //sphere.color = col2;
        }
        /*
        else if(state == 11)
        {
            if (Ratio > 2)
            {
                Debug.Log("pushed");
                Cube.transform.Rotate(new Vector3(0, 0, -(Ratio/warizan)));
                transform.Rotate(new Vector3(0, 0, (Ratio/warizan)));
                //f -= (NowWeight - WeightAve + WeightOffset) / warizan;
                if (transform.rotation.eulerAngles.z > 90f)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                    particle.Play();
                    state = 2;
                }
            }
            else if (Ratio <1)
            {
                step = rotspeed * Time.deltaTime;

                //指定した方向にゆっくり回転する場合
                Cube.transform.rotation = Quaternion.RotateTowards(Cube.transform.rotation, Quaternion.Euler(0, 0f, 0), step);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0f, 0), step);
            }
        }
        */
	}
    void WeightAverage()
    {
        //if (NowWeight < 50f)
          //  return;
        WeightAve += NowWeight;
        firstTime += Time.deltaTime;
        CountForAve++;
        if (firstTime > 3f)
        {
            if (Mode)
                state = 1;
            else
                state = 11;
            WeightAve /= CountForAve;
        }
    }

    void WallColAppear()
    {
        if (transform.rotation.eulerAngles.z > appearAngle)
        {
            WallCol.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            WallCol.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void DummyWallOnOff()
    {
        if (dummyState == 0)
        {
            for(int i = 0; i < dummyWall.Length; i++)
            {
                dummyWall[i].GetComponent<BoxCollider>().enabled = true;
            }
        }else if(dummyState == 1)
        {
            for (int i = 0; i < dummyWall.Length; i++)
            {
                dummyWall[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
