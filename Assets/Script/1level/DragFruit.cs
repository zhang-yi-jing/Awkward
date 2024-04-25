using UnityEngine;
using UnityEngine.EventSystems;

public class DragFruit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTrans;
    private Vector2 originalPosition;
    private CanvasGroup canvasGroup;
    private RandomTween randomTween;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTrans.anchoredPosition;
        randomTween = GetComponent<RandomTween>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        // 禁用 RandomTween 脚本
        if (randomTween != null)
        {
            randomTween.enabled = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<Slot>() == null)
        {
            // 如果没有触发 OnDrop 事件，则将 UI 回到原来的位置
            rectTrans.anchoredPosition = originalPosition;
        }

        // 在拖拽结束后重新启用 RandomTween 脚本
        if (randomTween != null)
        {
            randomTween.enabled = true;
        }
    }
}