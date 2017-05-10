using System.Collections;
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
    public static List<GameObject> all_nodes = new List<GameObject>();

    public Text coef_funds_time_text, coef_labor_time_text, coef_test_cost_time_text, coef_criteriaA_time_text,
        coef_criteriaB_time_text, coef_criteriaC_time_text, coef_criteriaD_time_text, coef_criteriaE_time_text, coef_criteriaF_time_text,
        coef_criteriaG_time_text, coef_criteriaH_time_text, coef_explore_labor_time_text;
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

        all_nodes.Add(GameObject.FindGameObjectWithTag("Initial Node"));
    }


    private void Update()
    {
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
        
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("all nodes list: ");
            for (int i = 0; i < GodMode.all_nodes.Count; i++)
            {
                Debug.Log(GodMode.all_nodes[i].name);
            }
        }

    }

}
