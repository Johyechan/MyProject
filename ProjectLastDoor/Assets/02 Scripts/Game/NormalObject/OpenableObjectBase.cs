using Game.Interface;
using UnityEngine;

namespace Game.NormalObject
{
    // �ۼ���: ������
    // ������ ������ ��ü�� �θ� Ŭ����
    public abstract class OpenableObjectBase : MonoBehaviour, IOpenableObject
    {
        [SerializeField] protected float _animationTime; // �ִϸ��̼� �ð�

        protected bool _isOpen; // ����, ���� Ȯ�� ����

        protected virtual void Awake()
        {
            _isOpen = false; // ���� ����
        }

        // �ݴ� �Լ�
        public abstract void Close();

        // ���� �Լ�
        public abstract void Open();

        // �����̴� �Լ�
        public abstract void Rattle();

        public bool IsOpen()
        {
            return _isOpen; // ����, ���� Ȯ�� ���� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.06.02
