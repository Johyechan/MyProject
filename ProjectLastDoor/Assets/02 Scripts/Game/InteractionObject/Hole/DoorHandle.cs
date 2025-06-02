using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 문 손잡이 클래스
    public class DoorHandle : HandleBase
    {
        public override void Interaction()
        {
            if (_openableObject.IsOpen()) // 문이 열린 상태라면
            {
                _openableObject.Close(); // 닫기
            }
            else
            {
                if (HasRightKey()) // 맞는 열쇠(번호)가 있다면
                {
                    _openableObject.Open(); // 열기
                }
                else
                {
                    _openableObject.Rattle(); // 덜컹이기
                }
            }
        }
    }
}
// 마지막 작성 일자: 2025.06.02
