using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Game.Manager;
using Game.Player;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ���� Ŭ����
    // ���� ���� ����: 1
    // ������ ���� ����(�� ������ ���������� 2, 3, 4....)
    public class Key : InteractionObjectBase
    {
        [SerializeField] private int keyNumber; // ���� ���� ��ȣ
        [SerializeField] private Image _image; // ���� ȹ�� �� ȹ�� ��ȣ�� �� UI
        [SerializeField] private float _fadeDelay; // UI ���̵� ��, �ƿ� ������
        [SerializeField] private float _changeDelay; // UI ���̵� �ο��� �ƿ��Ǵ� �ִϸ��̼��� �����ϱ� �������� ������
        
        private Material _material; // �ڱ��ڽ��� ���׸���

        protected override void Awake()
        {
            base.Awake();

            _material = GetComponent<Renderer>().material;
        }

        public override void Interaction()
        {
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>();

            Sequence sequence = DOTween.Sequence()
                .Append(_material.DOFade(0, 0.1f)) // ���� ��ü �����
                .AppendCallback(() => player.KeyNumbers.Add(keyNumber))
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // ��ȣ�ۿ� ����(�ٸ� �ൿ�� ������ ���·� ����)
                .AppendCallback(() => _image.gameObject.SetActive(true)) // UI Ȱ��ȭ
                .Append(_image.DOFade(1, _fadeDelay)) // _fadeDelay���� ���̵� ��
                .Insert(_changeDelay, _image.DOFade(0, _fadeDelay)) // _changeDelay��ŭ ��� �� _fadeDelay���� ���̵� �ƿ�
                .AppendCallback(() => _image.gameObject.SetActive(true)) // UI ��Ȱ��ȭ
                .AppendCallback(() => Destroy(gameObject)); // ���� ��ü �ı� (���� ��ȣ�� �ѱ����� ���� ���� ����)
        }
    }
}
// ������ �ۼ� ����: 2025.05.30
