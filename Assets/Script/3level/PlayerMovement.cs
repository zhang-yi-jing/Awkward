using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �����ƶ��ٶ�

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // ��ȡˮƽ����

        // ������������ٶ�
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // ��ת���ﳯ��
        if (moveX > 0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f); // ����
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f); // ����
        }
    }
}