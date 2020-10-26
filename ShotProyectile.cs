using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProyectile : MonoBehaviour
{
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
        }
    } 
}
