﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeAttributes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public string[] attributes = new string[9];
    public static int attrIndex;
    public static bool colliding;
    public static string thisNode;

    public GUISkin gameSkin;
    public float funds, labor, numofturn, attrA, attrB, attrC, attrD, attrE, attrF, attrG, attrH;
    public bool ifMiniGame, ifDrill_1, ifDrill_2;
    public List<string> childNode = new List<string>();

    public bool displayInfo = false;
    private string basicInfo, criteriaA, criteriaB, criteriaC, criteriaD, criteriaE, criteriaF, criteriaG, criteriaH;
    


    void Awake () {

        funds = UnityEngine.Random.Range(15, 50) * 10;
        labor = UnityEngine.Random.Range(1, 5);
        numofturn = UnityEngine.Random.Range(1, 3);
        attrA = UnityEngine.Random.Range(0, 9);
        attrB = UnityEngine.Random.Range(0, 9);
        attrC = UnityEngine.Random.Range(0, 9);
        attrD = UnityEngine.Random.Range(0, 9);
        attrE = UnityEngine.Random.Range(0, 9);
        attrF = UnityEngine.Random.Range(0, 9);
        attrG = UnityEngine.Random.Range(0, 9);
        attrH = UnityEngine.Random.Range(0, 9);

        basicInfo = "$ " + funds + '\n' + "Labor " + labor + '\n' + "NumofTurn " + numofturn + '\n';
        criteriaA = "Criteria A " + attrA + '\n';
        criteriaB = "Criteria B " + attrB + '\n';
        criteriaC = "Criteria C " + attrC + '\n';
        criteriaD = "Criteria D " + attrD + '\n';
        criteriaE = "Criteria E " + attrE + '\n';
        criteriaF = "Criteria F " + attrF + '\n';
        criteriaG = "Criteria G " + attrG + '\n';
        criteriaH = "Criteria H " + attrH + '\n';

        UpdateDisplayInfo();

	}

	
    public void UpdateDisplayInfo()
    {
        basicInfo = "$ " + funds + '\n' + "Labor " + labor + '\n' + "NumofTurn " + numofturn + '\n';
        criteriaA = "Criteria A " + attrA + '\n';
        criteriaB = "Criteria B " + attrB + '\n';
        criteriaC = "Criteria C " + attrC + '\n';
        criteriaD = "Criteria D " + attrD + '\n';
        criteriaE = "Criteria E " + attrE + '\n';
        criteriaF = "Criteria F " + attrF + '\n';
        criteriaG = "Criteria G " + attrG + '\n';
        criteriaH = "Criteria H " + attrH + '\n';


        ManipulateString(attrIndex);

        attributes[0] = basicInfo;
        attributes[1] = criteriaA;
        attributes[2] = criteriaB;
        attributes[3] = criteriaC;
        attributes[4] = criteriaD;
        attributes[5] = criteriaE;
        attributes[6] = criteriaF;
        attributes[7] = criteriaG;
        attributes[8] = criteriaH;
    }

    private void ManipulateString(int attrIndex)
    {
        switch (attrIndex)
        {
            case 1:
                criteriaA = "Criteria A " + attrA + '\n';
                break;
            case 11:
                criteriaA = "";
                break;
            case 2:
                criteriaB = "Criteria B " + attrB + '\n';
                break;
            case 22:
                criteriaB = "";
                break;
            case 3:
                criteriaC = "Criteria C " + attrC + '\n';
                break;
            case 33:
                criteriaC = "";
                break;
            case 4:
                criteriaD = "Criteria D " + attrD + '\n';
                break;
            case 44:
                criteriaD = "";
                break;
            case 5:
                criteriaE = "Criteria E " + attrE + '\n';
                break;
            case 55:
                criteriaE = "";
                break;
            case 6:
                criteriaF = "Criteria F " + attrF + '\n';
                break;
            case 66:
                criteriaF = "";
                break;
            case 7:
                criteriaG = "Criteria G " + attrG + '\n';
                break;
            case 77:
                criteriaG = "";
                break;
            case 8:
                criteriaH = "Criteria H " + attrH + '\n';
                break;
            case 88:
                criteriaH = "";
                break;
        }
    }

    private void Update()
    {
        UpdateDisplayInfo();
    }

    void OnGUI()
	{
		GUI.skin = gameSkin;
        DisplayName();
        
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		displayInfo = true;
        colliding = true;
        thisNode = transform.parent.gameObject.name;

	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		displayInfo = false;
        colliding = false;
	}

	public void DisplayName()
	{
		if (displayInfo)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x + 20, Event.current.mousePosition.y + 10, 150, 180), Array2String(attributes));
		}
	}


    // helper method, change string array to one single string
	private string Array2String(string[] input){
		string result = "";
		for (int i = 0; i < 9; i++) {
			result += input [i];
		}
		return result;
	}


		
}
