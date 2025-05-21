using Game.Interface;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 로딩과 관련된 기능들을 모아둔 네임스페이스
namespace Game.Loading
{
    // 작성자: 조혜찬
    // 로딩 기능을 처리하는 클래스
    public class LoadingSystem : MonoBehaviour
    {
        [SerializeField] private Slider _loadingSlider; // 로딩 바
        [SerializeField] private TMP_Text _loadingText; // 로딩 텍스트
        [SerializeField] private List<GameObject> _initializeGameObjectList = new(); // 초기화 인터페이스를 가지는 객체 리스트

        private List<IMyInitializable> _myInitializables = new(); // 초기화 인터페이스 리스트

        private int count = 0; // 몇 개의 객체가 초기화가 완료되었는지 확인하는 변수

        private void Awake()
        {
            foreach(var obj in _initializeGameObjectList) // 초기화 인터페이스를 가지는 객체 리스트 순회
            {
                if(obj.TryGetComponent(out IMyInitializable myInitialize)) // 초기화 인터페이스를 가지고 있는지 확인 및 해당 객체의 초기화 인터페이스 변수 out
                {
                    _myInitializables.Add(myInitialize); // 초기화 인터페이스 리스트에 추가
                }
            }

            StartCoroutine(InitializeCo()); // 초기화 시작
        }

        private void Update()
        {
            if(_loadingSlider.value == 1) // 만약 로딩 바가 최대가 되었다면 씬 변경
            {
                SceneManager.LoadScene("Play");
            }

            if(count == 0)
            {
                _loadingSlider.value = 0;
            }
            else
            {
                _loadingSlider.value = _myInitializables.Count / count; // 로딩 바 갱신 value = (기존 초기화 해야할 객체 수 / 현재 초기화된 객체 수)
            }
            _loadingText.text =  $"[{count} / {_myInitializables.Count}]"; // 로딩 텍스트 갱신 텍스트 = [현재 초기화 된 객체수 / 기존 초기화 해야할 객체 수] 
        }

        // 초기화 코루틴
        private IEnumerator InitializeCo()
        {
            foreach(var myInit in  _myInitializables) // 초기화 인터페이스 리스트 순회
            {
                yield return new WaitUntil(() => myInit.Initialize()); // 초기화가 완료될 때까지 대기

                count++; // 완료되었다면 확인 변수 증가
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.21