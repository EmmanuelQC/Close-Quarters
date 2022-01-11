using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

	public int damage = 10;

	//public GameObject impact;

	void OnCollisionEnter (Collision collision)
	{
        Destroy (gameObject);
        
		GameObject hit = collision.gameObject;
        
        //Topdown
		Player1Movement health = hit.GetComponent <Player1Movement> ();
        if (health != null) 
		{
			health.TakeDamage (damage);
		}

		Player2Movement health1 = hit.GetComponent <Player2Movement> ();
		if (health1 != null) 
		{
			health1.TakeDamage (damage);
		}
       
       //third person
       PlayerThirdPersonMovement healthTh = hit.GetComponent <PlayerThirdPersonMovement> ();
       if (healthTh != null)
       {
           healthTh.TakeDamage (damage);
       }

       PlayerThirPersonMovement2 healthTh1 = hit.GetComponent <PlayerThirPersonMovement2> ();
       if (healthTh1 != null)
       {
           healthTh1.TakeDamage (damage);
       }
        
		HealthScript objhealth = hit.GetComponent <HealthScript> ();
		if (objhealth != null) 
		{
			objhealth.TakeDamage (damage);
		}

	}
}
