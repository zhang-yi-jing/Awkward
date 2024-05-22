using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public int number; // 公共整数变量
    public Button[] increaseButtons; // 增加按钮数组
    public Button[] decreaseButtons; // 减少按钮数组

    private void Start()
    {
        // 绑定增加按钮的点击事件
        for (int i = 0; i < increaseButtons.Length; i++)
        {
            int index = i; // 保存当前按钮索引
            increaseButtons[i].onClick.AddListener(() => IncreaseNumber(index));
        }

        // 绑定减少按钮的点击事件
        for (int i = 0; i < decreaseButtons.Length; i++)
        {
            int index = i; // 保存当前按钮索引
            decreaseButtons[i].onClick.AddListener(() => DecreaseNumber(index));
        }
    }

    private void IncreaseNumber(int buttonIndex)
    {
        number++; // 增加数值
        Debug.Log("Number increased by button " + buttonIndex + ": " + number);
    }

    private void DecreaseNumber(int buttonIndex)
    {
        number--; // 减少数值
        Debug.Log("Number decreased by button " + buttonIndex + ": " + number);
    }
}