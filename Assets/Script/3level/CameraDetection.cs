using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public GameObject playerObject; // Ҫʶ����ض�����

    private Camera mainCamera; // �������������
    public Transform[] targetPositions; // �ض�λ�õ�Transform�������
    public Collider2D[] targetRangeColliders; // �ض���Χ����ײ��

    public float smoothSpeed = 0.5f; // ƽ���ƶ����ٶ�

    private Vector3 targetPosition; // Ŀ���ƶ�λ��

    private void Start()
    {
        mainCamera = Camera.main; // ��ȡ�������������
    }

    private void Update()
    {
        bool isPlayerInTargetRange = false;
        int targetRangeIndex = -1;

        // ���������ض���Χ����ײ��
        for (int i = 0; i < targetRangeColliders.Length; i++)
        {
            Collider2D collider = targetRangeColliders[i];

            // ����ض������Ƿ����ض���Χ����ײ���ص�
            if (collider.OverlapPoint(playerObject.transform.position))
            {
                isPlayerInTargetRange = true;
                targetRangeIndex = i;
                break;
            }
        }

        // ���ݼ����ִ����Ӧ����
        if (isPlayerInTargetRange)
        {
            //Debug.Log("Player object is in target range " + targetRangeIndex);

            // ��ȡĿ��λ��
            if (targetRangeIndex >= 0 && targetRangeIndex < targetPositions.Length)
            {
                targetPosition = targetPositions[targetRangeIndex].position;
            }
        }
        else
        {
            //Debug.Log("Player object is not in any target range");
        }

        // ƽ���ƶ��������Ŀ��λ��
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        mainCamera.transform.position = smoothedPosition;
    }
}