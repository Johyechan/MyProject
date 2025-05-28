using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 상호작용 전 대기 상태로 전이
    public class LockIdleTransition : LockTransitionBase
    {
        public LockIdleTransition(StateMachine machine, IState changeState, LockInteraction lockInteraction) : base(machine, changeState, lockInteraction)
        {
        }

        public override bool IsTransition()
        {
            if(!_lockInteraction.IsLockInteractionOn) // 자물쇠 상호작용이 아닐경우
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2025.05.28
