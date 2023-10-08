using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatingTrap : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * rotationSpeed * Time.fixedDeltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.RestartLevelScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
