using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MyText : MonoBehaviour {
    private Text text;
    private float detal=0;
    //[Tooltip("设置目标字体的RGB颜色")] //靠近时显示注释
    //滑杆的值在0到255变化
    [SerializeField, Tooltip("设置目标字体的R数值"), Range(0, 255), Header("设置目标字体的RGB颜色")]
    public int R=255;
    [SerializeField, Tooltip("设置目标字体的G数值"), Range(0, 255)]
    public int G = 255;
    [SerializeField, Tooltip("设置目标字体的B数值"), Range(0, 255)]
    public int B = 255;
    [SerializeField, Tooltip("设置目标字体的透明度"), Range(0,1)]
    public int a = 1;
    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>();
        DOTween.To(() => detal, x => detal = x, 1, 5);
        //text.DOText("接下来,我们进入第一章", 2,true,ScrambleMode.All).SetEase(Ease.InBack);
    }

    // Update is called once per frame
    void Update()
    {
        text.color=new Color((R/255f)*detal,(G / 255f) * detal, (B / 255f) * detal,a*detal);
    }
}
