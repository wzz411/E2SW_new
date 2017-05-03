using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
// using System.Text.RegularExpressions; string temp = laborInput.text; temp = Regex.Replace(temp, @"[^0-9]", "");  <-- to filter out unexpected characters other than int

public class Explore : MonoBehaviour
{
    public Button exploreButton;
    public InputField laborInput;
    public LineRenderer lr;
    public BuyNode bn;
    public Text labor;

    private float laborSpent;

    void Start()
    {
        exploreButton = GetComponent<Button>();
        laborInput = transform.parent.GetComponentInChildren<InputField>();
        exploreButton.onClick.AddListener(TaskOnClick);
        lr = gameObject.transform.parent.GetComponentInChildren<LineRenderer>();
        bn = gameObject.transform.parent.GetComponentInChildren<BuyNode>();
        labor = GameObject.Find("laborValue").GetComponent<Text>();

    }

    private void TaskOnClick()
    {
        laborSpent = int.Parse(laborInput.text) * GodMode.coef_explore_labor;
        if (laborSpent <= 2 && laborSpent > 0) // reveal 1 node, if there are, could be the same node as the already bought one
        {
            RevealNode(transform.parent.GetComponent<NodeAttributes>().childNode.Count, 1);
        }
        else if (laborSpent <= 5)
        { // reveal max 3 nodes, if there are, ...
            RevealNode(transform.parent.GetComponent<NodeAttributes>().childNode.Count, 3);
        }
        else
        { // reveal max 5 nodes, if there are, ...
            RevealNode(transform.parent.GetComponent<NodeAttributes>().childNode.Count, 5);
        }
        // transform.parent.GetComponent<NodeAttributes>().childNode
        laborInput.text = "";

        labor.text = (float.Parse(labor.text) - laborSpent).ToString();

        Debug.Log("this node has " + transform.parent.GetComponent<NodeAttributes>().childNode.Count + " child nodes");

        /*
        // copy components into new instantiated node GameObject
        GameObject hh = Instantiate(gameObject.transform.parent.parent.gameObject, new Vector3(-250, -90, 0), Quaternion.identity) as GameObject;
        // copy NodeAttributes
        Destroy(hh.GetComponentInChildren<NodeAttributes>());
        Component old_component = this.gameObject.GetComponentInParent<NodeAttributes>();
        Component new_component = hh.transform.FindChild("Canvas").gameObject.AddComponent(old_component.GetType());
        foreach(FieldInfo f in old_component.GetType().GetFields())
        {
            f.SetValue(new_component, f.GetValue(old_component));
        }
        // copy Create Nodes
        Destroy(hh.GetComponentInChildren<ManualTreeGenerator>());
        old_component = this.gameObject.transform.parent.parent.GetComponentInChildren<ManualTreeGenerator>();
        new_component = hh.transform.FindChild("CreateButton").gameObject.AddComponent(old_component.GetType());
        foreach (FieldInfo f in old_component.GetType().GetFields())
        {
            f.SetValue(new_component, f.GetValue(old_component));
        }
        // copy lr
        */



    }

    private void RevealNode(int potentialNodes, int nodes2reveal)
    {
        if ( potentialNodes <= nodes2reveal)
        {
           RevealAllNodes();
        }else{
            int[] nodeIndex = new int[nodes2reveal];
            for (int j = 0; j < nodes2reveal; j++)
            {
                nodeIndex[j] = UnityEngine.Random.Range(0, potentialNodes);
            }
            for (int i = 0; i < nodes2reveal; i++)
            {
                Vector3 nodeMoveFwd = transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex[i]].transform.position;
                nodeMoveFwd.z = 250;
                transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex[i]].transform.position = nodeMoveFwd;
                transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex[i]].transform.localScale = new Vector3(1f, 1f, 1f);

                // 2) move LineRenderer
                lr.startWidth = 5f;
                Vector3 temp = transform.parent.position;
                temp.z = 250;
                lr.SetPosition(bn.lrIndex, temp);
                lr.SetPosition(bn.lrIndex + 1, transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex[i]].transform.position);
                bn.lrIndex += 2;
            }
        }
    }

    private void RevealAllNodes()
    {
        int nodeIndex = transform.parent.GetComponent<NodeAttributes>().childNode.Count;
        for (int i = 0; i < nodeIndex; i++)
        {
            Vector3 nodeMoveFwd = transform.parent.GetComponent<NodeAttributes>().childNode[i].transform.position;
            nodeMoveFwd.z = 250;
            transform.parent.GetComponent<NodeAttributes>().childNode[i].transform.position = nodeMoveFwd;
            transform.parent.GetComponent<NodeAttributes>().childNode[i].transform.localScale = new Vector3(1f, 1f, 1f);

            // 2) move LineRenderer
            lr.startWidth = 5f;
            Vector3 temp = transform.parent.position;
            temp.z = 250;
            lr.SetPosition(bn.lrIndex, temp);
            lr.SetPosition(bn.lrIndex + 1, transform.parent.GetComponent<NodeAttributes>().childNode[i].transform.position);
            bn.lrIndex += 2;
        }
    }

}
