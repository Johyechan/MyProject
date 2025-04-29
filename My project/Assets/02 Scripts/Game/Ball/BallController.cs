using UnityEngine;

namespace Game.Ball
{
    // 작성자: 조혜찬
    // 구슬과 관련된 기능들을 모아서 관리하는 클래스
    public class BallController : MonoBehaviour
    {
        // 구슬 인풋 처리 클래스 변수
        private BallInput _ballInput;
        // 구슬 움직임 처리 클래스 변수
        private BallMovement _ballMovement;

        // 초기화: 클래스 변수 초기화
        private void Awake()
        {
            _ballInput = GetComponent<BallInput>();
            _ballMovement = GetComponent<BallMovement>();
        }

        void Start()
        {

        }

        void Update()
        {
            _ballMovement.Move(_ballInput.TiltValue, 1f);
        }
    }
}
// 마지막 작성 일자: 2025.04.29

