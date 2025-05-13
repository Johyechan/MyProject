using Game.Interface;
using Game.Struct;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    // �ۼ���: ������
    // UI �ִϸ��̼ǵ��� �������� ��ɵ��� ������ �߻�(�θ�) Ŭ����
    public abstract class UIAnimationBase : IUIAnimation
    {
        // �ڷ�ƾ�� �����Ű�� ���� ����
        protected MonoBehaviour _mono;

        // ���� ���� ���� �ڷ�ƾ�� ���� �� �ʿ��� �� ���� ��Ű�� ���� ���� �ڷ�ƾ ���� ���� 
        protected Coroutine _currentCo;

        // UI�� �����ϱ� ���ؼ� �ʿ��� ����
        protected RectTransform _rectTrans;

        // �ִϸ��̼� ���� �ð�
        protected float _duration;

        // �����ڿ��� ���� �ʱ�ȭ
        public UIAnimationBase(UIAnimationVariables animationVariables)
        {
            _mono = animationVariables.mono;
            _rectTrans = animationVariables.rectTrans;
            _duration = animationVariables.duration;
        }

        // �ڷ�ƾ ���� �� ���� �ڷ�ƾ ���� ������ ���� + ����
        public virtual void Play()
        {
            _currentCo = _mono.StartCoroutine(UIAnimationCo());
        }

        // ���� �ڷ�ƾ ������ ����� �ڷ�ƾ ����
        public void Stop()
        {
            if (_currentCo != null)
                _mono.StopCoroutine(_currentCo);
        }

        // �ڽĿ��� �����ϵ��� ����
        public abstract IEnumerator UIAnimationCo();
    }
}
// ������ �ۼ� ����: 2025.05.13
