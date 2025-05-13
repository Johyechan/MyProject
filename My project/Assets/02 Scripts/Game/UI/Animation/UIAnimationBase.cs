using Game.Interface;
using Game.Struct;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    // 작성자: 조혜찬
    // UI 애니메이션들의 종합적인 기능들을 가지는 추상(부모) 클래스
    public abstract class UIAnimationBase : IUIAnimation
    {
        // 코루틴을 실행시키기 위한 변수
        protected MonoBehaviour _mono;

        // 현재 실행 중인 코루틴을 저장 후 필요할 때 정지 시키기 위한 현재 코루틴 저장 변수 
        protected Coroutine _currentCo;

        // UI를 변형하기 위해서 필요한 변수
        protected RectTransform _rectTrans;

        // 애니메이션 실행 시간
        protected float _duration;

        // 생성자에서 변수 초기화
        public UIAnimationBase(UIAnimationVariables animationVariables)
        {
            _mono = animationVariables.mono;
            _rectTrans = animationVariables.rectTrans;
            _duration = animationVariables.duration;
        }

        // 코루틴 실행 후 현재 코루틴 저장 변수에 저장 + 실행
        public virtual void Play()
        {
            _currentCo = _mono.StartCoroutine(UIAnimationCo());
        }

        // 현재 코루틴 변수에 저장된 코루틴 정지
        public void Stop()
        {
            if (_currentCo != null)
                _mono.StopCoroutine(_currentCo);
        }

        // 자식에서 구현하도록 강제
        public abstract IEnumerator UIAnimationCo();
    }
}
// 마지막 작성 일자: 2025.05.13
