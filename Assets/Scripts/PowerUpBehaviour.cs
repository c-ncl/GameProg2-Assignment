using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject particleSystemToSpawn;
    public GameObject bluePowerUp;
    public Transform spawnPoint;

    private Vector3 spawnPointPosition;
    private Quaternion spawnPointRotation;

    // Start is called before the first frame update
    void Start()
    {
        spawnPointPosition = spawnPoint.transform.position;
        spawnPointRotation = spawnPoint.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(Instantiate(particleSystemToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation), 3);
        }
        Invoke("RespawnPowerUp", 30);
    }

    void RespawnPowerUp()
    {
        Instantiate(bluePowerUp, spawnPointPosition, spawnPointRotation);
    }
}
