using DG.Tweening;
using Game.Struct;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    // �ۼ���: ������
    // UI �˾� �ִϸ��̼��� ������ Ŭ����
    public class UIPopupAnimation : UIAnimationBase
    {
        // ���� ��ǥ ����
        private Vector3 _targetPos;

        // �߰� ��ǥ ������ ������ֱ� ���� ����
        private Vector3 _overPos;

        // �߰� ��ǥ �������� ���µ� �ɸ��� �ð� ����
        private float _overMoveDuration;

        // ������ ����
        public UIPopupAnimation(UIAnimationVariables animationVariables, UIPopupAnimationVariables popupVariables) : base(animationVariables)
        {
            _targetPos = popupVariables.targetPos;
            _overPos = popupVariables.overPos;
            _overMoveDuration = popupVariables.overMoveDuration;
        }

        public override IEnumerator UIAnimationCo()
        {
            // DOTween�� ����Ͽ� Ư�� UI�� ��ǥ���� ���� �� ���� �ִϸ��̼� ���� �ð����� ���� ������ �̵�
            // ���� �ٽ� ��ǥ���� ���� �ִϸ��̼� ���� �ð���ŭ �̵�
            // ���ϰ� Ƣ�� ������ �ֱ� ���ؼ� �̷� ������ ����
            Sequence sequence = DOTween.Sequence()
                .Append(_rectTrans.DOMove(_targetPos + _overPos, _overMoveDuration))
                .Append(_rectTrans.DOMove(_targetPos, _duration - _overMoveDuration));

            yield return null;
        }
    }
}
// ������ �ۼ� ����: 2025.05.13
