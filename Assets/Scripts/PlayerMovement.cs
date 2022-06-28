using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed;
    public float horizontalSpeed;
    private Vector3 playerPos;
    float horizontalMovement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!UIController.dead)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            playerPos.y = transform.position.y;
            playerPos.x = Mathf.Clamp(playerPos.x + (horizontalMovement * Time.deltaTime * horizontalSpeed), -2.22f, 2.05f);

            playerPos.z = transform.position.z + forwardSpeed * Time.deltaTime;
            transform.position = playerPos;
        }
    }
}
