using Game.Interface;
using MyUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Manager
{
    // �ۼ���: ������
    // ��ǲ�� ���õ� ��ɵ��� ó���ϴ� �̱��� Ŭ����
    public class InputManager : Singleton<InputManager>, IMyInitializable
    {
        [SerializeField] private InputActionAsset _myGameInputAsset; // ���� �� ��ǲ ����

        private Dictionary<string, InputActionMap> _inputActionMaps = new(); // ��ǲ �� ��ųʸ�
        private Dictionary<string, InputAction> _inputActions = new(); // ��ǲ �׼� ��ųʸ�

        public bool IsInitialized { get; private set; }

        public bool Initialize()
        {
            foreach (var map in _myGameInputAsset.actionMaps) // ���¿� �ִ� ���� ��ȸ
            {
                _inputActionMaps.Add(map.name, map); // ��ųʸ��� �Ҵ�

                foreach (var action in map.actions) // �ʿ� �ִ� �׼��� ��ȸ
                {
                    _inputActions.Add(action.name, action); // ��ųʸ��� �Ҵ�
                }
            }

            return true;
        }

        // �ʱ�ȭ
        protected override void Awake()
        {
            IsInitialized = false;

            base.Awake();

            IsInitialized = true;
        }

        // ��ǲ ���� Ȱ��ȭ ���� ���� �Լ�
        public void WaitAndEnable(bool IsEnable, float delay = 0)
        {
            StartCoroutine(WaitAndEnableCo(delay, IsEnable));
        }

        // n�� �� ��ǲ ���� Ȱ��ȭ ���� ���� �ڷ�ƾ
        private IEnumerator WaitAndEnableCo(float delay, bool IsEnable)
        {
            yield return new WaitForSeconds(delay); // n�� ��

            if (IsEnable) // Ȱ��ȭ���
                _myGameInputAsset.Enable(); // Ȱ��ȭ
            else // ��Ȱ��ȭ���
                _myGameInputAsset.Disable();
        }

        // ���ϴ� �׼��� �θ��� �Լ�
        public InputAction GetInputAction(string key)
        {
            if(_inputActions.TryGetValue(key, out InputAction action))
            {
                return action;
            }

            Debug.LogWarning($"InputAction {key} not found");
            return null;
        }

        // �� �Ǵ� �׼��� Ȱ��ȭ, ��Ȱ��ȭ ��Ű�� �Լ�
        public void InputSetEnable(string key, bool IsMap, bool IsEnable)
        {
            if(IsMap) // ���� Ȱ��ȭ ���θ� �����ϴ� ���̶��
            {
                if (_inputActionMaps.TryGetValue(key, out InputActionMap map)) // ��ǲ �� ��ųʸ� �� key���� �����Ѵٸ� ���� out
                {
                    if (IsEnable) // Ȱ��ȭ���
                    {
                        map.Enable(); // �� Ȱ��ȭ
                    }
                    else // �ƴ϶��
                    {
                        map.Disable(); // �� ��Ȱ��ȭ
                    }
                }
            }
            else // �׼��� Ȱ��ȭ ���θ� �����ϴ� ���̶��
            {
                if (_inputActions.TryGetValue(key, out InputAction action)) // ��ǲ �׼� ��ųʸ� �� key���� �����Ѵٸ� �׼��� out
                {
                    if (IsEnable) // Ȱ��ȭ���
                    {
                        action.Enable(); // �׼� Ȱ��ȭ
                    }
                    else // �ƴ϶��
                    {
                        action.Disable(); // �׼� ��Ȱ��ȭ
                    }
                }
            }

            Debug.LogWarning($"InputActionMap {key} not Found");
        }
    }
}
// ������ �ۼ� ����: 2025.05.20