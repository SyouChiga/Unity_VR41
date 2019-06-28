using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gun : MonoBehaviour
{
    // <summer>ボタン</summer>
    private SteamVR_Action_Boolean actionToShoot = SteamVR_Actions._default.InteractUI;

    //<summer>弾のオブジェクト</summer>
    [SerializeField] public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右トリガーで弾発射
        if(actionToShoot.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000.0f);
            Destroy(newBullet, 3.0f);
        }
    }
}
