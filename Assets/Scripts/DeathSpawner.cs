using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSpawner : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float lowerYlimit = -20f;
    private Vector3 spawnPoint1;
    private Vector3 spawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        if(player1!=null){
            spawnPoint1 = player1.transform.position;
        }
        if(player2!=null){
            spawnPoint2 = player2.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player1!=null && player1.transform.position.y < lowerYlimit||player2!=null && player2.transform.position.y < lowerYlimit){
            player1.transform.position = spawnPoint1;
            player2.transform.position = spawnPoint2;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
