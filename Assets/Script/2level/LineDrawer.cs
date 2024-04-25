using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public Transform line; // 场景中的线条对象
    public Transform startPoint; // 起始点
    public Transform endPoint; // 终止点

    private void Start()
    {
        // 初始化线条位置和角度
        UpdateLine();
    }

    private void Update()
    {
        // 实时更新线条位置和角度
        UpdateLine();
    }

    private void UpdateLine()
    {
        // 计算中点位置
        Vector3 midPoint = (startPoint.position + endPoint.position) / 2f;

        // 设置线条的起始点和终止点为中点位置
        line.position = midPoint;
        line.LookAt(endPoint.position);

        // 计算线条的长度
        float distance = Vector3.Distance(startPoint.position, endPoint.position);
        line.localScale = new Vector3(distance, 0.4f, 1f);

        // 调整线条的角度
        float angle = Mathf.Atan2(endPoint.position.y - startPoint.position.y, endPoint.position.x - startPoint.position.x) * Mathf.Rad2Deg;
        line.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}