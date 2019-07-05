using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VR
{
    public class Input : MonoBehaviour
    {
        private SteamVR_Action_Boolean actionToHaptic = SteamVR_Actions._default.InteractUI;
        private SteamVR_Action_Vibration haptic = SteamVR_Actions._default.Haptic;

        [SerializeField]
        private GameObject bullet_;
        private void Update()
        {
            
            if (actionToHaptic.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                GameObject obj =  Instantiate(bullet_, transform.position, Quaternion.identity);

                Vector3 up = transform.forward;
                up.z *= 2.0f;
                up.x *= 2.0f;
                obj.GetComponent<Rigidbody>().AddForce(up * 10.0f);

                DestroyObject(obj, 5.0f);
            }
        }


        // Start is called before the first frame update
        void Start()
        {

        }




    }
}
