using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Game.Manager;
using Game.Player;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 열쇠 클래스
    // 문을 여는 열쇠: 1
    // 서랍을 여는 열쇠(맨 위부터 순차적으로 2, 3, 4....)
    public class Key : InteractionObjectBase
    {
        [SerializeField] private int keyNumber; // 열쇠 고유 번호
        [SerializeField] private Image _image; // 열쇠 획득 시 획득 신호를 줄 UI
        [SerializeField] private float _fadeDelay; // UI 페이드 인, 아웃 딜레이
        [SerializeField] private float _changeDelay; // UI 페이드 인에서 아웃되는 애니메이션을 실행하기 전까지의 딜레이
        
        private Material _material; // 자기자신의 메테리얼

        protected override void Awake()
        {
            base.Awake();

            _material = GetComponent<Renderer>().material;
        }

        public override void Interaction()
        {
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>();

            Sequence sequence = DOTween.Sequence()
                .Append(_material.DOFade(0, 0.1f)) // 열쇠 객체 숨기기
                .AppendCallback(() => player.KeyNumbers.Add(keyNumber))
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // 상호작용 종료(다른 행동이 가능한 상태로 변경)
                .AppendCallback(() => _image.gameObject.SetActive(true)) // UI 활성화
                .Append(_image.DOFade(1, _fadeDelay)) // _fadeDelay동안 페이드 인
                .Insert(_changeDelay, _image.DOFade(0, _fadeDelay)) // _changeDelay만큼 대기 후 _fadeDelay동안 페이드 아웃
                .AppendCallback(() => _image.gameObject.SetActive(true)) // UI 비활성화
                .AppendCallback(() => Destroy(gameObject)); // 열쇠 객체 파괴 (고유 번호를 넘김으로 이제 쓸모를 다함)
        }
    }
}
// 마지막 작성 일자: 2025.05.30
