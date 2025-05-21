using Game.Interface;
using MyUtil;
using UnityEngine;

// 매니저들을 모아둔 네임스페이스
namespace Game.Manager
{
    // 작성자: 조혜찬
    // 게임에 필요한 기능들을 가지고 있는 싱글톤 클래스
    public class GameManager : Singleton<GameManager>, IMyInitializable
    {
        public GameObject Player { get; set; } // 플레이어 객체

        public float Sensitivity { get; set; } // 마우스 감도

        public bool Initialize()
        {
            Sensitivity = 10f; // 감도 초기화

            return true;
        }
    }
}
// 마지막 작성 일자: 2025.05.20
