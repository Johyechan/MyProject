using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 자물쇠를 푼 상태로 전이
    public class LockSuccessTransition : LockTransitionBase
    {
        private int _successGoal;

        public LockSuccessTransition(StateMachine machine, IState changeState, PushButtonLock pushButtonLock, int successGoal) : base(machine, changeState, pushButtonLock)
        {
            _successGoal = successGoal;
        }

        public override bool IsTransition()
        {
            if(_pushButtonLock.SuccessCount >= _successGoal) // 만약 성공 상태라면
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2025.05.30
