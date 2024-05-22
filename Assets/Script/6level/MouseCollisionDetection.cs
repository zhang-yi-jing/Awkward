using UnityEngine;

public class MouseCollisionDetection : MonoBehaviour
{
    public Collider2D[] targetColliders; // Ŀ����ײ������
    public Camera mainCamera; // �������
    public GameObject activationObject1; // ���������1
    public GameObject activationObject2; // ���������2
    public AudioSource audioSource; // ����Դ
    public AudioClip audioclip;

    private bool isMousePressed; // ����Ƿ���
    private bool wasMouseWithinCollider; // ��һ֡����Ƿ��ڷ�Χ��

    private void Start()
    {
        mainCamera = Camera.main;
        activationObject1.SetActive(false); // ��������1
        activationObject2.SetActive(false); // ��������2
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
            audioSource.Stop(); // ֹͣ��������
            activationObject1.SetActive(false); // ��������1
            activationObject2.SetActive(false); // ��������2
            wasMouseWithinCollider = false;
        }

        if (isMousePressed)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            bool isMouseWithinCollider = false;

            foreach (Collider2D targetCollider in targetColliders)
            {
                if (targetCollider.OverlapPoint(mousePosition2D))
                {
                    isMouseWithinCollider = true;
                    //ebug.Log("Mouse is within the collider range: " + targetCollider.name);

                    if (!wasMouseWithinCollider)
                    {
                        audioSource.clip = audioclip;
                        audioSource.Play(); // ��������
                    }

                    if (targetCollider.name == "Trigger1")
                    {
                        activationObject1.SetActive(true); // ��������1
                    }
                    else if (targetCollider.name == "Trigger2")
                    {
                        activationObject2.SetActive(true); // ��������2
                    }
                }
            }

            if (!isMouseWithinCollider)
            {
                audioSource.Stop(); // ֹͣ��������
                activationObject1.SetActive(false); // ��������1
                activationObject2.SetActive(false); // ��������2
            }

            wasMouseWithinCollider = isMouseWithinCollider;
        }
    }
}