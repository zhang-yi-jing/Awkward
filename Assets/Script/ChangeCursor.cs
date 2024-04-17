using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D cursorTextureNormal;  // ����״̬�µ����ָ��ͼ��
    public Texture2D cursorTexturePressed; // ������������ָ��ͼ��

    private void Start()
    {
        // ���ó�ʼ���ָ��ͼ��Ϊ����״̬�µ�ͼ��
        Cursor.SetCursor(cursorTextureNormal, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        // �����갴���¼�
        if (Input.GetMouseButtonDown(0))
        {
            // �л����ָ��ͼ��Ϊ���������ͼ��
            Cursor.SetCursor(cursorTexturePressed, Vector2.zero, CursorMode.Auto);

            // ��ȡ���λ��
            Vector2 mousePosition = Input.mousePosition;

            // �������д��ϣ��ִ�еĴ��룬����ʹ�����λ�ý����жϻ����
        }
        // ������̧���¼�
        else if (Input.GetMouseButtonUp(0))
        {
            // �л����ָ��ͼ��Ϊ����״̬�µ�ͼ��
            Cursor.SetCursor(cursorTextureNormal, Vector2.zero, CursorMode.Auto);
        }
    }
}