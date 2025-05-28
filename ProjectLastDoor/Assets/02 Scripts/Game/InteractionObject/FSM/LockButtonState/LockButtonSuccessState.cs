using DG.Tweening;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �´� ��ư�� ����
    public class LockButtonSuccessState : LockButtonStateBase
    {
        public LockButtonSuccessState(Material material, float animationTime, LockInteraction lockInteraction) : base(material, animationTime, lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("success");

            Sequence sequncen = DOTween.Sequence(); // ������ ����
            sequncen.Append(_material.DOColor(Color.green, _animationTime)); // ��ư ���� �ʷϻ����� ����
            sequncen.AppendCallback(() => _lockInteraction.SuccessCount++); // ���� ���� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
