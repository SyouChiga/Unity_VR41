using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Player : MonoBehaviour
{
    //var device = SteamVR_
    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean isGrabAction;
    [SerializeField] private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabAction.GetState(SteamVR_Input_Sources.Any))
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward);
            Destroy(bullet, 2.0f);
        }
        


    }

    void Controller()
    {
        
    }
}
