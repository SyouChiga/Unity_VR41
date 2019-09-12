using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //
    [SerializeField] ParticleSystem hitEffect;

    private void Update()
    {
       
    }

    //
    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem particle = Instantiate<ParticleSystem>(hitEffect,transform.position, Quaternion.identity);
        Destroy(particle.gameObject, 1.0f);
        Destroy(this.gameObject);
    }
}
