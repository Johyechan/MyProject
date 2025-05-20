using MyUtil;
using UnityEngine;

// 매니저들을 모아둔 네임스페이스
namespace Game.Manager
{
    // 작성자: 조혜찬
    // 게임에 필요한 기능들을 가지고 있는 싱글톤 클래스
    public class GameManager : Singleton<GameManager>
    {
        public float Sensitivity { get; set; }
    }
}

