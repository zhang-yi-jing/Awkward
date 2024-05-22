using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarFollow : MonoBehaviour
{
    public Transform target; // Ҫ�����2D����
    public RectTransform scrollbarHandle; // Scrollbar�Ļ���

    public RectTransform canvasRect; // Canvas��RectTransform���

    public float horizontalOffset = 0f; // ˮƽ����ƫ����
    public float verticalOffset = 0f; // ��ֱ����ƫ����

    private void Start()
    {
        // ��ȡCanvas��RectTransform���
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
            // ��2D�������������ת��Ϊ��Ļ����
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // ����Ļ����ת��ΪCanvas�ڵ�����
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            // ���ƫ����
            canvasPos.x += horizontalOffset;
            canvasPos.y += verticalOffset;

            // ����Scrollbar�Ļ���λ��
            scrollbarHandle.anchoredPosition = canvasPos;
        }
    }
}