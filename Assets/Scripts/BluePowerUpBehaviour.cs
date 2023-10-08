using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePowerUpBehaviour : MonoBehaviour
{
    public GameObject particleSystemToSpawn;
    public GameObject bluePowerUp;
    public Transform spawnPoint;
    float rotationSpeed = 3.0f;
    float maxTime = 1.3f;
    float timer = 0.0f;
    float speed = 0.25f;
    Vector3 movement = new Vector3(0, -1, 0);

    // Float
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            movement = -1.0f * movement;
            timer = 0.0f;
        }

        transform.position = transform.position - movement * speed * Time.deltaTime;
    }

    // Rotate
    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(Instantiate(particleSystemToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation), 3);
            gameObject.SetActive(false);
            Invoke("RespawnPowerUp", 30.0f);
        }
    }

    void RespawnPowerUp()
    {
        gameObject.SetActive(true);
    }
}
