using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovingPlatform : MonoBehaviour
{

    public float maxTime = 5.0f;
    float timer = 0.0f;
    float speed = 3.0f;
    Vector3 mouvement = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            mouvement = -1.0f * mouvement;
            timer = 0.0f;
        }

        transform.position = transform.position + mouvement * speed * Time.deltaTime;
    }
}
