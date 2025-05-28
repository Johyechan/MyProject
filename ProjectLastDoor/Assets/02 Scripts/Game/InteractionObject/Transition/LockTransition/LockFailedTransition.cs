using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��踦 �� Ǭ ���� ���·� ����
    public class LockFailedTransition : LockTransitionBase
    {
        public LockFailedTransition(StateMachine machine, IState changeState, LockInteraction lockInteraction) : base(machine, changeState, lockInteraction)
        {
        }

        public override bool IsTransition()
        {
            if(_lockInteraction.IsFailed) // ���ж��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
