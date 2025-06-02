using UnityEngine;

namespace Game.Interface
{
    // 작성자: 조혜찬
    // 문, 서랍 등 열고 닫는 오브젝트의 기능 인터페이스
    public interface IOpenableObject
    {
        public bool IsOpen(); // 열렸는지 확인하는 함수

        public void Open(); // 여는 함수

        public void Close(); // 닫는 함수

        public void Rattle(); // 덜컹이는 함수
    }
}
// 마지막 작성 일자: 2025.06.02
