using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ��ȣ�ۿ� �� ����
    public class LockWaitState : LockStateBase
    {
        public LockWaitState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _lockInteraction.ChangeChannel(); // �ó׸ӽ� ä�� ����
            _lockInteraction.IsFailed = false; // ���� �ʱ�ȭ
            _lockInteraction.SuccessCount = 0; // ���� �ʱ�ȭ
            GameManager.Instance.IsNeedMousePos = true; // ���콺 Ŀ�� ��ġ�� ���̸� ���� �Ѵٰ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
