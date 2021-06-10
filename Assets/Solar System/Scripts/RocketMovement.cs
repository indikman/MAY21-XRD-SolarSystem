using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float shootForce = 2f;

    [SerializeField] private Rigidbody body;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip laserSound;

    [SerializeField] private GameObject laser;
    [SerializeField] private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");


        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(transform.forward * movementSpeed * Time.deltaTime * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(transform.right * movementSpeed * Time.deltaTime * -1);
        }

        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            body.velocity = body.velocity * 0.99f;
        }

        //transform.Rotate(transform.up, horizontal * Time.deltaTime * rotationSpeed);
        //transform.Rotate(transform.right, vertical * Time.deltaTime * rotationSpeed);

        if (horizontal == 0 && vertical == 0)
        {
            body.angularVelocity = body.angularVelocity * 0.99f;
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                body.AddTorque(0, horizontal * Time.deltaTime * rotationSpeed, 0);
                body.AddTorque(vertical * Time.deltaTime * rotationSpeed, 0,0); 
            }

        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject laserShot =  Instantiate(laser, spawnPoint.position, spawnPoint.rotation);
            laserShot.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

            audioPlayer.PlayOneShot(laserSound);

            Destroy(laserShot, 5.0f);
        }
        
        

    }
}
