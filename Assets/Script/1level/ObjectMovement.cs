using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ObjectMovement : MonoBehaviour
{
    public float delay = 2f; // �ӳ�ʱ�䣨����Ϊ��λ��
    public float speed = 1f; // �ƶ��ٶȣ�ÿ���ƶ��ľ��룩
    public float distance = 5f; // �ƶ��ľ���

    private bool isMoving = false; // �Ƿ������ƶ�
    private float elapsedTime = 0f; // �Ѿ�����ʱ��
    public float initialY; // ��ʼ Y ����

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
    }

    private void StopMovement()
    {
        isMoving = false; // ֹͣ�ƶ�
    }
}