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
    public GameObject uiToActivate1; // 要激活的 UI1 游戏对象
    public GameObject uiToActivate2; // 要激活的 UI2 游戏对象
    public GameObject uiToActivate3; // 要激活的 UI3 游戏对象
    public GameObject uiToActivate4; // 要激活的 UI4 游戏对象
    public List<GameObject> uiToDeactivate = new List<GameObject>(); // 要禁用的 UI 游戏对象列表
    public List<GameObject> ToActivate = new List<GameObject>();
    public float ActivateTime = 2f; // 延迟激活时间

    private void Start()
    {
        popoDrag.OnMoveCompleted += HandleMoveCompleted;
        // 在开始时查找ScrollbarManager脚本所在的游戏对象
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

        // 找到最小距离对应的 UI 索引
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

        // 遍历 uiToActivate 列表中的所有 GameObject
        foreach (GameObject ui in uiToActivate)
        {
            // 将每个 GameObject 设置为激活状态
            ui.SetActive(true);
        }
    }
}
