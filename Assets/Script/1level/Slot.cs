using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class Slot : MonoBehaviour, IDropHandler
{
    public int closestUI; // 公共变量，用于保存最近的 UI 值
    public float delayTime; // 延迟时间

    public RectTransform ui1Transform; // UI1 的 RectTransform 组件
    public RectTransform ui2Transform; // UI2 的 RectTransform 组件
    public RectTransform ui3Transform; // UI3 的 RectTransform 组件
    public RectTransform ui4Transform; // UI4 的 RectTransform 组件

    public float UI1;
    public float UI2;
    public float UI3;
    public float UI4;

    public GameObject uiToActivate1; // 要激活的 UI1 游戏对象
    public GameObject uiToActivate2; // 要激活的 UI2 游戏对象
    public GameObject uiToActivate3; // 要激活的 UI3 游戏对象
    public GameObject uiToActivate4; // 要激活的 UI4 游戏对象
    public List<GameObject> uiToDeactivate = new List<GameObject>(); // 要禁用的 UI 游戏对象列表
    public List<GameObject> uiToActivate = new List<GameObject>();
    private ScrollbarManager scrollbarManager;

    private void Start()
    {
        // 在开始时查找ScrollbarManager脚本所在的游戏对象
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


        // 计算拖动的 UI 与每个 UI 的距离，并找到最近的 UI
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

        closestUI = closestUIIndex; // 将最近的 UI 值赋给公共变量
        switch (closestUI)
        {
            case 1:
                scrollbarManager.scrollbarValue += UI1;// 当 X 等于 1 时执行的操作
                // TODO: 添加针对 X 等于 1 的逻辑
                break;
            case 2:
                scrollbarManager.scrollbarValue += UI2;// 当 X 等于 2 时执行的操作
                // TODO: 添加针对 X 等于 2 的逻辑
                break;
            case 3:
                scrollbarManager.scrollbarValue += UI3;// 当 X 等于 3 时执行的操作
                // TODO: 添加针对 X 等于 3 的逻辑
                break;
            case 4:
                scrollbarManager.scrollbarValue += UI4;// 当 X 不等于 1、2 或 3 时执行的操作
                // TODO: 添加对于其他情况的逻辑
                break;
        }
        ///Debug.Log(scrollbarValue);
    }

    private IEnumerator DelayedActivation(float delayTime, List<GameObject> uiToActivate)
    {
        yield return new WaitForSeconds(delayTime);

        // 在延迟结束后执行激活操作
        foreach (GameObject ui in uiToActivate)
        {
            ui.SetActive(true);
        }
    }
    private void UpdateUIVisibility(int closestUIIndex)
    {
        // 根据 closestUIIndex 的值激活或禁用指定的 UI 游戏对象
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
        // 获取物体的当前位置
        Vector3 currentPosition = transform.position;

        // 计算目标位置
        Vector3 targetPosition = currentPosition + new Vector3(0f, distance, 0f);

        // 设置物体的新位置
        transform.position = targetPosition;
    }
}