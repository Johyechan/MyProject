using UnityEngine;

namespace Game.Player.FSM
{
    // 작성자: 조혜찬
    // 시작(플레이어가 처음 깨어난 시점) 상태
    public class PlayerStartState : PlayerStateBase
    {
        private Animator _animator;

        public PlayerStartState(Animator animator)
        {
            _animator = animator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            // 애니메이션 실행
            _animator.enabled = true;
        }

        public override void OnExit()
        {
            base.OnExit();

            // 애니메이션  종료
            _animator.enabled = false;
        }
    }
}
// 마지막 작성 일자: 2025.05.27
