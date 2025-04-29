using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Ball
{
    // �ۼ���: ������
    // ������ ��ǲ ó���ϴ� Ŭ����
    public class BallInput : MonoBehaviour
    {
        // ������ ��ǲ �ý��� ����
        [SerializeField] private InputActionAsset _ballInputAsset;
        // "Gameplay" �׼� ���� ����
        private InputActionMap _gameplayMap;
        // ������ �������� üũ�ϴ� "Tilt" �׼�
        private InputAction _tiltAction;

        // ������ ������ ������ ������Ƽ
        public Vector3 TiltValue { get; private set; }

        // �ʱ�ȭ: ��ǲ �׼� �ʰ� �׼� ã��
        private void Awake()
        {
            // "Gameplay" �׼� ���� ã��, �� �ȿ��� "Tilt" �׼��� ã��
            _gameplayMap = _ballInputAsset.FindActionMap("Gameplay", true);
            _tiltAction = _gameplayMap.FindAction("Tilt", true);
        }

        // ��ü Ȱ��ȭ ��: �׼��� Ȱ��ȭ�ϰ�, ���� �׼ǿ� ���� �̺�Ʈ ����
        private void OnEnable()
        {
            _tiltAction.Enable();
            _tiltAction.performed += OnTiltPerformed;
        }

        // ��ü ��Ȱ��ȭ ��: �̺�Ʈ ���� ���� �� �׼� ��Ȱ��ȭ
        private void OnDisable()
        {
            _tiltAction.performed -= OnTiltPerformed;
            _tiltAction.Disable();
        }

        // ������ ������ �޾ƿ��� �޼���
        private void OnTiltPerformed(InputAction.CallbackContext context)
        {
            // ������ ������ ���� ����
            TiltValue = context.ReadValue<Vector3>();
        }
    }
}
// ������ �ۼ� ����: 2025.04.29
