using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    public float speed;

    //0:left 1:mid 2:right
    private int line = 1;
    public float lineDistance = 4;
    public float jumpForce;
    public float gravity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        dir.z = speed;
  
        if(controller.isGrounded)
        {
            dir.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            dir.y += gravity * Time.deltaTime;
        }



        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (line == 2) return;
            line++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (line == 0) return;
            line--;
        }

        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(line == 0)
        {
            targetPos += Vector3.left * lineDistance;
        }
        else if(line == 2)
        {
            targetPos += Vector3.right * lineDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, 80 * Time.fixedDeltaTime);


    }

    private void FixedUpdate()
    {
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }
}
