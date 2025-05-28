using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� Ǯ�� ���� ����
    public class LockSuccessState : LockStateBase
    {
        public LockSuccessState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _lockInteraction.ChangeChannel(false); // �ó׸ӽ� ä�� �÷��̾� ä�η� ��ȯ
            _lockInteraction.IsLockInteractionOn = false; // �ڹ��� ��ȣ�ۿ� ����
            GameManager.Instance.IsNeedMousePos = false; // ���콺 Ŀ�� ��ġ�� ���� ���� �ʾƵ� �ȴٰ� ����
            GameManager.Instance.IsInteractionOn = false; // ��ȣ�ۿ� ��ü�� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
