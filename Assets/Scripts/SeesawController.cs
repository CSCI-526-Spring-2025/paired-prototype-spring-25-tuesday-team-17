using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawController : MonoBehaviour
{
    [Header("Physics Settings")]
    public float maxAngle = 85f;     // maximum rotation angle
    public float balanceDamping = 2f; // rotation damping

    private Rigidbody2D beamRb;
    private HingeJoint2D hinge;

    void Start()
    {
        beamRb = GetComponent<Rigidbody2D>();
        hinge = GetComponent<HingeJoint2D>();
    }

    void FixedUpdate()
    {
        // limit the rotation angle
        float currentAngle = hinge.jointAngle;
        if (Mathf.Abs(currentAngle) > maxAngle)
        {   
            // Stop the beam from rotating further
            beamRb.angularVelocity = 0f;
            // beamRb.rotation = Mathf.Sign(currentAngle) * maxAngle;
        }
    }
}
