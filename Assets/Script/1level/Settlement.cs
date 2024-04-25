using UnityEngine;
using UnityEngine.SceneManagement;

public class Settlement : MonoBehaviour
{
    public string Scene1; // Ҫ���صĳ�������
    public string Scene2; // Ҫ���صĳ�������
    public string Scene3; // Ҫ���صĳ�������
    private ScrollbarManager scrollbarManager;

    private void Start()
    {
        // �ڿ�ʼʱ����ScrollbarManager�ű����ڵ���Ϸ����
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