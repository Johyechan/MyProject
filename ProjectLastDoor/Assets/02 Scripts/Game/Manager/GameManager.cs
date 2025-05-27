using Game.Interface;
using MyUtil;
using UnityEngine;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 게임에 필요한 기능들을 가지고 있는 싱글톤 클래스
    public class GameManager : Singleton<GameManager>, IMyInitializable
    {
        public GameObject Player { get; set; } // 플레이어 객체

        public float Sensitivity { get; set; } // 마우스 감도

        public bool IsInteractionOn { get; set; } // 상호작용 여부
        public bool IsNeedMousePos { get; set; } // 레이를 쏠 때 마우스 커서 위치가 필요한지 여부

        public bool Initialize()
        {
            Sensitivity = 10f; // 감도 초기화
            IsInteractionOn = false; // 상호작용 중 아님 선언
            IsNeedMousePos = false; // 필요없음

            return true;
        }
    }
}
// 마지막 작성 일자: 2025.05.23
