using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using System;

public class UpdateCollectiblesCount : MonoBehaviour
{    
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component
    // Start is called before the first frame update
    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        GameObject collectiblePrefab = GameObject.Find("collectibles");
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        // Type collectibleType = Type.GetType("Collectibles");
        // if (collectibleType != null)
        // {
        //     totalCollectibles += UnityEngine.Object.FindObjectsOfType(collectibleType).Length;
        // }
        totalCollectibles += collectiblePrefab.transform.childCount;

        // // Optionally, check and count objects of type Collectible2D as well if needed
        // Type collectible2DType = Type.GetType("Collectible2D");
        // if (collectible2DType != null)
        // {
        //     totalCollectibles += UnityEngine.Object.FindObjectsOfType(collectible2DType).Length;
        // }

        // Update the collectible count display
        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";

    }
}
