using Game.Manager;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� Ǯ�� ���� ����
    public class LockSuccessState : LockStateBase
    {
        private Animator _successAnimator;

        public LockSuccessState(LockInteraction lockInteraction, Animator successAnimator) : base(lockInteraction)
        {
            _successAnimator = successAnimator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => _lockInteraction.ChangeChannel(false)) // �ó׸ӽ� ä�� �÷��̾� ä�η� ��ȯ
                .InsertCallback(1.5f, () => _successAnimator.enabled = true) // �ִϸ������� Ȱ��ȭ��Ű�鼭 �ִϸ��̼� ����
                .AppendCallback(() => _lockInteraction.IsLockInteractionOn = false) // �ڹ��� ��ȣ�ۿ� ����
                .AppendCallback(() => _lockInteraction.IsSuccess = true) // ���������� ����
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // ���콺 Ŀ�� ��ġ�� ���� ���� �ʾƵ� �ȴٰ� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // ��ȣ�ۿ� ��ü�� ����
                .AppendCallback(() => _lockInteraction.gameObject.layer = 0); // ���� ��ȣ�ۿ��� �Ұ����� ���·� ���� (0 = Default)
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
