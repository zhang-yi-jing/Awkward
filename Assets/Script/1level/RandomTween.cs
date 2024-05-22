using UnityEngine;

public class RandomTween : MonoBehaviour
{
    public Transform[] waypoints; // �洢���Ŀ�� UI �� Transform ���
    public float speed = 1f; // �ƶ��ٶ�

    private int currentIndex = 0;
    private Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to LoopingTween script.");
            return;
        }

        Vector3 targetPosition = waypoints[currentIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
    }
}