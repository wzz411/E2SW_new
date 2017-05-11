using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public static Controller control;

    public Text funds_main, labor_main, currentTurnValue, turnsRemainingValue,EPGValue_min, EPGValue_max, APG_currentTest_Value, numofPNValue,
        numofTPValue, costValue, overallPGValue, coef_fund, coef_fund_time, coef_labor, coef_labor_time, coef_test_cost, coef_test_cost_time,
        coef_A, coef_A_time, coef_B, coef_B_time, coef_C, coef_C_time, coef_D, coef_D_time, coef_E, coef_E_time, coef_F, coef_F_time, coef_G, coef_G_time, coef_H, coef_H_time,
        coef_explore_labor, coef_explore_labor_time;


    public List<float> funds = new List<float>();
    public List<float> labor = new List<float>();
    public List<float> numofturn = new List<float>();
    public List<float> attrA = new List<float>();
    public List<float> attrB = new List<float>();
    public List<float> attrC = new List<float>();
    public List<float> attrD = new List<float>();
    public List<float> attrE = new List<float>();
    public List<float> attrF = new List<float>();
    public List<float> attrG = new List<float>();
    public List<float> attrH = new List<float>();
    public List<bool> ifMiniGame = new List<bool>();
    public List<bool> ifDrill_1 = new List<bool>();
    public List<bool> ifDrill_2 = new List<bool>();
    public List<string> allNodeNames = new List<string>();
    public List<float[]> pos_list = new List<float[]>();
    public List<float[]> scale_list = new List<float[]>();
    public List<float[,]> lrCreate_list = new List<float[,]>();
    public List<float[,]> lrBuy_list = new List<float[,]>();
    public List<string> childNode = new List<string>();
    public List<bool> buyBtn = new List<bool>();


    // helper var
    private float[,] lrBuy = new float[60, 3];
    private float[,] lrCreate = new float[60, 3];
    private GameObject[] node;
    private GameObject nodePrefab;


    private void Awake()
    {
        funds_main = GameObject.Find("fundsValue").GetComponent<Text>();
        labor_main = GameObject.Find("laborValue").GetComponent<Text>();
        currentTurnValue = GameObject.Find("currentTurnValue").GetComponent<Text>();
        turnsRemainingValue = GameObject.Find("turnsRemainingValue").GetComponent<Text>();
        EPGValue_min = GameObject.Find("EPGValue_min").GetComponent<Text>();
        EPGValue_max = GameObject.Find("EPGValue_max").GetComponent<Text>();
        APG_currentTest_Value = GameObject.Find("APG_currentTest_Value").GetComponent<Text>();
        numofPNValue = GameObject.Find("numofPNValue").GetComponent<Text>();
        numofTPValue = GameObject.Find("numofTPValue").GetComponent<Text>();
        costValue = GameObject.Find("CostValue").GetComponent<Text>();
        overallPGValue = GameObject.Find("overallPGValue").GetComponent<Text>();
        coef_fund = GameObject.Find("coef_fund").GetComponent<Text>();
        coef_fund_time = GameObject.Find("coef_fund_time").GetComponent<Text>();
        coef_labor = GameObject.Find("coef_fund").GetComponent<Text>();
        coef_labor_time = GameObject.Find("coef_labor_time").GetComponent<Text>();
        coef_test_cost = GameObject.Find("coef_testCost").GetComponent<Text>();
        coef_test_cost_time = GameObject.Find("coef_testCost_time").GetComponent<Text>();
        coef_A = GameObject.Find("coef_A").GetComponent<Text>();
        coef_A_time = GameObject.Find("coef_A_time").GetComponent<Text>();
        coef_B = GameObject.Find("coef_B").GetComponent<Text>();
        coef_B_time = GameObject.Find("coef_B_time").GetComponent<Text>();
        coef_C = GameObject.Find("coef_C").GetComponent<Text>();
        coef_C_time = GameObject.Find("coef_C_time").GetComponent<Text>();
        coef_D = GameObject.Find("coef_D").GetComponent<Text>();
        coef_D_time = GameObject.Find("coef_D_time").GetComponent<Text>();
        coef_E = GameObject.Find("coef_E").GetComponent<Text>();
        coef_E_time = GameObject.Find("coef_E_time").GetComponent<Text>();
        coef_F = GameObject.Find("coef_F").GetComponent<Text>();
        coef_F_time = GameObject.Find("coef_F_time").GetComponent<Text>();
        coef_G = GameObject.Find("coef_G").GetComponent<Text>();
        coef_G_time = GameObject.Find("coef_G_time").GetComponent<Text>();
        coef_H = GameObject.Find("coef_H").GetComponent<Text>();
        coef_H_time = GameObject.Find("coef_H_time").GetComponent<Text>();
        coef_explore_labor = GameObject.Find("coef_exploreLabor").GetComponent<Text>();
        coef_explore_labor_time = GameObject.Find("coef_exploreLabor_time").GetComponent<Text>();
        
        nodePrefab = Resources.Load("Prefabs/NewNode", typeof(GameObject)) as GameObject;
        
    }

    private void Update()
    {
        
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file_GameMain = File.Create(Application.persistentDataPath + "/GameMain.dat");
        /***********************************************************************************
        Debug.Log(Application.persistentDataPath);  <--- Use this method to check Save file's directory   
        ************************************************************************************/
        // Save values in Game Main
        GameMain data_GameMain = new GameMain();
        data_GameMain.funds_main = funds_main.text;
        data_GameMain.labor_main = labor_main.text;
        data_GameMain.currentTurnValue = currentTurnValue.text;
        data_GameMain.turnsRemainingValue = turnsRemainingValue.text;
        data_GameMain.EPGValue_max = EPGValue_max.text;
        data_GameMain.EPGValue_min = EPGValue_min.text;
        data_GameMain.APG_currentTest_Value = APG_currentTest_Value.text;
        data_GameMain.numofPNValue = numofPNValue.text;
        data_GameMain.numofTPValue = numofTPValue.text;
        data_GameMain.costValue = costValue.text;
        data_GameMain.overallPGValue = overallPGValue.text;
        data_GameMain.coef_fund = coef_fund.text;
        data_GameMain.coef_fund_time = coef_fund_time.text;
        data_GameMain.coef_labor = coef_labor.text;
        data_GameMain.coef_labor_time = coef_labor_time.text;
        data_GameMain.coef_test_cost = coef_test_cost.text;
        data_GameMain.coef_test_cost_time = coef_test_cost_time.text;
        data_GameMain.coef_A = coef_A.text;
        data_GameMain.coef_A_time = coef_A_time.text;
        data_GameMain.coef_B = coef_B.text;
        data_GameMain.coef_B_time = coef_B_time.text;
        data_GameMain.coef_C = coef_C.text;
        data_GameMain.coef_C_time = coef_C_time.text;
        data_GameMain.coef_D = coef_D.text;
        data_GameMain.coef_D_time = coef_D_time.text;
        data_GameMain.coef_E = coef_E.text;
        data_GameMain.coef_E_time = coef_E_time.text;
        data_GameMain.coef_F = coef_F.text;
        data_GameMain.coef_F_time = coef_F_time.text;
        data_GameMain.coef_G = coef_G.text;
        data_GameMain.coef_G_time = coef_G_time.text;
        data_GameMain.coef_H = coef_H.text;
        data_GameMain.coef_H_time = coef_H_time.text;
        data_GameMain.coef_explore_labor = coef_explore_labor.text;
        data_GameMain.coef_explore_labor_time = coef_explore_labor_time.text;

        bf.Serialize(file_GameMain, data_GameMain);
        file_GameMain.Close();


        // save node info
        node = GameObject.FindGameObjectsWithTag("Node Name");
        BinaryFormatter bf2 = new BinaryFormatter();
        FileStream file_node = File.Create(Application.persistentDataPath + "/Node.dat");
        NodeData data_Node = new NodeData();

        for (int k = 0; k < node.Length; k++)
        {
            // position info
            float[] pos = new float[3] { node[k].transform.position.x, node[k].transform.position.y, node[k].transform.position.z };
            data_Node.pos_list.Add(pos);

            // scale info
            float[] scale = new float[3] { node[k].transform.localScale.x, node[k].transform.localScale.y, node[k].transform.localScale.z };
            data_Node.scale_list.Add(scale);

            // attr info
            data_Node.funds.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().funds);
            data_Node.labor.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().labor);
            data_Node.numofturn.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().numofturn);
            data_Node.attrA.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrA);
            data_Node.attrB.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrB);
            data_Node.attrC.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrC);
            data_Node.attrD.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrD);
            data_Node.attrE.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrE);
            data_Node.attrF.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrF);
            data_Node.attrG.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrG);
            data_Node.attrH.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().attrH);
            data_Node.ifMiniGame.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().ifMiniGame);
            data_Node.ifDrill_1.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().ifDrill_1);
            data_Node.ifDrill_2.Add(node[k].transform.GetComponentInChildren<NodeAttributes>().ifDrill_2);

            // lr info
            lrCreate = new float[60, 3];
            for (int i = 0; i < 60; i++)
            {    
                lrCreate[i, 0] = node[k].transform.FindChild("CreateButton").GetComponent<LineRenderer>().GetPosition(i).x;
                lrCreate[i, 1] = node[k].transform.FindChild("CreateButton").GetComponent<LineRenderer>().GetPosition(i).y;
                lrCreate[i, 2] = node[k].transform.FindChild("CreateButton").GetComponent<LineRenderer>().GetPosition(i).z;
            }
            data_Node.lrCreate_list.Add(lrCreate);

            lrBuy = new float[60, 3];
            for (int i = 0; i < 60; i++)
            {
                lrBuy[i, 0] = node[k].transform.FindChild("Canvas").FindChild("Button").GetComponent<LineRenderer>().GetPosition(i).x;
                lrBuy[i, 1] = node[k].transform.FindChild("Canvas").FindChild("Button").GetComponent<LineRenderer>().GetPosition(i).y;
                lrBuy[i, 2] = node[k].transform.FindChild("Canvas").FindChild("Button").GetComponent<LineRenderer>().GetPosition(i).z;
            }
            data_Node.lrBuy_list.Add(lrBuy);

            // node's childNode list
            data_Node.childNode.Add(StringList2String(node[k].transform.GetComponentInChildren<NodeAttributes>().childNode));
            /***********************************************************
             * method to check each node's child list
            Debug.Log(node[k].name + " list of child: " + StringList2String(node[k].transform.GetComponentInChildren<NodeAttributes>().childNode));
            ***********************************************************/


            // whether the node has been purchased
            data_Node.buyBtn.Add(node[k].transform.FindChild("Canvas").FindChild("Button").GetComponent<Button>().interactable);
        }

        // update total node list in GodMode
        for (int i = 0; i < GodMode.all_nodes.Count; i++)
        {
            data_Node.allNodeNames.Add(GodMode.all_nodes[i]);
        }

        bf2.Serialize(file_node, data_Node);
        file_node.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/GameMain.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameMain.dat", FileMode.Open);
            GameMain data_GameMain = (GameMain)bf.Deserialize(file);
            file.Close();

            // load values in Game Main
            funds_main.text = data_GameMain.funds_main;
            labor_main.text = data_GameMain.labor_main;
            currentTurnValue.text = data_GameMain.currentTurnValue;
            turnsRemainingValue.text = data_GameMain.turnsRemainingValue;
            EPGValue_max.text = data_GameMain.EPGValue_max;
            EPGValue_min.text = data_GameMain.EPGValue_min;
            APG_currentTest_Value.text = data_GameMain.APG_currentTest_Value;
            numofPNValue.text = data_GameMain.numofPNValue;
            numofTPValue.text = data_GameMain.numofTPValue;
            costValue.text = data_GameMain.costValue;
            overallPGValue.text = data_GameMain.overallPGValue;
            GodMode.coef_funds_time = float.Parse(data_GameMain.coef_fund_time);
            GodMode.coef_funds = float.Parse(data_GameMain.coef_fund);
            GodMode.coef_labor = float.Parse(data_GameMain.coef_labor);
            GodMode.coef_labor_time = float.Parse(data_GameMain.coef_labor_time);
            GodMode.coef_testCost = float.Parse(data_GameMain.coef_test_cost);
            GodMode.coef_test_cost_time = float.Parse(data_GameMain.coef_test_cost_time);
            GodMode.coef_criteriaA = float.Parse(data_GameMain.coef_A);
            GodMode.coef_criteriaA_time = float.Parse(data_GameMain.coef_A_time);
            GodMode.coef_criteriaB = float.Parse(data_GameMain.coef_B);
            GodMode.coef_criteriaB_time = float.Parse(data_GameMain.coef_B_time);
            GodMode.coef_criteriaC = float.Parse(data_GameMain.coef_C);
            GodMode.coef_criteriaC_time = float.Parse(data_GameMain.coef_C_time);
            GodMode.coef_criteriaD = float.Parse(data_GameMain.coef_D);
            GodMode.coef_criteriaD_time = float.Parse(data_GameMain.coef_D_time);
            GodMode.coef_criteriaE = float.Parse(data_GameMain.coef_E);
            GodMode.coef_criteriaE_time = float.Parse(data_GameMain.coef_E_time);
            GodMode.coef_criteriaF = float.Parse(data_GameMain.coef_F);
            GodMode.coef_criteriaF_time = float.Parse(data_GameMain.coef_F_time);
            GodMode.coef_criteriaG = float.Parse(data_GameMain.coef_G);
            GodMode.coef_criteriaG_time = float.Parse(data_GameMain.coef_G_time);
            GodMode.coef_criteriaH = float.Parse(data_GameMain.coef_H);
            GodMode.coef_criteriaH_time = float.Parse(data_GameMain.coef_H_time);
            GodMode.coef_explore_labor = float.Parse(data_GameMain.coef_explore_labor);
            GodMode.coef_explore_labor_time = float.Parse(data_GameMain.coef_explore_labor_time);

   
        }
        if (File.Exists(Application.persistentDataPath + "/Node.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Node.dat", FileMode.Open);
            NodeData data_Node = (NodeData)bf.Deserialize(file);
            file.Close();

            // clear out current existing nodes
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Node Name"))
            {
                Destroy(obj);
            }

            // instantiate all nodes and load their info
            for (int k = 0; k < data_Node.allNodeNames.Count; k++)
            {
                // instantiate at stored pos
                GameObject creatingNode = Instantiate(nodePrefab, new Vector3(data_Node.pos_list[k][0], data_Node.pos_list[k][1], data_Node.pos_list[k][2]), Quaternion.identity) as GameObject;

                // scale up/down each node
                creatingNode.transform.localScale = new Vector3(data_Node.scale_list[k][0], data_Node.scale_list[k][1], data_Node.scale_list[k][2]);

                // load node name and set it in correct place
                creatingNode.name = data_Node.allNodeNames[k].ToString();
                Button btn = creatingNode.gameObject.GetComponentInChildren<Button>();
                btn.GetComponentInChildren<Text>().text = creatingNode.name;
                creatingNode.transform.SetParent(GameObject.FindGameObjectWithTag("Node Group").transform);

                // load all attributes
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().funds = data_Node.funds[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().labor = data_Node.labor[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().numofturn = data_Node.numofturn[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrA = data_Node.attrA[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrB = data_Node.attrB[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrC = data_Node.attrC[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrD = data_Node.attrD[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrE = data_Node.attrE[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrF = data_Node.attrF[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrG = data_Node.attrG[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().attrH = data_Node.attrH[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().ifDrill_1 = data_Node.ifDrill_1[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().ifDrill_2 = data_Node.ifDrill_2[k];
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().ifMiniGame = data_Node.ifMiniGame[k];

                // load all lr
                for (int i = 0; i < 60; i++)
                {
                    creatingNode.transform.FindChild("CreateButton").GetComponent<LineRenderer>().SetPosition(i, new Vector3(data_Node.lrCreate_list[k][i, 0], data_Node.lrCreate_list[k][i, 1], data_Node.lrCreate_list[k][i, 2]));
                }

                for (int j = 0; j < 60; j++)
                {
                    creatingNode.transform.FindChild("Canvas").FindChild("Button").GetComponent<LineRenderer>().SetPosition(j, new Vector3(data_Node.lrBuy_list[k][j, 0], data_Node.lrBuy_list[k][j, 1], data_Node.lrBuy_list[k][j, 2]));
                }

                // load child node list
                creatingNode.transform.GetComponentInChildren<NodeAttributes>().childNode.Clear();
                string[] temp = data_Node.childNode[k].Split(',');
                for (int j = 0; j < temp.Length; j++)
                {
                    creatingNode.transform.GetComponentInChildren<NodeAttributes>().childNode.Add(temp[j]);
                }

                // load whether the node has been purchased
                creatingNode.transform.FindChild("Canvas").FindChild("Button").GetComponent<Button>().interactable = data_Node.buyBtn[k];
            }
        }

        // disable all edit/create button
        GameObject[] createButton_lrs = GameObject.FindGameObjectsWithTag("Create Button");
        foreach (GameObject createButton_lr in createButton_lrs)
        {
            createButton_lr.transform.localScale = new Vector3(0f, 0f, 0f);
        }
        GameObject[] editButtons = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editButton in editButtons)
        {
            editButton.transform.localScale = new Vector3(0f, 0f, 0f);
        }
    }



    // helper method to convert List<string> to one string, separated by ','
    private string StringList2String(List<string> input)
    {
        if (input.Count != 0)
        {
            string output = "";
            for (int i = 0; i < input.Count - 1; i++)
            {
                output += input[i] + ",";
            }
            output += input[input.Count - 1];
            return output;
        }
        else
        {
            return "";
        }
        
    }


}

[Serializable]
public class NodeData
{
    public List<float> funds = new List<float>();
    public List<float> labor = new List<float>();
    public List<float> numofturn = new List<float>();
    public List<float> attrA = new List<float>();
    public List<float> attrB = new List<float>();
    public List<float> attrC = new List<float>();
    public List<float> attrD = new List<float>();
    public List<float> attrE = new List<float>();
    public List<float> attrF = new List<float>();
    public List<float> attrG = new List<float>();
    public List<float> attrH = new List<float>();
    public List<bool> ifMiniGame = new List<bool>();
    public List<bool> ifDrill_1 = new List<bool>();
    public List<bool> ifDrill_2 = new List<bool>();
    public List<string> allNodeNames = new List<string>();
    public List<float[]> pos_list = new List<float[]>();
    public List<float[]> scale_list = new List<float[]>();
    public List<float[,]> lrCreate_list = new List<float[,]>();
    public List<float[,]> lrBuy_list = new List<float[,]>();
    public List<string> childNode = new List<string>();
    public List<bool> buyBtn = new List<bool>();
}


[Serializable]
public class GameMain
{
    public string funds_main, labor_main, currentTurnValue, turnsRemainingValue, EPGValue_min, EPGValue_max, APG_currentTest_Value, numofPNValue,
        numofTPValue, costValue, overallPGValue, coef_fund, coef_fund_time, coef_labor, coef_labor_time, coef_test_cost, coef_test_cost_time,
        coef_A, coef_A_time, coef_B, coef_B_time, coef_C, coef_C_time, coef_D, coef_D_time, coef_E, coef_E_time, coef_F, coef_F_time, coef_G, coef_G_time, coef_H, coef_H_time,
        coef_explore_labor, coef_explore_labor_time;
    
}
