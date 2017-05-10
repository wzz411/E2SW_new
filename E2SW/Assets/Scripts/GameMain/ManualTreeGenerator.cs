using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManualTreeGenerator : MonoBehaviour {

    // Create connecting lines between nodes
    private LineRenderer lr;
    private Vector3 initialPos = new Vector3(0, 0, 0);
    private Vector3 currentPos = new Vector3(0, 0, 0);
    private bool ifOnGUI = false;
    private int index = 1; // even #, including 0, for parent node; odd # for child node

    // 
    private GameObject node;
    private static int count = 1;


    void Start () {
        // initiate line renderer -- conncecting lines
        lr = GetComponent<LineRenderer>();
        Button createButton = GetComponent<Button>();
        createButton.onClick.AddListener(TaskOnClick);
        initialPos = transform.parent.position;
        initialPos.z = 250;
        
        // initiate all line points 
        for (int i = 0; i < 60; i++)
        {
            lr.SetPosition(i, initialPos);
        }

        // initiate new node
        node = Resources.Load("Prefabs/NewNode", typeof(GameObject)) as GameObject;


    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("dd");
            for (int i = 0; i < 60; i++)
            {
                Debug.Log(lr.GetPosition(i));
            }
        }
        */
    }


    // if create button is clicked
    private void TaskOnClick()
    {
        ifOnGUI = true;
    }

    private void OnGUI()
    {
        if (ifOnGUI)
        {
            // create line 
            currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 250;
            lr.SetPosition(2 * index - 1, currentPos);
            // if mouse clicked, generate the node
            if (Event.current.isMouse)
            {
                ifOnGUI = false;
                if (NodeAttributes.colliding)
                {
                    Debug.Log("collide with existing node: " + NodeAttributes.thisNode );
                    gameObject.transform.parent.GetComponentInChildren<NodeAttributes>().childNode.Add(NodeAttributes.thisNode);
                    lr.SetPosition(2 * index - 1, NodeAttributes.thisNode.transform.FindChild("Canvas").transform.position);
                }
                else
                {
                    GameObject newNode = Instantiate(node, currentPos, Quaternion.identity) as GameObject;
                    newNode.name = "node" + count;
                    // re-name new node
                    Button btn = newNode.gameObject.GetComponentInChildren<Button>();
                    btn.GetComponentInChildren<Text>().text = newNode.name;
                    // assign new node to its parent
                    //newNode.transform.SetParent(transform.parent.Find("ChildrenNode"));
                    newNode.transform.SetParent(transform.root.Find("Node Group"));
               /*     // method 1 : use string list to store all children node
                    gameObject.transform.parent.GetComponentInChildren<NodeAttributes>().childNodeNameString.Add(newNode.name);
                    Debug.Log(gameObject.transform.parent.name + " has ");
                    foreach (string aString in gameObject.transform.parent.GetComponentInChildren<NodeAttributes>().childNodeNameString)
                    {
                        
                        Debug.Log(aString);
                    }
               */
                    // moethod 2: use GameObject to store all children node
                    gameObject.transform.parent.GetComponentInChildren<NodeAttributes>().childNode.Add(newNode);
                    count++;
                    GodMode.all_nodes.Add(newNode);
                }

                /*
                Debug.Log(gameObject.transform.parent.name + " has ");
                foreach (GameObject aNode in gameObject.transform.parent.GetComponentInChildren<NodeAttributes>().childNode)
                {

                    Debug.Log(aNode);
                }
                */

                index++;

            }
        }


    }


}
