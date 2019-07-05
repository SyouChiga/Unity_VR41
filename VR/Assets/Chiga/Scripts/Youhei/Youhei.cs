using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youhei : MonoBehaviour
{
    [SerializeField]
    private float angleX_;
    private float time_ = 0.0f;
    [SerializeField]
    private float timeRotation_ = 0.0f;
    private Quaternion quo_;
    [SerializeField]
    private Vector3 location_;
    private bool destroyRigid_ = false;
    private bool remote_ = false;
    // Start is called before the first frame update
    void Start()
    {
        angleX_ = transform.localEulerAngles.x;
        quo_ = transform.rotation;
        location_ = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angleX_ = transform.localEulerAngles.x;

        if (angleX_ <= 30.0f && remote_ == false)
        {
            remote_ = true;
        }
        if(remote_ == true)
        { 
            time_ += Time.deltaTime;
            if(time_ >= 4.0f)
            {

                if(destroyRigid_ == false)Destroy(gameObject.GetComponent<Rigidbody>());

                destroyRigid_ = true;
                transform.rotation = Quaternion.Slerp(transform.rotation, quo_, timeRotation_);
                transform.position = Vector3.Slerp(transform.position, location_, timeRotation_);
                timeRotation_ += 1.0f / 60.0f; ;

                if(timeRotation_ >= 1.0f)
                {
                    time_ = 0.0f;
                    timeRotation_ = 0.0f;
                    Rigidbody body =  gameObject.AddComponent<Rigidbody>();
                    body.mass = 20.0f;
                    remote_ = false;
                    destroyRigid_ = false;
                }
            }
        }
    }
}
