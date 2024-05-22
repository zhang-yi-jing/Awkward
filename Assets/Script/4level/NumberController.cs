using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public int number; // ������������
    public Button[] increaseButtons; // ���Ӱ�ť����
    public Button[] decreaseButtons; // ���ٰ�ť����

    private void Start()
    {
        // �����Ӱ�ť�ĵ���¼�
        for (int i = 0; i < increaseButtons.Length; i++)
        {
            int index = i; // ���浱ǰ��ť����
            increaseButtons[i].onClick.AddListener(() => IncreaseNumber(index));
        }

        // �󶨼��ٰ�ť�ĵ���¼�
        for (int i = 0; i < decreaseButtons.Length; i++)
        {
            int index = i; // ���浱ǰ��ť����
            decreaseButtons[i].onClick.AddListener(() => DecreaseNumber(index));
        }
    }

    private void IncreaseNumber(int buttonIndex)
    {
        number++; // ������ֵ
        Debug.Log("Number increased by button " + buttonIndex + ": " + number);
    }

    private void DecreaseNumber(int buttonIndex)
    {
        number--; // ������ֵ
        Debug.Log("Number decreased by button " + buttonIndex + ": " + number);
    }
}