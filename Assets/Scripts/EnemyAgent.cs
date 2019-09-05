using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    enum AgentState
    {
        Patrol,
        Chase,
        Attack,
        Escape
    }
    
    private class ReactiveState : ReactiveProperty<AgentState>
    {
        public ReactiveState(){}

        public ReactiveState(AgentState initialValue) : base(initialValue){}
    }
    
    void Start()
    {
        ReactiveState state = new ReactiveState(AgentState.Patrol);
        
        // ステートによって挙動を切り替える
        state.Subscribe(_ =>
        {
            switch (state.Value)
            {
                case AgentState.Patrol:
                    // 巡回
                    break;
                case AgentState.Chase:
                    // 追跡
                    break;
                case AgentState.Attack:
                    // 攻撃
                    break;
                case AgentState.Escape:
                    // 逃走
                    break;
            }
        });
    }
}
