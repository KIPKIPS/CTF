using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OpacityColor : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>();
        text.DOColor(Color.red, 2).SetEase(Ease.InCubic);//颜色控制
        text.DOFade(1, 2).SetEase(Ease.InCubic);//透明度控制
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
