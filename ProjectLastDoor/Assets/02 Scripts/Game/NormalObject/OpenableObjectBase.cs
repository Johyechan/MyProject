using Game.Interface;
using UnityEngine;

namespace Game.NormalObject
{
    // 작성자: 조혜찬
    // 열리고 닫히는 객체의 부모 클래스
    public abstract class OpenableObjectBase : MonoBehaviour, IOpenableObject
    {
        [SerializeField] protected float _animationTime; // 애니메이션 시간

        protected bool _isOpen; // 열림, 닫힘 확인 변수

        protected virtual void Awake()
        {
            _isOpen = false; // 닫힌 상태
        }

        // 닫는 함수
        public abstract void Close();

        // 여는 함수
        public abstract void Open();

        // 덜컹이는 함수
        public abstract void Rattle();

        public bool IsOpen()
        {
            return _isOpen; // 열림, 닫힘 확인 변수 반환
        }
    }
}
// 마지막 작성 일자: 2025.06.02
