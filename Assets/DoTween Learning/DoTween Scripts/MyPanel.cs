using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MyPanel : MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {
        Tweener obj = transform.DOLocalMoveX(0, 2f);
        obj.SetEase(Ease.OutBounce);//缓动效果
        obj.SetLoops(1);//设置循环次数
        obj.OnComplete(OnThen);//设置动画完成后执行的事件
    }

    // Update is called once per frame
    void Update() {

    }

    void OnThen() {
        Debug.Log("Then函数执行");
    }
}
