using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Image curtain;


    public void Dark(float time)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LockMovement();
        StartCoroutine(FadeIn(time));
    }

    public void Light(float time)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UnlockMovement();
        StartCoroutine(FadeOut(time));
    }

    public IEnumerator FadeOut(float fadeTime)
    {
        // Сохраняем оригинальный цвет
        Color originalColor = curtain.color;

        float timer = 0f;
        float startAlpha = originalColor.a;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / fadeTime);

            // Плавно изменяем альфа-канал от текущего значения до 0
            float currentAlpha = Mathf.Lerp(startAlpha, 0f, progress);
            curtain.color = new Color(originalColor.r, originalColor.g, originalColor.b, currentAlpha);

            yield return null;
        }

        // Устанавливаем окончательное значение (полностью прозрачный)
        curtain.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    public IEnumerator FadeIn(float fadeTime)
    {
        Color originalColor = curtain.color;

        // Устанавливаем полностью прозрачный цвет
        curtain.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Убедимся, что объект активен
        gameObject.SetActive(true);

        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / fadeTime);

            // Плавно изменяем альфа-канал от 0 до 1
            curtain.color = new Color(originalColor.r, originalColor.g, originalColor.b, progress);

            yield return null;
        }

        // Устанавливаем окончательное значение
        curtain.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }
}
