using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject[] uiElements; // UIԪ������
    private int currentElementIndex; // ��ǰ��ʾ��UIԪ������

    private void Start()
    {
        // ��ʼ������Ϊ��һ��UIԪ��
        currentElementIndex = 0;
        UpdateUIVisibility();
    }

    private void Update()
    {
        // ����Ƿ�����E��
        if (Input.GetKeyDown(KeyCode.E))
        {
            // ���ص�ǰUIԪ��
            uiElements[currentElementIndex].SetActive(false);

            // ��������
            currentElementIndex++;

            // ��������Ƿ�Խ�磬���������������
            if (currentElementIndex >= uiElements.Length)
            {
                Destroy(gameObject);
                return;
            }

            // ������һ��UIԪ��
            uiElements[currentElementIndex].SetActive(true);
        }
    }

    private void UpdateUIVisibility()
    {
        // ��������UIԪ��
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }
}