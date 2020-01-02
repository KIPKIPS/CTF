using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        transform.DOShakePosition(2,new Vector3(1,1,0));//x,y轴上抖动
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
