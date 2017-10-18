using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public GameObject gunBullet;               // Object to Instantiate
    public Transform Gun;                      // Position where to shoot

    public float gunFireRate;                  // Rate of fire
    private float gunNextFire;                 // Next Shoot rate

    void Start () {
		
	}
	
	void Update () {

        // Shoot
        if (Input.GetMouseButtonDown(0) && Time.time > gunNextFire)
        {
            gunNextFire = Time.time + gunFireRate;
            Instantiate(gunBullet, new Vector3(Gun.position.x, Gun.position.y, Gun.position.z), Quaternion.identity);
        }

    }
}
