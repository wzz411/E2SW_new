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

    public float[] pos = new float[3];
    public float funds, labor, numofturn, attrA, attrB, attrC, attrD, attrE, attrF, attrG, attrH;
    public bool ifMiniGame, ifDrill_1, ifDrill_2;
    public float[,] lr = new float[60, 3];

    private GameObject initialNode;

    private void Start()
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

        initialNode = GameObject.FindWithTag("Initial Node");
    }

    private void Update()
    {
        
    }


    public void Save()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file_GameMain = File.Create(Application.persistentDataPath + "/GameMain.dat");
            //Debug.Log(Application.persistentDataPath);
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


        // save node pos
        BinaryFormatter bf2 = new BinaryFormatter();
        FileStream file_node = File.Create(Application.persistentDataPath + "/Node.dat");
        NodeData data_Node = new NodeData();

        
        data_Node.pos[0] = GameObject.FindWithTag("Initial Node").transform.position.x;
        data_Node.pos[1] = GameObject.FindWithTag("Initial Node").transform.position.y;
        data_Node.pos[2] = GameObject.FindWithTag("Initial Node").transform.position.z;

        data_Node.funds = initialNode.transform.GetComponentInChildren<NodeAttributes>().funds;
        data_Node.labor = initialNode.transform.GetComponentInChildren<NodeAttributes>().labor;
        data_Node.numofturn = initialNode.transform.GetComponentInChildren<NodeAttributes>().numofturn;
        data_Node.attrA = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrA;
        data_Node.attrB = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrB;
        data_Node.attrC = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrC;
        data_Node.attrD = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrD;
        data_Node.attrF = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrE;
        data_Node.attrG = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrF;
        data_Node.attrH = initialNode.transform.GetComponentInChildren<NodeAttributes>().attrG;
        data_Node.ifMiniGame = initialNode.transform.GetComponentInChildren<NodeAttributes>().ifMiniGame;
        data_Node.ifDrill_1 = initialNode.transform.GetComponentInChildren<NodeAttributes>().ifDrill_1;
        data_Node.ifDrill_2 = initialNode.transform.GetComponentInChildren<NodeAttributes>().ifDrill_2;

        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                data_Node.lr[i, 0] = initialNode.transform.FindChild("CreateButton").GetComponent<LineRenderer>().GetPosition(i).x;
                data_Node.lr[i, 1] = initialNode.transform.FindChild("CreateButton").GetComponent<LineRenderer>().GetPosition(i).y;
                data_Node.lr[i, 2] = initialNode.transform.FindChild("CreateButton").GetComponent<LineRenderer>().GetPosition(i).z;
            }
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

            pos[0] = data_Node.pos[0];
            pos[1] = data_Node.pos[1];
            pos[2] = data_Node.pos[2];
            /*
            Debug.Log(pos[0]);
            Debug.Log(pos[1]);
            Debug.Log(pos[2]);
            */
            initialNode.transform.GetComponentInChildren<NodeAttributes>().funds = data_Node.funds;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().labor = data_Node.labor;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().numofturn = data_Node.numofturn;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrA = data_Node.attrA;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrB = data_Node.attrB;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrC = data_Node.attrC;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrD = data_Node.attrD;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrE = data_Node.attrE;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrF = data_Node.attrF;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrG = data_Node.attrG;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().attrH = data_Node.attrH;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().ifDrill_1 = data_Node.ifDrill_1;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().ifDrill_2 = data_Node.ifDrill_2;
            initialNode.transform.GetComponentInChildren<NodeAttributes>().ifMiniGame = data_Node.ifMiniGame;

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    initialNode.transform.FindChild("CreateButton").GetComponent<LineRenderer>().SetPosition(i, new Vector3(data_Node.lr[i,0], data_Node.lr[i, 1], data_Node.lr[i, 2]));
                }
            }
        }
    }

    /*
    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/gamedata.dat"))
        {
            File.Delete(Application.persistentDataPath + "/gamedata.dat");
        }
    }
	*/
}

[Serializable]
public class NodeData
{
    public float[] pos = new float[3];
    public float funds, labor, numofturn, attrA, attrB, attrC, attrD, attrE, attrF, attrG, attrH;
    public bool ifMiniGame, ifDrill_1, ifDrill_2;
    public float[,] lr = new float[60,3];
}


[Serializable]
public class GameMain
{
    public string funds_main, labor_main, currentTurnValue, turnsRemainingValue, EPGValue_min, EPGValue_max, APG_currentTest_Value, numofPNValue,
        numofTPValue, costValue, overallPGValue, coef_fund, coef_fund_time, coef_labor, coef_labor_time, coef_test_cost, coef_test_cost_time,
        coef_A, coef_A_time, coef_B, coef_B_time, coef_C, coef_C_time, coef_D, coef_D_time, coef_E, coef_E_time, coef_F, coef_F_time, coef_G, coef_G_time, coef_H, coef_H_time,
        coef_explore_labor, coef_explore_labor_time;
}