using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ObjectMovement : MonoBehaviour
{
    public float delay = 2f; // 延迟时间（以秒为单位）
    public float speed = 1f; // 移动速度（每秒移动的距离）
    public float distance = 5f; // 移动的距离

    private bool isMoving = false; // 是否正在移动
    private float elapsedTime = 0f; // 已经过的时间
    public float initialY; // 初始 Y 坐标

    private void Start()
    {
        Invoke("StartMovement", delay); // 延迟指定时间后开始移动
    }

    private void Update()
    {
        if (isMoving)
        {
            // 根据速度和已经过的时间计算当前位置
            float newY = initialY + speed * elapsedTime;

            // 更新物体的位置
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            elapsedTime += Time.deltaTime; // 更新已经过的时间

            // 判断是否达到目标位置
            if (newY >= initialY + distance)
            {
                StopMovement(); // 停止移动
            }
        }
    }

    private void StartMovement()
    {
        isMoving = true; // 开始移动
    }

    private void StopMovement()
    {
        isMoving = false; // 停止移动
    }
}