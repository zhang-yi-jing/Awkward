using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour
{
    public RectTransform dialogImage; // UIͼ���RectTransform���
    public TMP_Text dialogText; // TMP���
    public string[] dialogTexts; // �Ի��ı�����
    public float[] dialogImageWidths; // UIͼ��������
    public float[] dialogImageHeights; // UIͼ��߶�����
    public float switchDuration = 0.5f; // �л����ɵĳ���ʱ��
    public float[] switchTimes; // �л�ʱ������

    public int currentDialogIndex; // ��ǰ�Ի�����

    private void Start()
    {
        currentDialogIndex = 0;
        dialogImage.sizeDelta = Vector2.zero; // ��UIͼ��ĳ�ʼ��С����Ϊ0
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
            // �Ի���������������
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
            // �Ի������������鷶Χ����������
            gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator TransitionImageSize()
    {
        int index = currentDialogIndex % dialogImageWidths.Length; // ʹ��ȡ�����ȷ���������ᳬ�����鷶Χ
        float targetWidth = dialogImageWidths[index];
        float targetHeight = dialogImageHeights[index];

        float initialWidth = 0f; // ��ʼ���Ϊ0
        float initialHeight = 0f; // ��ʼ�߶�Ϊ0

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