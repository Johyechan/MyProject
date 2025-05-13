using Game.Manager;
using Game.Struct;
using UnityEngine;

namespace Game.UI
{
    // 작성자: 조혜찬
    // UI 팝업 애니메이션을 전담하는 클래스
    public class PopupController : UIControllerBase
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _overPos;
        [SerializeField] private float _overMoveDuration;

        private UIPopupAnimationVariables _popupvariables;

        private UIPopupAnimation _popupAnimation;

        // 팝업 전용 변수 구조체 초기화
        protected override void Init()
        {
            base.Init();

            _popupvariables = new UIPopupAnimationVariables();
            _popupvariables.targetPos = _target.position;
            _popupvariables.overPos = _overPos;
            _popupvariables.overMoveDuration = _overMoveDuration;
        }

        // 변수 초기화
        private void Awake()
        {
            Init();
            _popupAnimation = new UIPopupAnimation(_animationVariables, _popupvariables);
        }

        // 게임 매니저 이벤트에 팝업 애니메이션 구독
        private void OnEnable()
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.OnClear += _popupAnimation.Play;
            }
        }

        // 게임 매니저 이벤트에서 팝업 애니메이션 구독 해제
        private void OnDisable()
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.OnClear -= _popupAnimation.Play;
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.13
