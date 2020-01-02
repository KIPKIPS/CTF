using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        //transform.DOMoveX(5, 3).From();//从0位置移动到当前位置(绝对坐标)
        transform.DOMoveX(5, 3).From(true);//从1位置移动到当前位置(相对坐标6)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
