using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movements : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A)){
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D)){
            moveInput = 1f;
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
