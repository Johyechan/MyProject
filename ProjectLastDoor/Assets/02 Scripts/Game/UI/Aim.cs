using Game.Manager;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MyUI
{
    // 작성자: 조혜찬
    // 에임 UI 클래스
    public class Aim : MonoBehaviour
    {
        [SerializeField] private float _duration; // 페이드 되는데 걸리는 시간

        private Image _image; // 페이드 인, 아웃을 시키기 위한 이미지

        // 변수 초기화
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if(GameManager.Instance.IsNeedMousePos) // 만약 마우스 위치에서 레이를 쏘는 상태라면
            {
                if(_image.color.a == 1) // 현재 에임 UI의 투명도가 1일경우에만
                    _image.DOFade(0, _duration); // 0으로 만들면서 에임 UI 숨기기
            }
            else // 만약 카메라 중앙에서 레이를 쏘는 상태라면
            {
                if(_image.color.a == 0) // 현재 에임 UI의 투명도가 0일 경우에만
                    _image.DOFade(1, _duration); // 1로 만들면서 에임 UI 보이기
            }
        }
    }
}
// 마지막 작성 일자: 2025.06.03
