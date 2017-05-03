using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeObject : MonoBehaviour {

    public NodeData nodeData = new NodeData();

    public float fund, labor;

    public void SaveNodeData()
    {
        nodeData.fund = fund;
        nodeData.labor = labor;
        nodeData.pos = transform.position;
    }
	
    public void LoadNodeData()
    {
        fund = nodeData.fund;
        labor = nodeData.labor;
        transform.position = nodeData.pos;
    }

    public void ApplyNodeData()
    {

    }

    private void OnEnable()
    {
        SaveData.OnLoaded += LoadNodeData;
        SaveData.OnBeforeSave += SaveNodeData;
        SaveData.OnBeforeSave += ApplyNodeData;
    }

    private void OnDisable()
    {
        SaveData.OnLoaded -= LoadNodeData;
        SaveData.OnBeforeSave -= SaveNodeData;
        SaveData.OnBeforeSave += ApplyNodeData;
    }


}

[Serializable]
public class NodeData
{
    public float fund, labor;
    public Vector3 pos;
}
