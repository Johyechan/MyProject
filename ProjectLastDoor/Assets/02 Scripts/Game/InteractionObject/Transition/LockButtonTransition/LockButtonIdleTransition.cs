using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 상호작용 되지 않은 상태로 전이
    public class LockButtonIdleTransition : LockButtonTransitionBase
    {
        public LockButtonIdleTransition(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState, lockButton)
        {
        }

        public override bool IsTransition()
        {
            if(!_lockButton.IsSuccess && !_lockButton.IsFailed) // 성공도 실패도 아닌 상태라면
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2025.05.28
