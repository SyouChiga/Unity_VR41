using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] ParticleSystem goalEffect;

    private void Update()
    {
       
    }

    //
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            ParticleSystem particle = Instantiate<ParticleSystem>(hitEffect, transform.position, Quaternion.identity);
            Destroy(particle.gameObject, 1.0f);
            Destroy(this.gameObject);
        }
        
        if(collision.gameObject.tag == "Goal")
        {
            ParticleSystem particle = Instantiate<ParticleSystem>(hitEffect, transform.position, Quaternion.identity);
            Destroy(particle.gameObject, 1.0f);
            Destroy(this.gameObject);
            GameObject.Find("ClearText").GetComponent<TextMesh>().text = "GameClear";
        }

        if (collision.gameObject.tag == "Pannel")
        {
            ParticleSystem particle = Instantiate<ParticleSystem>(hitEffect, transform.position, Quaternion.identity);
           
        }
    }
}
