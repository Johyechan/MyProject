using UnityEngine;
using DG.Tweening;

// ��ȣ�ۿ� ��ü ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.InteractionObject
{
    // �ۼ���: ������
    // �ڹ����� ��ư���� ����� ����ϴ� Ŭ����
    public class LockButton : InteractionObjectBase
    {
        [SerializeField] private bool _isCorrectAnswer; // �� ��ư�� �������ϴ� ��ư���� �����ϴ� ����
        [SerializeField] private float _animationTime; // �� ���� �ִϸ��̼� �÷��� Ÿ��

        private LockInteraction _lockInteraction; // �θ�(�ڹ���) Ŭ����
        private SpriteRenderer _spriteRenderer; // ��ư�� ���� �����ϱ� ���� ����

        private void Awake()
        {
            _lockInteraction = transform.parent.GetComponent<LockInteraction>(); // �θ�, �� �ڹ��� Ŭ���� ��������
            _spriteRenderer = GetComponent<SpriteRenderer>(); // ���п� ������ ���� ��ư�� �� ������ ���� ����
        }

        public override void Interaction()
        {
            if(_lockInteraction.IsLockInteractionOn) // ���� �ڹ��谡 ��ȣ�ۿ� �Ǿ��ִٸ� (�׳� ��ư�� ������ ��Ȳ�� ����)
            {
                if(!_isCorrectAnswer) // ���� �� ��ư�� �ùٸ� ��ư�� �ƴϾ��� ���
                {
                    Sequence sequence = DOTween.Sequence(); // ������ ����
                    sequence.Append(_spriteRenderer.DOColor(Color.red, _animationTime)); // ��ư ���� �Ӱ� ����
                    sequence.Append(_spriteRenderer.DOColor(Color.white, _animationTime)); // ��ư ���� �ٽ� ������� ����
                    sequence.AppendCallback(() => _lockInteraction.IsFailed = true); // �ִϸ��̼��� ���� �� �ڹ��迡 ���� �˸���
                    return; // �׸��� ����
                }

                // ���� �ùٸ� ��ư�̾��ٸ�
                Sequence sequncen = DOTween.Sequence();
                sequncen.Append(_spriteRenderer.DOColor(Color.green, _animationTime)); // ��ư ���� �Ӱ� ����
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.23