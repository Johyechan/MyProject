using Game.Interface;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾�� ���õ� ����� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // ��ȣ�ۿ��� ó���ϴ� Ŭ����
    public class PlayerInteractionRaycaster : MonoBehaviour
    {
        private Transform _playerCam; // �÷��̾� ī�޶�

        private Image _guideImage; // �� Ŭ���ؾ� ��ȣ�ۿ� �Ǵ��� �˷��ִ� ���̵� ����

        private float _rayDistance; // ��ȣ�ۿ� ��ü ���� �Ÿ�

        private IInteraction _currentInteraction; // ���� ��ȣ�ۿ�

        public PlayerInteractionRaycaster(Transform playerCam, Image guideImage, float rayDistance)
        {
            _playerCam = playerCam;
            _guideImage = guideImage;
            _rayDistance = rayDistance;
        }

        // ��ȣ�ۿ� ��ü ���� ���� üũ �Լ�
        public bool IsOnInteractionObject()
        {
            Ray ray = new Ray(_playerCam.transform.position, _playerCam.transform.forward); // �÷��̾� ī�޶󿡼� forward�� ���� ������ ����

            if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, LayerMask.GetMask("Interaction"))) // ���� ��ȣ�ۿ��� �Ǵ� ��ü�� ��´ٸ�
            {
                _guideImage.gameObject.SetActive(true); // ���̵� ���� Ȱ��ȭ

                if (hit.transform.TryGetComponent(out IInteraction interaction)) // ��ȣ�ۿ� �������̽��� ������ �� �ִ��� Ȯ��
                {
                    _currentInteraction = interaction; // ���� ��ȣ�ۿ� ����
                }

                return true; // ��ȣ�ۿ� ��ü ���� �� ��ȯ
            }
            else // �ƴ϶��
            {
                _guideImage.gameObject.SetActive(false); // ���̵� ���� ��Ȱ��ȭ

                return false; // ��ȣ�ۿ� ��ü ���� ���� ��ȯ
            }
        }

        // ��ȣ�ۿ� ���� �Լ�
        public void PlayInteraction()
        {
            _currentInteraction.Interaction(); // ��ȣ�ۿ� �Լ� ȣ��
        }
    }
}
// ������ �ۼ� ����: 2025.05.22
