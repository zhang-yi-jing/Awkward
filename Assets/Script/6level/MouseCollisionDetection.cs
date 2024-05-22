using UnityEngine;

public class MouseCollisionDetection : MonoBehaviour
{
    public Collider2D[] targetColliders; // 目标碰撞体数组
    public Camera mainCamera; // 主摄像机
    public GameObject activationObject1; // 激活的物体1
    public GameObject activationObject2; // 激活的物体2
    public AudioSource audioSource; // 声音源
    public AudioClip audioclip;

    private bool isMousePressed; // 鼠标是否按下
    private bool wasMouseWithinCollider; // 上一帧鼠标是否在范围内

    private void Start()
    {
        mainCamera = Camera.main;
        activationObject1.SetActive(false); // 禁用物体1
        activationObject2.SetActive(false); // 禁用物体2
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
            audioSource.Stop(); // 停止播放声音
            activationObject1.SetActive(false); // 禁用物体1
            activationObject2.SetActive(false); // 禁用物体2
            wasMouseWithinCollider = false;
        }

        if (isMousePressed)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            bool isMouseWithinCollider = false;

            foreach (Collider2D targetCollider in targetColliders)
            {
                if (targetCollider.OverlapPoint(mousePosition2D))
                {
                    isMouseWithinCollider = true;
                    //ebug.Log("Mouse is within the collider range: " + targetCollider.name);

                    if (!wasMouseWithinCollider)
                    {
                        audioSource.clip = audioclip;
                        audioSource.Play(); // 播放声音
                    }

                    if (targetCollider.name == "Trigger1")
                    {
                        activationObject1.SetActive(true); // 激活物体1
                    }
                    else if (targetCollider.name == "Trigger2")
                    {
                        activationObject2.SetActive(true); // 激活物体2
                    }
                }
            }

            if (!isMouseWithinCollider)
            {
                audioSource.Stop(); // 停止播放声音
                activationObject1.SetActive(false); // 禁用物体1
                activationObject2.SetActive(false); // 禁用物体2
            }

            wasMouseWithinCollider = isMouseWithinCollider;
        }
    }
}