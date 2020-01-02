using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

//追击敌人,直至敌人跑出视距范围
public class Defend : Action {

    public SharedFloat viewDistance;
    public SharedFloat fieldOfViewAngle;

    public SharedFloat speed;
    public SharedFloat angularSpeed;
    public SharedTransform target; //防御的目标

    private float sqrViewDistance;
    private NavMeshAgent navMeshAgent;

    public override void OnAwake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void OnStart() {
        sqrViewDistance = viewDistance.Value * viewDistance.Value;
        //启用导航组件
        navMeshAgent.enabled = true;
        //设置导航组件的默认值
        navMeshAgent.speed = speed.Value;
        navMeshAgent.angularSpeed = angularSpeed.Value;
        navMeshAgent.destination = target.Value.position;
    }

    //如果目标在视野范围内,则追击,否则回到自己的wayPoint,认为防御成功
    public override TaskStatus OnUpdate() {
        if (target == null && target.Value == null) { //安全校验
            return TaskStatus.Failure;
        }
        float sqrDistance = (target.Value.position - transform.position).sqrMagnitude;
        float angle = Vector3.Angle(transform.forward, target.Value.position - transform.position);
        if (sqrViewDistance > sqrDistance && angle < fieldOfViewAngle.Value * 0.5f) {
            if (navMeshAgent.destination != target.Value.position) { //在视野范围内,导航系统追寻目标
                navMeshAgent.destination = target.Value.position; //导航目标设置为位置目标
            }
            return TaskStatus.Running;
        }
        else {
            return TaskStatus.Success;
        }
    }
    public override void OnEnd() {
        navMeshAgent.enabled = false;
    }
}
