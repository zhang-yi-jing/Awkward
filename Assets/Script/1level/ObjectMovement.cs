using UnityEngine;
using System;

public class ObjectMovement : MonoBehaviour
{
    public float delay = 8f; // �ӳ�ʱ�䣨����Ϊ��λ��
    public GameObject popo1; // ������GameObject

    public AudioSource audioSource1; // ��һ������
    public AudioSource audioSource2; // �ڶ�������

    public bool isMoving = false; // �Ƿ������ƶ�
    private bool isPaused = false; // �Ƿ���ͣ�ƶ�
    private float elapsedTime = 0f; // �Ѿ�����ʱ��
    private float initialY = - 2.3f ; // ��ʼ Y ����

    public int currentInterval = 0; // ��ǰʱ����������
    public float[] startTimes; // ��ʼʱ���
    public float[] speeds; // �ƶ��ٶ�
    public float endTimes;

    private void Start()
    {

        // ��ʼ������
        Invoke("StartMovement", delay); // �ӳ�ָ��ʱ���ʼ�ƶ�
        Invoke("PlayAudioSource1", delay - 2.7f); // �ӳ�ָ��ʱ��󲥷ŵ�һ������
        Invoke("ActivatePopo1", delay + 5f); // �ӳ�5��󼤻�popo1
    }

    private void Update()
    {
        float time1 = elapsedTime;
        //time1 = Mathf.Round(time1 * 10f) / 10f;
        //Debug.Log("Current Time: " + time1);

        if (isMoving && !isPaused)
        {
            // ��ȡ��ǰʱ��������ƶ��ٶȺ;���
            float speed = speeds[currentInterval];

            // �����ٶȺ��Ѿ�����ʱ����㵱ǰλ��
            float newY = initialY + speed * elapsedTime;

            // ���������λ��
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            elapsedTime += Time.deltaTime; // �����Ѿ�����ʱ��
                                           
            time1 = Mathf.Round(elapsedTime * 10f) / 10f;
            //Debug.Log(time1);

            if (elapsedTime >= startTimes[currentInterval])
            {
                PauseMovement(); // ��ͣ�ƶ�
                initialY = initialY + speed * elapsedTime;
            }

            if (elapsedTime >= endTimes)
            {
                StopMovement(); // ��ͣ�ƶ�
            }
        }
    }

    private void ActivatePopo1()
    {
        popo1.SetActive(true); // ����popo1
    }

    private void StartMovement()
    {
        isMoving = true; // ��ʼ�ƶ�
    }

    private void PauseMovement()
    {
        isMoving = false; // ֹͣ�ƶ�
        Debug.Log("isPaused");

        audioSource1.Pause(); // ��ͣ��һ������
        audioSource2.Play(); // ����ڶ�������

        Invoke("ResumeMovement", 4.75f); // �ӳ�5���ָ��ƶ�
    }

    private void ResumeMovement()
    {
        isMoving = true; // �ָ��ƶ�

        audioSource2.Stop(); // ֹͣ�ڶ�������
        audioSource1.UnPause(); // �ָ���һ������

        currentInterval++; // �л�����һ��ʱ������

        // ����Ƿ񳬳�ʱ����������
       
            // �����Ѿ�����ʱ��
        elapsedTime = 0f;
        
    }

    private void StopMovement()
    {
        isMoving = false; // ֹͣ�ƶ�
    }

    private void PlayAudioSource1()
    {
        audioSource1.Play(); // ���ŵ�һ������
    }
}