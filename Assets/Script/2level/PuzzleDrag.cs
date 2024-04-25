using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleDrag : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private Transform[] correctTransArray;
    [SerializeField] public bool isFinished; // 默认为false
    public GameObject objectToActivate; // 要激活的物体
    public TMP_Text tmpText;
    public TMP_Text secondTmpText;
    private Color startColor1;
    private Color startColor2;
    private float duration = 1f; // 渐变的持续时间

    private int triggeredIndex = -1; // 触发的 correctTransArray 元素的索引

    private void Start()
    {
        startPos = transform.position;
        startColor1 = tmpText.color;
        startColor2 = secondTmpText.color;

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
        bool isCorrect = false;
        triggeredIndex = -1; // 重置触发的索引

        for (int i = 0; i < correctTransArray.Length; i++)
        {
            Transform correctTrans = correctTransArray[i];
            if (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
                Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f)
            {
                transform.position = new Vector2(correctTrans.position.x, correctTrans.position.y);
                isCorrect = true;
                triggeredIndex = i; // 记录触发的索引
                break;
            }
        }

        Debug.Log(triggeredIndex);
        if (triggeredIndex == 0)
        {
            Color targetColor = startColor1;
            targetColor.a = 1f;
            StartCoroutine(OpacityCoroutine(targetColor));
        }
        if (triggeredIndex == 1)
        {
            Color targetColor = startColor2;
            targetColor.a = 1f;
            StartCoroutine(OpacityCoroutine1(targetColor));
        }

        if (isCorrect)
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true); // 激活物体
            }
        }

        if (!isCorrect)
        {
            transform.position = new Vector2(startPos.x, startPos.y);
        }

        isFinished = isCorrect;
    }

    private System.Collections.IEnumerator OpacityCoroutine(Color targetColor)
    {
        float elapsedTime = 0f;
        Color currentColor = tmpText.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            Color newColor = Color.Lerp(currentColor, targetColor, t);
            tmpText.color = newColor;
            yield return null;
        }

        tmpText.color = targetColor; // 确保最终的透明度值为目标值
    }

    private System.Collections.IEnumerator OpacityCoroutine1(Color targetColor)
    {
        float elapsedTime = 0f;
        Color currentColor = secondTmpText.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            Color newColor = Color.Lerp(currentColor, targetColor, t);
            secondTmpText.color = newColor;
            yield return null;
        }

        secondTmpText.color = targetColor; // 确保最终的透明度值为目标值
    }

    private void OnMouseDown()
    {
        if (isFinished)
            return;
    }
}