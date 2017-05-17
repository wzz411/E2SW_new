﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditModeConfirmButton_Main : MonoBehaviour {
    public InputField funds_input, labor_input, current_input, remaining_input, overallPG_input, numofPN_input, numofTP_input, coef_funds_input,
        coef_labor_input, coef_testCost_input, coef_criteriaA_input, coef_criteriaB_input, coef_criteriaC_input, coef_criteriaD_input, coef_criteriaE_input,
        coef_criteriaF_input, coef_criteriaG_input, coef_criteriaH_input, coef_expolore_labor_input;
    public InputField coef_funds_turn_input, coef_labor_turn_input, coef_test_cost_turn_input, coef_criteriaA_turn_input, coef_criteriaB_turn_input, coef_criteriaC_turn_input, coef_criteriaD_turn_input, coef_criteriaE_turn_input, coef_criteriaF_turn_input, coef_criteriaG_turn_input, coef_criteriaH_turn_input, coef_explore_labor_turn_input;
    /*******************************************************************************************************************************************************************************
     * written for Time count down, instead of turn count down. To use this part of code, in EditPanelMain, drag the correct InputField to the coresponding variable
     *  public InputField coef_funds_time_input, coef_labor_time_input, coef_test_cost_time_input, coef_criteriaA_time_input, coef_criteriaB_time_input, coef_criteriaC_time_input, coef_criteriaD_time_input, coef_criteriaE_time_input, coef_criteriaF_time_input, coef_criteriaG_time_input, coef_criteriaH_time_input, coef_explore_labor_time_input;
    *********************************************************************************************************************************************************************************/
    public Text funds, labor, current, remaining, overallPG, numofPN, numofTP;
    public Button confirmButton;
    // Use this for initialization
    void Start () {
        confirmButton = GetComponent<Button>();
        confirmButton.onClick.AddListener(TaskOnClick);

        funds = GameObject.Find("fundsValue").GetComponent<Text>();
        labor = GameObject.Find("laborValue").GetComponent<Text>();
        current = GameObject.Find("currentTurnValue").GetComponent<Text>();
        remaining = GameObject.Find("turnsRemainingValue").GetComponent<Text>();
        overallPG = GameObject.Find("overallPGValue").GetComponent<Text>();
        numofPN = GameObject.Find("numofPNValue").GetComponent<Text>();
        numofTP = GameObject.Find("numofTPValue").GetComponent<Text>();
    }

    


    private void TaskOnClick()
    {
        if (funds_input.text != "")
        {
            funds.text = funds_input.text;
        }
        if (labor_input.text != "")
        {
            labor.text = labor_input.text;
        }
        if (current_input.text != "")
        {
            current.text = current_input.text;
        }
        if(remaining_input.text != "")
        {
            remaining.text = remaining_input.text;
        }
        if(overallPG_input.text != "")
        {
            overallPG.text = overallPG_input.text;
        }
        if(numofPN_input.text != "")
        {
            numofPN.text = numofPN_input.text;
        }
        if(numofTP_input.text != "")
        {
            numofTP.text = numofTP_input.text;
        }



        if(coef_funds_input.text != "")
        {
            GodMode.coef_funds = float.Parse(coef_funds_input.text);
        }
        if (coef_labor_input.text != "")
        {
            GodMode.coef_labor = float.Parse(coef_labor_input.text);
        }
        if (coef_testCost_input.text != "")
        {
            GodMode.coef_testCost = float.Parse(coef_testCost_input.text);
        }
        if (coef_criteriaA_input.text != "")
        {
            GodMode.coef_criteriaA = float.Parse(coef_criteriaA_input.text);
        }
        if (coef_criteriaB_input.text != "")
        {
            GodMode.coef_criteriaB = float.Parse(coef_criteriaB_input.text);
        }
        if (coef_criteriaC_input.text != "")
        {
            GodMode.coef_criteriaC = float.Parse(coef_criteriaC_input.text);
        }
        if (coef_criteriaD_input.text != "")
        {
            GodMode.coef_criteriaD = float.Parse(coef_criteriaD_input.text);
        }
        if (coef_criteriaE_input.text != "")
        {
            GodMode.coef_criteriaE = float.Parse(coef_criteriaE_input.text);
        }
        if (coef_criteriaF_input.text != "")
        {
            GodMode.coef_criteriaF = float.Parse(coef_criteriaF_input.text);
        }
        if (coef_criteriaG_input.text != "")
        {
            GodMode.coef_criteriaG = float.Parse(coef_criteriaG_input.text);
        }
        if (coef_criteriaH_input.text != "")
        {
            GodMode.coef_criteriaH = float.Parse(coef_criteriaH_input.text);
        }
        if (coef_expolore_labor_input.text != "")
        {
            GodMode.coef_explore_labor = float.Parse(coef_expolore_labor_input.text);
        }
        if (coef_funds_turn_input.text != "")
        {
            GodMode.coef_funds_turn = int.Parse(coef_funds_turn_input.text);
        }
        if (coef_labor_turn_input.text != "")
        {
            GodMode.coef_labor_turn = int.Parse(coef_labor_turn_input.text);
        }
        if (coef_test_cost_turn_input.text != "")
        {
            GodMode.coef_test_cost_turn = int.Parse(coef_test_cost_turn_input.text);
        }
        if (coef_criteriaA_turn_input.text != "")
        {
            GodMode.coef_criteriaA_turn = int.Parse(coef_criteriaA_turn_input.text);
        }
        if (coef_criteriaB_turn_input.text != "")
        {
            GodMode.coef_criteriaB_turn = int.Parse(coef_criteriaB_turn_input.text);
        }
        if (coef_criteriaC_turn_input.text != "")
        {
            GodMode.coef_criteriaC_turn = int.Parse(coef_criteriaC_turn_input.text);
        }
        if (coef_criteriaD_turn_input.text != "")
        {
            GodMode.coef_criteriaD_turn = int.Parse(coef_criteriaD_turn_input.text);
        }
        if (coef_criteriaE_turn_input.text != "")
        {
            GodMode.coef_criteriaE_turn = int.Parse(coef_criteriaE_turn_input.text);
        }
        if (coef_criteriaF_turn_input.text != "")
        {
            GodMode.coef_criteriaF_turn = int.Parse(coef_criteriaF_turn_input.text);
        }
        if (coef_criteriaG_turn_input.text != "")
        {
            GodMode.coef_criteriaG_turn = int.Parse(coef_criteriaG_turn_input.text);
        }
        if (coef_criteriaH_turn_input.text != "")
        {
            GodMode.coef_criteriaH_turn = int.Parse(coef_criteriaH_turn_input.text);
        }
        if (coef_explore_labor_turn_input.text != "")
        {
            GodMode.coef_explore_labor_turn = int.Parse(coef_explore_labor_turn_input.text);
        }

        /*******************************************************************************************************************************************************************
         * written for Time count down, instead of turn count down. To use this part of code, in EditPanelMain, drag the correct InputField to the coresponding variable
         *******************************************************************************************************************************************************************
         * if (coef_funds_time_input.text != "")
        {
            GodMode.coef_funds_time = float.Parse(coef_funds_time_input.text);
        }
        if (coef_labor_time_input.text != "")
        {
            GodMode.coef_labor_time = float.Parse(coef_labor_time_input.text);
        }
        if (coef_test_cost_time_input.text != "")
        {
            GodMode.coef_test_cost_time = float.Parse(coef_test_cost_time_input.text);
        }
        if (coef_criteriaA_time_input.text != "")
        {
            GodMode.coef_criteriaA_time = float.Parse(coef_criteriaA_time_input.text);
        }
        if (coef_criteriaB_time_input.text != "")
        {
            GodMode.coef_criteriaB_time = float.Parse(coef_criteriaB_time_input.text);
        }
        if (coef_criteriaC_time_input.text != "")
        {
            GodMode.coef_criteriaC_time = float.Parse(coef_criteriaC_time_input.text);
        }
        if (coef_criteriaD_time_input.text != "")
        {
            GodMode.coef_criteriaD_time = float.Parse(coef_criteriaD_time_input.text);
        }
        if (coef_criteriaE_time_input.text != "")
        {
            GodMode.coef_criteriaE_time = float.Parse(coef_criteriaE_time_input.text);
        }
        if (coef_criteriaF_time_input.text != "")
        {
            GodMode.coef_criteriaF_time = float.Parse(coef_criteriaF_time_input.text);
        }
        if (coef_criteriaG_time_input.text != "")
        {
            GodMode.coef_criteriaG_time = float.Parse(coef_criteriaG_time_input.text);
        }
        if (coef_criteriaH_time_input.text != "")
        {
            GodMode.coef_criteriaH_time = float.Parse(coef_criteriaH_time_input.text);
        }
        if (coef_explore_labor_time_input.text != "")
        {
            GodMode.coef_explore_labor_time = float.Parse(coef_explore_labor_time_input.text);
        }
        ****************************************************************************************************************************************************************/


        transform.parent.localScale = new Vector3(0f,0f,0f);
        //Destroy(transform.parent.gameObject);
        GameObject[] editBtns = GameObject.FindGameObjectsWithTag("Edit Button");
        foreach (GameObject editBtn in editBtns)
        {
            editBtn.GetComponent<Button>().enabled = true;
        }
    }



}
