using Game.Manager;
using Game.NormalObject;
using Game.Player;
using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 손잡이 부모 클래스
    public abstract class HandleBase : InteractionObjectBase
    {
        [SerializeField] protected OpenableObjectBase _openableObject; // 서랍, 문 등
        [SerializeField] protected int _holeNumber; // 열쇠 고유 번호와 비교할 열쇠 구멍 고유 번호

        protected bool HasRightKey()
        {
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>(); // 플레이어가 가지고 있는 열쇠(고유 번호)를 알기 위해 가져옴

            foreach(int number in player.KeyNumbers) // 플레이어가 가진 열쇠 번호 순회
            {
                if(number == _holeNumber) // 일치하는 번호가 있다면
                {
                    return true; // 열림
                }
            }

            return false; // 닫힘
        }
    }
}
// 마지막 작성 일자: 2025.06.02
