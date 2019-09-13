using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float score;

    [SerializeField] private TextMesh text;

    [SerializeField] private GameObject point;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpPoint()
    {
        score += 10.0f;

        text.text = score.ToString();

        float x = Random.value % 4 -2;
        
        Instantiate<GameObject>(point, new Vector3(x, 2, 2), Quaternion.identity);
    }
}
