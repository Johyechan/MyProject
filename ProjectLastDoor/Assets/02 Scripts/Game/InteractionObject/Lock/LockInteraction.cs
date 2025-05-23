using Game.Manager;
using UnityEngine;

// 상호작용 객체 기능들을 모아둔 네임스페이스
namespace Game.InteractionObject
{
    // 자물쇠의 상호작용을 처리하는 클래스
    public class LockInteraction : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; private set; } // 자물쇠 상호작용이 되었는지 여부

        public bool IsFailed { get; set; } // 실패 여부 판단

        public int SuccessCount { get; set; } // 성공 개수 카운트 변수

        [SerializeField] private int _successGoal;

        private void Update()
        {
            if (!IsLockInteractionOn) // 상호작용 중이 아니라면
                return; // 반환

            if(IsFailed) // 실패했다면
            {
                Failed(); // 실패 함수 실행
            }

            if(SuccessCount >= _successGoal) // 성공했다면
            {
                Success(); // 성공 함수 실행
            }
        }

        // 상호작용 함수
        public override void Interaction() 
        {
            IsFailed = false;
            SuccessCount = 0;
            IsLockInteractionOn = true; // 자물쇠 상호작용 O
            GameManager.Instance.IsNeedMousePos = true; // 마우스 커서 위치로 레이를 쏴야함 선언
            ChangeChannel(); // 메인 카메라의 시네머신 브레인 채널 변경
        }

        // 자물쇠 열기를 실패 했을 때 함수
        private void Failed()
        {
            // 소리 출력 - 철컹거리는 소리
            ChangeChannel(false); // 원래 채널로 변경
            IsLockInteractionOn = false; // 자물쇠 상호작용 끝
            GameManager.Instance.IsNeedMousePos = false; // 마우스 커서 위치로 레이를 쏘지 않아도 됨 선언
            GameManager.Instance.IsInteractionOn = false; // 상호작용 끝
        }

        // 자물쇠 열기를 성공 했을 때 함수
        private void Success()
        {
            ChangeChannel(false); // 원래 채널로 변경
            IsLockInteractionOn = false; // 자물쇠 상호작용 끝
            GameManager.Instance.IsNeedMousePos = false; // 마우스 커서 위치로 레이를 쏘지 않아도 됨 선언
            GameManager.Instance.IsInteractionOn = false; // 상호작용 끝
        }
    }
}
// 마지막 작성 일자: 2025.05.23