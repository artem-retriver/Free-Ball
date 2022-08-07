using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Transform:")]
    [SerializeField] private Transform ball;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - ball.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, offset.y + ball.position.y - 3, transform.position.z); 
        transform.position = newPosition;
    }
}
