using UnityEngine;

public class Gymnastics : MonoBehaviour
{
    public GameObject uiElement1; // UIԪ��1
    public GameObject uiElement2; // UIԪ��2
    public GameObject uiElement3; // UIԪ��3
    public GameObject uiElement4; // UIԪ��4
    public GameObject uiElement5; // UIԪ��5

    private bool inputDisabled; // �������״̬
    private float disableTime; // ���ÿ�ʼʱ��

    private void Start()
    {
        // ��ʼ��״̬
        uiElement1.SetActive(true);
        uiElement2.SetActive(false);
        uiElement3.SetActive(false);
        uiElement4.SetActive(false);
        uiElement5.SetActive(false);
        inputDisabled = false;
    }

    private void Update()
    {
        // ����Ƿ�����W��
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!inputDisabled)
            {
                // ����UIԪ��1������UIԪ��2������UIԪ��3
                uiElement1.SetActive(false);
                uiElement2.SetActive(true);
                DisableInput();
            }
        }

        // ����Ƿ�����S��
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!inputDisabled)
            {
                // ����UIԪ��1������UIԪ��3������UIԪ��2
                uiElement1.SetActive(false);
                uiElement3.SetActive(true);
                DisableInput();
            }
        }

        // ����Ƿ�����A��
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!inputDisabled)
            {
                // ����UIԪ��4������UIԪ��5
                uiElement4.SetActive(true);
                uiElement1.SetActive(false);
                DisableInput();
            }
        }

        // ����Ƿ�����D��
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!inputDisabled)
            {
                // ����UIԪ��5������UIԪ��4
                uiElement1.SetActive(false);
                uiElement5.SetActive(true);
                DisableInput();
            }
        }

        // ����������״̬�Ƿ����
        if (inputDisabled && Time.timeSinceLevelLoad >= disableTime + 1f)
        {
            EnableInput();
            uiElement1.SetActive(true);
            uiElement2.SetActive(false);
            uiElement3.SetActive(false);
            uiElement4.SetActive(false);
            uiElement5.SetActive(false);
        }
    }

    private void DisableInput()
    {
        inputDisabled = true;
        disableTime = Time.timeSinceLevelLoad;
    }

    private void EnableInput()
    {
        inputDisabled = false;
    }
}