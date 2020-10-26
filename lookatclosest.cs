using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatclosest : MonoBehaviour
{
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Unit");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine("Fade");
        }
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100);

            Destroy(bullet, 1);
    }
}
