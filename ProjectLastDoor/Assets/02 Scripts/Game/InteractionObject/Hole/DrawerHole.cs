using Game.Manager;
using Game.Player;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 열쇠 구멍 클래스
    public class DrawerHole : InteractionObjectBase
    {
        [SerializeField] private Transform _drawer; // 서랍 전체
        [SerializeField] private int _holeNumber; // 열쇠 고유 번호와 비교할 열쇠 구멍 고유 번호
        [SerializeField] private float _openDistance; // 열리면서 움직이는 길이
        [SerializeField] private float _rattleDistance; // 덜컹거리면서 움직이는 길이
        [SerializeField] private float _animationTime; // 애니메이션 시간

        public override void Interaction()
        {
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>(); // 플레이어가 가지고 있는 열쇠(고유 번호)를 알기 위해 가져옴
            Sequence sequence = DOTween.Sequence();

            foreach (int keyNumber in player.KeyNumbers)
            {
                if(_holeNumber == keyNumber)
                {
                    sequence
                        .Append(_drawer.DOMoveZ(_drawer.position.z + _openDistance, _animationTime))// 열리는 애니메이션 실행
                        .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // 상호작용 종료
                    return;
                }
            }

            sequence // 덜컹거리는 애니메이션 실행
                .Append(_drawer.DOMoveZ(_drawer.position.z + _rattleDistance, _animationTime / 4)) // _rattleDistance만큼 나왔다가
                .Append(_drawer.DOMoveZ(_drawer.position.z - _rattleDistance, _animationTime / 4)) // _rattleDistance만큼 들어갔다가
                .Append(_drawer.DOMoveZ(_drawer.position.z + _rattleDistance, _animationTime / 4)) // _rattleDistance만큼 나왔다가
                .Append(_drawer.DOMoveZ(_drawer.position.z - _rattleDistance, _animationTime / 4)) // _rattleDistance만큼 들어갔다가
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false);// 상호작용 종료
        }
    }

}
// 마지막 작성 일자: 2025.05.30