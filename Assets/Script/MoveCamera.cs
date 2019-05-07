using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField]
    float speed = 50.0f;

    [SerializeField]
    float wheelSpeed = 500.0f;

    [SerializeField]
    float rotateSpeed = 50.0f;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.position += transform.right * x;
        transform.position += transform.forward * y;

        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotateSpeed;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotateSpeed;

        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(-MouseY, MouseX, 0));
            Vector3 eulerAngle = transform.eulerAngles;
            eulerAngle.z = 0;
            transform.eulerAngles = eulerAngle;
        }

        float MouseWheel = Input.GetAxis("Mouse ScrollWheel");
        transform.position += MouseWheel * transform.forward * Time.deltaTime * speed *1000;

        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(2))
        {
            transform.position += transform.right * MouseX;
            transform.position += transform.up * MouseY;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
       /*
        Vector3 normals = Vector3.zero;
        float separates = 0;

        foreach (ContactPoint point in collision.contacts)
        {
            normals += point.normal;
            if (separates > point.separation)
                separates = point.separation;
        }

        Debug.Log((normals ).ToString("F12"));
        transform.position += normals * Mathf.Abs(separates); 
        */

    }
}
