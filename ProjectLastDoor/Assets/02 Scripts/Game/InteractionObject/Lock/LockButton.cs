using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 자물쇠의 버튼들을 기능을 담당하는 클래스
    public class LockButton : InteractionObjectBase
    {
        [SerializeField] private bool _isCorrectAnswer; // 이 버튼이 눌러야하는 버튼인지 결정하는 변수
        [SerializeField] private float _animationTime; // 색 변경 애니메이션 플레이 타임

        private LockInteraction _lockInteraction; // 부모(자물쇠) 클래스
        private Material _material; // 버튼의 색을 변경하기 위한 변수

        private void Awake()
        {
            _lockInteraction = transform.parent.GetComponent<LockInteraction>(); // 부모, 즉 자물쇠 클래스 가져오기
            _material = GetComponent<Material>(); // 실패와 성공에 따라 버튼의 색 변경을 위한 변수
        }

        public override void Interaction()
        {
            Debug.Log("버튼?");
            if(_lockInteraction.IsLockInteractionOn) // 만약 자물쇠가 상호작용 되어있다면 (그냥 버튼이 눌리는 상황을 방지)
            {
                Debug.Log("버튼 눌림");
                if(!_isCorrectAnswer) // 만약 이 버튼이 올바른 버튼이 아니었을 경우
                {
                    Sequence sequence = DOTween.Sequence(); // 시퀀스 생성
                    sequence.Append(_material.DOColor(Color.red, _animationTime)); // 버튼 색을 붉게 변경
                    sequence.Append(_material.DOColor(Color.white, _animationTime)); // 버튼 색을 다시 흰색으로 변경
                    sequence.AppendCallback(() => _lockInteraction.IsFailed = true); // 애니메이션이 끝난 후 자물쇠에 실패 알리기
                    return; // 그리고 종료
                }

                // 만약 올바른 버튼이었다면
                Sequence sequncen = DOTween.Sequence(); // 시퀀스 생성
                sequncen.Append(_material.DOColor(Color.green, _animationTime)); // 버튼 색을 초록색으로 변경
                _lockInteraction.SuccessCount++; // 성공 개수 증가
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.23