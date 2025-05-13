using DG.Tweening;
using Game.Struct;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    // 작성자: 조혜찬
    // UI 팝업 애니메이션을 구현한 클래스
    public class UIPopupAnimation : UIAnimationBase
    {
        // 최종 목표 지점
        private Vector3 _targetPos;

        // 중간 목표 지점을 만들어주기 위한 변수
        private Vector3 _overPos;

        // 중간 목표 지점까지 가는데 걸리는 시간 변수
        private float _overMoveDuration;

        // 생성자 구현
        public UIPopupAnimation(UIAnimationVariables animationVariables, UIPopupAnimationVariables popupVariables) : base(animationVariables)
        {
            _targetPos = popupVariables.targetPos;
            _overPos = popupVariables.overPos;
            _overMoveDuration = popupVariables.overMoveDuration;
        }

        public override IEnumerator UIAnimationCo()
        {
            // DOTween을 사용하여 특정 UI를 목표보다 조금 더 위로 애니메이션 실행 시간보다 조금 빠르게 이동
            // 그후 다시 목표까지 남은 애니메이션 실행 시간만큼 이동
            // 통하고 튀는 느낌을 주기 위해서 이런 식으로 개발
            Sequence sequence = DOTween.Sequence()
                .Append(_rectTrans.DOMove(_targetPos + _overPos, _overMoveDuration))
                .Append(_rectTrans.DOMove(_targetPos, _duration - _overMoveDuration));

            yield return null;
        }
    }
}
// 마지막 작성 일자: 2025.05.13
