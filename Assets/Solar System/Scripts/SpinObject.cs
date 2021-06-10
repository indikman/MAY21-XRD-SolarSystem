using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] Vector3 rotation;


    void Start()
    {
       
    }

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
