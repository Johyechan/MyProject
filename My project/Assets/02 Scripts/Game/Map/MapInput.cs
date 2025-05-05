using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Map
{
    // �ۼ���: ������
    // ���� ��ǲ ó���ϴ� Ŭ����
    public class MapInput : MonoBehaviour
    {
        // �� ��ǲ ����
        [SerializeField] private InputActionAsset _mapInputAsset;
        // "Gameplay" �׼� ���� ����
        private InputActionMap _gameplayMap;
        // ������ �������� üũ�ϴ� "Tilt" �׼�
        private InputAction _tiltAction;

        // ������ ������ ������ ������Ƽ
        public Vector3 TiltValue { get; private set; }

        // ó�� ������ �ִ� ������ �⺻ ������ �����ϱ� ���� ���� ��
        private Vector3 _initTiltValue = Vector3.zero;

        // �ʱ�ȭ: ��ǲ �׼� �ʰ� �׼� ã��
        private void Awake()
        {
            // "Gameplay" �׼� ���� ã��, �� �ȿ��� "Tilt" �׼��� ã��
            _gameplayMap = _mapInputAsset.FindActionMap("Gameplay", true);
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
            Vector3 currentTilt = context.ReadValue<Vector3>();

            // �ڵ����� ���� ���¸� �⺻ ���·� ����� ���� ���� ���� �� ó������ �ϱ� ���� zero�� �� �ʱ�ȭ
            if (_initTiltValue == Vector3.zero)
            {
                ResetTilt(currentTilt);
            }

            // Ư�� ������ ���� �����ϴ� ������ ���� ������ ������ �� ���� ���� ������ ������ �Ǵ�
            TiltValue = currentTilt - _initTiltValue;
        }

        // ���� ������ ���¸� �⺻ ������ �ʱ�ȭ �ϱ� ���� �Լ�
        public void ResetTilt(Vector3 currentTilt)
        {
            // ���� ������ �� ���� ���� ������ �ʱ�ȭ
            _initTiltValue = currentTilt;
        }
    }
}
// ������ �ۼ� ����: 2025.05.05
