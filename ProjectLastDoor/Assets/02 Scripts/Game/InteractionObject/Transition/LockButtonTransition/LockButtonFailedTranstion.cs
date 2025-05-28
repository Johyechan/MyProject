using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �߸��� ��ư�� ���·� ����
    public class LockButtonFailedTranstion : LockButtonTransitionBase
    {
        public LockButtonFailedTranstion(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState, lockButton)
        {
        }

        public override bool IsTransition()
        {
            if(_lockButton.IsFailed) // �ùٸ� ��ư�� �ƴ϶��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28