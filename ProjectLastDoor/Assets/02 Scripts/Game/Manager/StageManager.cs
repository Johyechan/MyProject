using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace Game.Manager
{
    // �ۼ���: ������
    // ���������� �����Ű�� �Ŵ���
    // ���������� ������ �ʿ��� Ŭ������ �ƴϹǷ� �̱��� Ŭ������ �ƴ�
    public class StageManager : MonoBehaviour
    {
        [SerializeField] private Image _sight;
        [SerializeField] private float _duration;

        private bool _once = false;

        private void Update()
        {
            if(GameManager.Instance.IsCurrentLastDoorOpen && !_once) // ���� ���� ���������� ������ ���� ���� �����̸� + ó���̶��
            {
                StartCoroutine(GoNextStageCo()); // ���� ����������
                _once = true; // ó���� �ƴ��� ���
            }
        }

        private IEnumerator GoNextStageCo()
        {
            Sequence sequence = DOTween.Sequence().SetUpdate(true)
                    .AppendCallback(() => Time.timeScale = 0) // ��� ����
                    .AppendCallback(() => _sight.gameObject.SetActive(true)) // �ϸ� �г� Ȱ��ȭ
                    .Append(_sight.DOFade(1, _duration)); // �ϸ� ���̵� ��

            yield return new WaitForSeconds(1); // �̺κ� ���� �ʱ�ȭ ������Ʈ ����Ʈ���� �ʱ�ȭ �Լ��� ���� true�� �� �Ѿ���� ����

            sequence
                .Append(_sight.DOFade(0, _duration)) // �ϸ� ���̵� �ƿ�
                .AppendCallback(() => _sight.gameObject.SetActive(true)) // �ϸ� �г� ��Ȱ��ȭ
                .AppendCallback(() => GameManager.Instance.IsCurrentLastDoorOpen = false) // �ʱ�ȭ �Ϸ�� ���� ������ ���� �� ���� ���·� ����
                .AppendCallback(() => _once = false) // ���� �ٽ� ���������� ���� ������ ���·� �ʱ�ȭ
                .AppendCallback(() => Time.timeScale = 1); // ���� Ǯ��
        }
    }
}
// ������ �ۼ� ����: 2025.06.03
