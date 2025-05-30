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

        public LockSuccessState(PushButtonLock pushButtonLock, Animator successAnimator) : base(pushButtonLock)
        {
            _successAnimator = successAnimator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => _pushButtonLock.ChangeChannel(false)) // �ó׸ӽ� ä�� �÷��̾� ä�η� ��ȯ
                .InsertCallback(1.5f, () => _successAnimator.enabled = true) // �ִϸ������� Ȱ��ȭ��Ű�鼭 �ִϸ��̼� ����
                .AppendCallback(() => _pushButtonLock.IsLockInteractionOn = false) // �ڹ��� ��ȣ�ۿ� ����
                .AppendCallback(() => _pushButtonLock.IsSuccess = true) // ���������� ����
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // ���콺 Ŀ�� ��ġ�� ���� ���� �ʾƵ� �ȴٰ� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // ��ȣ�ۿ� ��ü�� ����
                .AppendCallback(() => _pushButtonLock.gameObject.layer = 0); // ���� ��ȣ�ۿ��� �Ұ����� ���·� ���� (0 = Default)
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
