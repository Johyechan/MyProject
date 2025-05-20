using MyUtil;
using UnityEngine;

// �Ŵ������� ��Ƶ� ���ӽ����̽�
namespace Game.Manager
{
    // �ۼ���: ������
    // ���ӿ� �ʿ��� ��ɵ��� ������ �ִ� �̱��� Ŭ����
    public class GameManager : Singleton<GameManager>
    {
        public GameObject Player { get; private set; } // �÷��̾� ��ü

        public float Sensitivity { get; set; } // ���콺 ����

        protected override void Awake()
        {
            base.Awake();

            Player = GameObject.Find("Player"); // �÷��̾� �ʱ�ȭ
        }
    }
}
// ������ �ۼ� ����: 2025.05.20
