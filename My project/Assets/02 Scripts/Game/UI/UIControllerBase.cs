using Game.Struct;
using UnityEngine;

namespace Game.UI
{
    // 작성자: 조혜찬
    // UI 컨트롤러의 기반이 되는 클래스
    public class UIControllerBase : MonoBehaviour
    {
        [SerializeField] protected RectTransform _uiRectTrans;
        [SerializeField] protected float _duration;

        // 기본적으로 UI 애니메이션에서 필요로 하는 변수 구조체
        protected UIAnimationVariables _animationVariables;


        // 구조체 초기화
        protected virtual void Init()
        {
            _animationVariables = new UIAnimationVariables();
            _animationVariables.mono = this;
            _animationVariables.rectTrans = _uiRectTrans;
            _animationVariables.duration = _duration;
        }
    }
}
// 마지막 작성 일자: 2025.05.13
