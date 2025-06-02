using Game.Manager;
using Game.Player;
using UnityEngine;
using Game.NormalObject;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ���� ������ Ŭ����
    public class DrawerHandle : HandleBase
    {
        public override void Interaction()
        {
            if(_openableObject.IsOpen()) // ������ ���� ���¶��
            {
                _openableObject.Close(); // �ݱ�
            }
            else
            {
                if(HasRightKey()) // �´� ����(��ȣ)�� �ִٸ�
                {
                    _openableObject.Open(); // ����
                }
                else
                {
                    _openableObject.Rattle(); // �����̱�
                }
            }
        }
    }

}
// ������ �ۼ� ����: 2025.06.02