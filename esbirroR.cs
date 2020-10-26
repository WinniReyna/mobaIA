using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esbirroR : MonoBehaviour
{
	
	public UnityEngine.AI.NavMeshAgent agente;
	public GameObject blR;
	bool moviendose = true;
	
	bool atack = false;
	float shotinRate = 2;
	
	Vector3 enemiPos = Vector3.zero;
	float jitPoints = 100;  //vida del esbirroR
	
	void Update()
    {
		if (jitPoints <=0)
		{
			Destroy(gameObject);
			return;
		}
		
		Collider[] losColiders = Physics.OverlapSphere(transform.position, 2.4f);
		
		for (int i = 0; i< losColiders.Length; i++)
		{
			if(losColiders[i].gameObject.tag == "azul")
			{
				atack = true;
				//Debug.Log("vivo"+ i);
				moviendose = false;
				agente.isStopped = true;
				
				enemiPos = losColiders[i].gameObject.transform.position - transform.position;
				i = losColiders.Length;
			} else
			{
				moviendose = true;
				agente.isStopped = false;
				atack = false;
			}
		}
		
		if( atack )
		{
			if (shotinRate >= 2)
			{
				//Debug.Log("atac");
				Debug.DrawRay(transform.position, enemiPos, Color.red);
				GameObject balaR = Instantiate( blR, transform.position, transform.rotation);
				Rigidbody balarC = balaR.GetComponent<Rigidbody>();
				balarC.velocity = enemiPos;
				//shotinRate = 2;
			}
			shotinRate -= Time.deltaTime;
			//Debug.Log(shotinRate);
			if(shotinRate<=0)
			{
				shotinRate = 2;
			}
			
		}
		
		if (moviendose)
		{
			//Debug.Log(" oov");
			agente.SetDestination(new Vector3(0,1,20));
		}

        
	}
	
	void OnCollisionEnter( UnityEngine.Collision col )
	{
		
		if (col.gameObject.tag == "balazu")
		{

			jitPoints -= 25;
			Debug.Log(jitPoints);
			Destroy(col.gameObject);
		}
		
	}
	
	/*
	void OnTriggerStay( Collider col )
	{
		
		if (col.gameObject.tag == "azul")
		{
			//Debug.Log("hola");
			moviendose = false;
			//agente.velocity = Vector3.zero;
			agente.isStopped = true;
			atac = true;
			enemiPos = col.gameObject.transform.position - transform.position;
			
		} else
		{
			moviendose = true;
			agente.isStopped = false;
			atac = false;
		}
		
	}*/
	
	/*void OnTriggerExit( Collider col)
	{
		if (col.gameObject.tag == "azul")
		{
			moviendose = true;
			agente.isStopped = false;
			atac = false;
			
		}
	}*/
	
}
