using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creaEsbirro : MonoBehaviour
{
	
	public GameObject minionA;
	public GameObject minionR;
	
	float ST = 7;
	float timer = 7;
	


    // Update is called once per frame
    void Update()
    {
        if (timer >=ST)
		{
			GameObject minionAA = Instantiate( minionA, new Vector3(0,1,16), transform.rotation);
			GameObject minionRR = Instantiate( minionR, new Vector3(0,1,-16), transform.rotation);
		}
		
		
		timer -= Time.deltaTime;
		//Debug.Log("timer valor:  " + timer);

		if(timer <=0)
		{
			timer = ST;
		}		
    }
}
