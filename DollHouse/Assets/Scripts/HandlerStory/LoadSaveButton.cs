using UnityEngine;
using UnityEngine.UI;
using System;


public class LoadSaveButton : MonoBehaviour {

    public Text ButtonText;

    private int buttonSlotID;
    private string buttonText;
    private int loadSaveOption;

    private GameObject goLSMenu;

    private void Start()
    {
        ButtonText.text = buttonText;    
    }


    public void LoadSaveSlotClick () {


        if (loadSaveOption == GameVirtualEnums.LoadAndRun)
        {
            if ( buttonText != GameVirtualEnums.Empty)
            {
                //will auto load at the begining of next scene after ref retrival from pref file auto load
                ContainerPreferences.ins.loadedPreferences.slotToLoad = buttonSlotID;

                IOStory.ins.SaveGamePref();//Saves to what slot to load at the start of the loading game in mainscene

                FadePanel.fade.targetScene = "MainScene";
                FadePanel.fade.OnButtonClick();

                goLSMenu.GetComponent<LoadSaveMenu>().destroyThis();


            }
        }
        else if (loadSaveOption == GameVirtualEnums.LoadAndStay)
        {
            if ( buttonText != GameVirtualEnums.Empty)
            {
                IOStory.ins.LoadCurrentStory(buttonSlotID);//load game file with this ID into container

                GameObject goEditor = GameObject.FindGameObjectWithTag("EditorDisplayer");//CHANGE THIS!

                goEditor.transform.GetComponent<EditorDisplayer>().DestroyAllBottons(0);
                goEditor.transform.GetComponent<EditorDisplayer>().CallStory();

                goLSMenu.GetComponent<LoadSaveMenu>().destroyThis();
            }
        }
        else if(loadSaveOption == GameVirtualEnums.Save)
        {

            IOStory.ins.SaveCurrentStory(buttonSlotID);//save game file with file with this id slot
            goLSMenu.GetComponent<LoadSaveMenu>().destroyThis();
        }


        goLSMenu.GetComponent<LoadSaveMenu>().SaveLoadPref(loadSaveOption);//refresh bottons

    }

    public void PopulateSaveLoadButton(int i,string info,int o, GameObject go)
    {
        buttonSlotID = i;
        buttonText = info;
        loadSaveOption = o;

        goLSMenu = go;
    }
}
