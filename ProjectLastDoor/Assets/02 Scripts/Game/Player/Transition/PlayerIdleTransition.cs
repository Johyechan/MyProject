using MyUtil.Transition;
using UnityEngine;

// 플레이어 전이 네임스페이스
namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 대기 상태로 전이하는 클래스
    public class PlayerIdleTransition : ITransition
    {
        public bool IsTransition()
        {
            return true;
        }
    }
}
// 마지막 작성 일자: 2025.05.27
