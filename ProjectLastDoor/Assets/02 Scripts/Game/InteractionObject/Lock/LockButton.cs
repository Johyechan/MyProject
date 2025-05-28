using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // �ڹ����� ��ư���� ����� ����ϴ� Ŭ����
    public class LockButton : InteractionObjectBase
    {
        [SerializeField] private bool _isCorrectAnswer; // �� ��ư�� �������ϴ� ��ư���� �����ϴ� ����
        [SerializeField] private float _animationTime; // �� ���� �ִϸ��̼� �÷��� Ÿ��

        private LockInteraction _lockInteraction; // �θ�(�ڹ���) Ŭ����
        private Material _material; // ��ư�� ���� �����ϱ� ���� ����

        private void Awake()
        {
            _lockInteraction = transform.parent.GetComponent<LockInteraction>(); // �θ�, �� �ڹ��� Ŭ���� ��������
            _material = GetComponent<Material>(); // ���п� ������ ���� ��ư�� �� ������ ���� ����
        }

        public override void Interaction()
        {
            Debug.Log("��ư?");
            if(_lockInteraction.IsLockInteractionOn) // ���� �ڹ��谡 ��ȣ�ۿ� �Ǿ��ִٸ� (�׳� ��ư�� ������ ��Ȳ�� ����)
            {
                Debug.Log("��ư ����");
                if(!_isCorrectAnswer) // ���� �� ��ư�� �ùٸ� ��ư�� �ƴϾ��� ���
                {
                    Sequence sequence = DOTween.Sequence(); // ������ ����
                    sequence.Append(_material.DOColor(Color.red, _animationTime)); // ��ư ���� �Ӱ� ����
                    sequence.Append(_material.DOColor(Color.white, _animationTime)); // ��ư ���� �ٽ� ������� ����
                    sequence.AppendCallback(() => _lockInteraction.IsFailed = true); // �ִϸ��̼��� ���� �� �ڹ��迡 ���� �˸���
                    return; // �׸��� ����
                }

                // ���� �ùٸ� ��ư�̾��ٸ�
                Sequence sequncen = DOTween.Sequence(); // ������ ����
                sequncen.Append(_material.DOColor(Color.green, _animationTime)); // ��ư ���� �ʷϻ����� ����
                _lockInteraction.SuccessCount++; // ���� ���� ����
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.23