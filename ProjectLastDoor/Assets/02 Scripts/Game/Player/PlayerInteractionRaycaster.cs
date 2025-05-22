using Game.Interface;
using UnityEngine;
using UnityEngine.UI;

// 플레이어와 관련된 기능을 모아둔 네임스페이스
namespace Game.Player
{
    // 작성자: 조혜찬
    // 상호작용을 처리하는 클래스
    public class PlayerInteractionRaycaster : MonoBehaviour
    {
        private Transform _playerCam; // 플레이어 카메라

        private Image _guideImage; // 뭘 클릭해야 상호작용 되는지 알려주는 가이드 사진

        private float _rayDistance; // 상호작용 객체 감지 거리

        private IInteraction _currentInteraction; // 현재 상호작용

        public PlayerInteractionRaycaster(Transform playerCam, Image guideImage, float rayDistance)
        {
            _playerCam = playerCam;
            _guideImage = guideImage;
            _rayDistance = rayDistance;
        }

        // 상호작용 객체 감지 여부 체크 함수
        public bool IsOnInteractionObject()
        {
            Ray ray = new Ray(_playerCam.transform.position, _playerCam.transform.forward); // 플레이어 카메라에서 forward로 뻗는 형태의 레이

            if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, LayerMask.GetMask("Interaction"))) // 만약 상호작용이 되는 객체와 닿는다면
            {
                _guideImage.gameObject.SetActive(true); // 가이드 사진 활성화

                if (hit.transform.TryGetComponent(out IInteraction interaction)) // 상호작용 인터페이스를 가져올 수 있는지 확인
                {
                    _currentInteraction = interaction; // 현재 상호작용 갱신
                }

                return true; // 상호작용 객체 감지 함 반환
            }
            else // 아니라면
            {
                _guideImage.gameObject.SetActive(false); // 가이드 사진 비활성화

                return false; // 상호작용 객체 감지 못함 반환
            }
        }

        // 상호작용 실행 함수
        public void PlayInteraction()
        {
            _currentInteraction.Interaction(); // 상호작용 함수 호출
        }
    }
}
// 마지막 작성 일자: 2025.05.22
