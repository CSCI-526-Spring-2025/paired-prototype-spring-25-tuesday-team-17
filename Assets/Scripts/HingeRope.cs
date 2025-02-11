using System.Collections.Generic;
using UnityEngine;

public class HingeRope : MonoBehaviour
{
    [Header("Rope Settings")]
    public Rigidbody2D startPoint;       // 绳子起点
    public Rigidbody2D endPoint;         // 绳子终点
    public int segmentCount = 5;         // 分段数量
    public float segmentSpacing = 0.5f;  // 每段绳子间距(长度)
    
    [Header("Prefab Reference")]
    public GameObject segmentPrefab;     // 预制体(必须带Rigidbody2D等)

    // 用于存储生成的每段绳子
    private List<Rigidbody2D> segments = new List<Rigidbody2D>();

    void Start()
    {
        if (!startPoint || !endPoint || segmentCount < 1 || !segmentPrefab)
        {
            Debug.LogError("RopeHinge2D: 参数未设置完整，无法生成绳子");
            return;
        }

        GenerateRope();
    }

    void GenerateRope()
    {
        // 上一个刚体，最初是 startPoint
        Rigidbody2D previousBody = startPoint;

        // 根据分段数插值地摆放每一段
        for (int i = 0; i < segmentCount; i++)
        {
            // 计算这一段的初始位置 (可在 start & end 间插值，也可只往下排)
            float t = (float)(i + 1) / (segmentCount + 1);
            Vector2 spawnPos = Vector2.Lerp(startPoint.position, endPoint.position, t);

            // 生成预制体
            GameObject newSegment = Instantiate(segmentPrefab, spawnPos, Quaternion.identity, transform);
            
            // 确保有 Rigidbody2D
            Rigidbody2D rb = newSegment.GetComponent<Rigidbody2D>();
            if (rb == null) rb = newSegment.AddComponent<Rigidbody2D>();

            // 确保有 HingeJoint2D
            HingeJoint2D joint = newSegment.GetComponent<HingeJoint2D>();
            if (joint == null) joint = newSegment.AddComponent<HingeJoint2D>();

            // 连接到上一段
            joint.connectedBody = previousBody;
            // 关掉自动配置，以便我们自定义锚点
            joint.autoConfigureConnectedAnchor = false;

            // 根据你的 Prefab 大小决定 anchor 的位置
            // 如果你的 Prefab 高度是 segmentSpacing，顶部 anchor = +segmentSpacing/2，底部 anchor = -segmentSpacing/2
            // 这里简单演示，把每段的 "锚点" 放在自身中心(0,0) + 连接对方的anchor往下 shift一点
            joint.anchor = Vector2.zero; 
            joint.connectedAnchor = new Vector2(0f, -segmentSpacing * 0.5f);

            // 可选：调节是否使用 limits/motor
            // joint.useLimits = true;
            // joint.limits = new JointAngleLimits2D { min = -45f, max = 45f };

            // 记录这一段
            segments.Add(rb);
            previousBody = rb;
        }

        // 将最后一段连接到 endPoint
        HingeJoint2D endJoint = previousBody.gameObject.AddComponent<HingeJoint2D>();
        endJoint.connectedBody = endPoint;
        endJoint.autoConfigureConnectedAnchor = false;
        endJoint.anchor = Vector2.zero;
        endJoint.connectedAnchor = new Vector2(0f, -segmentSpacing * 0.5f);
    }
}
