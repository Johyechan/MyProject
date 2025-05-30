using Game.Manager;
using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 상호작용 후 상태로 전이
    public class LockWaitTransition : LockTransitionBase
    {
        public LockWaitTransition(StateMachine machine, IState changeState, PushButtonLock pushButtonLock) : base(machine, changeState, pushButtonLock)
        {
        }

        public override bool IsTransition()
        {
            if(_pushButtonLock.IsLockInteractionOn) // 만약 자물쇠 상호작용이 되었다면
            {
                ChangeState(); // 상태 변경
                return true; // 상태를 전이 또는 이 상태여야 한다고 반환
            }

            return false; // 상태를 전이하지 않음 또는 이 상태가 아니어야 한다고 반환
        }
    }
}
// 마지막 작성 일자: 2025.05.30
