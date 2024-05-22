using UnityEngine;
using UnityEngine.UI;

public class HorizontalVelocityDetector : MonoBehaviour
{
    public Rigidbody2D targetObject; // Ҫ����ٶȵ�����
    public Scrollbar scrollbar; // ���ƹ�����
    private float previousHorizontalPosition; // ��һ֡��ˮƽλ��
    private float lastUpdateTime; // �ϴθ��µ�ʱ��
    private float targetSize; // Ŀ���������С
    private float sizeChangeSpeed = 0.6f; // ��������С�仯���ٶ�
    private float decreaseSpeed = 0.3f; // ��������С��С���ٶ�

    private void Start()
    {
        // ��ʼ����һ֡��ˮƽλ��Ϊ����ĳ�ʼˮƽλ��
        previousHorizontalPosition = targetObject.position.x;
        lastUpdateTime = Time.time;

        // ��ʼ��Ŀ���������СΪ��ǰ��С
        targetSize = scrollbar.size;
    }

    private void Update()
    {
        // ���㵱ǰ֡��ˮƽ�ٶ�
        float currentHorizontalVelocity = (targetObject.position.x - previousHorizontalPosition) / (Time.time - lastUpdateTime);

        // ������һ֡��ˮƽλ�ú��ϴθ��µ�ʱ��
        previousHorizontalPosition = targetObject.position.x;
        lastUpdateTime = Time.time;

        // ÿ�����һ��ˮƽ�ٶ�
        if (Time.time % 1f < Time.deltaTime)
        {
            // ȡ��ˮƽ�ٶ�
            int roundedHorizontalVelocity = Mathf.RoundToInt(currentHorizontalVelocity);

            // ���ȡ�����ˮƽ�ٶ�
            Debug.Log("Rounded Horizontal Velocity: " + roundedHorizontalVelocity);

            // �����ٶȴ�С����Ŀ���������С
            if (Mathf.Abs(roundedHorizontalVelocity) >= 7)
            {
                targetSize += sizeChangeSpeed;
            }
            else
            {
                targetSize -= decreaseSpeed;
            }
        }

        // ƽ�������������Ĵ�С
        targetSize = Mathf.Clamp01(targetSize);
        scrollbar.size = Mathf.Lerp(scrollbar.size, targetSize, Time.deltaTime * sizeChangeSpeed);
    }
}