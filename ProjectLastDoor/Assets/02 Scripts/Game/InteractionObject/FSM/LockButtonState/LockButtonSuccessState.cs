using DG.Tweening;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 맞는 버튼인 상태
    public class LockButtonSuccessState : LockButtonStateBase
    {
        public LockButtonSuccessState(Material material, float animationTime, PushButtonLock pushButtonLock) : base(material, animationTime, pushButtonLock)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequncen = DOTween.Sequence(); // 시퀀스 생성
            sequncen.Append(_material.DOColor(Color.green, _animationTime)); // 버튼 색을 초록색으로 변경
            sequncen.AppendCallback(() => _pushButtonLock.SuccessCount++); // 성공 개수 증가
        }
    }
}
// 마지막 작성 일자: 2025.05.28
