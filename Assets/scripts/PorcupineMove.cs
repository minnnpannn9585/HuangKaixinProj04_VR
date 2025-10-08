using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTransformWalker : MonoBehaviour
{
    [Header("移动设置")]
    [Tooltip("NPC移动速度")]
    public float moveSpeed = 2f;
    
    [Tooltip("NPC旋转速度")]
    public float rotationSpeed = 10f;
    
    [Header("范围设置")]
    [Tooltip("移动范围的中心点")]
    public Transform centerPoint;
    
    [Tooltip("最大移动半径")]
    public float maxRadius = 5f;
    
    [Header("等待设置")]
    [Tooltip("到达目标点后的最小等待时间")]
    public float minWaitTime = 1f;
    
    [Tooltip("到达目标点后的最大等待时间")]
    public float maxWaitTime = 3f;

    private Vector3 targetPosition;
    private bool isWaiting = false;
    private float waitTimer = 0f;
    private float currentWaitTime = 0f;

    private void Start()
    {
        // 如果没有设置中心点，使用NPC初始位置作为中心点
        if (centerPoint == null)
        {
            centerPoint = new GameObject("NPC_Walk_Center").transform;
            centerPoint.position = transform.position;
            centerPoint.parent = transform.parent;
        }
        
        // 生成第一个目标点
        GenerateNewTargetPosition();
    }

    private void Update()
    {
        if (isWaiting)
        {
            // 等待状态，倒计时结束后生成新目标
            waitTimer += Time.deltaTime;
            if (waitTimer >= currentWaitTime)
            {
                isWaiting = false;
                waitTimer = 0;
                GenerateNewTargetPosition();
            }
            return;
        }

        // 计算到目标点的方向
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; // 保持在同一平面
        
        // 如果到达目标点附近，进入等待状态
        if (direction.magnitude < 0.2f)
        {
            isWaiting = true;
            currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
            return;
        }
        
        // 移动到目标点（直接修改transform.position）
        direction.Normalize();
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        // 旋转面向移动方向
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// 生成新的随机目标位置
    /// </summary>
    private void GenerateNewTargetPosition()
    {
        // 在圆内随机生成一个点
        Vector2 randomCircle = Random.insideUnitCircle * maxRadius;
        targetPosition = new Vector3(
            centerPoint.position.x + randomCircle.x,
            transform.position.y, // 保持Y轴不变
            centerPoint.position.z + randomCircle.y
        );
    }

    /// <summary>
    /// 在Scene视图中绘制Gizmos，显示移动范围
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (centerPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(centerPoint.position, maxRadius);
        }
        
        // 绘制到目标点的线
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, targetPosition);
    }
}
    
