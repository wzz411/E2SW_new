using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour {

    public static NodeContainer nodeContainer = new NodeContainer();

    public delegate void SerilizeAction();
    public static event SerilizeAction OnLoaded;
    public static event SerilizeAction OnBeforeSave;

    public static void Load(string path)
    {
        nodeContainer = LoadNodes(path);
        foreach(NodeData data in nodeContainer.nodes)
        {
            GameController.CreateNode(data, GameController.nodePath, data.pos, Quaternion.identity);
        }
        OnLoaded();
        ClearNodeList();
    }

    public static void Save(string path, NodeContainer nodes)
    {
        OnBeforeSave();
        SaveNodes(path, nodes);
        ClearNodeList();
    }

    public static void AddNodeData(NodeData data)
    {
        nodeContainer.nodes.Add(data);
    }

    public static void ClearNodeList()
    {
        nodeContainer.nodes.Clear();
    }

    private static NodeContainer LoadNodes(string path)
    {
        string E2SW = File.ReadAllText(path);
        return JsonUtility.FromJson<NodeContainer>(E2SW);
    }

    private static void SaveNodes(string path, NodeContainer nodes)
    {
        string E2SW = JsonUtility.ToJson(nodes);
        StreamWriter sw = File.CreateText(path);
        sw.Close();
        File.WriteAllText(path, E2SW);
    }
}
