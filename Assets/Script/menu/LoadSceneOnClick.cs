using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName; // 要加载的场景名称

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}