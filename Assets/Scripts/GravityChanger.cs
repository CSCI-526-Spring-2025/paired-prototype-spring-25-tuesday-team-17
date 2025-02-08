using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public Rigidbody2D player1Rb;
    public Rigidbody2D player2Rb;
    public SpriteRenderer player1Sprite;
    public SpriteRenderer player2Sprite;
    public float floatingForce = 0.15f;
    public Color lowMassColor=new Color(1f,0.6f,0.6f);
    public Color mediumMassColor=new Color(1f,0.3f,0.3f);
    public Color highMassColor=new Color(1f,0f,0f);

    public Color lowMassColor2=new Color(0.85f, 1f, 1f);
    public Color mediumMassColor2=new Color(0.5f, 1f, 1f);
    public Color highMassColor2=new Color(0f, 1f, 1f);
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
        changeFloatingState();
    }

    void FixedUpdate(){
        if(player1Rb.mass==0.01f){
            player1Rb.AddForce(Vector2.up*floatingForce);
        }
        else if(player2Rb.mass==0.01f){
            player2Rb.AddForce(Vector2.up*floatingForce);
        }
    }
    void changeFloatingState(){
        if(floatingState==0){
            player1Rb.mass=0.01f;
            player2Rb.mass=1f;
            player1Sprite.color=lowMassColor;
            player2Sprite.color=highMassColor2;
        }
        else if(floatingState==1){
            player1Rb.mass=0.5f;
            player2Rb.mass=0.5f;
            player1Sprite.color=mediumMassColor;
            player2Sprite.color=mediumMassColor2;
        }
        else if(floatingState==2){
            player1Rb.mass=1f;
            player2Rb.mass=0.01f;
            player1Sprite.color=highMassColor;
            player2Sprite.color=lowMassColor2;
        }
    }
}
