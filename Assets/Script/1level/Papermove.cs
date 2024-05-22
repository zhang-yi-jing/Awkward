using UnityEngine;

public class Papermove : MonoBehaviour
{
    public float delay = 2f; // �ӳ�ʱ�䣨����Ϊ��λ��
    public float speed = 1f; // �ƶ��ٶȣ�ÿ���ƶ��ľ��룩
    public float distance = 5f; // �ƶ��ľ���

    private bool isMoving = false; // �Ƿ������ƶ�
    private float elapsedTime = 0f; // �Ѿ�����ʱ��
    private float initialY; // ��ʼ Y ����

    private void Start()
    {
        Invoke("StartMovement", delay); // �ӳ�ָ��ʱ���ʼ�ƶ�
    }

    private void Update()
    {
        if (isMoving)
        {
            // �����ٶȺ��Ѿ�����ʱ����㵱ǰλ��
            float newY = initialY + speed * elapsedTime;

            // ʹ�ò�ֵƽ���ƶ�����
            float t = Mathf.Clamp01(elapsedTime / (distance / speed));
            float smoothStep = Mathf.SmoothStep(0f, 1f, t);
            newY = Mathf.Lerp(initialY, initialY + distance, smoothStep);

            // ���������λ��
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            elapsedTime += Time.deltaTime; // �����Ѿ�����ʱ��

            // �ж��Ƿ�ﵽĿ��λ��
            if (newY >= initialY + distance)
            {
                StopMovement(); // ֹͣ�ƶ�
            }
        }
    }

    private void StartMovement()
    {
        isMoving = true; // ��ʼ�ƶ�
        initialY = transform.position.y; // ��¼��ʼ Y ����
    }

    private void StopMovement()
    {
        isMoving = false; // ֹͣ�ƶ�
    }
}