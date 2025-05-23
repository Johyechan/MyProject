using Game.Manager;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾�� �ʿ��� ��ɵ��� ��Ƽ� ó���ϴ� Ŭ����
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed; // �̵� �ӵ�
        [SerializeField] private float _disableDelay; // ��Ȱ��ȭ ��� �ð�
        [SerializeField] private float _enableDelay; // Ȱ��ȭ ��� �ð�
        [SerializeField] private float _rayDistance; // ���� ���� �Ÿ�

        [SerializeField] private Transform _playerCamTrans; // �÷��̾� ī�޶�

        [SerializeField] private Image _guideImage; // ��ȣ�ۿ� Ű ���̵� UI

        private PlayerInputHandle _inputHandle; // ��ǲ�� ó���ϴ� Ŭ����
        private PlayerMovement _movement; // �������� ó���ϴ� Ŭ����
        private PlayerInteractionRaycaster _interactionRaycast; // ��ȣ�ۿ��� ó���ϴ� Ŭ����

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(_playerCamTrans.position, _playerCamTrans.forward * _rayDistance);
        }

        // ���� �ʱ�ȭ
        private void Awake()
        {
            GameManager.Instance.Player = gameObject;

            _inputHandle = new PlayerInputHandle(this);
            _movement = new PlayerMovement(transform, _playerCamTrans, _moveSpeed);
            _interactionRaycast = new PlayerInteractionRaycaster(_guideImage, _rayDistance);
        }

        // ��ü �ʱ�ȭ
        private void Start()
        {
            transform.rotation = Quaternion.identity;
        }

        private void OnEnable()
        {
            if(InputManager.Instance != null)
            {
                InputManager.Instance.WaitAndEnable(_enableDelay, true); // ��ǲ Ȱ��ȭ
                _inputHandle.OnEnable(); // ��ǲ �ڵ��� Ȱ��ȭ �Լ� ȣ��
            }
        }

        private void OnDisable()
        {
            if(InputManager.Instance != null)
            {
                _inputHandle.OnDisable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
                InputManager.Instance.WaitAndEnable(_disableDelay, false); // ��ǲ ��Ȱ��ȭ
            }
        }

        private void Update()
        {
            if (_interactionRaycast.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // ��ȣ�ۿ� ��ü�� ����������
            {
                if (_inputHandle.IsInteraction) // ��ȣ�ۿ� Ű�� �����ٸ�
                {
                    GameManager.Instance.IsInteractionOn = true; // ��ȣ�ۿ� ���̶�� ����
                    _inputHandle.IsInteraction = false; // Ŭ�� ���� �ʱ�ȭ
                    _interactionRaycast.PlayInteraction(); // ��ȣ�ۿ�
                }
            }

            if (GameManager.Instance.IsInteractionOn)
                return;

            if (_inputHandle.IsInputActionCalling("Look")) // "Look" ��ǲ�� �� ���� Ȯ��
                _movement.Look(_inputHandle.LookVector); // �� �����Ӹ��� ������ ���� �ٶ󺸰� �ϴ� �Լ� ȣ��

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" ��ǲ�� �� ���� Ȯ��
                _movement.Move(_inputHandle.MoveVector); // �� �����Ӹ��� ������ �Լ� ȣ��
        }
    }
}
// ������ �ۼ� ����: 2025.05.22