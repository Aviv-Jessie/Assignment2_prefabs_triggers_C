using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMoverWASD : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float Speed = 4f;

    void Update(){
        Vector3 pos = transform.position;

        if (Input.GetKey("t")){
            pos.y += Speed * Time.deltaTime;
        }
        if (Input.GetKey("g")){
            pos.y -= Speed * Time.deltaTime;
        }
        if (Input.GetKey("h")){
            pos.x += Speed * Time.deltaTime;
        }
        if (Input.GetKey("f")){
            pos.x -= Speed * Time.deltaTime;
        }


        transform.position = pos;
    }




















}
