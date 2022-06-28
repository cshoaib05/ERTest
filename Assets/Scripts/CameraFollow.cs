using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float offset;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        offset = transform.position.z - player.transform.position.z;
    }

    void FixedUpdate()
    {
        pos.z = player.transform.position.z + offset;
        transform.position = pos;

    }
}
