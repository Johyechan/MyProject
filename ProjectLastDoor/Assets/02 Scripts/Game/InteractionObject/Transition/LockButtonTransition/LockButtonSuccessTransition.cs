using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 올바른 버튼인 상태로 전이
    public class LockButtonSuccessTransition : LockButtonTransitionBase
    {
        public LockButtonSuccessTransition(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState, lockButton)
        {
        }

        public override bool IsTransition()
        {
            if(_lockButton.IsSuccess) // 올바른 버튼이었다면
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}

