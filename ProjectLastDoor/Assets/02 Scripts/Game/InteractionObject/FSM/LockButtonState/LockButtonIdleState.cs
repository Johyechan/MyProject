using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 상호작용 되지 않은 상태
    public class LockButtonIdleState : LockButtonStateBase
    {
        public LockButtonIdleState(Material material, float animationTime, LockInteraction lockInteraction) : base(material, animationTime, lockInteraction)
        {
        }
    }
}
// 마지막 작성 일자: 2025.05.28
