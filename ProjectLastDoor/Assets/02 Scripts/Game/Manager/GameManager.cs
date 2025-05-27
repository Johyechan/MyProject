using Game.Interface;
using MyUtil;
using UnityEngine;

namespace Game.Manager
{
    // �ۼ���: ������
    // ���ӿ� �ʿ��� ��ɵ��� ������ �ִ� �̱��� Ŭ����
    public class GameManager : Singleton<GameManager>, IMyInitializable
    {
        public GameObject Player { get; set; } // �÷��̾� ��ü

        public float Sensitivity { get; set; } // ���콺 ����

        public bool IsInteractionOn { get; set; } // ��ȣ�ۿ� ����
        public bool IsNeedMousePos { get; set; } // ���̸� �� �� ���콺 Ŀ�� ��ġ�� �ʿ����� ����

        public bool Initialize()
        {
            Sensitivity = 10f; // ���� �ʱ�ȭ
            IsInteractionOn = false; // ��ȣ�ۿ� �� �ƴ� ����
            IsNeedMousePos = false; // �ʿ����

            return true;
        }
    }
}
// ������ �ۼ� ����: 2025.05.23
