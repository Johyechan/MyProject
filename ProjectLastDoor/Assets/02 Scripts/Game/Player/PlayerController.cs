using Game.Manager;
using UnityEngine;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어에게 필요한 기능들을 모아서 처리하는 클래스
    public class PlayerController : PlayerVariables
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(_playerCamTrans.position, _playerCamTrans.forward * _rayDistance);
        }

        // 객체 초기화
        private void Start()
        {
            _machine.ChangeState(_startState); // 첫 상태를 대기 상태로 지정
        }

        private void Update()
        {
            _transitionHandle.CheckTransition(); // 상태 전이 조건 확인

            _machine.UpdateExecute(); // 현재 상태의 실행되어야 할 코드 실행
        }

        // 대기 상태 애니메이션이 종료되면 호출될 애니메이션 함수
        private void OnAnimationEnd()
        {
            IsStart = false;
        }
    }
}
// 마지막 작성 일자: 2025.05.27