using UnityEngine;

// 상호작용 객체 기능들을 모아둔 네임스페이스
namespace Game.InteractionObject
{
    // 자물쇠의 상호작용을 처리하는 클래스
    public class LockInteraction : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; private set; } // 자물쇠 상호작용이 되었는지 여부

        public bool IsFailed { get; set; } // 실패 여부 판단

        public int SuccessCount { get; set; } // 

        // 변수 초기화
        private void Awake()
        {
            IsLockInteractionOn = false;
            IsFailed = false;
            SuccessCount = 0;
        }

        // 상호작용 함수
        public override void Interaction() 
        {
            IsLockInteractionOn = true; // 자물쇠 상호작용 O
            ChangeChannel(); // 메인 카메라의 시네머신 브레인 채널 변경

        }
    }
}
// 마지막 작성 일자: 2025.05.23