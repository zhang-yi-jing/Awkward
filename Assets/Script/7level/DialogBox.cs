using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour
{
    public RectTransform dialogImage; // UI图像的RectTransform组件
    public TMP_Text dialogText; // TMP组件
    public string[] dialogTexts; // 对话文本数组
    public float[] dialogImageWidths; // UI图像宽度数组
    public float[] dialogImageHeights; // UI图像高度数组
    public float switchDuration = 0.5f; // 切换过渡的持续时间
    public float[] switchTimes; // 切换时间数组

    public int currentDialogIndex; // 当前对话索引

    private void Start()
    {
        currentDialogIndex = 0;
        dialogImage.sizeDelta = Vector2.zero; // 将UI图像的初始大小设置为0
        UpdateDialog();
    }

    private void Update()
    {
        if (currentDialogIndex < dialogTexts.Length)
        {
            float switchTime = switchTimes[currentDialogIndex];
            if (Time.time >= switchTime)
            {
                currentDialogIndex++;
                UpdateDialog();
            }
        }
        else
        {
            // 对话结束，隐藏物体
            gameObject.SetActive(false);
        }
    }

    private void UpdateDialog()
    {
        if (currentDialogIndex < dialogTexts.Length && currentDialogIndex < dialogImageWidths.Length && currentDialogIndex < dialogImageHeights.Length)
        {
            StartCoroutine(TransitionImageSize());
            dialogText.text = dialogTexts[currentDialogIndex];
        }
        else
        {
            // 对话索引超出数组范围，隐藏物体
            gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator TransitionImageSize()
    {
        int index = currentDialogIndex % dialogImageWidths.Length; // 使用取余操作确保索引不会超出数组范围
        float targetWidth = dialogImageWidths[index];
        float targetHeight = dialogImageHeights[index];

        float initialWidth = 0f; // 初始宽度为0
        float initialHeight = 0f; // 初始高度为0

        float elapsedTime = 0f;

        while (elapsedTime < switchDuration)
        {
            float t = elapsedTime / switchDuration;
            float newWidth = Mathf.Lerp(initialWidth, targetWidth, t);
            float newHeight = Mathf.Lerp(initialHeight, targetHeight, t);

            dialogImage.sizeDelta = new Vector2(newWidth, newHeight);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dialogImage.sizeDelta = new Vector2(targetWidth, targetHeight);
    }
}