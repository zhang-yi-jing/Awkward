using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject[] uiElements; // UI元素数组
    private int currentElementIndex; // 当前显示的UI元素索引

    private void Start()
    {
        // 初始化索引为第一个UI元素
        currentElementIndex = 0;
        UpdateUIVisibility();
    }

    private void Update()
    {
        // 检测是否按下了E键
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 隐藏当前UI元素
            uiElements[currentElementIndex].SetActive(false);

            // 增加索引
            currentElementIndex++;

            // 检查索引是否越界，如果是则销毁物体
            if (currentElementIndex >= uiElements.Length)
            {
                Destroy(gameObject);
                return;
            }

            // 激活下一个UI元素
            uiElements[currentElementIndex].SetActive(true);
        }
    }

    private void UpdateUIVisibility()
    {
        // 隐藏所有UI元素
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }
}