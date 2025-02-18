using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [Tooltip("Assign the first player's Rigidbody2D here")]
    public Rigidbody2D player1;
    
    [Tooltip("Assign the second player's Rigidbody2D here")]
    public Rigidbody2D player2;

    void Start()
    {
        if (player1 == null)
        {
            player1 = GameObject.Find("Player1").GetComponent<Rigidbody2D>();
        }
        if (player2 == null)
        {
            player2 = GameObject.Find("Player2").GetComponent<Rigidbody2D>();
        }
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogWarning("Player references are missing!");
            return;
        }

        Vector2 midpoint = (player1.position + player2.position) * 0.5f + Vector2.up * 2f;

        transform.position = new Vector3(midpoint.x, midpoint.y, transform.position.z);
    }
}
