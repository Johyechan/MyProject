using MyUtil;
using UnityEngine;

// �Ŵ������� ��Ƶ� ���ӽ����̽�
namespace Game.Manager
{
    // �ۼ���: ������
    // ���ӿ� �ʿ��� ��ɵ��� ������ �ִ� �̱��� Ŭ����
    public class GameManager : Singleton<GameManager>
    {
        public float Sensitivity { get; set; }
    }
}

