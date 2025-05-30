using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 상호작용 되지 않은 상태
    public class LockButtonIdleState : LockButtonStateBase
    {
        public LockButtonIdleState(Material material, float animationTime, PushButtonLock pushButtonLock) : base(material, animationTime, pushButtonLock)
        {
        }
    }
}
// 마지막 작성 일자: 2025.05.28
