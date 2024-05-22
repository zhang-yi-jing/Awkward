using UnityEngine;
using UnityEngine.UI;

public class ScrollbarManager : MonoBehaviour
{
    public static ScrollbarManager Instance { get; private set; }
    public Scrollbar scrollbar;
    private des slotScript;
    public float scrollbarValue;

   
    private void Start()
    {
        // ��ȡ Slot �ű���ʵ��
        slotScript = FindObjectOfType<des>();

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
            scrollbar.size = scrollbarValue;

        }
    }
}