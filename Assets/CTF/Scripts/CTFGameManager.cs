using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class CTFGameManager : MonoBehaviour {

    private static CTFGameManager _instance;

    public static CTFGameManager Instance {
        get { return _instance; }
    }

    private List<BehaviorTree> flagNotTakenBehaviorTrees=new List<BehaviorTree>();
    private List<BehaviorTree> flagTakenBehaviorTrees=new List<BehaviorTree>();
    void Awake() {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
        BehaviorTree [] bts= FindObjectsOfType<BehaviorTree>();//得到场景中所有行为树
        foreach (var bt in bts) {
            if (bt.Group==1) {
                flagNotTakenBehaviorTrees.Add(bt);
            }
            else {
                flagTakenBehaviorTrees.Add(bt);
            }
        }
    }

    public void TakeFlag() { //捡起旗帜后,将FlagNotTaken行为树禁用掉
        foreach (var bt in flagNotTakenBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt)) { //判断行为树是否启用
                bt.DisableBehavior(); //禁用自身
            }
        }
        foreach (var bt in flagTakenBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt)==false) { //判断行为树是否启用
                bt.EnableBehavior(); //启用
            }
        }
    }

    public void DropFlag() { //捡起旗帜后,将FlagTaken行为树禁用掉
        foreach (var bt in flagTakenBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt)) { //判断行为树是否启用
                bt.DisableBehavior(); //禁用自身
            }
        }
        foreach (var bt in flagNotTakenBehaviorTrees) {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt) == false) { //判断行为树是否启用
                bt.EnableBehavior(); //启用
            }
        }
    }
}
