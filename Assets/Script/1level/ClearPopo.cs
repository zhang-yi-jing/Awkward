using System.Collections.Generic;
using UnityEngine;

public class ClearPopo : MonoBehaviour
{
    public ObjectMovement objectMovementScript;
    public GameObject[] popo;
    private ScrollbarManager scrollbarManager;
    public des desScript;
    public List<GameObject> ToActivate = new List<GameObject>();
    public List<GameObject> uiToDeactivate = new List<GameObject>(); // 要禁用的 UI 游戏对象列表

    private bool wasMoving = false;

    private void Start()
    {
        scrollbarManager = FindObjectOfType<ScrollbarManager>();
        desScript = FindObjectOfType<des>();
    }
    private void Update()
    {
        if (objectMovementScript.isMoving && !wasMoving)
        {
            ClearPopo1();
        }

        wasMoving = objectMovementScript.isMoving;
    }

    private void ClearPopo1()
    {
        // 禁用 popo 数组中的所有对象
        foreach (GameObject p in popo)
        {
            if (p.activeSelf)
            {
                p.SetActive(false);
                scrollbarManager.scrollbarValue += 0.2f;
                desScript.StartCoroutine(desScript.ActivateUI(ToActivate));
                foreach (GameObject ui in uiToDeactivate)
                {
                    ui.SetActive(false);
                }
            }
        }
        Debug.Log("All popo objects have been deactivated!");
    }
}