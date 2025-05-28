using Game.Interface;
using Game.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 상호작용을 처리하는 클래스
    public class PlayerInteractionRaycaster
    {
        private Image _guideImage; // 뭘 클릭해야 상호작용 되는지 알려주는 가이드 사진

        private float _rayDistance; // 상호작용 객체 감지 거리

        private IInteraction _currentInteraction; // 현재 상호작용

        public PlayerInteractionRaycaster(Image guideImage, float rayDistance)
        {
            _guideImage = guideImage;
            _rayDistance = rayDistance;
        }

        // 상호작용 객체 감지 여부 체크 함수
        public bool IsOnInteractionObject(bool needMousePos = false)
        {
            Ray ray;
            if (!needMousePos) // 만약 마우스가 필요하지 않다면
                ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // 플레이어 카메라에서 forward로 뻗는 형태의 레이
            else // 마우스 포지션이 필요하다면
                ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 커서 방향으로 레이

            if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, LayerMask.GetMask("Interaction"))) // 만약 상호작용이 되는 객체와 닿는다면
            {
                GameManager.Instance.IsInteractionObjectFind = true; // 상호작용 가능 오브젝트를 감지 함
                _guideImage.gameObject.SetActive(true); // 가이드 사진 활성화

                if (hit.transform.TryGetComponent(out IInteraction interaction)) // 상호작용 인터페이스를 가져올 수 있는지 확인
                {
                    _currentInteraction = interaction; // 현재 상호작용 갱신
                }

                return true; // 상호작용 객체 감지 함 반환
            }
            else // 아니라면
            {
                GameManager.Instance.IsInteractionObjectFind = false; // 상호작용 가능 오브젝트를 감지 못함
                _guideImage.gameObject.SetActive(false); // 가이드 사진 비활성화

                return false; // 상호작용 객체 감지 못함 반환
            }
        }

        // 상호작용 실행 함수
        public void PlayInteraction()
        {
            _currentInteraction.Interaction(); // 상호작용 함수 호출
            _guideImage.gameObject.SetActive(false); // 가이드 사진 비활성화
        }
    }
}
// 마지막 작성 일자: 2025.05.22
