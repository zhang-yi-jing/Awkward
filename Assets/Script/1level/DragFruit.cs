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

        // ���� RandomTween �ű�
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
            // ���û�д��� OnDrop �¼����� UI �ص�ԭ����λ��
            rectTrans.anchoredPosition = originalPosition;
        }

        // ����ק�������������� RandomTween �ű�
        if (randomTween != null)
        {
            randomTween.enabled = true;
        }
    }
}