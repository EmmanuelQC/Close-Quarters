using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		AudioSource reloadingSound = GetComponent<AudioSource> ();
		reloadingSound.Play ();
	}

}
