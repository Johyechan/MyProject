using UnityEngine;

// 플레이어와 관련된 기능들을 모아둔 네임스페이스
namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어의 움직임을 처리하는 클래스
    public class PlayerMovement
    {
        private Transform _playerTrans; // 플레이어의 Transform
        private float _moveSpeed; // 이동 속도

        // 생성자에서 변수 초기화
        public PlayerMovement(Transform playerTrans, float moveSpeed)
        {
            _playerTrans = playerTrans;
            _moveSpeed = moveSpeed;
        }

        public void Move(Vector2 moveInput)
        {
            _playerTrans.Translate(new Vector3(moveInput.x, 0, moveInput.y) * _moveSpeed * Time.deltaTime, Space.World); // Vector2로 이동 벡터를 받았기 때문에 x축은 같지만 매개변수의 y축을 z축의 이동으로 지정 + 부모의 움직임에 관여받지 않기 위해 Space를 월드로 설정
        }
    }
}
// 마지막 작성 일자: 2025.05.19