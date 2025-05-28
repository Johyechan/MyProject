using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��迡 ��ȣ�ۿ��ϱ� �� ��� ����
    public class LockIdleState : LockStateBase
    {
        public LockIdleState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _lockInteraction.ChangeChannel(false); // �÷��̾� �ó׸ӽ����� ä�� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
