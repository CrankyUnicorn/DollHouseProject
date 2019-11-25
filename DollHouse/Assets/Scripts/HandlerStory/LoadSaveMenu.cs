using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSaveMenu : MonoBehaviour {

    public Transform LoadSaveButton;
    public Transform buttonsTarget;
    public Text headerText;

    private int LoadSaveOpt;

    private string info;

    private void Start()
    {
        //SaveLoadPref(LoadSaveOpt);
    }

    public void SaveLoadPref (int opt)
    {
        //be sure its the right input to create load or save panel
        if (opt == GameVirtualEnums.Save)
        {
            headerText.text = "Save";
            LoadSaveOpt = opt;
        }
        else if( opt == GameVirtualEnums.LoadAndStay || opt == GameVirtualEnums.LoadAndRun)
        {
            headerText.text = "Load";
            LoadSaveOpt = opt;
        }
        else
        {
            Debug.Log("WRONG INPUT!");
        }
        

        //cleaning
        foreach (Transform child in buttonsTarget) 
        {
            Destroy(child.gameObject);
            
        }

          
        //creating buttons
        for (int i = 1; i < IOStory.ins.saveSlotsRef; i++)
        {

            info= ContainerPreferences.ins.loadedPreferences.saveNameSlots[i]; 
            Transform go = Instantiate(LoadSaveButton) as Transform;

            if (LoadSaveOpt == GameVirtualEnums.Save)
            {
                go.GetComponent<Image>().color = Color.red;
            }

            go.GetComponent<LoadSaveButton>().PopulateSaveLoadButton(i, info, LoadSaveOpt, this.gameObject);
           
            go.SetParent(buttonsTarget);
        }
	}

   

    public void destroyThis()
    {
      Destroy(this.transform.gameObject);
    }
	
}
