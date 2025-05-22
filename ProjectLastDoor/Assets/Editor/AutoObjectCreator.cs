using UnityEngine;
using UnityEditor;

// �ڵ����� ������Ʈ�� ������Ű�� ���� ��
public class AutoObjectCreator : EditorWindow
{
    private GameObject prefabToSpawn; // ������ ������
    private Transform parentTrans; // �θ� Transform

    private int row = 3; // �⺻ ��
    private int col = 3; // �⺻ ��
    private int[,] spawnGrid; // �迭

    private float spacing = 2f; // �⺻ ����
    private Vector3 spawnScale = Vector3.one; // �⺻ ũ��

    [MenuItem("Tools/Editable Auto Spawner")] // Unity ������ ��� �޴� �ٿ� �޴� �׸� �߰�
    public static void ShowWindow() // â ���� static �Լ�
    {
        GetWindow<AutoObjectCreator>("Editable Auto Spawner"); // ���� ���� Ŭ���� Ÿ��, �̸��� Editable Auto Spawner�� â ����
    }

    private void OnEnable() // Ȱ��ȭ �Ǿ��� ��
    {
        InitGrid(); // �迭 ����
    }

    private void InitGrid()
    {
        spawnGrid = new int[row, col]; // ���ο� �࿭�� �迭 ����

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                spawnGrid[i, j] = 0; // ���� 0���� �ʱ�ȭ
            }
        }
    }

    private void OnGUI() // ȭ�鿡 UI�� ���� �׸��� ������� �Էµ� ó���ϴ� �Լ�
    {
        GUILayout.Label("�迭 ũ�� ����", EditorStyles.boldLabel); // �̸� �� ����, �β��� ��Ÿ���� ����

        int newRow = EditorGUILayout.IntField("��(Row, ����)", row); // int�� �Է� ĭ (�̸�, ��) 
        int newCol = EditorGUILayout.IntField("��(Col, ����)", col); // int�� �Է� ĭ (�̸�, ��)

        if(newRow != row || newCol != col) // ���� ���ο� �� �Ǵ� ���� ������ �ٸ��ٸ�
        {
            row = Mathf.Max(1, newRow); // 1�� ���ο� �� �� ū ���� ���� (1 �̸��� ���� �Ұ�)
            col = Mathf.Max(1, newCol); // 1�� ���ο� �� �� ū ���� ���� (1 �̸��� ���� �Ұ�)
            InitGrid(); // �迭 �ʱ�ȭ
        }

        GUILayout.Space(10); // ���� ���� ����

        GUILayout.Label("ǥ (Ŭ���ؼ� 0, 1 ���)", EditorStyles.boldLabel); // ����(�̸�), �β��� ��Ÿ���� ����

        for(int i = 0; i < row; i++) // ��(����) ��ȸ
        {
            EditorGUILayout.BeginHorizontal(); // �������·� ��ġ ����
            for(int j = 0; j < col; j++) // ��(����) ��ȸ�ϸ� ������ ���� ���·� UI�� �׸��� �Ǿ� ���η� �� �׷���
            {
                string label = spawnGrid[i, j] == 1 ? "1" : "0"; // ���� �迭 ���� 1�̶�� 1�� �ƴ϶�� 0�� ����
                if(GUILayout.Button(label, GUILayout.Width(25), GUILayout.Height(25))) // label�� �����ִ� ����, ���� 25 ũ���� ��ư�� �����ٸ�
                {
                    spawnGrid[i, j] = spawnGrid[i, j] == 1 ? 0 : 1; // ���� �迭�� 1�̸� 0���� 0�̾��ٸ� 1�� �迭 ���� ����
                }
            }
            EditorGUILayout.EndHorizontal(); // �������� ��ġ ����, �ٽ� ���η� �׸���
        }

        GUILayout.Space(10); // 10��ŭ �Ʒ��� ����

        prefabToSpawn = (GameObject)EditorGUILayout.ObjectField("������ ������", prefabToSpawn, typeof(GameObject), false); // ���� ������Ʈ ���·� ObjectŸ���� ����ȯ�ϸ� ������Ʈ Ÿ���� �� �ޱ�(����(�̸�), ���� �Ҵ�� ��(���� �� ��) *�����ϴ� ������ ����ڰ� ���� ���õ� ���� �˰� �ϱ� ���ؼ�, � Ÿ���� ������Ʈ�� �޴� �ʵ�����, �� ������Ʈ ��� ���� false�� ������Ʈ �ڻ길 ���)
        parentTrans = (Transform)EditorGUILayout.ObjectField("�θ� ������Ʈ", parentTrans, typeof(Transform), true); // Transform ���·� Object Ÿ���� ����ȯ�ϸ� ������Ʈ Ÿ���� �� �ޱ�(����(�̸�), ���� �Ҵ�� ��(���� �� ��) *�����ϴ� ������ ����ڰ� ���� ���õ� ���� �˰� �ϱ� ���ؼ�, � Ÿ���� ������Ʈ�� �޴� �ʵ�����, �� ������Ʈ ��� ���� false�� ������Ʈ �ڻ길 ���)
        spacing = EditorGUILayout.FloatField("����", spacing); // �Ǽ� ������ ���� �޴� �ʵ�� �̸�(����), �׸��� ���� �� 
        spawnScale = EditorGUILayout.Vector3Field("ũ��", spawnScale); // ����3 ������ ���� �޴� �ʵ�� �̸�(����), �׸��� ���� ��

        if(GUILayout.Button("�����ϱ�")) // �⺻ ũ�⿡ �����ϱ��� ���ڰ� ���� ��ư�� ������ 
        {
            SpawnObjectsFromGrid(); // ���� �Լ� ȣ��
        }
    }

    // ���� �Լ�
    private void SpawnObjectsFromGrid() 
    {
        if(prefabToSpawn == null) // ���� ���� ��ų ������Ʈ�� ���̶��
        {
            Debug.LogWarning("�������� �������ּ���"); // ����׷� ���� ǥ��
            return; // ��� ��ȯ
        }

        for(int i = 0; i < col; i++) // �� ��ȸ(����)
        {
            for(int j = 0; j < row; j++) // �� ��ȸ(����)
            {
                if(spawnGrid[j, i] == 1) // ���� �迭�� 1�̶��
                {
                    GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(prefabToSpawn); // ��ü ����

                    if(parentTrans != null) // �׸��� �θ� ���� �ƴ϶��
                        obj.transform.SetParent(parentTrans); // �ڽ����� �ֱ�

                    obj.transform.position = Vector3.zero; // ������ ������Ʈ�� ��ġ�� �ʱ�ȭ

                    Vector3 pos = new Vector3(-i * spacing, -j * spacing, 0.3f); // ���ݸ�ŭ ������ ��ġ
                    obj.transform.localPosition = pos; // �θ� ���� ���� ����Ͽ� ���尡 �ƴ� ���÷� ��ġ ����

                    obj.transform.localScale = spawnScale; // ��ü ũ�� ����

                    Undo.RegisterCreatedObjectUndo(obj, "Spawn Grid Objects"); // �ǵ����� ��� ����
                }
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.22