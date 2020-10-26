using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettime : MonoBehaviour
{
   float timer = 4;

    // Update is called once per frame
    void Update()
    {
        if(timer <=0)
		{
			Destroy(gameObject);
		}
		timer -= Time.deltaTime;
    }
}
