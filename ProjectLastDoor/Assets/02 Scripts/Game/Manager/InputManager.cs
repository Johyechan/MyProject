using Game.Interface;
using MyUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 인풋과 관련된 기능들을 처리하는 싱글톤 클래스
    public class InputManager : Singleton<InputManager>, IMyInitializable
    {
        [SerializeField] private InputActionAsset _myGameInputAsset; // 게임 내 인풋 에셋

        private Dictionary<string, InputActionMap> _inputActionMaps = new(); // 인풋 맵 딕셔너리
        private Dictionary<string, InputAction> _inputActions = new(); // 인풋 액션 딕셔너리

        public bool IsInitialized { get; private set; }

        public bool Initialize()
        {
            foreach (var map in _myGameInputAsset.actionMaps) // 에셋에 있는 맵을 순회
            {
                _inputActionMaps.Add(map.name, map); // 딕셔너리에 할당

                foreach (var action in map.actions) // 맵에 있는 액션을 순회
                {
                    _inputActions.Add(action.name, action); // 딕셔너리에 할당
                }
            }

            return true;
        }

        // 초기화
        protected override void Awake()
        {
            IsInitialized = false;

            base.Awake();

            IsInitialized = true;
        }

        // 인풋 에셋 활성화 여부 결정 함수
        public void WaitAndEnable(bool IsEnable, float delay = 0)
        {
            StartCoroutine(WaitAndEnableCo(delay, IsEnable));
        }

        // n초 후 인풋 에셋 활성화 여부 결정 코루틴
        private IEnumerator WaitAndEnableCo(float delay, bool IsEnable)
        {
            yield return new WaitForSeconds(delay); // n초 후

            if (IsEnable) // 활성화라면
                _myGameInputAsset.Enable(); // 활성화
            else // 비활성화라면
                _myGameInputAsset.Disable();
        }

        // 원하는 액션을 부르는 함수
        public InputAction GetInputAction(string key)
        {
            if(_inputActions.TryGetValue(key, out InputAction action))
            {
                return action;
            }

            Debug.LogWarning($"InputAction {key} not found");
            return null;
        }

        // 맵 또는 액션을 활성화, 비활성화 시키는 함수
        public void InputSetEnable(string key, bool IsMap, bool IsEnable)
        {
            if(IsMap) // 맵의 활성화 여부를 결정하는 것이라면
            {
                if (_inputActionMaps.TryGetValue(key, out InputActionMap map)) // 인풋 맵 딕셔너리 내 key값이 존재한다면 맵을 out
                {
                    if (IsEnable) // 활성화라면
                    {
                        map.Enable(); // 맵 활성화
                    }
                    else // 아니라면
                    {
                        map.Disable(); // 맵 비활성화
                    }
                }
            }
            else // 액션의 활성화 여부를 결정하는 것이라면
            {
                if (_inputActions.TryGetValue(key, out InputAction action)) // 인풋 액션 딕셔너리 내 key값이 존재한다면 액션을 out
                {
                    if (IsEnable) // 활성화라면
                    {
                        action.Enable(); // 액션 활성화
                    }
                    else // 아니라면
                    {
                        action.Disable(); // 액션 비활성화
                    }
                }
            }

            Debug.LogWarning($"InputActionMap {key} not Found");
        }
    }
}
// 마지막 작성 일자: 2025.05.20