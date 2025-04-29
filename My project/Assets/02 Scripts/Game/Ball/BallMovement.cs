using UnityEngine;

namespace Game.Ball
{
    // 작성자: 조혜찬
    // 공의 움직임을 처리하는 클래스
    public class BallMovement : MonoBehaviour
    {
        // 물리적인 움직임을 가지기 위한 물리엔진 변수
        private Rigidbody _rigid;

        // 초기화: 물리엔진 초기화
        private void Awake()
        {
            // 구슬 객체의 물리엔진 가져오기
            _rigid = GetComponent<Rigidbody>();
            // 마찰력 계수 설정
            _rigid.linearDamping = 0.5f;
        }

        // 기울어진 방향으로 속도만큼 구슬을 움직이도록 하는 움직임 함수
        public void Move(Vector3 tilt, float speed)
        {
            _rigid.AddForce(tilt.normalized * speed);
        }
    }
}
// 마지막 작성 일자: 2025.04.29