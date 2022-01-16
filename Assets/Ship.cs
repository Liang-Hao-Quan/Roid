using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // some public variables that can be used to tune the Ship’s movement
    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;

    // Use this for initialization
    void Start()
    {
        // Vector3 default initializes all components to 0.0f
        forceVector.x = 1.0f;
        rotationSpeed = 2.0f;
    }
    /* forced changes to rigid body physics parameters should be done through the FixedUpdate() method, not the Update() method
    */
    void FixedUpdate()
    {
        // force thruster
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(forceVector);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rotation += rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rotation -= rotationSpeed; Quaternion rot = Quaternion.Euler(new
            Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
            //GetComponent<Rigidbody>().Rotate(0, -2.0f, 0.0f );
        }
    }

    // Update is called once per frame
    void Update()
    {
        // nothing in here now that movement is done by physics
    }
}