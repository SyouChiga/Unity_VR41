using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour
{
    public SteamVR_Input_Sources hand;

    public SteamVR_Action_Boolean vrAction;

    public Transform verRot;

    public Transform horRot;

    private bool isMouse;

    //bullet
    [SerializeField] private GameObject bulletPrefab;
    //r
    [SerializeField] private Transform rHand;
    //l
    [SerializeField] private Transform lHand;

    void Start()
    {
        vrAction = SteamVR_Actions._default.InteractUI;
        isMouse = false;
    }

    // Update is called once per frame
    void Update()
    {
        //右手
        if (vrAction.GetStateDown(SteamVR_Input_Sources.RightHand) || Input.GetMouseButtonDown(0))
        {
            RightFunc();
        }

        //左手
        if (vrAction.GetState(SteamVR_Input_Sources.RightHand) || Input.GetMouseButton(1))
        {
            LeftFunc();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMouse ^= true;
        }

        if(isMouse)
        {
            UpdateMouseCamera();
        }
    }

    void UpdateMouseCamera()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        verRot.transform.Rotate(0, X_Rotation, 0);
        horRot.transform.Rotate(-Y_Rotation, 0, 0);
    }

    protected virtual void RightFunc()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab, rHand.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(rHand.forward*200);
        Destroy(bullet, 5.0f);
    }

    protected virtual void LeftFunc()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab, lHand.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(lHand.forward);
        Destroy(bullet, 2.0f);
    }
}
