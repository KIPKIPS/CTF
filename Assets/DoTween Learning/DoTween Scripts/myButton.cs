using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class myButton : MonoBehaviour {
    public RectTransform panelTransform;
    // Start is called before the first frame update
    void Start()
    {
        panelTransform=(RectTransform)GameObject.Find("Panel").transform;

        //panelTransform.DOMove(new Vector3(0, 0, 0), 2);//DoTween引入的DOMove方法(修改的是世界坐标)
        Tweener inCameraAnimation = panelTransform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);//默认动画播放完成后会被销毁
        //Tweener对象保存这个动画的信息,每次调用DO类型的方法都会创建一个Tweener对象,由DoTween来管理
        inCameraAnimation.SetAutoKill(false);//将自动销毁设置为false
        inCameraAnimation.Pause();
    }
    private bool inCamera = false;
    public void OnClick() {
        
        if (inCamera == false) {
            panelTransform.DOPlayForward();//播放动画(前放),DOPlay()方法只播放一次
            inCamera = true;
        }
        else {
            panelTransform.DOPlayBackwards();//倒放动画
            inCamera = false;
        }
        
    }
}
