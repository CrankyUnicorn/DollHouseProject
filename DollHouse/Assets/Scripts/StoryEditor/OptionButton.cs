using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour {

    public Text optionTextBox;

    private string optionText;
    private string optFunct;
    private int optValue;

	// Use this for initialization
	void Start () {
        optionTextBox.text = optionText;
	}

    public void OptionPressed( )
    {
        GameObject go = GameObject.FindGameObjectWithTag("ManagerDisplayer");
        go.transform.GetComponent<DialogDisplay>().DoFunction(optFunct,optValue);
        
        
    }

    public void PopulateOptionButton(string Name, string Funct, int Value)
    {
        optionText = Name;
        optFunct = Funct;
        optValue = Value;
    }
}
