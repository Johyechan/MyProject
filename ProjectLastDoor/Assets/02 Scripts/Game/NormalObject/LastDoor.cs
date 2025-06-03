using DG.Tweening;
using Game.Manager;
using UnityEngine;

namespace Game.NormalObject
{
    // 작성자: 조혜찬
    // 마지막 문의 기능을 처리하는 클래스
    public class LastDoor : OpenableObjectBase
    {
        [SerializeField] private float _openRotation; // 열리면서 회전하는 크기
        [SerializeField] private float _rattleRotation; // 덜컹이면서 회전하는 크기

        private float _originRotationY; // 기본 y축 상태

        // 초기화
        protected override void Awake()
        {
            base.Awake();

            _originRotationY = transform.eulerAngles.y;
        }

        public override void Close()
        {
            Debug.Log("마지막 문은 닫는 기능이 존재하지 않습니다");
        }

        public override void Open()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, _openRotation, 0), _animationTime)) // 여는 애니메이션
                .AppendCallback(() => _isOpen = true) // 열린 상태
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // 상호작용 종료
                .AppendCallback(() => GameManager.Instance.IsCurrentLastDoorOpen = true); // 현재 스테이지의 마지막 문이 열림
        }

        public override void Rattle()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, _rattleRotation, 0), _animationTime / 4)) // 당기는 애니메이션
                .Append(transform.DORotate(new Vector3(0, _originRotationY, 0), _animationTime / 4)) // 도로 닫히는 애니메이션
                .Append(transform.DORotate(new Vector3(0, _rattleRotation, 0), _animationTime / 4)) // 당기는 애니메이션
                .Append(transform.DORotate(new Vector3(0, _originRotationY, 0), _animationTime / 4)) // 도로 닫히는 애니메이션
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // 상호작용 종료
        }
    }
}
// 마지막 작성 일자: 2025.06.03
