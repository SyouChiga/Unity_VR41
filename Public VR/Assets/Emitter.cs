using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Emitter : MonoBehaviour
{
	public GameObject obj;
	static float counter = 0;
	SteamVR_TrackedObject trackedObj;

	//GameObject LeftController;
	//GameObject  RightController;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}


	// Start is called before the first frame update
	void Start()
	{

	}


	void Update()
	{

		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{

			GameObject Tracker = GameObject.Find("[CameraRig]");

			GameObject LeftController = Tracker.transform.Find("Controller (left)").gameObject;

			// Cubeプレハブを元に、インスタンスを生成、
			GameObject Ball = Instantiate(obj, LeftController.transform.position, Quaternion.identity);

			Ball.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000.0f);

			Destroy(Ball, 3.0f);
				
			
		}


	}

}