using Game.Manager;
using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // ��ȣ�ۿ� �� ���·� ����
    public class LockWaitTransition : LockTransitionBase
    {
        public LockWaitTransition(StateMachine machine, IState changeState, PushButtonLock pushButtonLock) : base(machine, changeState, pushButtonLock)
        {
        }

        public override bool IsTransition()
        {
            if(_pushButtonLock.IsLockInteractionOn) // ���� �ڹ��� ��ȣ�ۿ��� �Ǿ��ٸ�
            {
                ChangeState(); // ���� ����
                return true; // ���¸� ���� �Ǵ� �� ���¿��� �Ѵٰ� ��ȯ
            }

            return false; // ���¸� �������� ���� �Ǵ� �� ���°� �ƴϾ�� �Ѵٰ� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
