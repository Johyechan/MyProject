using System.Collections;
using UnityEngine;

namespace Game.Interface
{
    // �ۼ���: ������
    // UI �ִϸ��̼ǵ��� �⺻������ ��� �޴� �������̽�
    public interface IUIAnimation
    {
        // �ִϸ��̼��� ���� ��Ű�� �Լ�
        public void Play();

        // �ִϸ��̼��� ���� ��Ű�� �Լ�
        public void Stop();

        // ���� �ִϸ��̼��� ������ �ڷ�ƾ
        public IEnumerator UIAnimationCo();
    }
}
// ������ �ۼ� ����: 2025.05.13
