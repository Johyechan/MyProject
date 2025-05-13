using Game.Struct;
using UnityEngine;

namespace Game.UI
{
    // �ۼ���: ������
    // UI ��Ʈ�ѷ��� ����� �Ǵ� Ŭ����
    public class UIControllerBase : MonoBehaviour
    {
        [SerializeField] protected RectTransform _uiRectTrans;
        [SerializeField] protected float _duration;

        // �⺻������ UI �ִϸ��̼ǿ��� �ʿ�� �ϴ� ���� ����ü
        protected UIAnimationVariables _animationVariables;


        // ����ü �ʱ�ȭ
        protected virtual void Init()
        {
            _animationVariables = new UIAnimationVariables();
            _animationVariables.mono = this;
            _animationVariables.rectTrans = _uiRectTrans;
            _animationVariables.duration = _duration;
        }
    }
}
// ������ �ۼ� ����: 2025.05.13
