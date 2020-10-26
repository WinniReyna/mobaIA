using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agenteControl : MonoBehaviour
{
	
	public Camera cam;
	public UnityEngine.AI.NavMeshAgent agente;
	public GameObject bala;
	
	float speed = 3.0f;
    

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit))
			{
				agente.SetDestination(hit.point);
			}
		}
		
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit))
			{
				Debug.DrawRay( transform.position, hit.point, Color.black);
				Debug.Log(hit.point);
				Vector3 aparicion = hit.point+ 0.7f*Vector3.up - transform.position;
				GameObject balat = Instantiate(bala, aparicion.normalized* 0.4f, transform.rotation);
				Rigidbody balaC = balat.GetComponent<Rigidbody>();
			
				balaC.AddForce( aparicion.normalized* 200.0f);
			}
			
			 
			//Debug.DrawRay(transform.position, (ray.direction - ray.direction.y*Vector3.up) *5.0f , Color.black);
			
			
			/*GameObject balat = Instantiate(bala, transform.position, transform.rotation);
			Rigidbody balaC = balat.GetComponent<Rigidbody>();
			
			balaC.addForce( transform.position - ray);*/
			
		}
    }
}
