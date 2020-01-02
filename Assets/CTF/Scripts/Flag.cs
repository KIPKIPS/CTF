using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

    //旗帜拥有者
    public Offense owner;
    //public Vector3 flagStartPos;
    //public  Quaternion flagStartRotation;

    void Awake() {
        //flagStartPos = transform.position;
        //flagStartRotation = transform.rotation;
    }
    // 物体进入时触发
    public void OnTriggerEnter(Collider other) {
        if (other.tag=="Offense") {
            if (owner==null) { //旗帜没有拥有者的时候
                CTFGameManager.Instance.TakeFlag();
            }

            if (owner!=null) { //旗帜拥有者不为空说明旗帜之前有主人,现在将旗帜拥有者的hasFlag设置为false
                owner.hasFlag = false;
                //CTFGameManager.Instance.DropFlag();

                //transform.position = flagStartPos;
                //transform.rotation = flagStartRotation;
            }

            other.GetComponent<Offense>().hasFlag = true; //将抢夺到旗帜的offense的hasFlag设置为true
            transform.parent = other.transform;
            owner = other.GetComponent<Offense>(); //将旗帜拥有者设置为现在的夺旗者
            //transform.position = other.transform.position;
            
        }
    }
}
