using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public float camSpeed;

    private Vector3 offset;

    private void Start()
    {
        offset = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position-offset, Time.deltaTime * camSpeed);      
    }
}
