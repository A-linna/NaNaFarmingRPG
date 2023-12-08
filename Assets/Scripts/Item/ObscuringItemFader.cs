using System;
using System.Collections;
using UnityEngine;

/**
 * 淡入淡出
 */
public class ObscuringItemFader : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeIn()
    {
        StartCoroutine(nameof(FadeInRoutine));
        
    }

    public void FadeOut()
    {
        StartCoroutine(nameof(FadeOutRoutine));
    }

    //淡出
    private IEnumerator FadeOutRoutine()
    {
        var currentAlpha = _spriteRenderer.color.a;
        //距离目标透明度 差
        var distance = 1f - currentAlpha;
        while ((1f - currentAlpha) > 0.01f)
        {
            currentAlpha += distance / Settings.fadeOutSeconds * Time.deltaTime;
            _spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }


    //淡入
    private IEnumerator FadeInRoutine()
    {
        var currentAlpha = _spriteRenderer.color.a;
        var distance = 1f - Settings.targetAlpha;
        while (currentAlpha - Settings.targetAlpha>0.01f)
        {
            currentAlpha -= distance / Settings.fadeInSeconds * Time.deltaTime;
            _spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }
        _spriteRenderer.color = new Color(1f, 1f, 1f, Settings.targetAlpha);
    }
}