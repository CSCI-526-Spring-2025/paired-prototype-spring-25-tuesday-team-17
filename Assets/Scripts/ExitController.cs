using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject collectiblePrefab = GameObject.Find("collectibles");
        int totalCollectibles = 0;
        totalCollectibles += collectiblePrefab.transform.childCount;
        Debug.Log("All collectibles collected!");
        if (totalCollectibles == 0)
        {
            Debug.Log("All collectibles collected!");
            if(other.CompareTag("Player"))
            {
                Debug.Log("Player has reached the exit!");
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
