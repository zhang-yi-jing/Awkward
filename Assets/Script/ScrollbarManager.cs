using UnityEngine;
using UnityEngine.UI;

public class ScrollbarManager : MonoBehaviour
{
    public Scrollbar scrollbar;
    private Slot slotScript;

    private void Start()
    {
        // ��ȡ Slot �ű���ʵ��
        slotScript = FindObjectOfType<Slot>();

        // ����Ƿ��ҵ��� Slot �ű���ʵ��
        if (slotScript == null)
        {
            Debug.LogError("Slot script not found!");
        }
    }

    private void Update()
    {
        // ����Ƿ��ҵ��� Slot �ű���ʵ���� Scrollbar ���
        if (slotScript != null && scrollbar != null)
        {
            // ���ý������Ĵ�СΪ slotScript �е� scrollbarValue ֵ
            scrollbar.size = slotScript.scrollbarValue;

        }
    }
}