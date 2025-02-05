using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1 != null && player2 != null){
            lineRenderer.SetPosition(0, player1.position);
            lineRenderer.SetPosition(1, player2.position);
        }
    }
}
