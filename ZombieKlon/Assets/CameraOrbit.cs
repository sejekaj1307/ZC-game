using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

    public GameObject target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f / 2;
    public float ySpeed = 120.0f / 2;

    public float yMinLimit = 15f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private Rigidbody rigidbody1;
    private bool rightClickDown = false;
    private bool test = true;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody1 = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody1 != null)
        {
            rigidbody1.freezeRotation = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) { rightClickDown = true; }
        else if (Input.GetMouseButtonUp(1)) { rightClickDown = false; }
    }

    void LateUpdate()
    {
        test2();
        if (rightClickDown) { test1();  }
        if(test) { test1(); test = false; }
    }

    //Makes it posible to orbit the camera arround the player
    void test1()
    {
            if (target)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);

                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

                RaycastHit hit;
                if (Physics.Linecast(target.transform.position, transform.position, out hit))
                {
                    //distance -= hit.distance;
                }
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.transform.position;

                transform.rotation = rotation;
                //target.transform.rotation = Quaternion.Euler(0, x, 0); ;
                transform.position = position;  
            }
    }

    //follows the player when it moves 
    void test2()
    {
        if (target)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.transform.position, transform.position, out hit))
            {
                //distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.transform.position;

            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
