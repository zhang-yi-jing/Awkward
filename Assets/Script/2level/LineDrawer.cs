using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public Transform line; // �����е���������
    public Transform startPoint; // ��ʼ��
    public Transform endPoint; // ��ֹ��

    private void Start()
    {
        // ��ʼ������λ�úͽǶ�
        UpdateLine();
    }

    private void Update()
    {
        // ʵʱ��������λ�úͽǶ�
        UpdateLine();
    }

    private void UpdateLine()
    {
        // �����е�λ��
        Vector3 midPoint = (startPoint.position + endPoint.position) / 2f;

        // ������������ʼ�����ֹ��Ϊ�е�λ��
        line.position = midPoint;
        line.LookAt(endPoint.position);

        // ���������ĳ���
        float distance = Vector3.Distance(startPoint.position, endPoint.position);
        line.localScale = new Vector3(distance, 0.4f, 1f);

        // ���������ĽǶ�
        float angle = Mathf.Atan2(endPoint.position.y - startPoint.position.y, endPoint.position.x - startPoint.position.x) * Mathf.Rad2Deg;
        line.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}