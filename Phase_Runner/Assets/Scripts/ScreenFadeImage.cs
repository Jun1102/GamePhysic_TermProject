using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeImage : MonoBehaviour
{
    public AudioSource open;
    public Image targetImage; 
    public float fadeDuration = 2.0f; // ������ ���ϴ� �ð�

    private float currentAlpha = 0f; // ���� ���� ��
    private bool isFading = false; // ���̵� ����
    public static bool isGameOver = false;

    void Start()
    {
        if(isGameOver == false)
            isGameOver = true;
        if (targetImage != null)
        {
            // �ʱ�ȭ
            Color color = targetImage.color;
            color.a = 0f; // ���� ���� 0���� ����
            targetImage.color = color;
        }
        if(!isFading)
            StartCoroutine(FadeToWhite());
    }
    IEnumerator FadeToWhite()
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            currentAlpha = Mathf.Clamp01(elapsedTime / fadeDuration); 
            if (targetImage != null)
            {
                Color color = targetImage.color;
                color.a = currentAlpha;
                targetImage.color = color;
            }
            yield return null;
        }

        
        if (targetImage != null)
        {
            Color finalColor = targetImage.color;
            finalColor.a = 1f;
            targetImage.color = finalColor;
        }

        isFading = false;
    }
}
