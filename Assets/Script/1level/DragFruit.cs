using UnityEngine;
using UnityEngine.EventSystems;

public class DragFruit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTrans; // �����RectTransform��������ڻ�ȡ���޸������λ�úͳߴ�
    private Vector2 originalPosition; // ����ĳ�ʼλ��
    private CanvasGroup canvasGroup; // �����CanvasGroup��������ڿ�������Ľ�����
    private RandomTween randomTween; // �����ϵ�RandomTween����������������Ч��

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTrans.anchoredPosition; // ��¼��ʼλ��
        randomTween = GetComponent<RandomTween>(); // ��ȡRandomTween���
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // ��������������赲��ʹ������ק�����в����赲����Ͷ��

        // ���� RandomTween �ű�
        if (randomTween != null)
        {
            randomTween.enabled = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta; // ������ק��λ�Ƹ��������λ��
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // ��������������赲��ʹ������ٴν�������Ͷ��

        // �����ק����ʱָ��û�н����κ�һ��Slot�����������λ������Ϊ��ʼλ��
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<des>() == null)
        {
            rectTrans.anchoredPosition = originalPosition;
        }

        // ����ק�������������� RandomTween �ű�
        if (randomTween != null)
        {
            randomTween.enabled = true;
        }
    }
}