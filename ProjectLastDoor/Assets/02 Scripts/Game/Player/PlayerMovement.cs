using Game.Manager;
using UnityEngine;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어의 움직임을 처리하는 클래스
    public class PlayerMovement
    {
        private Transform _playerTrans; // 플레이어의 Transform
        private Transform _playerCamTrans; // 플레이어의 눈 역할을 하는 카메라 Transform
        private float _moveSpeed; // 이동 속도

        // 생성자에서 변수 초기화
        public PlayerMovement(Transform playerTrans, Transform playerCamTrans, float moveSpeed)
        {
            _playerTrans = playerTrans;
            _playerCamTrans = playerCamTrans;
            _moveSpeed = moveSpeed;
        }

        // 움직이는 함수
        public void Move(Vector2 moveInput)
        {
            Vector3 moveDir = _playerTrans.forward.normalized * moveInput.y + _playerTrans.right.normalized * moveInput.x; // 플레이어가 바라보고 있는 방향을 기준으로 움직임 + Vector2로 이동 벡터를 받았기 때문에 x축(right)은 같지만 매개변수의 y축을 z축(forward)의 이동으로 지정
            _playerTrans.Translate(moveDir * _moveSpeed * Time.deltaTime, Space.World); //  부모의 움직임에 관여받지 않기 위해 Space를 월드로 설정
        }

        // 움직이는 방향을 바라보게 하는 함수
        public void Look(Vector2 lookDirection)
        {
            // 카메라의 x축만 회전하여 상하를 살필 수 있도록 함 + y축 앞에 '-'를 붙이는 이유는 마우스 좌표계와 유니티 좌표계가 반대이기 때문(예) 마우스를 위로 올리면 양수 값 양수 값이면 유니티에서는 아래로 회전함 그래서 -를 붙이면 마우스가 움직이는 방향에 맞게) 
            _playerCamTrans.Rotate(new Vector3(-lookDirection.y, 0, 0) * GameManager.Instance.Sensitivity * Time.deltaTime);

            // 플레이어의 y축만 회전하여 좌우를 살필 수 있도록 함
            _playerTrans.Rotate(new Vector3(0, lookDirection.x, 0) * GameManager.Instance.Sensitivity * Time.deltaTime);
        }
    }
}
// 마지막 작성 일자: 2025.05.21