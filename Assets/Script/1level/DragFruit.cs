using UnityEngine;
using UnityEngine.EventSystems;

public class DragFruit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTrans; // 物体的RectTransform组件，用于获取和修改物体的位置和尺寸
    private Vector2 originalPosition; // 物体的初始位置
    private CanvasGroup canvasGroup; // 物体的CanvasGroup组件，用于控制物体的交互性
    private RandomTween randomTween; // 物体上的RandomTween组件，用于随机动画效果

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTrans.anchoredPosition; // 记录初始位置
        randomTween = GetComponent<RandomTween>(); // 获取RandomTween组件
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // 禁用物体的射线阻挡，使其在拖拽过程中不会阻挡射线投射

        // 禁用 RandomTween 脚本
        if (randomTween != null)
        {
            randomTween.enabled = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta; // 根据拖拽的位移更新物体的位置
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // 启用物体的射线阻挡，使其可以再次接收射线投射

        // 如果拖拽结束时指针没有进入任何一个Slot对象，则将物体的位置重置为初始位置
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<des>() == null)
        {
            rectTrans.anchoredPosition = originalPosition;
        }

        // 在拖拽结束后重新启用 RandomTween 脚本
        if (randomTween != null)
        {
            randomTween.enabled = true;
        }
    }
}