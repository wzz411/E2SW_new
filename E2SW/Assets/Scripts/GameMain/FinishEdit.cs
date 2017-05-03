using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishEdit : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("if labor spent less than 2, reveal maximum 1 node\nif labor spent less than 5, reveal maximum 3 nodes\n else reveal all nodes");
    }

    public void Finish()
    {
        // move all node's children to background
        
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node Name");
        foreach (GameObject node in nodes)
        {
            Vector3 nodeMoveBwd = node.transform.position;
            nodeMoveBwd.z = 2000;
            node.transform.position = nodeMoveBwd;
            node.transform.localScale = new Vector3(0f, 0f, 0f);
        }


        // move all nodes' line renderer components
        GameObject[] createButton_lrs = GameObject.FindGameObjectsWithTag("Create Button");
        foreach (GameObject createButton_lr in createButton_lrs)
        {
            for (int j = 0; j < 60; j++)
            {
                Vector3 initialPos = createButton_lr.GetComponent<LineRenderer>().GetPosition(j);
                initialPos.z = 2000;
                createButton_lr.GetComponent<LineRenderer>().SetPosition(j, initialPos);
            }
            // "destroy" all Create Button by scaling them down
            createButton_lr.transform.localScale = new Vector3(0f, 0f, 0f);
            createButton_lr.GetComponent<LineRenderer>().startWidth = 0f;
        }
        
        GameObject[] buyBtns = GameObject.FindGameObjectsWithTag("Buy Node");
        foreach (GameObject buyBtn in buyBtns)
        {
            for (int j = 0; j < 60; j++)
            {
                Vector3 initialPos = buyBtn.transform.position;
                buyBtn.GetComponent<LineRenderer>().SetPosition(j, initialPos);
            }
            //buyBtn.GetComponent<LineRenderer>().startWidth = 0f;
        }
        GameObject[] editButtons = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editButton in editButtons)
        {
            editButton.transform.localScale = new Vector3(0f, 0f, 0f);
        }

    }

    public void Edit()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node Name");
        foreach (GameObject node in nodes)
        {
            Vector3 nodeMoveBwd = node.transform.position;
            nodeMoveBwd.z = 250;
            node.transform.position = nodeMoveBwd;
            node.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        GameObject[] createButton_lrs = GameObject.FindGameObjectsWithTag("Create Button");
        foreach (GameObject createButton_lr in createButton_lrs)
        {
            for (int j = 0; j < 60; j++)
            {
                Vector3 initialPos = createButton_lr.GetComponent<LineRenderer>().GetPosition(j);
                initialPos.z = 250;
                createButton_lr.GetComponent<LineRenderer>().SetPosition(j, initialPos);
            }
            createButton_lr.transform.localScale = new Vector3(1f, 1f, 1f);
            createButton_lr.GetComponent<LineRenderer>().startWidth = 5f;
        }

        GameObject[] editButtons = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editButton in editButtons)
        {
            editButton.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        GameObject[] buyBtns = GameObject.FindGameObjectsWithTag("Buy Node");
        foreach (GameObject buyBtn in buyBtns)
        {
            buyBtn.GetComponent<Button>().interactable = true;
            buyBtn.GetComponent<LineRenderer>().startWidth = 5f;
        }

    }
}