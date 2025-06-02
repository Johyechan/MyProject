using UnityEngine;

namespace Game.Interface
{
    // �ۼ���: ������
    // ��, ���� �� ���� �ݴ� ������Ʈ�� ��� �������̽�
    public interface IOpenableObject
    {
        public bool IsOpen(); // ���ȴ��� Ȯ���ϴ� �Լ�

        public void Open(); // ���� �Լ�

        public void Close(); // �ݴ� �Լ�

        public void Rattle(); // �����̴� �Լ�
    }
}
// ������ �ۼ� ����: 2025.06.02
