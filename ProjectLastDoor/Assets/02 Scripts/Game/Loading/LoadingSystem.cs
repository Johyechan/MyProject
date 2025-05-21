using Game.Interface;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// �ε��� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Loading
{
    // �ۼ���: ������
    // �ε� ����� ó���ϴ� Ŭ����
    public class LoadingSystem : MonoBehaviour
    {
        [SerializeField] private Slider _loadingSlider; // �ε� ��
        [SerializeField] private TMP_Text _loadingText; // �ε� �ؽ�Ʈ
        [SerializeField] private List<GameObject> _initializeGameObjectList = new(); // �ʱ�ȭ �������̽��� ������ ��ü ����Ʈ

        private List<IMyInitializable> _myInitializables = new(); // �ʱ�ȭ �������̽� ����Ʈ

        private int count = 0; // �� ���� ��ü�� �ʱ�ȭ�� �Ϸ�Ǿ����� Ȯ���ϴ� ����

        private void Awake()
        {
            foreach(var obj in _initializeGameObjectList) // �ʱ�ȭ �������̽��� ������ ��ü ����Ʈ ��ȸ
            {
                if(obj.TryGetComponent(out IMyInitializable myInitialize)) // �ʱ�ȭ �������̽��� ������ �ִ��� Ȯ�� �� �ش� ��ü�� �ʱ�ȭ �������̽� ���� out
                {
                    _myInitializables.Add(myInitialize); // �ʱ�ȭ �������̽� ����Ʈ�� �߰�
                }
            }

            StartCoroutine(InitializeCo()); // �ʱ�ȭ ����
        }

        private void Update()
        {
            if(_loadingSlider.value == 1) // ���� �ε� �ٰ� �ִ밡 �Ǿ��ٸ� �� ����
            {
                SceneManager.LoadScene("Play");
            }

            if(count == 0)
            {
                _loadingSlider.value = 0;
            }
            else
            {
                _loadingSlider.value = _myInitializables.Count / count; // �ε� �� ���� value = (���� �ʱ�ȭ �ؾ��� ��ü �� / ���� �ʱ�ȭ�� ��ü ��)
            }
            _loadingText.text =  $"[{count} / {_myInitializables.Count}]"; // �ε� �ؽ�Ʈ ���� �ؽ�Ʈ = [���� �ʱ�ȭ �� ��ü�� / ���� �ʱ�ȭ �ؾ��� ��ü ��] 
        }

        // �ʱ�ȭ �ڷ�ƾ
        private IEnumerator InitializeCo()
        {
            foreach(var myInit in  _myInitializables) // �ʱ�ȭ �������̽� ����Ʈ ��ȸ
            {
                yield return new WaitUntil(() => myInit.Initialize()); // �ʱ�ȭ�� �Ϸ�� ������ ���

                count++; // �Ϸ�Ǿ��ٸ� Ȯ�� ���� ����
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.21