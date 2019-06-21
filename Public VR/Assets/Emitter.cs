using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
	public GameObject obj;
	static float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		counter += Time.deltaTime;

		if(counter > 3.0f)
		{

			// Cubeプレハブを元に、インスタンスを生成、
			Instantiate(obj, this.transform.position, Quaternion.identity);

			counter = 0.0f;
		}


	}


}

