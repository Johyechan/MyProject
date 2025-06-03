using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 스테이지를 변경시키는 매니저
    // 전역적으로 접근이 필요한 클래스는 아니므로 싱글톤 클래스는 아님
    public class StageManager : MonoBehaviour
    {
        [SerializeField] private Image _sight;
        [SerializeField] private float _duration;

        private bool _once = false;

        private void Update()
        {
            if(GameManager.Instance.IsCurrentLastDoorOpen && !_once) // 만약 현재 스테이지의 마지막 문이 열린 상태이며 + 처음이라면
            {
                StartCoroutine(GoNextStageCo()); // 다음 스테이지로
                _once = true; // 처음이 아님을 명시
            }
        }

        private IEnumerator GoNextStageCo()
        {
            Sequence sequence = DOTween.Sequence().SetUpdate(true)
                    .AppendCallback(() => Time.timeScale = 0) // 모두 정지
                    .AppendCallback(() => _sight.gameObject.SetActive(true)) // 암막 패널 활성화
                    .Append(_sight.DOFade(1, _duration)); // 암막 페이드 인

            yield return new WaitForSeconds(1); // 이부분 이제 초기화 오브젝트 리스트에서 초기화 함수가 전부 true일 때 넘어가도록 변경

            sequence
                .Append(_sight.DOFade(0, _duration)) // 암막 페이드 아웃
                .AppendCallback(() => _sight.gameObject.SetActive(true)) // 암막 패널 비활성화
                .AppendCallback(() => GameManager.Instance.IsCurrentLastDoorOpen = false) // 초기화 완료로 현재 마지막 문은 안 열린 상태로 변경
                .AppendCallback(() => _once = false) // 이제 다시 스테이지를 변경 가능한 상태로 초기화
                .AppendCallback(() => Time.timeScale = 1); // 정지 풀림
        }
    }
}
// 마지막 작성 일자: 2025.06.03
