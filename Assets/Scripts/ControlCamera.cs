using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Transform target;
    
    [SerializeField]
    private Vector3 offset;

    public float smoothSpeed;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + target.position, smoothSpeed);
        transform.position = newPos; 
    }
}
