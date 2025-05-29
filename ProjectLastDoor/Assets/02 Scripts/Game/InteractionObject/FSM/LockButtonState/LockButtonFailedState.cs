using MyUtil.FSM;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // Ʋ�� ��ư�� ����
    public class LockButtonFailedState : LockButtonStateBase
    {
        public LockButtonFailedState(Material material, float animationTime, LockInteraction lockInteraction) : base(material, animationTime, lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence(); // ������ ����
            sequence.Append(_material.DOColor(Color.red, _animationTime)); // ��ư ���� �Ӱ� ����
            sequence.Append(_material.DOColor(Color.white, _animationTime)); // ��ư ���� �ٽ� ������� ����
            sequence.AppendCallback(() => _lockInteraction.IsFailed = true); // �ִϸ��̼��� ���� �� �ڹ��迡 ���� �˸���
        }
    }
}

