using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour {

    public string ClickOption;
    private GameObject target;

	// Use this for initialization
	void Start () {


        if (ClickOption == "Save")
        {
            GetComponent<Button>().onClick.AddListener(ActionsMenu.ins.SaveGame);
        }
        else if (ClickOption == "Load")
        {
            GetComponent<Button>().onClick.AddListener(ActionsMenu.ins.LoadGame);
        }
        else if (ClickOption == "Help")
        {
            GetComponent<Button>().onClick.AddListener(ActionsMenu.ins.OpenHelp);
        }
        else if (ClickOption == "Options")
        {
            GetComponent<Button>().onClick.AddListener(ActionsMenu.ins.OpenOptions);
        }
        else if(ClickOption == "Exit")
        {
            GetComponent<Button>().onClick.AddListener(ActionsMenu.ins.ExitToMenu);
        }
       
    }
	
	
}
