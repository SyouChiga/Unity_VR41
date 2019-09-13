using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            //effect.Play();
            Instantiate<ParticleSystem>(effect,collision.transform.position, Quaternion.identity);
            //Destroy(effect.gameObject, 1.0f);
            GameObject.Find("GameManager").GetComponent<GameManager>().UpPoint();
         
        }
    }
}
