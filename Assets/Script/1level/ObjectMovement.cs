using UnityEngine;
using System;

public class ObjectMovement : MonoBehaviour
{
    public float delay = 8f; // 延迟时间（以秒为单位）
    public GameObject popo1; // 新增的GameObject

    public AudioSource audioSource1; // 第一个声音
    public AudioSource audioSource2; // 第二个声音

    public bool isMoving = false; // 是否正在移动
    private bool isPaused = false; // 是否暂停移动
    private float elapsedTime = 0f; // 已经过的时间
    private float initialY = - 2.3f ; // 初始 Y 坐标

    public int currentInterval = 0; // 当前时间区间索引
    public float[] startTimes; // 开始时间点
    public float[] speeds; // 移动速度
    public float endTimes;

    private void Start()
    {

        // 初始化数组
        Invoke("StartMovement", delay); // 延迟指定时间后开始移动
        Invoke("PlayAudioSource1", delay - 2.7f); // 延迟指定时间后播放第一个声音
        Invoke("ActivatePopo1", delay + 5f); // 延迟5秒后激活popo1
    }

    private void Update()
    {
        float time1 = elapsedTime;
        //time1 = Mathf.Round(time1 * 10f) / 10f;
        //Debug.Log("Current Time: " + time1);

        if (isMoving && !isPaused)
        {
            // 获取当前时间区间的移动速度和距离
            float speed = speeds[currentInterval];

            // 根据速度和已经过的时间计算当前位置
            float newY = initialY + speed * elapsedTime;

            // 更新物体的位置
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            elapsedTime += Time.deltaTime; // 更新已经过的时间
                                           
            time1 = Mathf.Round(elapsedTime * 10f) / 10f;
            //Debug.Log(time1);

            if (elapsedTime >= startTimes[currentInterval])
            {
                PauseMovement(); // 暂停移动
                initialY = initialY + speed * elapsedTime;
            }

            if (elapsedTime >= endTimes)
            {
                StopMovement(); // 暂停移动
            }
        }
    }

    private void ActivatePopo1()
    {
        popo1.SetActive(true); // 激活popo1
    }

    private void StartMovement()
    {
        isMoving = true; // 开始移动
    }

    private void PauseMovement()
    {
        isMoving = false; // 停止移动
        Debug.Log("isPaused");

        audioSource1.Pause(); // 暂停第一个声音
        audioSource2.Play(); // 激活第二个声音

        Invoke("ResumeMovement", 4.75f); // 延迟5秒后恢复移动
    }

    private void ResumeMovement()
    {
        isMoving = true; // 恢复移动

        audioSource2.Stop(); // 停止第二个声音
        audioSource1.UnPause(); // 恢复第一个声音

        currentInterval++; // 切换到下一个时间区间

        // 检查是否超出时间区间数量
       
            // 重置已经过的时间
        elapsedTime = 0f;
        
    }

    private void StopMovement()
    {
        isMoving = false; // 停止移动
    }

    private void PlayAudioSource1()
    {
        audioSource1.Play(); // 播放第一个声音
    }
}