using DG.Tweening;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �´� ��ư�� ����
    public class LockButtonSuccessState : LockButtonStateBase
    {
        public LockButtonSuccessState(PushButtonLock pushButtonLock, LockButton lockButton, Material material, float animationTime) : base(pushButtonLock, lockButton, material, animationTime)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequncen = DOTween.Sequence(); // ������ ����
            sequncen.Append(_material.DOColor(Color.green, _animationTime)); // ��ư ���� �ʷϻ����� ����
            sequncen.AppendCallback(() => _pushButtonLock.SuccessCount++); // ���� ���� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
