using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 자물쇠를 못 푼 실패 상태로 전이
    public class LockFailedTransition : LockTransitionBase
    {
        public LockFailedTransition(StateMachine machine, IState changeState, LockBase lockBase) : base(machine, changeState, lockBase)
        {
        }

        public override bool IsTransition()
        {
            if(_lock.IsFailed) // 실패라면
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2025.05.28
