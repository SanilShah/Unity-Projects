using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 7f;

    private Vector3 dir;
    private bool dirTurn;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dirTurn = !dirTurn;

            if (dirTurn)
                dir = Vector3.forward;
            else
                dir = Vector3.back;
        }

        transform.position = transform.position + dir * playerSpeed * Time.deltaTime;
    }
}
