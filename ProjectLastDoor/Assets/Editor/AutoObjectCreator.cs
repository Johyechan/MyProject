using UnityEngine;
using UnityEditor;

// 자동으로 오브젝트를 생성시키는 개발 툴
public class AutoObjectCreator : EditorWindow
{
    private GameObject prefabToSpawn; // 생성할 프리팹
    private Transform parentTrans; // 부모 Transform

    private int row = 3; // 기본 행
    private int col = 3; // 기본 열
    private int[,] spawnGrid; // 배열

    private float spacing = 2f; // 기본 간격
    private Vector3 spawnScale = Vector3.one; // 기본 크기

    [MenuItem("Tools/Editable Auto Spawner")] // Unity 에디터 상단 메뉴 바에 메뉴 항목 추가
    public static void ShowWindow() // 창 여는 static 함수
    {
        GetWindow<AutoObjectCreator>("Editable Auto Spawner"); // 내가 만든 클래스 타입, 이름은 Editable Auto Spawner인 창 띄우기
    }

    private void OnEnable() // 활성화 되었을 때
    {
        InitGrid(); // 배열 설정
    }

    private void InitGrid()
    {
        spawnGrid = new int[row, col]; // 새로운 행열의 배열 생성

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                spawnGrid[i, j] = 0; // 전부 0으로 초기화
            }
        }
    }

    private void OnGUI() // 화면에 UI를 새로 그리고 사용자의 입력도 처리하는 함수
    {
        GUILayout.Label("배열 크기 설정", EditorStyles.boldLabel); // 이름 및 설명, 두꺼운 스타일의 글자

        int newRow = EditorGUILayout.IntField("행(Row, 세로)", row); // int형 입력 칸 (이름, 값) 
        int newCol = EditorGUILayout.IntField("열(Col, 가로)", col); // int형 입력 칸 (이름, 값)

        if(newRow != row || newCol != col) // 만약 새로운 행 또는 열이 기존과 다르다면
        {
            row = Mathf.Max(1, newRow); // 1과 새로운 값 중 큰 값을 선택 (1 미만은 설정 불가)
            col = Mathf.Max(1, newCol); // 1과 새로운 값 중 큰 값을 선택 (1 미만은 설정 불가)
            InitGrid(); // 배열 초기화
        }

        GUILayout.Space(10); // 세로 간격 띄우기

        GUILayout.Label("표 (클릭해서 0, 1 토글)", EditorStyles.boldLabel); // 설명(이름), 두꺼운 스타일의 글자

        for(int i = 0; i < row; i++) // 행(세로) 순회
        {
            EditorGUILayout.BeginHorizontal(); // 가로형태로 배치 시작
            for(int j = 0; j < col; j++) // 열(가로) 순회하며 위에서 가로 형태로 UI를 그리게 되어 가로로 잘 그려짐
            {
                string label = spawnGrid[i, j] == 1 ? "1" : "0"; // 만약 배열 값이 1이라면 1을 아니라면 0을 쓰기
                if(GUILayout.Button(label, GUILayout.Width(25), GUILayout.Height(25))) // label이 써져있는 가로, 세로 25 크기의 버튼을 눌렀다면
                {
                    spawnGrid[i, j] = spawnGrid[i, j] == 1 ? 0 : 1; // 만약 배열이 1이면 0으로 0이었다면 1로 배열 값을 변경
                }
            }
            EditorGUILayout.EndHorizontal(); // 가로형태 배치 종료, 다시 세로로 그리기
        }

        GUILayout.Space(10); // 10만큼 아래로 띄우기

        prefabToSpawn = (GameObject)EditorGUILayout.ObjectField("생성할 프리팹", prefabToSpawn, typeof(GameObject), false); // 게임 오브젝트 형태로 Object타입을 형변환하며 오브젝트 타입의 값 받기(설명(이름), 현재 할당된 값(변경 전 값) *전달하는 이유는 사용자가 현재 선택된 값을 알게 하기 위해서, 어떤 타입의 오브젝트를 받는 필드인지, 씬 오브젝트 허용 여부 false면 프로젝트 자산만 허용)
        parentTrans = (Transform)EditorGUILayout.ObjectField("부모 오브젝트", parentTrans, typeof(Transform), true); // Transform 형태로 Object 타입을 형변환하며 오브젝트 타입의 값 받기(설명(이름), 현재 할당된 값(변경 전 값) *전달하는 이유는 사용자가 현재 선택된 값을 알게 하기 위해서, 어떤 타입의 오브젝트를 받는 필드인지, 씬 오브젝트 허용 여부 false면 프로젝트 자산만 허용)
        spacing = EditorGUILayout.FloatField("간격", spacing); // 실수 형태의 값을 받는 필드로 이름(설명), 그리고 현재 값 
        spawnScale = EditorGUILayout.Vector3Field("크기", spawnScale); // 벡터3 형태의 값을 받는 필드로 이름(설명), 그리고 현재 값

        if(GUILayout.Button("생성하기")) // 기본 크기에 생성하기라는 글자가 적힌 버튼을 누르면 
        {
            SpawnObjectsFromGrid(); // 생성 함수 호출
        }
    }

    // 생성 함수
    private void SpawnObjectsFromGrid() 
    {
        if(prefabToSpawn == null) // 만약 생성 시킬 오브젝트가 널이라면
        {
            Debug.LogWarning("프리팹을 지정해주세요"); // 디버그로 오류 표기
            return; // 즉시 반환
        }

        for(int i = 0; i < col; i++) // 열 순회(가로)
        {
            for(int j = 0; j < row; j++) // 행 순회(세로)
            {
                if(spawnGrid[j, i] == 1) // 만약 배열이 1이라면
                {
                    GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(prefabToSpawn); // 객체 생성

                    if(parentTrans != null) // 그리고 부모가 널이 아니라면
                        obj.transform.SetParent(parentTrans); // 자식으로 넣기

                    obj.transform.position = Vector3.zero; // 생성한 오브젝트의 위치를 초기화

                    Vector3 pos = new Vector3(-i * spacing, -j * spacing, 0.3f); // 간격만큼 떨어진 위치
                    obj.transform.localPosition = pos; // 부모가 있을 때를 대비하여 월드가 아닌 로컬로 위치 변경

                    obj.transform.localScale = spawnScale; // 객체 크기 변경

                    Undo.RegisterCreatedObjectUndo(obj, "Spawn Grid Objects"); // 되돌리기 기능 지원
                }
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.22