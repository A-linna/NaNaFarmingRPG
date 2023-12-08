using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwitchConfinerBoundShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundShape();
    }
    /// <summary>
    ///在boundConfiner对象上获取Polygon collider2d 组件 给cinemachine 来控制屏幕边界
    /// </summary>
    private void SwitchBoundShape()
    {
        //获取 polygon collider 组件
        var polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
        var cinemachineConfiner = GetComponent<CinemachineConfiner>();
        // 赋值
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
        //刷新缓存
        cinemachineConfiner.InvalidatePathCache();
    }
}
