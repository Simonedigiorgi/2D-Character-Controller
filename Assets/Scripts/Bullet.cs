using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float speed = 15;

    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (transform.position.z - Camera.main.transform.position.z);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.LookAt(worldPos, Vector3.forward);

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }

}