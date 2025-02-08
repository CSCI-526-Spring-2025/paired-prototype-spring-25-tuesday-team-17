using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeConfiguration : MonoBehaviour
{
    [Header("Endpoints (not counted in n)")]
    public Transform startPoint;
    public Transform endPoint;

    [Header("Rope Settings")]
    [Tooltip("Number of rope segments between the endpoints.")]
    public int segmentCount = 10;

    [Tooltip("Optional prefab for the rope segment. If not set, segments will be created in code.")]
    public GameObject segmentPrefab;

    public float segmentMass = 5.0f;

    private GameObject[] segments;

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        if (startPoint == null || endPoint == null || segmentPrefab == null)
        {
            Debug.LogError("Please assign both startPoint and endPoint in the inspector!");
            return;
        }

        Rigidbody2D startRb = startPoint.GetComponent<Rigidbody2D>();
        if (startRb == null)
        {
            startRb = startPoint.gameObject.AddComponent<Rigidbody2D>();

            startRb.isKinematic = true;
        }

        Rigidbody2D endRb = endPoint.GetComponent<Rigidbody2D>();
        if (endRb == null)
        {
            endRb = endPoint.gameObject.AddComponent<Rigidbody2D>();
            endRb.isKinematic = true;
        }

        startPoint.gameObject.layer = LayerMask.NameToLayer("rope");
        endPoint.gameObject.layer = LayerMask.NameToLayer("rope");

        Vector3 startPos = startPoint.position;
        Vector3 endPos = endPoint.position;
        float totalDistance = Vector3.Distance(startPos, endPos);

        if (segmentCount <= 0)
        {
            HingeJoint2D hinge = startPoint.gameObject.GetComponent<HingeJoint2D>();
            if (hinge == null)
                hinge = startPoint.gameObject.AddComponent<HingeJoint2D>();
            hinge.connectedBody = endRb;
            return;
        }

        float spacing = totalDistance / (segmentCount);
        Vector3 direction = (endPos - startPos).normalized;

        segments = new GameObject[segmentCount];

        for (int i = 0; i < segmentCount; i++)
        {
            Vector3 pos = startPos + direction * spacing * (i);
            GameObject segment;


            segment = Instantiate(segmentPrefab, pos, Quaternion.identity, transform);
            segment.layer = LayerMask.NameToLayer("rope");
            BoxCollider2D bc = segment.GetComponent<BoxCollider2D>();
            if (bc == null)
            {
                bc = segment.AddComponent<BoxCollider2D>();
            }

            Rigidbody2D rb = segment.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = segment.AddComponent<Rigidbody2D>();
            }
            rb.mass = segmentMass;
            rb.gravityScale = 0.5f;

            // Ensure the segment has a HingeJoint2D.
            HingeJoint2D hj = segment.GetComponent<HingeJoint2D>();
            if (hj == null)
                hj = segment.AddComponent<HingeJoint2D>();

            if (i == 0)
            {
                hj.connectedBody = startRb;
            }
            else
            {
                Rigidbody2D prevRb = segments[i - 1].GetComponent<Rigidbody2D>();
                hj.connectedBody = prevRb;
            }

            segments[i] = segment;
        }

        HingeJoint2D endHinge = endPoint.gameObject.GetComponent<HingeJoint2D>();
        if (endHinge == null)
            endHinge = endPoint.gameObject.AddComponent<HingeJoint2D>();
        Rigidbody2D lastRb = segments[segmentCount - 1].GetComponent<Rigidbody2D>();
        endHinge.connectedBody = lastRb;

        Destroy(segmentPrefab);
    }

}
