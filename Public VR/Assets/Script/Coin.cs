using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject hand;

    [SerializeField] private List<Transform> rootPosList;

    [SerializeField] private float speed;

    private int curRootNum;
    // Start is called before the first frame update
    void Start()
    {
        curRootNum = 1;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if( (hand.transform.position - transform.position).magnitude < 1.0)
        {

        }
        Move();
    }


    /// <summary>
    /// Move
    /// </summary>
    private void Move()
    {
        if (curRootNum != 0)
        {
            Vector3 dir = rootPosList[curRootNum].position - transform.position;
            transform.position = transform.position + dir * speed;

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            curRootNum++;
        }
    }

    /// <summary>
    /// コインの動きを開始
    /// </summary>
    void StartMovement()
    {
        curRootNum = 1;
    }
}
