using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // ��ȣ�ۿ� �� ��� ���·� ����
    public class LockIdleTransition : LockTransitionBase
    {
        public LockIdleTransition(StateMachine machine, IState changeState, LockInteraction lockInteraction) : base(machine, changeState, lockInteraction)
        {
        }

        public override bool IsTransition()
        {
            if(!_lockInteraction.IsLockInteractionOn) // �ڹ��� ��ȣ�ۿ��� �ƴҰ��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
