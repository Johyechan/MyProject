using DG.Tweening;
using Game.Manager;
using UnityEngine;
using Game.Interface;

namespace Game.NormalObject
{
    // �ۼ���: ������
    // ������ ����� ó���ϴ� Ŭ����
    public class Drawer : OpenableObjectBase
    {
        [SerializeField] private float _openDistance; // �����鼭 �����̴� ����
        [SerializeField] private float _rattleDistance; // ���ȰŸ��鼭 �����̴� ����

        private float _originPosZ; // ���� �⺻ z�� ��ġ

        protected override void Awake()
        {
            base.Awake();

            _originPosZ = transform.position.z; // ������ �⺻ z�� ��ġ ����
        }

        // ���� ���� �Լ�
        public override void Open()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DOMoveZ(transform.position.z + _openDistance, _animationTime)) // ������
                .AppendCallback(() => _isOpen = true) // ���� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // ��ȣ�ۿ� ����
        }

        // ���� �ݴ� �Լ�
        public override void Close()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DOMoveZ(_originPosZ, _animationTime)) // ������
                .AppendCallback(() => _isOpen = false) // ���� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // ��ȣ�ۿ� ����
        }

        // ���� ���ȰŸ��� �Լ�
        public override void Rattle()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DOMoveZ(transform.position.z + _rattleDistance, _animationTime / 5)) // _rattleDistance��ŭ ���Դٰ�
                .Append(transform.DOMoveZ(transform.position.z - _rattleDistance, _animationTime / 5)) // _rattleDistance��ŭ ���ٰ�
                .Append(transform.DOMoveZ(transform.position.z + _rattleDistance, _animationTime / 5)) // _rattleDistance��ŭ ���Դٰ�
                .Append(transform.DOMoveZ(transform.position.z - _rattleDistance, _animationTime / 5)) // _rattleDistance��ŭ ���ٰ�
                .Append(transform.DOMoveZ(_originPosZ, _animationTime / 5)) // �����ߴ� �⺻ ������ ��ġ�� ���ƿ���
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false);// ��ȣ�ۿ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.02
