using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class Slot : MonoBehaviour, IDropHandler
{
    public int closestUI; // �������������ڱ�������� UI ֵ
    public float delayTime; // �ӳ�ʱ��

    public RectTransform ui1Transform; // UI1 �� RectTransform ���
    public RectTransform ui2Transform; // UI2 �� RectTransform ���
    public RectTransform ui3Transform; // UI3 �� RectTransform ���
    public RectTransform ui4Transform; // UI4 �� RectTransform ���

    public float UI1;
    public float UI2;
    public float UI3;
    public float UI4;

    public GameObject uiToActivate1; // Ҫ����� UI1 ��Ϸ����
    public GameObject uiToActivate2; // Ҫ����� UI2 ��Ϸ����
    public GameObject uiToActivate3; // Ҫ����� UI3 ��Ϸ����
    public GameObject uiToActivate4; // Ҫ����� UI4 ��Ϸ����
    public List<GameObject> uiToDeactivate = new List<GameObject>(); // Ҫ���õ� UI ��Ϸ�����б�
    public List<GameObject> uiToActivate = new List<GameObject>();
    private ScrollbarManager scrollbarManager;

    private void Start()
    {
        // �ڿ�ʼʱ����ScrollbarManager�ű����ڵ���Ϸ����
        scrollbarManager = FindObjectOfType<ScrollbarManager>();

        if (scrollbarManager == null)
        {
            Debug.LogError("Cannot find ScrollbarManager component.");
        }
        scrollbarManager.scrollbarValue = 0.2f;

    }
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform draggedUI = eventData.pointerDrag.GetComponent<RectTransform>();
        draggedUI.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        FindClosestUI(draggedUI);

        UpdateUIVisibility(closestUI);
        StartCoroutine(DelayedActivation(delayTime, uiToActivate)); 
        MoveUp(500f);

    }

    private void FindClosestUI(RectTransform draggedUI)
    {
        float minDistance = float.MaxValue;
        int closestUIIndex = 0;


        // �����϶��� UI ��ÿ�� UI �ľ��룬���ҵ������ UI
        float distanceToUI1 = Vector2.Distance(draggedUI.anchoredPosition, ui1Transform.anchoredPosition);
        if (distanceToUI1 < minDistance)
        {
            minDistance = distanceToUI1;
            closestUIIndex = 1;
        }

        float distanceToUI2 = Vector2.Distance(draggedUI.anchoredPosition, ui2Transform.anchoredPosition);
        if (distanceToUI2 < minDistance)
        {
            minDistance = distanceToUI2;
            closestUIIndex = 2;
        }

        float distanceToUI3 = Vector2.Distance(draggedUI.anchoredPosition, ui3Transform.anchoredPosition);
        if (distanceToUI3 < minDistance)
        {
            minDistance = distanceToUI3;
            closestUIIndex = 3;
            
        }

        float distanceToUI4 = Vector2.Distance(draggedUI.anchoredPosition, ui4Transform.anchoredPosition);
        if (distanceToUI4 < minDistance)
        {
            minDistance = distanceToUI4;
            closestUIIndex = 4;
        }

        closestUI = closestUIIndex; // ������� UI ֵ������������
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
        ///Debug.Log(scrollbarValue);
    }

    private IEnumerator DelayedActivation(float delayTime, List<GameObject> uiToActivate)
    {
        yield return new WaitForSeconds(delayTime);

        // ���ӳٽ�����ִ�м������
        foreach (GameObject ui in uiToActivate)
        {
            ui.SetActive(true);
        }
    }
    private void UpdateUIVisibility(int closestUIIndex)
    {
        // ���� closestUIIndex ��ֵ��������ָ���� UI ��Ϸ����
        if (closestUIIndex == 1)
        {
            uiToActivate1.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
            }

        }
        else if (closestUIIndex == 2)
        {
            uiToActivate2.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
            }
        }
        else if (closestUIIndex == 3)
        {
            uiToActivate3.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
            }
        }
        else if (closestUIIndex == 4)
        {
            uiToActivate4.SetActive(true);
            foreach (GameObject ui in uiToDeactivate)
            {
                ui.SetActive(false);
            }
        }
    }

    void MoveUp(float distance)
    {
        // ��ȡ����ĵ�ǰλ��
        Vector3 currentPosition = transform.position;

        // ����Ŀ��λ��
        Vector3 targetPosition = currentPosition + new Vector3(0f, distance, 0f);

        // �����������λ��
        transform.position = targetPosition;
    }
}