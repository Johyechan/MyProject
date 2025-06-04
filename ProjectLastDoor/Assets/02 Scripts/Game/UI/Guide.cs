using Game.Manager;
using UnityEngine;

namespace Game.MyUI
{
    // �ۼ���: ������
    // ��ȣ�ۿ� Ű�� �˷��ִ� UI Ŭ����
    public class Guide : MonoBehaviour
    {
        [SerializeField] private float _xPos;
        [SerializeField] private float _yPos;

        private RectTransform _rectTrans;

        private void Awake()
        {
            _rectTrans = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if(GameManager.Instance.IsNeedMousePos) // ���콺 Ŀ���� ���̸� ��� ���¶��
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTrans.parent as RectTransform, Input.mousePosition, null, out Vector2 localPoint); // ���콺 ��ġ�� RectTransform�� ���� ��ǥ�� ����
                _rectTrans.anchoredPosition = localPoint + new Vector2(_xPos, _yPos); // ���콺 ��ġ���� _xPos, _yPos��ŭ ������ �Ÿ��� �̵�
            }
            else
            {
                _rectTrans.anchoredPosition = new Vector3(_xPos, _yPos); // _xPos, _yPos��ġ�� �̵�
            }
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
