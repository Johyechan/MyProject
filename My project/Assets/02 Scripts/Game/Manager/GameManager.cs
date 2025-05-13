using MyUtil;
using System;
using UnityEngine;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 게임에서 전체적으로 필요한 기능을 관리하는 싱글톤 클래스
    public class GameManager : Singleton<GameManager>
    {
        // 게임을 클리어 했을 때 해야할 기능들을 담는 이벤트
        public event Action OnClear;

        // 게임이 클리어 됐을 때 이벤트 실행
        public void GameClear()
        {
            OnClear?.Invoke();
        }
    }
}
// 마지막 작성 일자: 2025.05.13
