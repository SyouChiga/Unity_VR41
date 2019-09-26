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
    [SerializeField] protected GameObject bulletPrefab;
    //r
    [SerializeField] protected Transform rHand;
    //l
    [SerializeField] protected Transform lHand;

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

        if(Input.GetKey(KeyCode.UpArrow))
        {
            Y_Rotation += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Y_Rotation -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            X_Rotation += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            X_Rotation -= 1;
        }

        verRot.transform.Rotate(0, X_Rotation, 0);
        horRot.transform.Rotate(-Y_Rotation, 0, 0);
    }

    protected virtual void RightFunc()
    {
        Vector3 front = new Vector3();
        if(isMouse)
        {
            front = verRot.transform.forward;
        }
        else
        {
            front = rHand.forward;
        }
        GameObject bullet = Instantiate<GameObject>(bulletPrefab, rHand.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(front*100);
        Destroy(bullet, 5.0f);
    }

    protected virtual void LeftFunc()
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab, lHand.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(lHand.forward);
        Destroy(bullet, 2.0f);
    }
}
