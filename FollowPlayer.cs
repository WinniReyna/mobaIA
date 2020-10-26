using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object
    public GameObject spawnObject;
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    bool instanciated;
    public Transform spawnposition;


    // Use this for initialization
    void Start()
    {
        Instantiate(spawnObject, new Vector3(spawnposition.position.x, spawnposition.position.y, spawnposition.position.z), Quaternion.identity);
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        instanciated = true;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        player = GameObject.Find("Player(Clone)");

        if (instanciated == false)
        {
            StartCoroutine("Fade");
        }

        if (player != null)
        {
            StopCoroutine("Fade");
            transform.position = player.transform.position + offset;
        }else{
            instanciated = false;
        }
    }

    private IEnumerator Fade()
    {
        instanciated = true;
        yield return new WaitForSeconds(10f);
        Instantiate(spawnObject, new Vector3(spawnposition.position.x, spawnposition.position.y, spawnposition.position.z), Quaternion.identity);
       
    }
}
