using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject laserParticle;

    void OnCollisionEnter(Collision col)
    {
        Instantiate(laserParticle, transform.position, transform.rotation);
        Destroy(gameObject);

    }


}
