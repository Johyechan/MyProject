using Game.Manager;
using Game.Player;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ���� ���� Ŭ����
    public class DrawerHole : InteractionObjectBase
    {
        [SerializeField] private Transform _drawer; // ���� ��ü
        [SerializeField] private int _holeNumber; // ���� ���� ��ȣ�� ���� ���� ���� ���� ��ȣ
        [SerializeField] private float _openDistance; // �����鼭 �����̴� ����
        [SerializeField] private float _rattleDistance; // ���ȰŸ��鼭 �����̴� ����
        [SerializeField] private float _animationTime; // �ִϸ��̼� �ð�

        public override void Interaction()
        {
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>(); // �÷��̾ ������ �ִ� ����(���� ��ȣ)�� �˱� ���� ������
            Sequence sequence = DOTween.Sequence();

            foreach (int keyNumber in player.KeyNumbers)
            {
                if(_holeNumber == keyNumber)
                {
                    sequence
                        .Append(_drawer.DOMoveZ(_drawer.position.z + _openDistance, _animationTime))// ������ �ִϸ��̼� ����
                        .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // ��ȣ�ۿ� ����
                    return;
                }
            }

            sequence // ���ȰŸ��� �ִϸ��̼� ����
                .Append(_drawer.DOMoveZ(_drawer.position.z + _rattleDistance, _animationTime / 4)) // _rattleDistance��ŭ ���Դٰ�
                .Append(_drawer.DOMoveZ(_drawer.position.z - _rattleDistance, _animationTime / 4)) // _rattleDistance��ŭ ���ٰ�
                .Append(_drawer.DOMoveZ(_drawer.position.z + _rattleDistance, _animationTime / 4)) // _rattleDistance��ŭ ���Դٰ�
                .Append(_drawer.DOMoveZ(_drawer.position.z - _rattleDistance, _animationTime / 4)) // _rattleDistance��ŭ ���ٰ�
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false);// ��ȣ�ۿ� ����
        }
    }

}
// ������ �ۼ� ����: 2025.05.30