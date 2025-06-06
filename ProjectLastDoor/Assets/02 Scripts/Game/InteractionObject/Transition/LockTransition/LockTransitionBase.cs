using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��� ������ �θ� Ŭ����
    public abstract class LockTransitionBase : InteractionObjectTransitionBase
    {
        protected LockBase _lock;

        protected LockTransitionBase(StateMachine machine, IState changeState, LockBase lockBase) : base(machine, changeState)
        {
            _lock = lockBase;
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
