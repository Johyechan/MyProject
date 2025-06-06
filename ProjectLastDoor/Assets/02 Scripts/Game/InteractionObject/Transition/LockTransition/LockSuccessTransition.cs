using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // �ڹ��踦 Ǭ ���·� ����
    public class LockSuccessTransition : LockTransitionBase
    {
        private int _successGoal;

        public LockSuccessTransition(StateMachine machine, IState changeState, LockBase lockBase, int successGoal) : base(machine, changeState, lockBase)
        {
            _successGoal = successGoal;
        }

        public override bool IsTransition()
        {
            if(_lock.SuccessCount >= _successGoal) // ���� ���� ���¶��
            {
                ChangeState();
                return true;
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
