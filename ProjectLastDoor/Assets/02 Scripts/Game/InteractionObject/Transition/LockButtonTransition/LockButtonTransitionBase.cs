using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 자물쇠 버튼 전이의 부모 클래스
    public abstract class LockButtonTransitionBase : InteractionObjectTransitionBase
    {
        protected LockButton _lockButton;

        protected LockButtonTransitionBase(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState)
        {
            _lockButton = lockButton;
        }
    }
}
// 마지막 작성 일자: 2025.05.28
