using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    public int closestUI;
    public Transform ui1Transform;
    public Transform ui2Transform;
    public Transform ui3Transform;
    public Transform ui4Transform;
    private ScrollbarManager scrollbarManager;

    public float UI1;
    public float UI2;
    public float UI3;
    public float UI4;
    public GameObject uiToActivate1; // Ҫ����� UI1 ��Ϸ����
    public GameObject uiToActivate2; // Ҫ����� UI2 ��Ϸ����
    public GameObject uiToActivate3; // Ҫ����� UI3 ��Ϸ����
    public GameObject uiToActivate4; // Ҫ����� UI4 ��Ϸ����
    public List<GameObject> uiToDeactivate = new List<GameObject>(); // Ҫ���õ� UI ��Ϸ�����б�
    public List<GameObject> ToActivate = new List<GameObject>();
    public float ActivateTime = 2f; // �ӳټ���ʱ��

    private void Start()
    {
        popoDrag.OnMoveCompleted += HandleMoveCompleted;
        // �ڿ�ʼʱ����ScrollbarManager�ű����ڵ���Ϸ����
        scrollbarManager = FindObjectOfType<ScrollbarManager>();

        if (scrollbarManager == null)
        {
            Debug.LogError("Cannot find ScrollbarManager component.");
        }
    }

    private void OnDisable()
    {
        popoDrag.OnMoveCompleted -= HandleMoveCompleted;
    }

    private void HandleMoveCompleted()
    {
        //Debug.Log("Move completed!");
        float distanceToUI1 = Vector2.Distance(transform.position, ui1Transform.position);
        float distanceToUI2 = Vector2.Distance(transform.position, ui2Transform.position);
        float distanceToUI3 = Vector2.Distance(transform.position, ui3Transform.position);
        float distanceToUI4 = Vector2.Distance(transform.position, ui4Transform.position);

        // �ҵ���С�����Ӧ�� UI ����
        closestUI = 1;
        float minDistance = distanceToUI1;

        if (distanceToUI2 < minDistance)
        {
            closestUI = 2;
            minDistance = distanceToUI2;
        }

        if (distanceToUI3 < minDistance)
        {
            closestUI = 3;
            minDistance = distanceToUI3;
        }

        if (distanceToUI4 < minDistance)
        {
            closestUI = 4;
        }
        //Debug.Log(closestUI);
        switch (closestUI)
        {
            case 1:
                scrollbarManager.scrollbarValue += UI1;// �� X ���� 1 ʱִ�еĲ���
                // TODO: ������ X ���� 1 ���߼�
                break;
            case 2:
                scrollbarManager.scrollbarValue += UI2;// �� X ���� 2 ʱִ�еĲ���
                // TODO: ������ X ���� 2 ���߼�
                break;
            case 3:
                scrollbarManager.scrollbarValue += UI3;// �� X ���� 3 ʱִ�еĲ���
                // TODO: ������ X ���� 3 ���߼�
                break;
            case 4:
                scrollbarManager.scrollbarValue += UI4;// �� X ������ 1��2 �� 3 ʱִ�еĲ���
                // TODO: ��Ӷ�������������߼�
                break;
        }
        if (closestUI == 1)
        {
            uiToActivate1.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
                StartCoroutine(ActivateUI(ToActivate));
            }

        }
        else if (closestUI == 2)
        {
            uiToActivate2.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
                StartCoroutine(ActivateUI(ToActivate));
            }
        }
        else if (closestUI == 3)
        {
            uiToActivate3.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
                StartCoroutine(ActivateUI(ToActivate));
            }
        }
        else if (closestUI == 4)
        {
            uiToActivate4.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
                StartCoroutine(ActivateUI(ToActivate));
            }
        }
    }
public IEnumerator ActivateUI(List<GameObject> uiToActivate)
    {
        yield return new WaitForSeconds(ActivateTime);

        // ���� uiToActivate �б��е����� GameObject
        foreach (GameObject ui in uiToActivate)
        {
            // ��ÿ�� GameObject ����Ϊ����״̬
            ui.SetActive(true);
        }
    }
}
