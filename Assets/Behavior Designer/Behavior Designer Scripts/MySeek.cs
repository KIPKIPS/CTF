using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

//这个任务脚本的作用是控制目标物体到达指定位置
public class MySeek : Action { //该任务的调用是由behavior designer行为树控制的
    public SharedTransform target;//需要到达的目标位置
    public float speed = 6;
    public float arriveDistance = 0.1f;
    private float sqrArriveDistance;
    public override void OnStart() {
        sqrArriveDistance = arriveDistance * arriveDistance;
    }

    //进入任务时,会一直调用OnUpdate函数,直到任务返回一个成功或者失败的状态
    public override TaskStatus OnUpdate() { //这个方法的调用频率,默认和unity里面的帧一致
        if (target == null||target.Value==null) {
            return TaskStatus.Failure;
        }
        transform.LookAt(target.Value.position);
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        //if (Vector3.Distance(transform.position, target.Value.position) < arriveDistance) { //如果距离目标距离小于0.1,认为已经到达目标,返回任务成功
        //    return TaskStatus.Success;
        //}
        if ((target.Value.position - transform.position).sqrMagnitude < sqrArriveDistance) {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
