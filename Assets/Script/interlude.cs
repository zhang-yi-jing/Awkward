using UnityEngine;
using UnityEngine.SceneManagement;
using RenderHeads.Media.AVProVideo;

public class interlude : MonoBehaviour
{
    private MediaPlayer mediaPlayer;

    public string nextSceneName; // ��һ������������

    private void Start()
    {
        // ��ȡ AVPro ����� MediaPlayer ʵ��
        mediaPlayer = GetComponent<MediaPlayer>();

        // ��Ӳ�������¼�������
        mediaPlayer.Events.AddListener(OnMediaPlayerEvent);
    }

    private void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType eventType, ErrorCode errorCode)
    {
        if (eventType == MediaPlayerEvent.EventType.FinishedPlaying)
        {
            // �ڲ������ʱ�л�����һ������
            SwitchToNextScene();
        }
    }

    private void SwitchToNextScene()
    {
        // �л�����һ������
        SceneManager.LoadScene(nextSceneName);
    }

    // ���������������ֶ������л������Ĳ���
    public void ManualSwitchToNextScene()
    {
        SwitchToNextScene();
    }
}