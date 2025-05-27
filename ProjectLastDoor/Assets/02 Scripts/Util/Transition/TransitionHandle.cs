using System.Collections.Generic;
using UnityEngine;

// Transition ���ӽ����̽�
namespace MyUtil.Transition
{
    // �ۼ���: ������
    // Transition�� �����ϴ� Ŭ����
    public class TransitionHandle
    {
        private List<ITransition> _transitions; // Transition ����Ʈ
        
        // �����ڿ��� ���� �ʱ�ȭ
        public TransitionHandle(List<ITransition> transitions)
        {
            _transitions = transitions;
        }

        // Transition���� ��ȸ�ϸ� ������ Ȯ���ϴ� �Լ�
        public bool CheckTransition()
        {
            foreach(ITransition transtion in _transitions) // ����Ʈ�� �ִ� Transition ��ȸ
            {
                if (transtion.IsTransition()) // ���� ������ ������ ���¶��
                    return true; // true ��ȯ
            }

            return false; // ��� ��ȸ ���� �� �� �� ���� ������ ������ ���°� �ƴ϶�� false ��ȯ 
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
