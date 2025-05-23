using Game.Interface;
using MyUtil;
using UnityEngine;

// �Ŵ������� ��Ƶ� ���ӽ����̽�
namespace Game.Manager
{
    // �ۼ���: ������
    // ���ӿ� �ʿ��� ��ɵ��� ������ �ִ� �̱��� Ŭ����
    public class GameManager : Singleton<GameManager>, IMyInitializable
    {
        public GameObject Player { get; set; } // �÷��̾� ��ü

        public float Sensitivity { get; set; } // ���콺 ����

        public bool OnInteraction { get; set; } // ��ȣ�ۿ� ����

        public bool Initialize()
        {
            Sensitivity = 10f; // ���� �ʱ�ȭ
            OnInteraction = false; // ��ȣ�ۿ� ���� �ƴ� ����

            return true;
        }
    }
}
// ������ �ۼ� ����: 2025.05.23
