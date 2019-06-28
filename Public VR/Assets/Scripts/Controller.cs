using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour
{
    // <summer></summer>
    private SteamVR_Action_Boolean actionToHaptic = SteamVR_Actions._default.Menu;

    //<summer></summer>
    private SteamVR_Action_Vibration haptic = SteamVR_Actions._default.Haptic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(actionToHaptic.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            haptic.Execute(0, 0.005f, 0.005f, 1, SteamVR_Input_Sources.LeftHand);
        }
    }
}
