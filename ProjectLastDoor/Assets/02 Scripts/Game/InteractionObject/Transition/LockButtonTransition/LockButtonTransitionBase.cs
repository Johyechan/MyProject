using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��� ��ư ������ �θ� Ŭ����
    public abstract class LockButtonTransitionBase : InteractionObjectTransitionBase
    {
        protected LockButton _lockButton;

        protected LockButtonTransitionBase(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState)
        {
            _lockButton = lockButton;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
