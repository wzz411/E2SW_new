using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class BuyNode : MonoBehaviour
{
    public Button buyButton;
    public static int pn; // pn = numofPN = number of purchased nodes
    public static float attrWeightedSum;

    public Text funds, labor, current, remaining, criteriaA, criteriaB, criteriaC, criteriaD, criteriaE, criteriaF, criteriaG, criteriaH, numofPN;

    public int lrIndex = 0;
    private LineRenderer lr;
    private Vector3 nodePos = new Vector3(0, 0, 0);
    private int eventTrigger;
    private Button eventBtn;

    void Start()
    {
        buyButton = GetComponent<Button>();
        buyButton.onClick.AddListener(TaskOnClick);
        funds = GameObject.Find("fundsValue").GetComponent<Text>();
        labor = GameObject.Find("laborValue").GetComponent<Text>();
        current = GameObject.Find("currentTurnValue").GetComponent<Text>();
        remaining = GameObject.Find("turnsRemainingValue").GetComponent<Text>();
        numofPN = GameObject.Find("numofPNValue").GetComponent<Text>();
        criteriaA = GameObject.FindWithTag("EstCriteriaA").GetComponent<Text>();
        criteriaB = GameObject.FindWithTag("EstCriteriaB").GetComponent<Text>();
        criteriaC = GameObject.FindWithTag("EstCriteriaC").GetComponent<Text>();
        criteriaD = GameObject.FindWithTag("EstCriteriaD").GetComponent<Text>();
        criteriaE = GameObject.FindWithTag("EstCriteriaE").GetComponent<Text>();
        criteriaF = GameObject.FindWithTag("EstCriteriaF").GetComponent<Text>();
        criteriaG = GameObject.FindWithTag("EstCriteriaG").GetComponent<Text>();
        criteriaH = GameObject.FindWithTag("EstCriteriaH").GetComponent<Text>();

        eventBtn = Resources.Load("Prefabs/EventChoice", typeof(Button)) as Button;
    }

    /********************************************************************************************
     ***Awake is to prevent this script from overwriting lr coordinates when Loading*************
     ********************************************************************************************/
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        nodePos = transform.parent.position;
        nodePos.z = 250;
        for (int i = 0; i < 60; i++)
        {
            lr.SetPosition(i, nodePos);
        }
    }

    private void TaskOnClick()
    {
        // update attributes in game main panel
        NodeAttributes nodeAttr = gameObject.GetComponentInParent<NodeAttributes>();
        funds.text = (float.Parse(funds.text) - nodeAttr.funds * GodMode.coef_funds).ToString();
        labor.text = (float.Parse(labor.text) - nodeAttr.labor * GodMode.coef_labor).ToString();
        current.text = (float.Parse(current.text) + nodeAttr.numofturn).ToString();
        remaining.text = (float.Parse(remaining.text) - nodeAttr.numofturn).ToString();
        numofPN.text = (float.Parse(numofPN.text) + 1f).ToString();
        criteriaA.text = (float.Parse(criteriaA.text) + nodeAttr.attrA * GodMode.coef_criteriaA).ToString();
        criteriaB.text = (float.Parse(criteriaB.text) + nodeAttr.attrB * GodMode.coef_criteriaB).ToString();
        criteriaC.text = (float.Parse(criteriaC.text) + nodeAttr.attrC * GodMode.coef_criteriaC).ToString();
        criteriaD.text = (float.Parse(criteriaD.text) + nodeAttr.attrD * GodMode.coef_criteriaD).ToString();
        criteriaE.text = (float.Parse(criteriaE.text) + nodeAttr.attrE * GodMode.coef_criteriaE).ToString();
        criteriaF.text = (float.Parse(criteriaF.text) + nodeAttr.attrF * GodMode.coef_criteriaF).ToString();
        criteriaG.text = (float.Parse(criteriaG.text) + nodeAttr.attrG * GodMode.coef_criteriaG).ToString();
        criteriaH.text = (float.Parse(criteriaH.text) + nodeAttr.attrH * GodMode.coef_criteriaH).ToString();
        buyButton.GetComponent<Button>().interactable = false;

        attrWeightedSum += nodeAttr.attrA + nodeAttr.attrB + nodeAttr.attrC + nodeAttr.attrD + nodeAttr.attrE + nodeAttr.attrF + nodeAttr.attrG + nodeAttr.attrH;


        // decide whether minigames
        if (nodeAttr.ifMiniGame)
        {
            GameObject.FindWithTag("Mini Game").transform.position = new Vector3(400, 400, 250);
        }
        if (nodeAttr.ifDrill_1)
        {

            SceneManager.LoadScene("drill_1");
            GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 50;
        }
        if (nodeAttr.ifDrill_2)
        {

            SceneManager.LoadScene("drill_2");
            GameObject.FindWithTag("Main Game Scene").GetComponent<Canvas>().scaleFactor = 50;
        }


        /**********************************************************************************************************************************************************
         **************************************************************** this is an obselete method***************************************************************
        // move children, as well as its line renderer
        // 1) move Nodes
        for (int m = 0; m < gameObject.transform.parent.parent.GetChild(3).childCount; m++)
        {
            Vector3 nodeMoveFwd = gameObject.transform.parent.parent.GetChild(3).GetChild(m).transform.position;
            nodeMoveFwd.z = 250;
            gameObject.transform.parent.parent.GetChild(3).GetChild(m).transform.position = nodeMoveFwd;
            //gameObject.transform.parent.parent.GetChild(3).GetChild(m).transform.localScale = new Vector3(1f, 1f, 1f);

            Vector3 nodeChildMoveBwk = gameObject.transform.parent.parent.GetChild(3).GetChild(m).GetChild(3).position;
            nodeChildMoveBwk.z = 2000;
            gameObject.transform.parent.parent.GetChild(3).GetChild(m).GetChild(3).position = nodeChildMoveBwk;

            // Debug.Log("child count is :" + gameObject.transform.parent.parent.GetChild(3).childCount);
            // Debug.Log(gameObject.transform.parent.parent.GetChild(3).GetChild(m));
        }
        */

        /*  foreach (GameObject aNode in transform.parent.GetComponent<NodeAttributes>().childNode)
          {
              Vector3 nodeMoveFwd = aNode.transform.position;
              nodeMoveFwd.z = 250;
              aNode.transform.position = nodeMoveFwd;
              aNode.transform.localScale = new Vector3 (1f, 1f, 1f);
          }
          */
        // 2) move (actually creating) LineRenderer
        /*
        for (int j = 0; j < 60; j++)
        {
            Vector3 lrMoveFwd = gameObject.transform.parent.parent.GetChild(1).GetComponent<LineRenderer>().GetPosition(j); // this is to find CreateButton in each Node Debug.log(gameObject.transform.parent.parent.GetChild(1));
            lrMoveFwd.z = 250;
            gameObject.transform.parent.parent.GetChild(1).GetComponent<LineRenderer>().SetPosition(j, lrMoveFwd);

        }
        *********************************************************************************************************************************************************************/


        // display random 1 of childnode, if no labor was input
        if (transform.parent.GetComponent<NodeAttributes>().childNode.Count > 0)
        {
            int nodeIndex = UnityEngine.Random.Range(0, transform.parent.GetComponent<NodeAttributes>().childNode.Count);
            if (GameObject.Find(transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex]) != null)
            {
                // 1) move node, set scale
                Vector3 nodeMoveFwd = GameObject.Find(transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex]).transform.position;
                nodeMoveFwd.z = 250;
                GameObject.Find(transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex]).transform.position = nodeMoveFwd;
                GameObject.Find(transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex]).transform.localScale = new Vector3(1f, 1f, 1f);

                // 2) move LineRenderer
                lr.startWidth = 5f;
                Vector3 temp = transform.parent.position;
                temp.z = 250;
                lr.SetPosition(lrIndex, temp);
                lr.SetPosition(lrIndex + 1, GameObject.Find(transform.parent.GetComponent<NodeAttributes>().childNode[nodeIndex]).transform.position);
                lrIndex += 2;
            }     
        }


        //if event system triggered
        eventTrigger = UnityEngine.Random.Range(0, 50);
        // [0,25] --> events not triggered
        if (eventTrigger > 25)
        {
            if (eventTrigger <= 34) // set (550, 300, 0) as center
            {
                // create 2 choices  
                Vector3[] posArr = new Vector3[2];
                posArr[0] = new Vector3(550 - 60, 300, 0);
                posArr[1] = new Vector3(550 + 60, 300, 0);
                int[] temp = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    temp[i] = UnityEngine.Random.Range(1, 4);
                }
                for (int i = 0; i < 2; i++)
                {
                    if (temp[i] == 1)
                    {
                        CreateEvent_add(posArr[i]);
                    }
                    if (temp[i] == 2)
                    {
                        CreateEvent_coef(posArr[i]);
                    }
                    if (temp[i] == 3)
                    {
                        CreateEvent_labor_zero(posArr[i]);
                    }
                }
            }
            else if (eventTrigger <= 42)
            {
                // create 3 choices
                Vector3[] posArr = new Vector3[3];
                posArr[0] = new Vector3(550 - 120, 300, 0);
                posArr[1] = new Vector3(550, 300, 0);
                posArr[2] = new Vector3(550 + 120, 300, 0);
                int[] temp = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    temp[i] = UnityEngine.Random.Range(1, 4);
                }
                for (int i = 0; i < 3; i++)
                {
                    if (temp[i] == 1)
                    {
                        CreateEvent_add(posArr[i]);
                    }
                    if (temp[i] == 2)
                    {
                        CreateEvent_coef(posArr[i]);
                    }
                    if (temp[i] == 3)
                    {
                        CreateEvent_labor_zero(posArr[i]);
                    }
                }
            }
            else
            {
                // create 4 choices
                Vector3[] posArr = new Vector3[4];
                posArr[0] = new Vector3(550 - 60, 300 + 75, 0);
                posArr[1] = new Vector3(550 + 60, 300 + 75, 0);
                posArr[2] = new Vector3(550 - 60, 300 - 75, 0);
                posArr[3] = new Vector3(550 + 60, 300 - 75, 0);
                int[] temp = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    temp[i] = UnityEngine.Random.Range(1, 4);
                }
                for (int i = 0; i < 4; i++)
                {
                    if (temp[i] == 1)
                    {
                        CreateEvent_add(posArr[i]);
                    }
                    if (temp[i] == 2)
                    {
                        CreateEvent_coef(posArr[i]);
                    }
                    if (temp[i] == 3)
                    {
                        CreateEvent_labor_zero(posArr[i]);
                    }
                }
            }

        }
    }

    private void CreateEvent_add(Vector3 pos)
    {
        Button eventBtnCreated = Instantiate(eventBtn, pos, Quaternion.identity);
        eventBtnCreated.transform.SetParent(GameObject.FindWithTag("Main Game Scene").transform);
        Events events = eventBtnCreated.GetComponent<Events>();
        int switchID = UnityEngine.Random.Range(1, 11);
        switch (switchID)
        {
            case 1:
                events.funds = UnityEngine.Random.Range(1,15) * 100;
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Funds: " + events.funds.ToString();
                events.caseID = 1;
                break;
            case 2:
                events.labor = UnityEngine.Random.Range(3, 15);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding labor: " + events.labor.ToString();
                events.caseID = 2;
                break;
            case 3:
                events.attrA = UnityEngine.Random.Range(3,8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute A: " + events.attrA.ToString();
                events.caseID = 3;
                break;
            case 4:
                events.attrB = UnityEngine.Random.Range(3, 8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute B: " + events.attrB.ToString();
                events.caseID = 4;
                break;
            case 5:
                events.attrC = UnityEngine.Random.Range(3, 8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute C: " + events.attrC.ToString();
                events.caseID = 5;
                break;
            case 6:
                events.attrD = UnityEngine.Random.Range(3, 8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute D: " + events.attrD.ToString();
                events.caseID = 6;
                break;
            case 7:
                events.attrE = UnityEngine.Random.Range(3, 8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute E: " + events.attrE.ToString();
                events.caseID = 7;
                break;
            case 8:
                events.attrF = UnityEngine.Random.Range(3,8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute F: " + events.attrF.ToString();
                events.caseID = 8;
                break;
            case 9:
                events.attrG = UnityEngine.Random.Range(3, 8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute G: " + events.attrG.ToString();
                events.caseID = 9;
                break;
            case 10:
                events.attrH = UnityEngine.Random.Range(3, 8);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Adding Attribute H: " + events.attrH.ToString();
                events.caseID = 10;
                break;
        }
    }
    private void CreateEvent_coef(Vector3 pos)
    {
        Button eventBtnCreated = Instantiate(eventBtn, pos, Quaternion.identity);
        eventBtnCreated.transform.SetParent(GameObject.FindWithTag("Main Game Scene").transform);
        Events events = eventBtnCreated.GetComponent<Events>();
        int switchID = UnityEngine.Random.Range(11, 23);
        switch (switchID)
        {
            case 11:
                events.funds_coef = RandomCoef();
                events.funds_t = UnityEngine.Random.Range(1,6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Funds Cost) to be: " + events.funds_coef.ToString() + " for " + events.funds_t.ToString() + " turns";
                events.caseID = 11;
                break;
            case 12:
                events.labor_coef = RandomCoef();
                events.labor_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Labor Cost) to be:  " + events.labor_coef.ToString() + " for " + events.labor_t.ToString() + " turns";
                events.caseID = 12;
                break;
            case 13:
                events.attrA_coef = RandomCoef();
                events.attrA_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute A) to be: " + events.attrA_coef.ToString() + " for " + events.attrA_t.ToString() + " turns";
                events.caseID = 13;
                break;
            case 14:
                events.attrB_coef = RandomCoef();
                events.attrB_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute B) to be: " + events.attrB_coef.ToString() + " for " + events.attrB_t.ToString() + " turns";
                events.caseID = 14;
                break;
            case 15:
                events.attrC_coef = RandomCoef();
                events.attrC_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute C) to be: " + events.attrC_coef.ToString() + " for " + events.attrC_t.ToString() + " turns";
                events.caseID = 15;
                break;
            case 16:
                events.attrD_coef = RandomCoef();
                events.attrD_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute D) to be: " + events.attrD_coef.ToString() + " for " + events.attrD_t.ToString() + " turns";
                events.caseID = 16;
                break;
            case 17:
                events.attrE_coef = RandomCoef();
                events.attrE_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute E) to be: " + events.attrE_coef.ToString() + " for " + events.attrE_t.ToString() + " turns";
                events.caseID = 17;
                break;
            case 18:
                events.attrF_coef = RandomCoef();
                events.attrF_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute F) to be: " + events.attrF_coef.ToString() + " for " + events.attrF_t.ToString() + " turns";
                events.caseID = 18;
                break;
            case 19:
                events.attrG_coef = RandomCoef();
                events.attrG_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute G) to be: " + events.attrG_coef.ToString() + " for " + events.attrG_t.ToString() + " turns";
                events.caseID = 19;
                break;
            case 20:
                events.attrH_coef = RandomCoef();
                events.attrH_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Attribute H) to be: " + events.attrH_coef.ToString() + " for " + events.attrH_t.ToString() + " turns";
                events.caseID = 20;
                break;
            case 21:
                events.exp_labor_coef = RandomCoef();
                events.exp_labor_coef_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Explore Labor) to be: " + events.exp_labor_coef.ToString() + " for " + events.exp_labor_coef_t.ToString() + " turns";
                events.caseID = 21;
                break;
            case 22:
                events.test_cost_coef = RandomCoef();
                events.test_cost_coef_t = UnityEngine.Random.Range(1, 6);
                eventBtnCreated.GetComponentInChildren<Text>().text = "Change Coefficient (Test Cost) to be: " + events.test_cost_coef.ToString() + " for " + events.test_cost_coef_t.ToString() + " turns";
                events.caseID = 22;
                break;
        }
    }
    private void CreateEvent_labor_zero(Vector3 pos)
    {
        Button eventBtnCreated = Instantiate(eventBtn, pos, Quaternion.identity);
        eventBtnCreated.transform.SetParent(GameObject.FindWithTag("Main Game Scene").transform);
        Events events = eventBtnCreated.GetComponent<Events>();
        events.caseID = 0;
        events.labor_t = UnityEngine.Random.Range(1,4);
        eventBtnCreated.GetComponentInChildren<Text>().text = "no labor for " + events.labor_t.ToString() + " turns";
    }
    private float RandomCoef()
    {
        int temp = UnityEngine.Random.Range(1, 7);
        if (temp == 2)
        {
            temp = 1;
        }
        return temp * 0.5f;
    }
}



