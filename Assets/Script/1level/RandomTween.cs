using UnityEngine;

public class RandomTween : MonoBehaviour
{
    public RectTransform[] waypoints; // 存储多个目标 UI 的 RectTransform 组件
    public float speed = 1f; // 移动速度

    private int currentIndex = 0;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to LoopingTween script.");
            return;
        }

        Vector2 targetPosition = waypoints[currentIndex].anchoredPosition;
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) < 0.01f)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
    }
}