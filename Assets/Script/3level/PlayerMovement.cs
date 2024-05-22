using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 人物移动速度

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // 获取水平输入

        // 根据输入更新速度
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // 翻转人物朝向
        if (moveX > 0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f); // 朝右
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f); // 朝左
        }
    }
}