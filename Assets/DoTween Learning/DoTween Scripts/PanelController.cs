using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
    public Image image;
    public DOTweenAnimation dotween;
    // Start is called before the first frame update
    void Start() {
        image = GetComponent<Image>();
        image.color=Color.gray;
        dotween=GetComponent<DOTweenAnimation>();
        dotween.autoPlay = true;
        dotween.loops = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
