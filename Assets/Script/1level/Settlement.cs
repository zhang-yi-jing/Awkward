using UnityEngine;
using UnityEngine.SceneManagement;

public class Settlement : MonoBehaviour
{
    public string Scene1; // 要加载的场景名称
    public string Scene2; // 要加载的场景名称
    public string Scene3; // 要加载的场景名称
    private ScrollbarManager scrollbarManager;

    private void Start()
    {
        // 在开始时查找ScrollbarManager脚本所在的游戏对象
        scrollbarManager = FindObjectOfType<ScrollbarManager>();
    }

        public void LoadScene()
    {
        float scrollbarValue = scrollbarManager.scrollbarValue;

        if (scrollbarValue >= 0f && scrollbarValue < 0.4f)
        {
            SceneManager.LoadScene(Scene1);
        }
        else if (scrollbarValue >= 0.4f && scrollbarValue < 0.8f)
        {
            SceneManager.LoadScene(Scene2);
        }
        else if (scrollbarValue >= 0.8f && scrollbarValue <= 1f)
        {
            SceneManager.LoadScene(Scene3);
        }
    }
}