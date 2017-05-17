using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour {

    public float funds = 0, labor = 0, attrA = 0, attrB = 0, attrC = 0, attrD = 0, attrE = 0, attrF = 0, attrG = 0, attrH = 0; // caseID: 1-10
    public float funds_coef = 0, labor_coef = 0, attrA_coef = 0, attrB_coef = 0, attrC_coef = 0, attrD_coef = 0, attrE_coef = 0, attrF_coef = 0, attrG_coef = 0,
        attrH_coef = 0, exp_labor_coef = 0, test_cost_coef = 0; // caseID = 11-22
    public int funds_t = 0, labor_t = 0, attrA_t = 0, attrB_t = 0, attrC_t = 0, attrD_t = 0, attrE_t = 0, attrF_t = 0, attrG_t = 0, attrH_t = 0, exp_labor_coef_t = 0, test_cost_coef_t = 0;

    public Text funds_text, labor_text, attrA_text, attrB_text, attrC_text, attrD_text, attrE_text, attrF_text, attrG_text, attrH_text;
    public Text funds_coef_text, labor_coef_text, attrA_coef_text, attrB_coef_text, attrC_coef_text, attrD_coef_text, attrE_coef_text, attrF_coef_text, attrG_coef_text, attrH_coef_text, exp_labor_coef_text, test_cost_coef_text;
    public Text funds_turn_text, labor_turn_text, attrA_turn_text, attrB_turn_text, attrC_turn_text, attrD_turn_text, attrE_turn_text, attrF_turn_text, attrG_turn_text, attrH_turn_text, exp_labor_turn_text, test_cost_turn_text;

    public int caseID; // caseID = 0 --> set labor to be 0, for certain rounds
    public Button confirmBtn;


	void Start () {
        confirmBtn = GetComponent<Button>();
        confirmBtn.onClick.AddListener(TaskOnClick);

        funds_text = GameObject.Find("fundsValue").GetComponent<Text>();
        labor_text = GameObject.Find("laborValue").GetComponent<Text>();
        attrA_text = GameObject.FindWithTag("EstCriteriaA").GetComponent<Text>();
        attrB_text = GameObject.FindWithTag("EstCriteriaB").GetComponent<Text>();
        attrC_text = GameObject.FindWithTag("EstCriteriaC").GetComponent<Text>();
        attrD_text = GameObject.FindWithTag("EstCriteriaD").GetComponent<Text>();
        attrE_text = GameObject.FindWithTag("EstCriteriaE").GetComponent<Text>();
        attrF_text = GameObject.FindWithTag("EstCriteriaF").GetComponent<Text>();
        attrG_text = GameObject.FindWithTag("EstCriteriaG").GetComponent<Text>();
        attrH_text = GameObject.FindWithTag("EstCriteriaH").GetComponent<Text>();

        funds_coef_text = GameObject.Find("coef_fund").GetComponent<Text>();
        labor_coef_text = GameObject.Find("coef_labor").GetComponent<Text>();
        attrA_coef_text = GameObject.Find("coef_A").GetComponent<Text>();
        attrB_coef_text = GameObject.Find("coef_B").GetComponent<Text>();
        attrC_coef_text = GameObject.Find("coef_C").GetComponent<Text>();
        attrD_coef_text = GameObject.Find("coef_D").GetComponent<Text>();
        attrE_coef_text = GameObject.Find("coef_E").GetComponent<Text>();
        attrF_coef_text = GameObject.Find("coef_F").GetComponent<Text>();
        attrG_coef_text = GameObject.Find("coef_G").GetComponent<Text>();
        attrH_coef_text = GameObject.Find("coef_H").GetComponent<Text>();
        exp_labor_coef_text = GameObject.Find("coef_exploreLabor").GetComponent<Text>();
        test_cost_coef_text = GameObject.Find("coef_testCost").GetComponent<Text>();

        funds_turn_text = GameObject.Find("coef_fund_turn").GetComponent<Text>();
        labor_turn_text = GameObject.Find("coef_labor_turn").GetComponent<Text>();
        attrA_turn_text = GameObject.Find("coef_A_turn").GetComponent<Text>();
        attrB_turn_text = GameObject.Find("coef_B_turn").GetComponent<Text>();
        attrC_turn_text = GameObject.Find("coef_C_turn").GetComponent<Text>();
        attrD_turn_text = GameObject.Find("coef_D_turn").GetComponent<Text>();
        attrE_turn_text = GameObject.Find("coef_E_turn").GetComponent<Text>();
        attrF_turn_text = GameObject.Find("coef_F_turn").GetComponent<Text>();
        attrG_turn_text = GameObject.Find("coef_G_turn").GetComponent<Text>();
        attrH_turn_text = GameObject.Find("coef_H_turn").GetComponent<Text>();
        test_cost_turn_text = GameObject.Find("coef_testCost_turn").GetComponent<Text>();
        exp_labor_turn_text = GameObject.Find("coef_exploreLabor_turn").GetComponent<Text>();
    }


    private void TaskOnClick()
    {
        // based on different cases, update corresponding variable in the main game scene
        switch (caseID)
        {
            case 0:
                labor_text.text = "0";
                labor_turn_text.text = labor_t.ToString();
                break;
                // TODO: a new Text object showing how many turns will 0 be
            // the following are respect to adding
            case 1:
                funds_text.text = (float.Parse(funds_text.text) + funds * GodMode.coef_funds).ToString();
                break;
            case 2:
                labor_text.text = (float.Parse(labor_text.text) + labor * GodMode.coef_labor).ToString();
                break;
            case 3:
                attrA_text.text = (float.Parse(attrA_text.text) + attrA * GodMode.coef_criteriaA).ToString();
                break;
            case 4:
                attrB_text.text = (float.Parse(attrB_text.text) + attrB * GodMode.coef_criteriaB).ToString();
                break;
            case 5:
                attrC_text.text = (float.Parse(attrC_text.text) + attrC * GodMode.coef_criteriaC).ToString();
                break;
            case 6:
                attrD_text.text = (float.Parse(attrD_text.text) + attrD * GodMode.coef_criteriaD).ToString();
                break;
            case 7:
                attrE_text.text = (float.Parse(attrE_text.text) + attrE * GodMode.coef_criteriaE).ToString();
                break;
            case 8:
                attrF_text.text = (float.Parse(attrF_text.text) + attrF * GodMode.coef_criteriaF).ToString();
                break;
            case 9:
                attrG_text.text = (float.Parse(attrG_text.text) + attrG * GodMode.coef_criteriaG).ToString();
                break;
            case 10:
                attrH_text.text = (float.Parse(attrH_text.text) + attrH * GodMode.coef_criteriaH).ToString();
                break;

            // the following are changes in coefficients
            case 11:
                GodMode.coef_funds = funds_coef;
                funds_coef_text.text = funds_coef.ToString();
                funds_turn_text.text = funds_t.ToString();
                break;
            case 12:
                GodMode.coef_labor = labor_coef;
                labor_coef_text.text = labor_coef.ToString();
                labor_turn_text.text = labor_t.ToString();
                break;
            case 13:
                GodMode.coef_criteriaA = attrA_coef;
                GodMode.coef_criteriaA_turn = attrA_t;
                attrA_coef_text.text = attrA_coef.ToString();
                attrA_turn_text.text = attrA_t.ToString();
                break;
            case 14:
                GodMode.coef_criteriaB = attrB_coef;
                GodMode.coef_criteriaB_turn = attrB_t;
                attrB_coef_text.text = attrB_coef.ToString();
                attrB_turn_text.text = attrB_t.ToString();
                break;
            case 15:
                GodMode.coef_criteriaC = attrC_coef;
                GodMode.coef_criteriaC_turn = attrC_t;
                attrC_coef_text.text = attrC_coef.ToString();
                attrC_turn_text.text = attrC_t.ToString();
                break;
            case 16:
                GodMode.coef_criteriaD = attrD_coef;
                GodMode.coef_criteriaD_turn = attrD_t;
                attrD_coef_text.text = attrD_coef.ToString();
                attrD_turn_text.text = attrD_t.ToString();
                break;
            case 17:
                GodMode.coef_criteriaE = attrE_coef;
                GodMode.coef_criteriaE_turn = attrE_t;
                attrE_coef_text.text = attrE_coef.ToString();
                attrE_turn_text.text = attrE_t.ToString();
                break;
            case 18:
                GodMode.coef_criteriaF = attrF_coef;
                GodMode.coef_criteriaF_turn = attrF_t;
                attrF_coef_text.text = attrF_coef.ToString();
                attrF_turn_text.text = attrF_t.ToString();
                break;
            case 19:
                GodMode.coef_criteriaG = attrG_coef;
                GodMode.coef_criteriaG_turn = attrG_t;
                attrG_coef_text.text = attrG_coef.ToString();
                attrG_turn_text.text = attrG_t.ToString();
                break;
            case 20:
                GodMode.coef_criteriaH = attrH_coef;
                GodMode.coef_criteriaH_turn = attrH_t;
                attrH_coef_text.text = attrH_coef.ToString();
                attrH_turn_text.text = attrH_t.ToString();
                break;
            case 21:
                GodMode.coef_explore_labor = exp_labor_coef;
                GodMode.coef_explore_labor_turn = exp_labor_coef_t;
                exp_labor_coef_text.text = exp_labor_coef.ToString();
                exp_labor_turn_text.text = exp_labor_coef_t.ToString();
                break;
            case 22:
                GodMode.coef_testCost = test_cost_coef;
                GodMode.coef_test_cost_turn = test_cost_coef_t;
                test_cost_coef_text.text = test_cost_coef.ToString();
                test_cost_turn_text.text = test_cost_coef_t.ToString();
                break;
        }
        
        // destroy all event choice buttons
        GameObject[] btns = GameObject.FindGameObjectsWithTag("EventChoice");
        foreach(GameObject btn in btns)
        {
            Destroy(btn);
        }
    }
}
