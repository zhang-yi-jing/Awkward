using UnityEngine;

public class Gymnastics : MonoBehaviour
{
    public GameObject uiElement1; // UI元素1
    public GameObject uiElement2; // UI元素2
    public GameObject uiElement3; // UI元素3
    public GameObject uiElement4; // UI元素4
    public GameObject uiElement5; // UI元素5

    private bool inputDisabled; // 输入禁用状态
    private float disableTime; // 禁用开始时间

    private void Start()
    {
        // 初始化状态
        uiElement1.SetActive(true);
        uiElement2.SetActive(false);
        uiElement3.SetActive(false);
        uiElement4.SetActive(false);
        uiElement5.SetActive(false);
        inputDisabled = false;
    }

    private void Update()
    {
        // 检测是否按下了W键
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!inputDisabled)
            {
                // 隐藏UI元素1，激活UI元素2和隐藏UI元素3
                uiElement1.SetActive(false);
                uiElement2.SetActive(true);
                DisableInput();
            }
        }

        // 检测是否按下了S键
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!inputDisabled)
            {
                // 隐藏UI元素1，激活UI元素3和隐藏UI元素2
                uiElement1.SetActive(false);
                uiElement3.SetActive(true);
                DisableInput();
            }
        }

        // 检测是否按下了A键
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!inputDisabled)
            {
                // 激活UI元素4，隐藏UI元素5
                uiElement4.SetActive(true);
                uiElement1.SetActive(false);
                DisableInput();
            }
        }

        // 检测是否按下了D键
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!inputDisabled)
            {
                // 激活UI元素5，隐藏UI元素4
                uiElement1.SetActive(false);
                uiElement5.SetActive(true);
                DisableInput();
            }
        }

        // 检测输入禁用状态是否结束
        if (inputDisabled && Time.timeSinceLevelLoad >= disableTime + 1f)
        {
            EnableInput();
            uiElement1.SetActive(true);
            uiElement2.SetActive(false);
            uiElement3.SetActive(false);
            uiElement4.SetActive(false);
            uiElement5.SetActive(false);
        }
    }

    private void DisableInput()
    {
        inputDisabled = true;
        disableTime = Time.timeSinceLevelLoad;
    }

    private void EnableInput()
    {
        inputDisabled = false;
    }
}