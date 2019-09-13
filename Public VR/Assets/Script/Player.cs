using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//仮
public class Player : Controller
{
    //var device = SteamVR_
    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean isGrabAction;
    [SerializeField] private Transform rHand;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        isGrabAction = SteamVR_Actions._default.InteractUI;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabAction.GetState(SteamVR_Input_Sources.RightHand) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab, rHand.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(rHand.forward);
            Destroy(bullet, 2.0f);
        }
        


    }

    override protected void RightFunc()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
