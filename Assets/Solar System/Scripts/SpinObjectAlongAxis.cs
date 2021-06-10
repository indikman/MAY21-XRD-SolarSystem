using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjectAlongAxis : MonoBehaviour
{

    [SerializeField] private Vector3 axis;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
