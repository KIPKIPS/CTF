using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsHasFlag : Conditional {

    private Offense offense;
    public override void OnAwake() {
        offense = this.GetComponent<Offense>();
    }

    public override TaskStatus OnUpdate() {
        if (offense.hasFlag==true) { //offense上有旗帜则返回任务成功
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}
