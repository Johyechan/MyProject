using MyUtil;
using System;
using UnityEngine;

namespace Game.Manager
{
    // �ۼ���: ������
    // ���ӿ��� ��ü������ �ʿ��� ����� �����ϴ� �̱��� Ŭ����
    public class GameManager : Singleton<GameManager>
    {
        // ������ Ŭ���� ���� �� �ؾ��� ��ɵ��� ��� �̺�Ʈ
        public event Action OnClear;

        // ������ Ŭ���� ���� �� �̺�Ʈ ����
        public void GameClear()
        {
            OnClear?.Invoke();
        }
    }
}
// ������ �ۼ� ����: 2025.05.13
