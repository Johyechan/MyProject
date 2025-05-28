using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ���� ���� ���·� ����
    public class LockButtonIdleTransition : LockButtonTransitionBase
    {
        public LockButtonIdleTransition(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState, lockButton)
        {
        }

        public override bool IsTransition()
        {
            if(!_lockButton.IsSuccess && !_lockButton.IsFailed) // ������ ���е� �ƴ� ���¶��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
