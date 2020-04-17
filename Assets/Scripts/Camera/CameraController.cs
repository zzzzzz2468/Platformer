using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //sets variables
    public GameObject player;
    private Vector3 offset;

    //detects player
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //Moves the camera
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
