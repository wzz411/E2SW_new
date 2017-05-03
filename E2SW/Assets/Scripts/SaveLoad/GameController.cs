using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Button saveBtn, loadBtn;
    public GameObject playerPrefab;
    public const string nodePath = "Prefabs/NewNode";

    private static string dataPath = string.Empty;
    

    private void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "nodes.json");
    }

    public static NodeObject CreateNode(string path, Vector3 position, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject go = Instantiate(prefab, position, rotation) as GameObject;

        NodeObject node = go.GetComponent<NodeObject>() ?? go.AddComponent<NodeObject>();

        return node;
    }
    public static NodeObject CreateNode(NodeData data, string path, Vector3 position, Quaternion rotation)
    {
        NodeObject node = CreateNode(path, position, rotation);
        node.nodeData = data;
        return node;
    }

    public void Save()
    {

        SaveData.Save(dataPath, SaveData.nodeContainer);
    }

    public void Load()
    {
        SaveData.Load(dataPath);
    }

}
