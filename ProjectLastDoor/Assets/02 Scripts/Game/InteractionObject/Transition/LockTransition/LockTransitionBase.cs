using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��� ������ �θ� Ŭ����
    public abstract class LockTransitionBase : InteractionObjectTransitionBase
    {
        protected PushButtonLock _pushButtonLock;

        protected LockTransitionBase(StateMachine machine, IState changeState, PushButtonLock pushButtonLock) : base(machine, changeState)
        {
            _pushButtonLock = pushButtonLock;
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
