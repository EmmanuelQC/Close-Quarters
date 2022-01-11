using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
	//Speeds
	public float bulletVelocity = 6.0f;
	public float FireRate = 15f;
	public float BulletSpawnTime = 5f;

	//Reload Variables
	public int maxAmmo = 30;
	private int currentAmmo;
	public float reloadTime = 1f;
	private bool isReloading = false;

	//Bullet Variables
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	//Magazine Variables
	public GameObject magPrefab;
	public Transform MagSpawn;

	//Shell Variable
	public Transform Shell;
	public Transform Shellejection;

	//Muzzle Flash Variable
	MuzzleFlash muzzleFlash;

    //Audio
    public AudioClip gunShot;
    private AudioSource gunAudio;
    
	private float nextTimeToFire = 0f;

	void Start()
	{
		currentAmmo = maxAmmo;
		muzzleFlash = GetComponent<MuzzleFlash> ();
        
        gunAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (isReloading) 
			return;
		

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)//|| Input.GetMouseButtonDown("Fire1")
		{
			nextTimeToFire = Time.time + 1f / FireRate;
			Shoot();

			Instantiate (Shell, Shellejection.position, Shellejection.rotation);
		}

		if (currentAmmo <= 0)
		{
			StartCoroutine (Reload());
			return;
		}
	}

	void Shoot()
	{
		//Decrease Ammo By One
		currentAmmo--;

		//Reference to muzzleflash script void activate
		muzzleFlash.Activate ();

		//GunSound
		//AudioSource gunsound  = GetComponent<AudioSource>();
        gunAudio.PlayOneShot(gunShot,1.0f);

		//Reference to bullet prefab and spawn position
		GameObject bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		//Adding force
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.right * bulletVelocity;

		Destroy (bullet, BulletSpawnTime);
	}

	IEnumerator Reload()
	{
		isReloading = true;

		GameObject Magazine =  (GameObject)Instantiate (magPrefab, MagSpawn.position, MagSpawn.rotation);

		Debug.Log ("Reloading...");

		yield return new WaitForSeconds (reloadTime);

		currentAmmo = maxAmmo;
		isReloading = false;
	}
}
