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
        public bool IsInteractionObjectFind { get; set; } // 상호작용 되는 오브젝트 감지 여부
        public bool IsNeedMousePos { get; set; } // 레이를 쏠 때 마우스 커서 위치가 필요한지 여부

        public bool IsCurrentLastDoorOpen { get; set; } // 현재 스테이지의 마지막 문이 열렸는지 체크하는 변수

        public string InteractionLayerName { get; set; } // 상호작용 레이어 명

        public bool Initialize()
        {
            Sensitivity = 10f; // 감도 초기화
            IsInteractionOn = false; // 상호작용 중 아님 선언
            IsInteractionObjectFind = false; // 감지 못함 선언
            IsNeedMousePos = false; // 필요없음
            IsCurrentLastDoorOpen = false; // 현재 스테이지의 마지막 문이 아직 안 열림
            InteractionLayerName = "Interaction";

            return true;
        }
    }
}
// 마지막 작성 일자: 2025.06.03
