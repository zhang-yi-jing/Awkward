using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject[] uiElements; // UIԪ������
    public DialogBox dialogBox; // DialogBox�ű�������

    private bool isPaused = false; // ��Ϸ�Ƿ���ͣ

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPaused = !isPaused; // �л���Ϸ��ͣ״̬

            if (isPaused)
            {
                Time.timeScale = 0f; // ��ͣ��Ϸʱ��
                ActivateUI(); // ����UIԪ��
            }
            else
            {
                Time.timeScale = 1f; // �ָ���Ϸʱ��
                DeactivateUI(); // ����UIԪ��
            }
        }
    }

    private void ActivateUI()
    {
        int currentDialogIndex = dialogBox.currentDialogIndex; // ��ȡDialogBox�еĵ�ǰ�Ի�����

        if (currentDialogIndex < uiElements.Length)
        {
            uiElements[currentDialogIndex].SetActive(true); // ������Ӧ��UIԪ��
        }
    }

    private void DeactivateUI()
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false); // ��������UIԪ��
        }
    }
}