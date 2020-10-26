using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMovement : MonoBehaviour
{
    private int speed = 5;

    public void Move()
    {

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        this.transform.position += Movement * speed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }
}
