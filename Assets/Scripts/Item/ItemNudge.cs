using System.Collections;
using UnityEngine;

/**
 * 玩家经过 风景组件时 摇曳效果
 */
public class ItemNudge : MonoBehaviour
{
    private WaitForSeconds _pause;
    private bool _isAnimating;
    private float _rotationAngle;

    private void Awake()
    {
        _pause = new WaitForSeconds(0.04f);
        _rotationAngle = 2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isAnimating) return;
        //item 在玩家的左边
        if (transform.position.x<other.transform.position.x)
        {
            //顺时针旋转
            StartCoroutine(RotateClock(_rotationAngle));
        }
        else
        {
            //逆时针旋转
            StartCoroutine(RotateClock(-_rotationAngle));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isAnimating) return;
        //item 在玩家的右边
        if (transform.position.x>other.transform.position.x)
        {
            StartCoroutine(RotateClock(-_rotationAngle));
        }
        else
        {
            StartCoroutine((RotateClock(_rotationAngle)));
        }
    }

    private IEnumerator RotateClock(float rotationAngle)
    {
        _isAnimating = true;
        for (int i = 0; i < 4; i++)
        {
            transform.Find("ItemSprite").Rotate(0f,0f,rotationAngle);
            yield return _pause;
        }

        for (int i = 0; i < 5; i++)
        {
            transform.Find("ItemSprite").Rotate(0f,0f,-rotationAngle);
            yield return _pause;
        }

        transform.Find("ItemSprite").Rotate(0f, 0f, rotationAngle);
        _isAnimating = false;
    }

}