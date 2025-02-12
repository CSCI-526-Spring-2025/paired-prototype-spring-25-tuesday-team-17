using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    public int totalCollectibles = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetCollectibleCount() == totalCollectibles)
        {
            Destroy(gameObject);
        }
    }

    private int GetCollectibleCount()
    {
        GameObject collectiblePrefab = GameObject.Find("collectibles");
        int totalCollectibles = 0;
        totalCollectibles += collectiblePrefab.transform.childCount;
        return totalCollectibles;
    }
}
