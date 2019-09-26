using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//仮
public class Player : Controller
{
    //var device = SteamVR_
    [SerializeField] private float speed;

    [SerializeField] private GameObject coin;

    enum PLAYER_STATE
    {
        WAIT,
        TOUCH,

    }

    private PLAYER_STATE curState;

    // Start is called before the first frame update
    void Start()
    {
        vrAction = SteamVR_Actions._default.InteractUI;
        curState = PLAYER_STATE.WAIT;

    }

    // Update is called once per frame
    void Update()
    {
        if(vrAction.GetState(SteamVR_Input_Sources.RightHand) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab, rHand.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(rHand.forward);
            Destroy(bullet, 2.0f);
        }
        
        if(curState == PLAYER_STATE.TOUCH)
        {
            
        }

    }

    /// <summary>
    /// coinから手を放す
    /// </summary>
    public void ExitCoin()
    {
        //game oever

    }

    override protected void RightFunc()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
