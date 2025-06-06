using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 숫자 자물쇠의 돌아가는 숫자 고리 클래스
    public class LockRing : LockTypeBase
    {
        [SerializeField] private float _rotateDuration; // 회전 시간
        [SerializeField] private float _successNumber; // 정답 숫자

        private RingLock _numberLock; // 부모 클래스

        private bool _isCorrect; // 정답 상태였다가 아닐 때 빼주고 정답 상태가 아니었던 상태에서 또 빼는 것을 막기 위한 변수

        // 초기화
        protected override void Awake()
        {
            base.Awake();

            _isCorrect = false;
            _numberLock = transform.parent.GetComponent<RingLock>();
        }

        // 회전에 따른 번호를 반환하는 함수
        private int RotationCalculator()
        {
            int number = 0;

            if(transform.rotation.eulerAngles.y > 0) // 만약 양수일 경우 + 왜 여기만 들어오지 음....
            {
                Debug.Log($"양수 {transform.rotation.eulerAngles.y}");
                number = (int)(transform.rotation.eulerAngles.y / 36); // 0~9 즉 10가지의 수를 구하기 위해서 -> (정수형으로 강제 형변환) 현재 회전 값 / (360을 10으로 나눈 값인)36을 합니다
                Debug.Log($"양수 번호 {number}");
                return number * 2; // 나온 값에 두 배를 해줘서 큰 번호들을 반환
            }
            else
            {
                Debug.Log($"음수 {transform.rotation.eulerAngles.y}");
                number = (int)(transform.rotation.eulerAngles.y / 36); // 0~9 즉 10가지의 수를 구하기 위해서 -> (정수형으로 강제 형변환) 현재 회전 값 / (360을 10으로 나눈 값인)36을 합니다
                Debug.Log($"음수 번호 {number}");
                return number; // 나온 값 그대로 번호들을 반환
            }
        }

        public override void Interaction()
        {
            if(_numberLock.IsLockInteractionOn) // 만약 자물쇠가 상호작용된 상태라면
            {
                float currentRotation = transform.rotation.eulerAngles.y; // 현재 회전 값을 euler값을 가져오기(rotation은 Quaternion값이라서 오류가 생김)
                transform.DORotate(new Vector3(0, currentRotation - 36f, 0), _rotateDuration); // 현재 회전 값 - 36만큼 _rotateDuration동안 회전한 값으로 회전

                if(RotationCalculator() == _successNumber) // 만약 정답이라면
                {
                    Debug.Log("답 입니다");
                    _numberLock.SuccessCount++; // 성공 카운트 늘려주기
                    _isCorrect = true; // 그리고 정답이라고 선언
                }
                else // 만약 정답 숫자가 아니라면
                {
                    if(_isCorrect) // 그리고 이전에 정답이었다면
                    {
                        _numberLock.SuccessCount--; // 다시 성공 카운트 줄여주기
                        _isCorrect = false; // 그리고 정답이 아니라고 선언
                    }
                }
            }
        }
    }
}
// 마지막 작성 일자: 2025.06.06
