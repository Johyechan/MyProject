using DG.Tweening;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �´� ��ư�� ����
    public class LockButtonSuccessState : LockButtonStateBase
    {
        public LockButtonSuccessState(Material material, float animationTime, PushButtonLock pushButtonLock) : base(material, animationTime, pushButtonLock)
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
