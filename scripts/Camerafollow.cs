using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    Vector3 camOffset;
    void Start()
    {
        camOffset = transform.position - target.position; 
    }
    private void FixedUpdate()
    {
        transform.position = target.position + camOffset;
    }

}
