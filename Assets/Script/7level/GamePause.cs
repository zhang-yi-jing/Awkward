using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject[] uiElements; // UI元素数组
    public DialogBox dialogBox; // DialogBox脚本的引用

    private bool isPaused = false; // 游戏是否暂停

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPaused = !isPaused; // 切换游戏暂停状态

            if (isPaused)
            {
                Time.timeScale = 0f; // 暂停游戏时间
                ActivateUI(); // 激活UI元素
            }
            else
            {
                Time.timeScale = 1f; // 恢复游戏时间
                DeactivateUI(); // 禁用UI元素
            }
        }
    }

    private void ActivateUI()
    {
        int currentDialogIndex = dialogBox.currentDialogIndex; // 获取DialogBox中的当前对话索引

        if (currentDialogIndex < uiElements.Length)
        {
            uiElements[currentDialogIndex].SetActive(true); // 激活相应的UI元素
        }
    }

    private void DeactivateUI()
    {
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false); // 禁用所有UI元素
        }
    }
}