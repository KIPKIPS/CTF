using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense : MonoBehaviour {

    public bool hasFlag = false;
    private Vector3 startPos;
    private Quaternion startRotation;

    void Awake() {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Defense") {
            if (hasFlag) {
                hasFlag = false;
                CTFGameManager.Instance.DropFlag();
                if (transform.childCount>0) {
                    Transform flagTransform = transform.GetChild(0); //得到0号子物体
                    flagTransform.GetComponent<Flag>().owner = null;
                    flagTransform.parent = null;
                    //flagTransform.position = flagTransform.GetComponent<Flag>().flagStartPos;
                    //flagTransform.rotation = flagTransform.GetComponent<Flag>().flagStartRotation;
                }
            }
            transform.position = startPos;
            transform.rotation = startRotation;
        }
    }
}
