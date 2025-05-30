using DG.Tweening;
using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ǫ���� ������ ����
    public class LockFailedState : LockStateBase
    {
        public LockFailedState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => _lockInteraction.ChangeChannel(false)) // �ó׸ӽ� ä�� �÷��̾� ä�η� ��ȯ
                .InsertCallback(1.5f, () => _lockInteraction.IsLockInteractionOn = false) // �ڹ��� ��ȣ�ۿ� ����
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // ���콺 Ŀ�� ��ġ�� ���� ���� �ʾƵ� �ȴٰ� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // ��ȣ�ۿ� ��ü�� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
