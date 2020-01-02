using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

//判断目标是否在视野内
public class MyCanSeeObject : Conditional {
    public Transform[] targets;

    public float fieldOfViewAngle=90;//视野范围
    //public float viewDistance = 7;//视距
    public SharedFloat sharedViewDistance;//视距

    public SharedTransform target;
    //public override void OnStart() {
    //    Console.WriteLine(GlobalVariables.Instance.GetVariable("viewDistance"));
    //}

    public override TaskStatus OnUpdate() {
        
        if (targets == null) {
            return TaskStatus.Failure;
        }
        foreach(var target in targets) {
            float distance = Vector3.Distance(transform.position, target.position);
            float angle= Vector3.Angle(transform.forward, target.position - transform.position);
            if(distance < sharedViewDistance.Value && angle < fieldOfViewAngle*0.5f) {
                this.target.Value = target;
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }
}
