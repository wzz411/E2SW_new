﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodMode : MonoBehaviour{
    public static float coef_funds = 1f;
    public static float coef_labor = 1f;
    public static float coef_criteriaA = 1f;
    public static float coef_criteriaB = 1f;
    public static float coef_criteriaC = 1f;
    public static float coef_criteriaD = 1f;
    public static float coef_criteriaE = 1f;
    public static float coef_criteriaF = 1f;
    public static float coef_criteriaG = 1f;
    public static float coef_criteriaH = 1f;
    public static float coef_testCost = 1f;
    public static float coef_explore_labor = 1f;
    public static float coef_funds_time = 0f;
    public static float coef_labor_time = 0f;
    public static float coef_test_cost_time = 0f;
    public static float coef_criteriaA_time = 0f;
    public static float coef_criteriaB_time = 0f;
    public static float coef_criteriaC_time = 0f;
    public static float coef_criteriaD_time = 0f;
    public static float coef_criteriaE_time = 0f;
    public static float coef_criteriaF_time = 0f;
    public static float coef_criteriaG_time = 0f;
    public static float coef_criteriaH_time = 0f;
    public static float coef_explore_labor_time = 0f;
    public static int coef_funds_turn = 0;
    public static int coef_labor_turn = 0;
    public static int coef_test_cost_turn = 0;
    public static int coef_criteriaA_turn = 0;
    public static int coef_criteriaB_turn = 0;
    public static int coef_criteriaC_turn = 0;
    public static int coef_criteriaD_turn = 0;
    public static int coef_criteriaE_turn = 0;
    public static int coef_criteriaF_turn = 0;
    public static int coef_criteriaG_turn = 0;
    public static int coef_criteriaH_turn = 0;
    public static int coef_explore_labor_turn = 0;
    public static List<string> all_nodes = new List<string>();

    public Text coef_funds_time_text, coef_labor_time_text, coef_test_cost_time_text, coef_criteriaA_time_text,
        coef_criteriaB_time_text, coef_criteriaC_time_text, coef_criteriaD_time_text, coef_criteriaE_time_text, coef_criteriaF_time_text,
        coef_criteriaG_time_text, coef_criteriaH_time_text, coef_explore_labor_time_text;
    public Text coef_funds_turn_text, coef_labor_turn_text, coef_test_cost_turn_text, coef_criteriaA_turn_text,
        coef_criteriaB_turn_text, coef_criteriaC_turn_text, coef_criteriaD_turn_text, coef_criteriaE_turn_text, coef_criteriaF_turn_text,
        coef_criteriaG_turn_text, coef_criteriaH_turn_text, coef_explore_labor_turn_text;
    public Text coef_funds_text, coef_labor_text, coef_test_cost_text, coef_criteriaA_text, coef_criteriaB_text, coef_criteriaC_text, coef_criteriaD_text,
        coef_criteriaE_text, coef_criteriaF_text, coef_criteriaG_text, coef_criteriaH_text, coef_explore_labor_text;
    private void Start()
    {
        coef_funds_time_text = GameObject.Find("coef_fund_time").GetComponent<Text>();
        coef_labor_time_text = GameObject.Find("coef_labor_time").GetComponent<Text>();
        coef_test_cost_time_text = GameObject.Find("coef_testCost_time").GetComponent<Text>();
        coef_criteriaA_time_text = GameObject.Find("coef_A_time").GetComponent<Text>();
        coef_criteriaB_time_text = GameObject.Find("coef_B_time").GetComponent<Text>();
        coef_criteriaC_time_text = GameObject.Find("coef_C_time").GetComponent<Text>();
        coef_criteriaD_time_text = GameObject.Find("coef_D_time").GetComponent<Text>();
        coef_criteriaE_time_text = GameObject.Find("coef_E_time").GetComponent<Text>();
        coef_criteriaF_time_text = GameObject.Find("coef_F_time").GetComponent<Text>();
        coef_criteriaG_time_text = GameObject.Find("coef_G_time").GetComponent<Text>();
        coef_criteriaH_time_text = GameObject.Find("coef_H_time").GetComponent<Text>();
        coef_explore_labor_time_text = GameObject.Find("coef_exploreLabor_time").GetComponent<Text>();

        coef_funds_turn_text = GameObject.Find("coef_fund_turn").GetComponent<Text>();
        coef_labor_turn_text = GameObject.Find("coef_labor_turn").GetComponent<Text>();
        coef_test_cost_turn_text = GameObject.Find("coef_testCost_turn").GetComponent<Text>();
        coef_criteriaA_turn_text = GameObject.Find("coef_A_turn").GetComponent<Text>();
        coef_criteriaB_turn_text = GameObject.Find("coef_B_turn").GetComponent<Text>();
        coef_criteriaC_turn_text = GameObject.Find("coef_C_turn").GetComponent<Text>();
        coef_criteriaD_turn_text = GameObject.Find("coef_D_turn").GetComponent<Text>();
        coef_criteriaE_turn_text = GameObject.Find("coef_E_turn").GetComponent<Text>();
        coef_criteriaF_turn_text = GameObject.Find("coef_F_turn").GetComponent<Text>();
        coef_criteriaG_turn_text = GameObject.Find("coef_G_turn").GetComponent<Text>();
        coef_criteriaH_turn_text = GameObject.Find("coef_H_turn").GetComponent<Text>();
        coef_explore_labor_turn_text = GameObject.Find("coef_exploreLabor_turn").GetComponent<Text>();

        coef_funds_text = GameObject.Find("coef_fund").GetComponent<Text>();
        coef_labor_text = GameObject.Find("coef_labor").GetComponent<Text>();
        coef_test_cost_text = GameObject.Find("coef_testCost").GetComponent<Text>();
        coef_criteriaA_text = GameObject.Find("coef_A").GetComponent<Text>();
        coef_criteriaB_text = GameObject.Find("coef_B").GetComponent<Text>();
        coef_criteriaC_text = GameObject.Find("coef_C").GetComponent<Text>();
        coef_criteriaD_text = GameObject.Find("coef_D").GetComponent<Text>();
        coef_criteriaE_text = GameObject.Find("coef_E").GetComponent<Text>();
        coef_criteriaF_text = GameObject.Find("coef_F").GetComponent<Text>();
        coef_criteriaG_text = GameObject.Find("coef_G").GetComponent<Text>();
        coef_criteriaH_text = GameObject.Find("coef_H").GetComponent<Text>();
        coef_explore_labor_text = GameObject.Find("coef_exploreLabor").GetComponent<Text>();

        if(all_nodes.Count == 0)
        {
            all_nodes.Add(GameObject.FindGameObjectWithTag("Node Name").name);
        }
        
    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        /******************************************************************************************************
         ********************method regarding to show Time count down instead of turn count down***************
         ******To use this method, or to use time count down, see comment in EditModeConfirmButton_Main.cs*****
         ******************************************************************************************************
        if (coef_funds_time > 0)
        {
            coef_funds_time -= Time.deltaTime;
            coef_funds_time_text.text = coef_funds_time.ToString();
            coef_funds_text.text = coef_funds.ToString();
        }
        else
        {
            coef_funds_time_text.text = "0";
            coef_funds = 1;
            coef_funds_text.text = coef_funds.ToString();
        }

        if (coef_labor_time > 0)
        {
            coef_labor_time -= Time.deltaTime;
            coef_labor_time_text.text = coef_labor_time.ToString();
            coef_labor_text.text = coef_labor.ToString();
        }
        else
        {
            coef_labor_time_text.text = "0";
            coef_labor = 1;
            coef_labor_text.text = coef_labor.ToString();
        }

        if (coef_test_cost_time > 0)
        {
            coef_test_cost_time -= Time.deltaTime;
            coef_test_cost_time_text.text = coef_test_cost_time.ToString();
            coef_test_cost_text.text = coef_testCost.ToString();
        }
        else
        {
            coef_test_cost_time_text.text = "0";
            coef_testCost = 1;
            coef_test_cost_text.text = coef_testCost.ToString();
        }

        if (coef_criteriaA_time > 0)
        {
            coef_criteriaA_time -= Time.deltaTime;
            coef_criteriaA_time_text.text = coef_criteriaA_time.ToString();
            coef_criteriaA_text.text = coef_criteriaA.ToString();
        }
        else
        {
            coef_criteriaA_time_text.text = "0";
            coef_criteriaA = 1;
            coef_criteriaA_text.text = coef_criteriaA.ToString();
        }

        if (coef_criteriaB_time > 0)
        {
            coef_criteriaB_time -= Time.deltaTime;
            coef_criteriaB_time_text.text = coef_criteriaB_time.ToString();
            coef_criteriaB_text.text = coef_criteriaB.ToString();
        }
        else
        {
            coef_criteriaB_time_text.text = "0";
            coef_criteriaB = 1;
            coef_criteriaB_text.text = coef_criteriaB.ToString();
        }

        if (coef_criteriaC_time > 0)
        {
            coef_criteriaC_time -= Time.deltaTime;
            coef_criteriaC_time_text.text = coef_criteriaC_time.ToString();
            coef_criteriaC_text.text = coef_criteriaC.ToString();
        }
        else
        {
            coef_criteriaC_time_text.text = "0";
            coef_criteriaC = 1;
            coef_criteriaC_text.text = coef_criteriaC.ToString();
        }

        if (coef_criteriaD_time > 0)
        {
            coef_criteriaD_time -= Time.deltaTime;
            coef_criteriaD_time_text.text = coef_criteriaD_time.ToString();
            coef_criteriaD_text.text = coef_criteriaD.ToString();
        }
        else
        {
            coef_criteriaD_time_text.text = "0";
            coef_criteriaD = 1;
            coef_criteriaD_text.text = coef_criteriaD.ToString();
        }

        if (coef_criteriaE_time > 0)
        {
            coef_criteriaE_time -= Time.deltaTime;
            coef_criteriaE_time_text.text = coef_criteriaE_time.ToString();
            coef_criteriaE_text.text = coef_criteriaE.ToString();
        }
        else
        {
            coef_criteriaE_time_text.text = "0";
            coef_criteriaE = 1;
            coef_criteriaE_text.text = coef_criteriaE.ToString();
        }

        if (coef_criteriaF_time > 0)
        {
            coef_criteriaF_time -= Time.deltaTime;
            coef_criteriaF_time_text.text = coef_criteriaF_time.ToString();
            coef_criteriaF_text.text = coef_criteriaF.ToString();
        }
        else
        {
            coef_criteriaF_time_text.text = "0";
            coef_criteriaF = 1;
            coef_criteriaF_text.text = coef_criteriaF.ToString();
        }

        if (coef_criteriaG_time > 0)
        {
            coef_criteriaG_time -= Time.deltaTime;
            coef_criteriaG_time_text.text = coef_criteriaG_time.ToString();
            coef_criteriaG_text.text = coef_criteriaG.ToString();
        }
        else
        {
            coef_criteriaG_time_text.text = "0";
            coef_criteriaG = 1;
            coef_criteriaG_text.text = coef_criteriaG.ToString();
        }

        if (coef_criteriaH_time > 0)
        {
            coef_criteriaH_time -= Time.deltaTime;
            coef_criteriaH_time_text.text = coef_criteriaH_time.ToString();
            coef_criteriaH_text.text = coef_criteriaH.ToString();
        }
        else
        {
            coef_criteriaH_time_text.text = "0";
            coef_criteriaH = 1;
            coef_criteriaH_text.text = coef_criteriaH.ToString();
        }

        if (coef_explore_labor_time > 0)
        {
            coef_explore_labor_time -= Time.deltaTime;
            coef_explore_labor_time_text.text = coef_explore_labor_time.ToString();
            coef_explore_labor_text.text = coef_explore_labor.ToString();
        }
        else
        {
            coef_explore_labor_time_text.text = "0";
            coef_explore_labor = 1;
            coef_explore_labor_text.text = coef_explore_labor.ToString();
        }
        *******************************************************************************************************/


        // update any input from InputField by the user
        if (coef_funds_turn > 0)
        {
            coef_funds_turn_text.text = coef_funds_turn.ToString();
            coef_funds_text.text = coef_funds.ToString();
        }
        else
        {
            coef_funds_turn_text.text = "0";
            coef_funds = 1;
            coef_funds_text.text = coef_funds.ToString();
        }

        if (coef_labor_turn > 0)
        {
            coef_labor_turn_text.text = coef_labor_turn.ToString();
            coef_labor_text.text = coef_labor.ToString();
        }
        else
        {
            coef_labor_turn_text.text = "0";
            coef_labor = 1;
            coef_labor_text.text = coef_labor.ToString();
        }

        if (coef_test_cost_turn > 0)
        {
            coef_test_cost_turn_text.text = coef_test_cost_turn.ToString();
            coef_test_cost_text.text = coef_testCost.ToString();
        }
        else
        {
            coef_test_cost_turn_text.text = "0";
            coef_testCost = 1;
            coef_test_cost_text.text = coef_testCost.ToString();
        }

        if (coef_criteriaA_turn > 0)
        {
            coef_criteriaA_turn_text.text = coef_criteriaA_turn.ToString();
            coef_criteriaA_text.text = coef_criteriaA.ToString();
        }
        else
        {
            coef_criteriaA_turn_text.text = "0";
            coef_criteriaA = 1;
            coef_criteriaA_text.text = coef_criteriaA.ToString();
        }

        if (coef_criteriaB_turn > 0)
        {
            coef_criteriaB_turn_text.text = coef_criteriaB_turn.ToString();
            coef_criteriaB_text.text = coef_criteriaB.ToString();
        }
        else
        {
            coef_criteriaB_turn_text.text = "0";
            coef_criteriaB = 1;
            coef_criteriaB_text.text = coef_criteriaB.ToString();
        }

        if (coef_criteriaC_turn > 0)
        {
            coef_criteriaC_turn_text.text = coef_criteriaC_turn.ToString();
            coef_criteriaC_text.text = coef_criteriaC.ToString();
        }
        else
        {
            coef_criteriaC_turn_text.text = "0";
            coef_criteriaC = 1;
            coef_criteriaC_text.text = coef_criteriaC.ToString();
        }

        if (coef_criteriaD_turn > 0)
        {
            coef_criteriaD_turn_text.text = coef_criteriaD_turn.ToString();
            coef_criteriaD_text.text = coef_criteriaD.ToString();
        }
        else
        {
            coef_criteriaD_turn_text.text = "0";
            coef_criteriaD = 1;
            coef_criteriaD_text.text = coef_criteriaD.ToString();
        }

        if (coef_criteriaE_turn > 0)
        {
            coef_criteriaE_turn_text.text = coef_criteriaE_turn.ToString();
            coef_criteriaE_text.text = coef_criteriaE.ToString();
        }
        else
        {
            coef_criteriaE_turn_text.text = "0";
            coef_criteriaE = 1;
            coef_criteriaE_text.text = coef_criteriaE.ToString();
        }

        if (coef_criteriaF_turn > 0)
        {
            coef_criteriaF_turn_text.text = coef_criteriaF_turn.ToString();
            coef_criteriaF_text.text = coef_criteriaF.ToString();
        }
        else
        {
            coef_criteriaF_turn_text.text = "0";
            coef_criteriaF = 1;
            coef_criteriaF_text.text = coef_criteriaF.ToString();
        }

        if (coef_criteriaG_turn > 0)
        {
            coef_criteriaG_turn_text.text = coef_criteriaG_turn.ToString();
            coef_criteriaG_text.text = coef_criteriaG.ToString();
        }
        else
        {
            coef_criteriaG_turn_text.text = "0";
            coef_criteriaG = 1;
            coef_criteriaG_text.text = coef_criteriaG.ToString();
        }

        if (coef_criteriaH_turn > 0)
        {
            coef_criteriaH_turn_text.text = coef_criteriaH_turn.ToString();
            coef_criteriaH_text.text = coef_criteriaH.ToString();
        }
        else
        {
            coef_criteriaH_turn_text.text = "0";
            coef_criteriaH = 1;
            coef_criteriaH_text.text = coef_criteriaH.ToString();
        }

        if (coef_explore_labor_turn > 0)
        {
            coef_explore_labor_turn_text.text = coef_explore_labor_turn.ToString();
            coef_explore_labor_text.text = coef_explore_labor.ToString();
        }
        else
        {
            coef_explore_labor_turn_text.text = "0";
            coef_explore_labor = 1;
            coef_explore_labor_text.text = coef_explore_labor.ToString();
        }


        // a method to see list of all nodes' names 
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("all nodes (" + all_nodes.Count + ") list: ");
            for (int i = 0; i < GodMode.all_nodes.Count; i++)
            {
                Debug.Log(GodMode.all_nodes[i]);
            }
        }


    }

}
