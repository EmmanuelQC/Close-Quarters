using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

	public GameObject flashHolder;

	public float FlashTime;

	// Use this for initialization 
	void Start () {
		Deactiviate ();
	}
	

	public void Activate () {
		flashHolder.SetActive (true);

		Invoke ("Deactiviate", FlashTime);
	}

	public void Deactiviate () {
		flashHolder.SetActive (false);
	}
}
