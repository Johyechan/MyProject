using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // �ڹ��� ��ư, �� ��� ���� ������ �ڹ��踦 ���µ� ���Ǵ� ��ü�� �θ� Ŭ����
    public abstract class LockTypeBase : InteractionObjectBase
    {
        public bool IsSuccess { get; set; } // ���� ���� üũ ����
        public bool IsFailed { get; set; } // ���� ���� üũ ����
    }
}
// ������ �ۼ� ����: 2025.06.06

