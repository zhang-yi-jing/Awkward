using UnityEngine;
using UnityEngine.SceneManagement;
using RenderHeads.Media.AVProVideo;

public class interlude : MonoBehaviour
{
    private MediaPlayer mediaPlayer;

    public string nextSceneName; // 下一个场景的名称

    private void Start()
    {
        // 获取 AVPro 组件的 MediaPlayer 实例
        mediaPlayer = GetComponent<MediaPlayer>();

        // 添加播放完成事件监听器
        mediaPlayer.Events.AddListener(OnMediaPlayerEvent);
    }

    private void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType eventType, ErrorCode errorCode)
    {
        if (eventType == MediaPlayerEvent.EventType.FinishedPlaying)
        {
            // 在播放完成时切换到下一个场景
            SwitchToNextScene();
        }
    }

    private void SwitchToNextScene()
    {
        // 切换到下一个场景
        SceneManager.LoadScene(nextSceneName);
    }

    // 公共方法，用于手动触发切换场景的操作
    public void ManualSwitchToNextScene()
    {
        SwitchToNextScene();
    }
}