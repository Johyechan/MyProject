using DG.Tweening;
using Game.Manager;
using UnityEngine;
using Game.Interface;

namespace Game.NormalObject
{
    // 작성자: 조혜찬
    // 서랍의 기능을 처리하는 클래스
    public class Drawer : OpenableObjectBase
    {
        [SerializeField] private float _openDistance; // 열리면서 움직이는 길이
        [SerializeField] private float _rattleDistance; // 덜컹거리면서 움직이는 길이

        private float _originPosZ; // 서랍 기본 z축 위치

        protected override void Awake()
        {
            base.Awake();

            _originPosZ = transform.position.z; // 서랍의 기본 z축 위치 저장
        }

        // 서랍 여는 함수
        public override void Open()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DOMoveZ(transform.position.z + _openDistance, _animationTime)) // 열리기
                .AppendCallback(() => _isOpen = true) // 열린 상태
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // 상호작용 종료
        }

        // 서랍 닫는 함수
        public override void Close()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DOMoveZ(_originPosZ, _animationTime)) // 닫히기
                .AppendCallback(() => _isOpen = false) // 닫힌 상태
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // 상호작용 종료
        }

        // 서랍 덜컹거리는 함수
        public override void Rattle()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DOMoveZ(transform.position.z + _rattleDistance, _animationTime / 5)) // _rattleDistance만큼 나왔다가
                .Append(transform.DOMoveZ(transform.position.z - _rattleDistance, _animationTime / 5)) // _rattleDistance만큼 들어갔다가
                .Append(transform.DOMoveZ(transform.position.z + _rattleDistance, _animationTime / 5)) // _rattleDistance만큼 나왔다가
                .Append(transform.DOMoveZ(transform.position.z - _rattleDistance, _animationTime / 5)) // _rattleDistance만큼 들어갔다가
                .Append(transform.DOMoveZ(_originPosZ, _animationTime / 5)) // 저장했던 기본 서랍의 위치로 돌아오기
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false);// 상호작용 종료
        }
    }
}
// 마지막 작성 일자: 2025.06.02
