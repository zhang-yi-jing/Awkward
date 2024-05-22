using UnityEngine;

public class popoDrag : MonoBehaviour
{
    public delegate void MoveCompleted();
    public static event MoveCompleted OnMoveCompleted; // 定义事件

    private Vector2 startPos;
    [SerializeField] private Transform correctTrans;
    [SerializeField] public bool isFinished; // 默认为 false

    private RandomTween randomTween; // 存储 RandomTween 组件的引用

    private void Start()
    {
        startPos = transform.position;
        randomTween = GetComponent<RandomTween>(); // 获取 RandomTween 组件的引用
    }

    private void OnMouseDrag()
    {
        if (!isFinished)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 1.5f &&
           Mathf.Abs(transform.position.y - correctTrans.position.y) <= 1.5f)
        {
            transform.position = new Vector2(correctTrans.position.x, correctTrans.position.y);
            isFinished = true;
            randomTween.enabled = false; // 禁用 RandomTween 组件

            // 触发事件
            if (OnMoveCompleted != null)
            {
                OnMoveCompleted();
            }

        }
        else
        {
            transform.position = new Vector2(startPos.x, startPos.y);
        }
    }

    private void OnMouseDown()
    {
        if (isFinished)
            return;
    }
}