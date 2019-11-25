using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*This Class deal with the information output/display ingame but not Dialog...dialogs are treated as parallel system*/
public class GameInfoDisplay : MonoBehaviour { 


    public static GameInfoDisplay ins;
    private void Awake()
    {
        ins = this;
    }

    [Header("ContentPanel")]
    public Transform targetStatusPanel;
    [Header("SliderPanel")]
    public Transform targetForStatusContent;
    [Header("StatusLine")]
    public Transform statusPrefab;
    [Header("StatusLineDropdown")]
    public Transform statusPrefabDrop;
    [Header("Clock Button")]
    public Text timeDisplay;
    [Header("Money Button")]
    public Text moneyDisplay;
    [Header("Open or Closed Button")]
    public GameObject openCloseDisplay;
    [Header("Kickingout Button")]
    public GameObject kickingoutDisplay;


    public bool infoPanelOpen;
    private string openPanelName;

    private List<string> statusList = new List<string>();

    public delegate void InfoDisplayEventTrue();
    public static event InfoDisplayEventTrue OnInfoDisplayEventTrue;

    public delegate void InfoDisplayEventFalse();
    public static event InfoDisplayEventFalse OnInfoDisplayEventFalse;

    //TIME RELATED STATS
    #region
    private void OnEnable()
    {
        CoreLoop.OnCoreLoopTrigger += DisplayTime;
        CoreLoop.OnCoreLoopTrigger += DisplayMoney;

        GameScapeActions.OnActionTigger += DisplayBuildingOpenOrNot;
        GameScapeActions.OnActionTigger += DisplayKickoutClients;

        GameScapeReferencesHandler.OnOpenInfoBoxEvent += DisplayBuildingOpenOrNot;
        GameScapeReferencesHandler.OnOpenInfoBoxEvent +=  DisplayKickoutClients;
        GameScapeReferencesHandler.OnCloseInfoBoxEvent += DisplayBuildingOpenOrNot;
        GameScapeReferencesHandler.OnCloseInfoBoxEvent += DisplayKickoutClients;
    }

    private void OnDisable()
    {
        CoreLoop.OnCoreLoopTrigger -= DisplayTime;
        CoreLoop.OnCoreLoopTrigger -= DisplayMoney;

        GameScapeActions.OnActionTigger += DisplayBuildingOpenOrNot;
        GameScapeActions.OnActionTigger += DisplayKickoutClients;

        GameScapeReferencesHandler.OnOpenInfoBoxEvent -= DisplayBuildingOpenOrNot;
        GameScapeReferencesHandler.OnOpenInfoBoxEvent -= DisplayKickoutClients;
        GameScapeReferencesHandler.OnCloseInfoBoxEvent -= DisplayBuildingOpenOrNot;
        GameScapeReferencesHandler.OnCloseInfoBoxEvent -= DisplayKickoutClients;
    }
  
    public void Start()
    {
        DisplayTime();
        DisplayMoney();
        DisplayBuildingOpenOrNot();
        DisplayKickoutClients();
    }

    public void DisplayTime() //display time on selected text box
    {

        timeDisplay.text = ContainerStory.ins.actStory.ActHour.ToString() + ":00h "
                         + ContainerStory.ins.actStory.ActDayPart.ToString() + "\n "
                         + ContainerStory.ins.actStory.ActDay.ToString() + " / "
                         + ContainerStory.ins.actStory.ActMonth.ToString() + " / "
                         + ContainerStory.ins.actStory.ActYear.ToString() + "\n "
                         + ContainerStory.ins.actStory.ActWeekday.ToString();

    }

    public void DisplayMoney() //display time on selected text box
    {
        
        moneyDisplay.text = ContainerStory.ins.actStory.ActMoney.ToString() + " $";
    }

    public void DisplayBuildingOpenOrNot()
    {

        ColorBlock cb = openCloseDisplay.GetComponent<Button>().colors;

        if (ContainerStory.ins.actStory.ClientsContainer.Count == 0)
        {
            openCloseDisplay.GetComponentInChildren<Text>().text = ContainerStory.ins.actStory.BuildingOpen ? "Open" : "Closed";

            cb.highlightedColor = ContainerStory.ins.actStory.BuildingOpen ? Color.green : Color.red;
            cb.normalColor = ContainerStory.ins.actStory.BuildingOpen ? Color.green : Color.red;
            openCloseDisplay.GetComponent<Button>().colors = cb;
        }
        else
        {
            openCloseDisplay.GetComponentInChildren<Text>().text = ContainerStory.ins.actStory.BuildingOpen ? "Open" : "Closing...";

            cb.highlightedColor = ContainerStory.ins.actStory.BuildingOpen ? Color.green : Color.yellow;
            cb.normalColor = ContainerStory.ins.actStory.BuildingOpen ? Color.green : Color.yellow;
            openCloseDisplay.GetComponent<Button>().colors = cb;
        }
        
    }

    public void DisplayKickoutClients()
    {

        ColorBlock cb = kickingoutDisplay.GetComponent<Button>().colors;

        Color orange = new Color(1f, 0.5f, 0f, 1f);

        if (ContainerStory.ins.actStory.ClientsContainer.Count == 0)
        {
            kickingoutDisplay.GetComponentInChildren<Text>().text = ContainerStory.ins.actStory.KickoutOrder ? "Empty" : "Empty";

            cb.highlightedColor = ContainerStory.ins.actStory.KickoutOrder ? Color.yellow : Color.yellow;
            kickingoutDisplay.GetComponent<Button>().colors = cb;
        }
        else
        {
            kickingoutDisplay.GetComponentInChildren<Text>().text = ContainerStory.ins.actStory.KickoutOrder ? "Kickingout..." : "Kickout?";

            cb.highlightedColor = ContainerStory.ins.actStory.KickoutOrder ? Color.red :  orange;
            kickingoutDisplay.GetComponent<Button>().colors = cb;
        }

    }
    #endregion

    //METHODS FOR REFRESHING BUTTONS
    public void RefeshStatus()
    {
        infoPanelOpen = false;
        if (openPanelName == "Status")
        {
            ClickStatus();
        }else if (openPanelName == ContainerStory.ins.actStory.BuildingInventoryType)
        {
            ClickStock();
        }else if (openPanelName == "Finances")
        {
            ClickFinances();
        }else if (openPanelName == "Building")
        {
            ClickBuilding();
        }else if (openPanelName == "Achivements")
        {
            ClickAchivements();
        }
        else if (openPanelName == "Characters")
        {
            ClickCharacters();
        }
    }

    //Displays PLAYER STATUS status
    public void ClickStatus()
    {
        statusList.Clear();

        foreach (Transform child in targetForStatusContent)
        {
            Destroy(child.gameObject);

        }

        if (infoPanelOpen == true && openPanelName == "Status")
        {

            if (OnInfoDisplayEventFalse != null) { OnInfoDisplayEventFalse(); }//Delegate event

            infoPanelOpen = false;
            targetStatusPanel.gameObject.SetActive(false);

        }
        else 
        {
            if (OnInfoDisplayEventTrue != null) { OnInfoDisplayEventTrue(); }//Delegate event

            infoPanelOpen = true;
            targetStatusPanel.gameObject.SetActive(true);

            openPanelName = "Status";

            statusList.Add("STATUS");

            List<string> alpha = new List<string>();

            alpha.Add("FirstName");
            alpha.Add("LastName");
            alpha.Add("Description");
            alpha.Add("BirthdayDay");
            alpha.Add("BirthdayMonth");
            alpha.Add("Zodiac");
            alpha.Add("Bloodtype");
            alpha.Add("IncapacitatedTicks");
            alpha.Add("PlayerCharisma");
            alpha.Add("PlayerFame");
            alpha.Add("PlayerFlatter");
            alpha.Add("PlayerWit");
            alpha.Add("PlayerPersuasion");
            alpha.Add("PlayerBargain");

            //PLAYER STATUS
            for (int i = 0; i < alpha.Count; i++)
            {

            string e = "";
            
            if (ContainerStory.ins.actStory.GetType().GetProperty(alpha[i]).GetValue(ContainerStory.ins.actStory, null) != null)
            {
                e = ContainerStory.ins.actStory.GetType().GetProperty(alpha[i]).GetValue(ContainerStory.ins.actStory, null).ToString();
            }

            
                statusList.Add(alpha[i] +": "+e);
            }

            List<string> delta = new List<string>();
            
            foreach (Item item in ContainerStory.ins.actStory.Inventory)//find items of kind stock
            {
                if (item.Able == true && item.Unlock == true)
                {
                    delta.Add("Name");
                    delta.Add("Description");
                    delta.Add("Quantity");
                    delta.Add("SellPrice");
                }
            }
            statusList.Add("");
            statusList.Add("INVENTORY");

            //Player Inventory
            for (int c = 0; c < ContainerStory.ins.actStory.Inventory.Count; c++)
            {
                //find by name the values for each item
                for (int i = 0; i < delta.Count; i++)
                {
                    // Debug.Log(delta[i]);
                    string e = "";

                    if (ContainerStory.ins.actStory.Inventory[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.Inventory[c], null) != null)
                    {
                        e = ContainerStory.ins.actStory.Inventory[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.Inventory[c], null).ToString();
                    }

                    statusList.Add(delta[i] + ": " + e);
                }
                statusList.Add("------------");
            }

            foreach (string _passString in statusList)
            {
                string tempText = _passString;
                Transform go = Instantiate(statusPrefab) as Transform;

                go.GetComponent<GameInfoButton>().PopulateStatusBotton(tempText);

                go.SetParent(targetForStatusContent);
            }
        }

    }

    //Displays STOCK AKA BUILDING INVENTORY status
    public void ClickStock()
    {
        statusList.Clear();

        foreach (Transform child in targetForStatusContent)
        {
            Destroy(child.gameObject);

        }

        if (infoPanelOpen == true && openPanelName == ContainerStory.ins.actStory.BuildingInventoryType)//if panel open close
        {
            if (OnInfoDisplayEventFalse != null) { OnInfoDisplayEventFalse(); }//Delegate event

            infoPanelOpen = false;
            targetStatusPanel.gameObject.SetActive(false);
            

        }
        else //if not open, open, name and populate
        {
            if (OnInfoDisplayEventTrue != null) { OnInfoDisplayEventTrue(); }//Delegate event

            infoPanelOpen = true;
            targetStatusPanel.gameObject.SetActive(true);

            openPanelName = ContainerStory.ins.actStory.BuildingInventoryType;

            //sets in a list what types of proprieties to get from the inventory items
            List<string> delta = new List<string>();

            delta.Add("Name");
            delta.Add("Description");
            delta.Add("Quantity");
            delta.Add("SellPrice");
            delta.Add("SPACER");


            //Building Inventory
            for (int c = 0; c < ContainerStory.ins.actStory.BuildingInventory.Count; c++)
            {
                //find by name the values for each item
                for (int i = 0; i < delta.Count; i++)
                {
                    if (delta[i]!= "SPACER")
                    {

                        // Debug.Log(delta[i]);
                        string e = "";

                        if (ContainerStory.ins.actStory.BuildingInventory[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.BuildingInventory[c], null) != null)
                        {
                            e = ContainerStory.ins.actStory.BuildingInventory[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.BuildingInventory[c], null).ToString();
                        }

                        statusList.Add(delta[i] + ": " + e);
                    }
                    else
                    {
                        statusList.Add("-----------");
                    }
                }
            }

            //populate panel with buttons with prossessed info string list of Building Inventory
            foreach (string _passString in statusList)
                {
                    string tempText = _passString;
                    Transform go = Instantiate(statusPrefab) as Transform;

                    go.GetComponent<GameInfoButton>().PopulateStatusBotton(tempText);

                    go.SetParent(targetForStatusContent);
                }
            
        }
    }

    //Displays FINANCIAL status
    public void ClickFinances()
    {
        statusList.Clear();

        foreach (Transform child in targetForStatusContent)
        {
            Destroy(child.gameObject);

        }

        if (infoPanelOpen == true && openPanelName == "Finances")
        {
            if (OnInfoDisplayEventFalse != null) { OnInfoDisplayEventFalse(); }//Delegate event

            infoPanelOpen = false;
            targetStatusPanel.gameObject.SetActive(false);
            

        }
        else 
        {
            if (OnInfoDisplayEventTrue != null) { OnInfoDisplayEventTrue(); }//Delegate event

            infoPanelOpen = true;
            targetStatusPanel.gameObject.SetActive(true);

            openPanelName = "Finances";

            
            List<string> delta = new List<string>();
            delta.Add("ActMoney");
            delta.Add("SPACER");
            delta.Add("ActDayIncome");
            delta.Add("ActDayExpenses");
            delta.Add("ActDayClients");
            delta.Add("ActDayClientsHappiness");
            delta.Add("ActMonthIncome");
            delta.Add("ActMonthExpenses");
            delta.Add("ActMonthClients");
            delta.Add("ActMonthClientsHappiness");
            delta.Add("SPACER");
            delta.Add("LastDayIncome");
            delta.Add("LastDayExpenses");
            delta.Add("LastDayClients");
            delta.Add("LastDayClientsHappiness");
            delta.Add("LastMonthIncome");
            delta.Add("LastMonthExpenses");
            delta.Add("LastMonthClients");
            delta.Add("LastMonthClientsHappiness");
            delta.Add("SPACER");
            delta.Add("ActDaySells");
            delta.Add("LastDaySells");
            delta.Add("ActMonthSells");
            delta.Add("LastMonthSells");
            delta.Add("SPACER");
            delta.Add("ActTotalDebt");
            

            for (int i = 0; i < delta.Count; i++)
            {
                if (delta[i] != "SPACER")
                {
                    string e = "";

                    if (ContainerStory.ins.actStory.GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory, null) != null)
                    {
                        e = ContainerStory.ins.actStory.GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory, null).ToString();
                    }


                    statusList.Add(delta[i] + ": " + e);
                }

                else
                {
                    statusList.Add("-----------");
                }
            }

            foreach (string _passString in statusList)
            {
                string tempText = _passString;
                Transform go = Instantiate(statusPrefab) as Transform;

                go.GetComponent<GameInfoButton>().PopulateStatusBotton(tempText);

                go.SetParent(targetForStatusContent);
            }
        }
    }

    //Displays BUILDING status
    public void ClickBuilding()
    {
        statusList.Clear();

        foreach (Transform child in targetForStatusContent)
        {
            Destroy(child.gameObject);

        }

        if (infoPanelOpen == true && openPanelName == "Building")
        {
            if (OnInfoDisplayEventFalse != null) { OnInfoDisplayEventFalse(); }//Delegate event

            infoPanelOpen = false;
            targetStatusPanel.gameObject.SetActive(false);

        }
        else 
        {
            if (OnInfoDisplayEventTrue != null) { OnInfoDisplayEventTrue(); }//Delegate event


            infoPanelOpen = true;
            targetStatusPanel.gameObject.SetActive(true);

            openPanelName = "Building";

            int deltaCount = 0;
            List<string> delta = new List<string>();
            delta.Add("BuildingName");
            delta.Add("BuildingReputation");
            delta.Add("BuildingNotoriety");
            delta.Add("BuildingLuxury");
            delta.Add("BuildingUpdateLevel");

            deltaCount = delta.Count;

            for (int i = 0; i < delta.Count; i++)
            {
                string e = "";

                if (ContainerStory.ins.actStory.GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory, null) != null)
                {
                    e = ContainerStory.ins.actStory.GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory, null).ToString();
                }
                statusList.Add(delta[i] + ": " + e);
            }

            //
            if (ContainerStory.ins.actStory.BuildingUpgradeContainer.Count>0)
            {
                foreach (BuildingUpgrade buildUp in ContainerStory.ins.actStory.BuildingUpgradeContainer)//find items of kind stock
                {
                    if (buildUp.Able==true && buildUp.Unlock==true)
                    {
                        delta.Add("BuildingUpgradeName");
                        delta.Add("BuildingUpgradeUpdateLevel");
                        delta.Add("BuildingUpgradeReputation");
                        delta.Add("BuildingUpgradeNotoriety");
                        delta.Add("BuildingUpgradeLuxury");
                    }

                }
            }
            for (int c = 0; c < ContainerStory.ins.actStory.BuildingUpgradeContainer.Count; c++)
            {
                //find by name the values for each item
                for (int i = deltaCount; i < delta.Count; i++)
                {

                    string e = "";

                    if (ContainerStory.ins.actStory.BuildingUpgradeContainer[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.BuildingUpgradeContainer[c], null) != null)
                    {
                        e = ContainerStory.ins.actStory.BuildingUpgradeContainer[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.BuildingUpgradeContainer[c], null).ToString();
                    }


                    statusList.Add(delta[i] + ": " + e);
                }
            }
            foreach (string _passString in statusList)
            {
                string tempText = _passString;
                Transform go = Instantiate(statusPrefab) as Transform;

                go.GetComponent<GameInfoButton>().PopulateStatusBotton(tempText);

                go.SetParent(targetForStatusContent);
            }
        }
    }

    //Displays ACHIVEMENTS status
    public void ClickAchivements()
    {
        statusList.Clear();

        foreach (Transform child in targetForStatusContent)
        {
            Destroy(child.gameObject);

        }

        if (infoPanelOpen == true && openPanelName == "Achivements")
        {
            if (OnInfoDisplayEventFalse != null) { OnInfoDisplayEventFalse(); }//Delegate event

            infoPanelOpen = false;
            targetStatusPanel.gameObject.SetActive(false);

        }
        else 
        {
            if (OnInfoDisplayEventTrue != null) { OnInfoDisplayEventTrue(); }//Delegate event

            infoPanelOpen = true;
            targetStatusPanel.gameObject.SetActive(true);

            openPanelName = "Achivements";


            if (ContainerStory.ins.actStory.AchivementsContainer.Count > 0)
            {

                List<string> delta = new List<string>();
                delta.Add("Name");
                delta.Add("Description");
                delta.Add("AchivementEffect1");
                delta.Add("AchivementEffect1Value");
                delta.Add("AchivementEffect2");
                delta.Add("AchivementEffect2Value");
                delta.Add("AchivementEffect3");
                delta.Add("AchivementEffect3Value");

                foreach (Achivement achiv in ContainerStory.ins.actStory.AchivementsContainer)//find items of kind stock
                {
                    
                    if (achiv.Unlock == true && achiv.Able == true)
                    {
                        for (int i = 0; i < delta.Count; i++)
                        {
                            
                            string e = "";

                            if (achiv.GetType().GetProperty(delta[i]).GetValue(achiv, null) != null)
                            {
                                e = achiv.GetType().GetProperty(delta[i]).GetValue(achiv, null).ToString();
                            }

                            statusList.Add(delta[i] + ": " + e);
                        }
                    }

                }
               
                foreach (string _passString in statusList)
                {
                    string tempText = _passString;
                    Transform go = Instantiate(statusPrefab) as Transform;

                    go.GetComponent<GameInfoButton>().PopulateStatusBotton(tempText);

                    go.SetParent(targetForStatusContent);
                }
            }
        }
    }

    //Displays CHARACTERS status
    public void ClickCharacters()
    {
        statusList.Clear();
        int goDropTimes = 0;
        List<string> goDropName = new List<string>();
        


        foreach (Transform child in targetForStatusContent)
        {
            Destroy(child.gameObject);

        }

        if (infoPanelOpen == true && openPanelName == "Characters")
        {
            if (OnInfoDisplayEventFalse != null) { OnInfoDisplayEventFalse(); }//Delegate event

            infoPanelOpen = false;
            targetStatusPanel.gameObject.SetActive(false);
            

        }
        else 
        {
            if (OnInfoDisplayEventTrue != null) { OnInfoDisplayEventTrue(); }//Delegate event

            infoPanelOpen = true;
            targetStatusPanel.gameObject.SetActive(true);

            openPanelName = "Characters";


            
            if (ContainerStory.ins.actStory.CharactersContainer.Count > 0)
            {

                List<string> delta = new List<string>();
                foreach (Character charac in ContainerStory.ins.actStory.CharactersContainer)//find items of kind stock
                {
                    if (charac.Unlock == true && charac.Able==true)
                    {
                        goDropName.Add(charac.FirstName);
                        delta.Add("FirstName");
                        delta.Add("LastName");
                        delta.Add("BirthdayDay");
                        delta.Add("BirthdayMonth");
                        delta.Add("CharacterRelationship");
                        delta.Add("CharacterIntimacy");
                        delta.Add("CharacterLoyalty");
                        delta.Add("CharacterStamina");
                        delta.Add("CharacterExperience");
                        delta.Add("CharacterLevel");
                        delta.Add("CharacterProficiency");
                        delta.Add("CharacterLovesWork");
                        delta.Add("CharacterHatesWork");
                        delta.Add("Place");
                        delta.Add("dropdown");//special case to call dropdown menu
                        delta.Add("CharacterResting");
                        delta.Add("CharacterWorkCost");
                        delta.Add("CharacterWorkDebt");
                    }

                }
                for (int c = 0; c < ContainerStory.ins.actStory.CharactersContainer.Count; c++)
                {


                    for (int i = 0; i < delta.Count; i++)
                    {
                        if (delta[i]== "dropdown")
                        {
                            statusList.Add("dropdown");
                        }
                        else { 
                        string e = "";

                        if (ContainerStory.ins.actStory.CharactersContainer[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.CharactersContainer[c], null) != null)
                        {
                            e = ContainerStory.ins.actStory.CharactersContainer[c].GetType().GetProperty(delta[i]).GetValue(ContainerStory.ins.actStory.CharactersContainer[c], null).ToString();
                        }


                        statusList.Add(delta[i] + ": " + e);
                        }
                    }
                    
                }

                foreach (string _passString in statusList)
                {
                    if (_passString == "dropdown")
                    {
                       
                        Transform goDrop = Instantiate(statusPrefabDrop) as Transform;

                        goDrop.GetComponent<GameInfoButton>().PopulateStatusBotton("Select Work Place: ");
                        goDrop.GetComponent<GameInfoButton>().NominateCharacter(goDropName[goDropTimes]);
                        goDropTimes++;
                        goDrop.GetComponent<GameInfoButton>().PopulateStatusDropDown();
                        goDrop.SetParent(targetForStatusContent);
                    }
                    else
                    { 
                         
                        Transform go = Instantiate(statusPrefab) as Transform;

                        go.GetComponent<GameInfoButton>().PopulateStatusBotton(_passString);
                        
                        go.SetParent(targetForStatusContent);
                    }
                }
            }
        }


    }

   
}
