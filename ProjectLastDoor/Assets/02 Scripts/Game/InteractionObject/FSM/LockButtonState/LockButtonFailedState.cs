using MyUtil.FSM;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // Ʋ�� ��ư�� ����
    public class LockButtonFailedState : LockButtonStateBase
    {
        public LockButtonFailedState(PushButtonLock pushButtonLock, LockButton lockButton, Material material, float animationTime) : base(pushButtonLock, lockButton, material, animationTime)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence(); // ������ ����
            sequence.AppendCallback(() => _pushButtonLock.IsFailed = true); // �ִϸ��̼��� ���� �� �ڹ��迡 ���� �˸���
            sequence.Append(_material.DOColor(Color.red, _animationTime)); // ��ư ���� �Ӱ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
