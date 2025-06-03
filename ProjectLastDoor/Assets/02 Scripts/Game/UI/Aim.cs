using Game.Manager;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MyUI
{
    // �ۼ���: ������
    // ���� UI Ŭ����
    public class Aim : MonoBehaviour
    {
        [SerializeField] private float _duration; // ���̵� �Ǵµ� �ɸ��� �ð�

        private Image _image; // ���̵� ��, �ƿ��� ��Ű�� ���� �̹���

        // ���� �ʱ�ȭ
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if(GameManager.Instance.IsNeedMousePos) // ���� ���콺 ��ġ���� ���̸� ��� ���¶��
            {
                if(_image.color.a == 1) // ���� ���� UI�� ������ 1�ϰ�쿡��
                    _image.DOFade(0, _duration); // 0���� ����鼭 ���� UI �����
            }
            else // ���� ī�޶� �߾ӿ��� ���̸� ��� ���¶��
            {
                if(_image.color.a == 0) // ���� ���� UI�� ������ 0�� ��쿡��
                    _image.DOFade(1, _duration); // 1�� ����鼭 ���� UI ���̱�
            }
        }
    }
}
// ������ �ۼ� ����: 2025.06.03
