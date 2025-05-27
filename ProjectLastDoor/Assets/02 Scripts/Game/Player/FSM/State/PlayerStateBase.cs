using MyUtil.FSM;
using UnityEngine;

namespace Game.Player.FSM
{
    // 작성자: 조혜찬
    // 플레이어 상태의 기틀
    public class PlayerStateBase : IState
    {
        private string _name;

        public virtual void OnEnter()
        {
            _name = GetType().Name;
            Debug.Log($"{_name} 상태로 들어옴");
        }

        public virtual void OnExecute()
        {
            Debug.Log($"{_name} 실행 중");
        }

        public virtual void OnExit()
        {
            Debug.Log($"{_name} 상태 나감");
        }
    }
}
// 마지막 작성 일자: 2025.05.26
