using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public GameObject playerObject; // 要识别的特定物体

    private Camera mainCamera; // 主摄像机的引用
    public Transform[] targetPositions; // 特定位置的Transform组件数组
    public Collider2D[] targetRangeColliders; // 特定范围的碰撞器

    public float smoothSpeed = 0.5f; // 平滑移动的速度

    private Vector3 targetPosition; // 目标移动位置

    private void Start()
    {
        mainCamera = Camera.main; // 获取主摄像机的引用
    }

    private void Update()
    {
        bool isPlayerInTargetRange = false;
        int targetRangeIndex = -1;

        // 遍历所有特定范围的碰撞器
        for (int i = 0; i < targetRangeColliders.Length; i++)
        {
            Collider2D collider = targetRangeColliders[i];

            // 检查特定物体是否与特定范围的碰撞器重叠
            if (collider.OverlapPoint(playerObject.transform.position))
            {
                isPlayerInTargetRange = true;
                targetRangeIndex = i;
                break;
            }
        }

        // 根据检测结果执行相应操作
        if (isPlayerInTargetRange)
        {
            //Debug.Log("Player object is in target range " + targetRangeIndex);

            // 获取目标位置
            if (targetRangeIndex >= 0 && targetRangeIndex < targetPositions.Length)
            {
                targetPosition = targetPositions[targetRangeIndex].position;
            }
        }
        else
        {
            //Debug.Log("Player object is not in any target range");
        }

        // 平滑移动摄像机到目标位置
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        mainCamera.transform.position = smoothedPosition;
    }
}