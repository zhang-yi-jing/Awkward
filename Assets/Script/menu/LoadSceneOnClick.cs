using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName; // Ҫ���صĳ�������

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}