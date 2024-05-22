using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarFollow : MonoBehaviour
{
    public Transform target; // 要跟随的2D物体
    public RectTransform scrollbarHandle; // Scrollbar的滑块

    public RectTransform canvasRect; // Canvas的RectTransform组件

    public float horizontalOffset = 0f; // 水平距离偏移量
    public float verticalOffset = 0f; // 竖直距离偏移量

    private void Start()
    {
        // 获取Canvas的RectTransform组件
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRect = canvas.GetComponent<RectTransform>();
        }
    }

    private void Update()
    {
        if (target != null && scrollbarHandle != null && canvasRect != null)
        {
            // 将2D物体的世界坐标转换为屏幕坐标
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // 将屏幕坐标转换为Canvas内的坐标
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            // 添加偏移量
            canvasPos.x += horizontalOffset;
            canvasPos.y += verticalOffset;

            // 设置Scrollbar的滑块位置
            scrollbarHandle.anchoredPosition = canvasPos;
        }
    }
}