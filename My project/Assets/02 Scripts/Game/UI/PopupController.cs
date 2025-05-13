using Game.Manager;
using Game.Struct;
using UnityEngine;

namespace Game.UI
{
    // �ۼ���: ������
    // UI �˾� �ִϸ��̼��� �����ϴ� Ŭ����
    public class PopupController : UIControllerBase
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _overPos;
        [SerializeField] private float _overMoveDuration;

        private UIPopupAnimationVariables _popupvariables;

        private UIPopupAnimation _popupAnimation;

        // �˾� ���� ���� ����ü �ʱ�ȭ
        protected override void Init()
        {
            base.Init();

            _popupvariables = new UIPopupAnimationVariables();
            _popupvariables.targetPos = _target.position;
            _popupvariables.overPos = _overPos;
            _popupvariables.overMoveDuration = _overMoveDuration;
        }

        // ���� �ʱ�ȭ
        private void Awake()
        {
            Init();
            _popupAnimation = new UIPopupAnimation(_animationVariables, _popupvariables);
        }

        // ���� �Ŵ��� �̺�Ʈ�� �˾� �ִϸ��̼� ����
        private void OnEnable()
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.OnClear += _popupAnimation.Play;
            }
        }

        // ���� �Ŵ��� �̺�Ʈ���� �˾� �ִϸ��̼� ���� ����
        private void OnDisable()
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.OnClear -= _popupAnimation.Play;
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.13
