using MyUtil.FSM;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 틀린 버튼인 상태
    public class LockButtonFailedState : LockButtonStateBase
    {
        public LockButtonFailedState(Material material, float animationTime, LockInteraction lockInteraction) : base(material, animationTime, lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence(); // 시퀀스 생성
            sequence.Append(_material.DOColor(Color.red, _animationTime)); // 버튼 색을 붉게 변경
            sequence.Append(_material.DOColor(Color.white, _animationTime)); // 버튼 색을 다시 흰색으로 변경
            sequence.AppendCallback(() => _lockInteraction.IsFailed = true); // 애니메이션이 끝난 후 자물쇠에 실패 알리기
        }
    }
}

