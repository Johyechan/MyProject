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

        private void OnDisable()
        {
            _inputHandle.OnDisable(); // 인풋 핸들의 비활성화 함수 호출
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

        // 시작 상태 애니메이션이 종료되면 호출될 애니메이션 함수
        private void OnAnimationEnd()
        {
            IsStart = false;

            _rigid.useGravity = true;
            // 인풋이 필요한 시점은 처음 시작 후 애니메이션이 전부 끝나고 난 후이기 때문에 여기서 인풋 함수 활성화
            _inputHandle.OnEnable(); // 인풋 핸들의 비활성화 함수 호출
        }
    }
}
// 마지막 작성 일자: 2025.06.04