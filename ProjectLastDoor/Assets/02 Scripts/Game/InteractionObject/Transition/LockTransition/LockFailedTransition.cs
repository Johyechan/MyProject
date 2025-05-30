using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��踦 �� Ǭ ���� ���·� ����
    public class LockFailedTransition : LockTransitionBase
    {
        public LockFailedTransition(StateMachine machine, IState changeState, PushButtonLock pushButtonLock) : base(machine, changeState, pushButtonLock)
        {
        }

        public override bool IsTransition()
        {
            if(_pushButtonLock.IsFailed) // ���ж��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
