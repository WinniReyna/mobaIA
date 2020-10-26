using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreA : MonoBehaviour
{
	public GameObject blA;
	
	bool atack = false;
	float shotinRate = 1.8f;
	
	Vector3 enemiPos = Vector3.zero;
	float jitPoints = 200;  //vida del esbirroR
	
   

    // Update is called once per frame
    void Update()
    {
		if (jitPoints <=0)
		{
			Destroy(gameObject);
		}
        Collider[] losColiders = Physics.OverlapSphere(transform.position, 2.5f);
		
		for (int i = 0; i< losColiders.Length; i++)
		{
			if(losColiders[i].gameObject.tag == "red")
			{
				atack = true;
				
				enemiPos = losColiders[i].gameObject.transform.position - transform.position;
				i = losColiders.Length;
			} else
			{
				atack = false;
			}
		}
		
		if( atack )
		{
			if (shotinRate >= 1.8f)
			{
				//Debug.Log("atac");
				Debug.DrawRay(transform.position, enemiPos, Color.red);
				GameObject balaA = Instantiate( blA, transform.position, transform.rotation);
				Rigidbody balaaC = balaA.GetComponent<Rigidbody>();
				balaaC.velocity = enemiPos;
				//shotinRate = 2;
			}
			shotinRate -= Time.deltaTime;
			//Debug.Log(shotinRate);
			if(shotinRate<=0)
			{
				shotinRate = 1.8f;
			}
		}
    }
	
	
	void OnCollisionEnter( UnityEngine.Collision col )
	{
		
		if (col.gameObject.tag == "balred")
		{

			jitPoints -= 20;
			Debug.Log(jitPoints);
			Destroy(col.gameObject);
		}
		
	}
}
