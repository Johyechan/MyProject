using Game.Interface;
using Game.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    // �ۼ���: ������
    // ��ȣ�ۿ��� ó���ϴ� Ŭ����
    public class PlayerInteractionRaycaster
    {
        private Image _guideImage; // �� Ŭ���ؾ� ��ȣ�ۿ� �Ǵ��� �˷��ִ� ���̵� ����

        private float _rayDistance; // ��ȣ�ۿ� ��ü ���� �Ÿ�

        private IInteraction _currentInteraction; // ���� ��ȣ�ۿ�

        public PlayerInteractionRaycaster(Image guideImage, float rayDistance)
        {
            _guideImage = guideImage;
            _rayDistance = rayDistance;
        }

        // ��ȣ�ۿ� ��ü ���� ���� üũ �Լ�
        public bool IsOnInteractionObject(bool needMousePos = false)
        {
            Ray ray;
            if (!needMousePos) // ���� ���콺�� �ʿ����� �ʴٸ�
                ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // �÷��̾� ī�޶󿡼� forward�� ���� ������ ����
            else // ���콺 �������� �ʿ��ϴٸ�
                ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 Ŀ�� �������� ����

            if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, LayerMask.GetMask("Interaction"))) // ���� ��ȣ�ۿ��� �Ǵ� ��ü�� ��´ٸ�
            {
                GameManager.Instance.IsInteractionObjectFind = true; // ��ȣ�ۿ� ���� ������Ʈ�� ���� ��
                _guideImage.gameObject.SetActive(true); // ���̵� ���� Ȱ��ȭ

                if (hit.transform.TryGetComponent(out IInteraction interaction)) // ��ȣ�ۿ� �������̽��� ������ �� �ִ��� Ȯ��
                {
                    _currentInteraction = interaction; // ���� ��ȣ�ۿ� ����
                }

                return true; // ��ȣ�ۿ� ��ü ���� �� ��ȯ
            }
            else // �ƴ϶��
            {
                GameManager.Instance.IsInteractionObjectFind = false; // ��ȣ�ۿ� ���� ������Ʈ�� ���� ����
                _guideImage.gameObject.SetActive(false); // ���̵� ���� ��Ȱ��ȭ

                return false; // ��ȣ�ۿ� ��ü ���� ���� ��ȯ
            }
        }

        // ��ȣ�ۿ� ���� �Լ�
        public void PlayInteraction()
        {
            _currentInteraction.Interaction(); // ��ȣ�ۿ� �Լ� ȣ��
            _guideImage.gameObject.SetActive(false); // ���̵� ���� ��Ȱ��ȭ
        }
    }
}
// ������ �ۼ� ����: 2025.05.22
