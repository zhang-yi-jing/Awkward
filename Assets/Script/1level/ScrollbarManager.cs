using UnityEngine;
using UnityEngine.UI;

public class ScrollbarManager : MonoBehaviour
{
    public static ScrollbarManager Instance { get; private set; }
    public Scrollbar scrollbar;
    private Slot slotScript;
    public float scrollbarValue;

   
    private void Start()
    {
        // 获取 Slot 脚本的实例
        slotScript = FindObjectOfType<Slot>();

        // 检查是否找到了 Slot 脚本的实例
        if (slotScript == null)
        {
            Debug.LogError("Slot script not found!");
        }
    }

    private void Update()
    {
        // 检查是否找到了 Slot 脚本的实例和 Scrollbar 组件
        if (slotScript != null && scrollbar != null)
        {
            // 设置进度条的大小为 slotScript 中的 scrollbarValue 值
            scrollbar.size = scrollbarValue;

        }
    }
}