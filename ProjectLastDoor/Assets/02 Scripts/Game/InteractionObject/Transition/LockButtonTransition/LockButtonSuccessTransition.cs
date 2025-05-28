using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ùٸ� ��ư�� ���·� ����
    public class LockButtonSuccessTransition : LockButtonTransitionBase
    {
        public LockButtonSuccessTransition(StateMachine machine, IState changeState, LockButton lockButton) : base(machine, changeState, lockButton)
        {
        }

        public override bool IsTransition()
        {
            if(_lockButton.IsSuccess) // �ùٸ� ��ư�̾��ٸ�
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}

