using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bullet;               // Object to Instantiate
    public Transform Gun;                   // Position where to shoot
    public float fireRate;                  // Rate of fire
    private float nextFire;                 // Next Shoot rate

    public float moveSpeed;
    public float jump;
    private CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float yStore = moveDirection.y;
        moveDirection = (transform.right * Input.GetAxis("Horizontal"));

        // This normalize the speed if you press two directions at the same time
        moveDirection = moveDirection.normalized * moveSpeed;

        moveDirection.y = yStore;

        // Jump
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetKeyDown(KeyCode.W))
            {
                moveDirection.y = jump;
            }
        }

        // Shoot

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, new Vector3(Gun.position.x, Gun.position.y, Gun.position.z), Quaternion.identity);
        }

        // To change the Psysics Gravity go to Edit/Project Settings/Physics
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

}
