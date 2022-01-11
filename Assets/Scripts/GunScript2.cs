using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript2 : MonoBehaviour {

	public float bulletVelocity = 6.0f;
	public float FireRate = 15f;
    public float BulletSpawnTime = 5f;

	public int maxAmmo = 30;
	private int currentAmmo;
	public float reloadTime = 1f;
	private bool isReloading = false;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public GameObject magPrefab;
	public Transform MagSpawn;

	public Transform Shell;
	public Transform Shellejection;

    //Audio
    public AudioClip gunShot;
    private AudioSource gunAudio;
    
	MuzzleFlash muzzleFlash;

	private float nextTimeToFire = 0f;

	// Update is called once per frame

	void Start()
	{
		currentAmmo = maxAmmo;
		muzzleFlash = GetComponent<MuzzleFlash> ();
        
        gunAudio = GetComponent<AudioSource>();
	}

	void Update () {

		if (isReloading) 
			return;

		if (Input.GetKey("o") && Time.time >= nextTimeToFire)
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
		currentAmmo--;

		//Reference to muzzleflash script void activate
		muzzleFlash.Activate ();

		//AudioSource gunsound  = GetComponent<AudioSource>();
		//gunsound.Play();
        gunAudio.PlayOneShot(gunShot,1.0f);

		GameObject bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.right * bulletVelocity;

		Destroy (bullet, BulletSpawnTime);
	}

	IEnumerator Reload()
	{
		isReloading = true;

		GameObject Magazine =  (GameObject)Instantiate (magPrefab, MagSpawn.position, MagSpawn.rotation);

		Debug.Log ("Player 2 Reloading...");

		yield return new WaitForSeconds (reloadTime);

		currentAmmo = maxAmmo;

		isReloading = false;
	}
}
