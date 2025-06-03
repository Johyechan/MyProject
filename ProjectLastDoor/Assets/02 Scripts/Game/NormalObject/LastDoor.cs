using DG.Tweening;
using Game.Manager;
using UnityEngine;

namespace Game.NormalObject
{
    // �ۼ���: ������
    // ������ ���� ����� ó���ϴ� Ŭ����
    public class LastDoor : OpenableObjectBase
    {
        [SerializeField] private float _openRotation; // �����鼭 ȸ���ϴ� ũ��
        [SerializeField] private float _rattleRotation; // �����̸鼭 ȸ���ϴ� ũ��

        private float _originRotationY; // �⺻ y�� ����

        // �ʱ�ȭ
        protected override void Awake()
        {
            base.Awake();

            _originRotationY = transform.eulerAngles.y;
        }

        public override void Close()
        {
            Debug.Log("������ ���� �ݴ� ����� �������� �ʽ��ϴ�");
        }

        public override void Open()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, _openRotation, 0), _animationTime)) // ���� �ִϸ��̼�
                .AppendCallback(() => _isOpen = true) // ���� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // ��ȣ�ۿ� ����
                .AppendCallback(() => GameManager.Instance.IsCurrentLastDoorOpen = true); // ���� ���������� ������ ���� ����
        }

        public override void Rattle()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, _rattleRotation, 0), _animationTime / 4)) // ���� �ִϸ��̼�
                .Append(transform.DORotate(new Vector3(0, _originRotationY, 0), _animationTime / 4)) // ���� ������ �ִϸ��̼�
                .Append(transform.DORotate(new Vector3(0, _rattleRotation, 0), _animationTime / 4)) // ���� �ִϸ��̼�
                .Append(transform.DORotate(new Vector3(0, _originRotationY, 0), _animationTime / 4)) // ���� ������ �ִϸ��̼�
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // ��ȣ�ۿ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.03
