using UnityEngine;
using UnityEngine.UI;

public class HorizontalVelocityDetector : MonoBehaviour
{
    public Rigidbody2D targetObject; // 要检测速度的物体
    public Scrollbar scrollbar; // 控制滚动条
    private float previousHorizontalPosition; // 上一帧的水平位置
    private float lastUpdateTime; // 上次更新的时间
    private float targetSize; // 目标滚动条大小
    private float sizeChangeSpeed = 0.6f; // 滚动条大小变化的速度
    private float decreaseSpeed = 0.3f; // 滚动条大小减小的速度

    private void Start()
    {
        // 初始化上一帧的水平位置为物体的初始水平位置
        previousHorizontalPosition = targetObject.position.x;
        lastUpdateTime = Time.time;

        // 初始化目标滚动条大小为当前大小
        targetSize = scrollbar.size;
    }

    private void Update()
    {
        // 计算当前帧的水平速度
        float currentHorizontalVelocity = (targetObject.position.x - previousHorizontalPosition) / (Time.time - lastUpdateTime);

        // 更新上一帧的水平位置和上次更新的时间
        previousHorizontalPosition = targetObject.position.x;
        lastUpdateTime = Time.time;

        // 每秒更新一次水平速度
        if (Time.time % 1f < Time.deltaTime)
        {
            // 取整水平速度
            int roundedHorizontalVelocity = Mathf.RoundToInt(currentHorizontalVelocity);

            // 输出取整后的水平速度
            Debug.Log("Rounded Horizontal Velocity: " + roundedHorizontalVelocity);

            // 根据速度大小调整目标滚动条大小
            if (Mathf.Abs(roundedHorizontalVelocity) >= 7)
            {
                targetSize += sizeChangeSpeed;
            }
            else
            {
                targetSize -= decreaseSpeed;
            }
        }

        // 平缓增减滚动条的大小
        targetSize = Mathf.Clamp01(targetSize);
        scrollbar.size = Mathf.Lerp(scrollbar.size, targetSize, Time.deltaTime * sizeChangeSpeed);
    }
}