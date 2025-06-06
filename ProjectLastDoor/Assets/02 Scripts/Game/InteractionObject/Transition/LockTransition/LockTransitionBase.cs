using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 자물쇠 전이의 부모 클래스
    public abstract class LockTransitionBase : InteractionObjectTransitionBase
    {
        protected LockBase _lock;

        protected LockTransitionBase(StateMachine machine, IState changeState, LockBase lockBase) : base(machine, changeState)
        {
            _lock = lockBase;
        }
    }
}
// 마지막 작성 일자: 2025.05.30
