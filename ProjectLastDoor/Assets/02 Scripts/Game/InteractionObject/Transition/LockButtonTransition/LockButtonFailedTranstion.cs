using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 잘못된 버튼인 상태로 전이
    public class LockButtonFailedTranstion : LockButtonTransitionBase
    {
        public LockButtonFailedTranstion(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState, lockButton)
        {
        }

        public override bool IsTransition()
        {
            if(_lockButton.IsFailed) // 올바른 버튼이 아니라면
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2025.05.28