using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // ��ȣ�ۿ� �� ��� ���·� ����
    public class LockIdleTransition : LockTransitionBase
    {
        public LockIdleTransition(StateMachine machine, IState changeState, PushButtonLock pushButtonLock) : base(machine, changeState, pushButtonLock)
        {
        }

        public override bool IsTransition()
        {
            if(!_pushButtonLock.IsLockInteractionOn) // �ڹ��� ��ȣ�ۿ��� �ƴҰ��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
