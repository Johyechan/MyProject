using Game.Interface;
using UnityEngine;

// 상호작용 객체 기능을 모아둔 네임스페이스
namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 상호작용 객체의 기본 틀을 가지는 추상 클래스
    public abstract class InteractionObjectBase : MonoBehaviour, IInteraction
    {
        public abstract void Interaction(); // 상호작용 함수
    }
}
// 마지막 작성 일자: 2025.05.22
