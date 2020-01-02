using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//引入DoTween命名空间
using DG.Tweening;


public class GetStart : MonoBehaviour {
    //cube的游戏对象
    public Transform cubeTransform;
    public Vector3 myValue = new Vector3(0, 0, 0);

    //面板的游戏对象
    public RectTransform taskRectTransform;
    public Vector3 taskPosition = new Vector3(0, 0, 0);

    //修改float类型的值,可以做颜色的渐变色
    public float R=0;
    public float G = 255;
    public float B = 130;

    // Start is called before the first frame update
    void Start() {

        //获取游戏对象的transform
        cubeTransform = GameObject.Find("Cube").transform;
        taskRectTransform = (RectTransform)GameObject.Find("taskPanel").transform;
        //对变量做一个动画(通过插值的方式修改一个变量的值)
        DOTween.To(() => myValue, x => myValue = x, new Vector3(10, 10, 10), 2);//前两个参数为委托类型的变量,一般固定这么写
        DOTween.To(() => taskPosition, x => taskPosition = x, new Vector3(0, 0, 0), 1);//task面板的动画效果
        DOTween.To(() => R, x => R = x, 255, 5);//float类型的数值 
        DOTween.To(() => G, x => G = x, 0, 5);//float类型的数值 
        DOTween.To(() => B, x => B = x, 255, 5);//float类型的数值 
    }

    // Update is called once per frame
    void Update() {
        //cube运动动画
        //cubeTransform.position = myValue;
        taskRectTransform.localPosition = taskPosition;//必须是localPosition
        //cube的颜色渐变
        cubeTransform.GetComponent<MeshRenderer>().material.color=new Color(R/255f, G / 255f, B / 255f);
    }
}

