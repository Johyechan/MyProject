using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��� ������ �θ� Ŭ����
    public abstract class LockTransitionBase : InteractionObjectTransitionBase
    {
        protected LockInteraction _lockInteraction;

        protected LockTransitionBase(StateMachine machine, IState changeState, LockInteraction lockInteraction) : base(machine, changeState)
        {
            _lockInteraction = lockInteraction;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
