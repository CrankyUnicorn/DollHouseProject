using UnityEngine;



public class ActionsMenu : MonoBehaviour {
    
    public static ActionsMenu ins = null;

    void Awake()
    {
        //Check if instance already exists
        if (ins == null)
        {

            //if not, set instance to this
            ins = this;
        }
        //If instance already exists and it's not this:
        else if (ins != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        
    }

    public GameObject loadSaveMenu;
    public GameObject optionsMenu;
    public GameObject mainCanvas;

    public bool loadAndRun;//Loads and go to game only if true else only load to container (edit mode)


    public void StartGame ()
    {
        ContainerPreferences.ins.loadedPreferences.slotToLoad = 0;
        FadePanel.fade.targetScene = "MainScene";
        FadePanel.fade.OnButtonClick();

    }

   


    //This methods get called by pressing the UI buttons on the menus
    public void LoadGame()
    {
        if (loadAndRun!=true)
        {
           
            GameObject go = Instantiate(loadSaveMenu) as GameObject;
            go.GetComponent<LoadSaveMenu>().SaveLoadPref(GameVirtualEnums.LoadAndStay);
            go.transform.SetParent(mainCanvas.transform, false);
            go.transform.SetAsLastSibling();
        }
        else 
        {
            GameObject go = Instantiate(loadSaveMenu) as GameObject;
            go.GetComponent<LoadSaveMenu>().SaveLoadPref(GameVirtualEnums.LoadAndRun);
            go.transform.SetParent(mainCanvas.transform, false);
            go.transform.SetAsLastSibling();
        }
    }

    //This methods get called by pressing the UI buttons on the menus
    public void SaveGame()
    {
            GameObject go = Instantiate(loadSaveMenu) as GameObject;
            go.GetComponent<LoadSaveMenu>().SaveLoadPref(GameVirtualEnums.Save);
            go.transform.SetParent(mainCanvas.transform, false);
            go.transform.SetAsLastSibling();
    }

    //This methods get called by pressing the UI buttons on the menus
    public void OpenEditor()
    {
        FadePanel.fade.targetScene = "Editor";
        FadePanel.fade.OnButtonClick();
    }

    //This methods get called by pressing the UI buttons on the menus
    public void OpenOptions()
    {
       
    }

    //This methods get called by pressing the UI buttons on the menus
    public void OpenHelp()
    {

    }

    //This methods get called by pressing the UI buttons on the menus
    public void ExitToMenu()
    {
        FadePanel.fade.targetScene="Menu";
        FadePanel.fade.OnButtonClick(); 
    }

    //This methods get called by pressing the UI buttons on the menus
    public void ExitGame()
    {
        FadePanel.fade.targetScene = "Quit";
        FadePanel.fade.OnButtonClick();
    }

}
