using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector2 startPos;               // 起始位置
    private bool isDragging = false;        // 是否正在拖拽
    private bool isDragging1 = false;        // 是否正在拖拽
    private Vector2 dragDirection;          // 拖拽的方向
    private Vector2 previousFramePosition;  // 上一帧的位置
    private Rigidbody2D rb;                 // 刚体组件的引用
    public float launchForce = 10f;         // 飞出的力大小
    public float downwardSpeed = 5f;        // 向下运动的速度

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;  // 设置刚体为运动学模式以防止受到重力影响
    }

    private void Update()
    {
        if (!isDragging1)
        {
            // 向下匀速运动
            transform.Translate(Vector2.down * downwardSpeed * Time.deltaTime);
        }

        previousFramePosition = transform.position;
    }

    private void OnMouseDrag()
    {
        isDragging = true;
        isDragging1 = true;

        // 更新物体的位置为鼠标的当前位置
        transform.position = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y
        );
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            // 计算拖拽的方向
            dragDirection = ((Vector2)transform.position - startPos).normalized;
            rb.isKinematic = false;  // 取消运动学模式，使刚体受到力的影响并飞出
            rb.AddForce(dragDirection * launchForce, ForceMode2D.Impulse);  // 应用飞出的力
        }
    }

    private void OnMouseDown()
    {
        isDragging = false;
    }
}