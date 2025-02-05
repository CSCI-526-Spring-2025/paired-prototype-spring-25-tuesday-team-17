using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public Rigidbody2D player1Rb;
    public Rigidbody2D player2Rb;
    public float floatingForce = 0.1f;
    private int floatingState=1;
    // Start is called before the first frame update
    void Start(){
        changeFloatingState();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            floatingState++;
            if(floatingState>2) floatingState=2;
        }
        else if(Input.GetKeyDown(KeyCode.J)){
            floatingState--;
            if(floatingState<0) floatingState=0;
        }
    }

    void FixedUpdate(){
        if(player1Rb.gravityScale==0f){
            player1Rb.AddForce(Vector2.up*floatingForce);
        }
        else if(player2Rb.gravityScale==0f){
            player2Rb.AddForce(Vector2.up*floatingForce);
        }
    }
    void changeFloatingState(){
        if(floatingState==0){
            player1Rb.gravityScale=0f;
            player2Rb.gravityScale=1f;
        }
        else if(floatingState==1){
            player1Rb.gravityScale=0.5f;
            player2Rb.gravityScale=0.5f;
        }
        else if(floatingState==2){
            player1Rb.gravityScale=1f;
            player2Rb.gravityScale=0f;
        }
    }
}
