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
        // 如果没有指定玩家对象，尝试从场景中查找
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
        // 确保两个玩家对象都存在
        if (player1 == null || player2 == null)
        {
            Debug.LogWarning("Player references are missing!");
            return;
        }

        // 计算两个玩家的中点坐标（2D空间）
        Vector2 midpoint = (player1.position + player2.position) * 0.5f + Vector2.up * 2f;
        
        // 更新当前物体的位置，保持原有Z轴不变（适用于摄像机等需要保持Z轴的情况）
        transform.position = new Vector3(midpoint.x, midpoint.y, transform.position.z);
    }
}
