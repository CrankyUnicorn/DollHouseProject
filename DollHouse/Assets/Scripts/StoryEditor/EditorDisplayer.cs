using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class EditorDisplayer : MonoBehaviour {

    public Transform editorPanel1;
    public Transform editorPanel2;
    public Transform editorPanel3;

    public Transform prefab;

    public Dropdown editordropdown1;
    public Dropdown editordropdown2;
    public Dropdown editordropdown3;

    public Text selectdropdown;

    
    private List<string> editorDropIndex = new List<string>() { "Story", "Dialogs", "Characters","NPCs","Clients","Rooms","Slots","Achivements","Items","Upgrades","Modifiers" };
    private List<string> displayModes = new List<string>() { "Complete", "Standard", "Basic" };
    private List<string> _optionFunctions;


    public Type selectedTypeByClass;

    public int selectedTypeByIndex;
    public int selectedByCoord;
    public int selectedBySubCoord;


    public string displayMode;


    private List<Action> dropDownActionsList = new List<Action>();
    private List<Action> dropDownActionsCall = new List<Action>();



    private void Start()
    {
        //Defines a instance dialog OPTIONS functions
        OptionFunctionsClass tempClass = new OptionFunctionsClass();
        _optionFunctions = tempClass.optionFunctions;

        dropDrownCorrelator();
    }


    //-------------------------------------------------------------------------
   
        
    //MAIN LOOP OF EDITOR
    public void StartDisplayer()
    {
        DestroyAllBottons(0);

        PopulateDropdown1();
        PopulateDropdown2();

        CallStory();

        GameObject saveButton = GameObject.FindGameObjectWithTag("SaveButton");

        saveButton.GetComponent<Button>().interactable = true;
    }


    //-------------------------------------------------------------------------


    //Correlates dropDownActions and dropDownActionsCall with editorDropIndex
    private void dropDrownCorrelator()
    {
        
        foreach (string indexItem in editorDropIndex)
        {
            switch (indexItem)
            {
                case "Story":
                    dropDownActionsList.Add(CallStory);
                    dropDownActionsCall.Add(CallStory);
                    break;
                case "Dialogs":
                    dropDownActionsList.Add(ListDialogs);
                    dropDownActionsCall.Add(() => CallDialog(selectedByCoord));
                    break;
                case "Characters":
                    dropDownActionsList.Add(ListCharacters);
                    dropDownActionsCall.Add(() => CallCharacter(selectedByCoord));
                    break;
                case "NPCs":
                    dropDownActionsList.Add(ListNPCs);
                    dropDownActionsCall.Add(() => CallNPC(selectedByCoord));
                    break;
                case "Clients":
                    dropDownActionsList.Add(ListClients);
                    dropDownActionsCall.Add(() => CallClient(selectedByCoord));
                    break;
                case "Rooms":
                    dropDownActionsList.Add(ListRooms);
                    dropDownActionsCall.Add(() => CallRoom(selectedByCoord));
                    break;
                case "Slots":
                    dropDownActionsList.Add(ListSlots);
                    dropDownActionsCall.Add(() => CallSlot(selectedByCoord));
                    break;
                case "Achivements":
                    dropDownActionsList.Add(ListAchivements);
                    dropDownActionsCall.Add(() => CallAchivement(selectedByCoord));
                    break;
                case "Items":
                    dropDownActionsList.Add(ListItems);
                    dropDownActionsCall.Add(() => CallItem(selectedByCoord));
                    break;
                case "Upgrades":
                    dropDownActionsList.Add(ListUpgrades);
                    dropDownActionsCall.Add(() => CallUpgrade(selectedByCoord));
                    break;
                case "Modifiers":
                    dropDownActionsList.Add(ListModifiers);
                    dropDownActionsCall.Add(() => CallModifier(selectedByCoord));
                    break;
                default:
                    break;
            }
        }
    }


    //CALL A METHOD BASED ON CURRENT TOPIC
    #region
    public void CallSelectedTypeByIndex()
    {

        //Exeptions
        if (selectedTypeByClass == typeof(Dialog))
        {
            ListDialogLines(selectedByCoord);
            CallDialog(selectedByCoord);
        }
        else if (selectedTypeByClass == typeof(DialogLine))
        {
            CallDialogLine(selectedByCoord, selectedBySubCoord);
        }
        else
        {
            dropDownActionsCall[selectedTypeByIndex]();
        }
    }
    #endregion


    //--------------------------------------------------------------------------


    //REFRESH
    public void RefreshDisplay()
    {
        DestroyAllBottons(0);


        //Exeptions
        if (selectedTypeByClass == typeof(DialogLine))
        {
           ListDialogs();
           ListDialogLines(selectedByCoord);
           CallDialogLine(selectedByCoord, selectedBySubCoord);
        }
        else
        {
            dropDownActionsList[selectedTypeByIndex]();

            dropDownActionsCall[selectedTypeByIndex]();
        }
    }


    //----------------------------------------------------------------------------

    
    // DEALS WITH INDEX PASSED BY THE TOP LEFT DROPDOWN MENU 1
    public void DropDown1_Index(int index)
    {
        DestroyAllBottons(0);

        selectedTypeByIndex = index;//stores in int what topic is opened


        dropDownActionsList[selectedTypeByIndex]();
        dropDownActionsCall[selectedTypeByIndex]();

    }
    
    // DEALS WITH INDEX PASSED BY THE DOWN RIGHT DROPDOWN MENU 2
    public void DropDown2_Index(int index)
    {
        
            if (index<displayModes.Count)
            {
                displayMode = displayModes[index];
                RefreshDisplay();
            }
    }

    //POPULATES DROPDOWN MENUS 1 and 2
    #region
    public void PopulateDropdown1()
    {
        
        editordropdown1.ClearOptions();
        editordropdown1.value = 1;
        editordropdown1.value = 0;
        editordropdown1.AddOptions(editorDropIndex);

    }

    public void PopulateDropdown2()
    {

        editordropdown2.ClearOptions();
        editordropdown2.value = 1;
        editordropdown2.value = 0;
        editordropdown2.AddOptions(displayModes);

    }

    #endregion


    //-----------------------------------------------------------------------------


    //CREATES TARGET BUTTON FOR LIST DISPLAY METHOD : TOP LEFT
    public void ListingMethod<T>(List<T> someList, string wantedProperty)
    {
        DestroyAllBottons(1);

        
        List<T> _someList = someList as List<T>;


        for (int coord = 0; coord < _someList.Count; coord++)
        {

            string e = "";
            string n = "";

            n = wantedProperty;

            if (_someList[coord].GetType().GetProperty(n).GetValue(_someList[coord], null) != null)
            {
                e = _someList[coord].GetType().GetProperty(n).GetValue(_someList[coord], null).ToString();
            }
            else
            {
                Debug.Log("PROPERTY NOT FOUND! Check Spelling");
            }


            string v = "";

            if (e != null)
            {
                v = e.ToString();
            }

            Transform go = Instantiate(prefab) as Transform;

            go.GetComponent<EditorButton>().PopulateButton(typeof(T), coord, n, v);

            go.SetParent(editorPanel1);

        }
    }
    //ORVERLOAD FOR SECOND LIST: BOTTOM LEFT
    public void ListingMethod<T>(List<T> someList, int coord, string wantedProperty)
    {
        List<T> _someList = someList as List<T>;

        DestroyAllBottons(2);

        for (int subcoord = 0; subcoord < someList.Count; subcoord++)
        {

            string e = "";
            string n = "";

            n = wantedProperty;
            if (_someList.Count > coord+1)
            {
                Debug.Log("PROPERTY NOT FOUND! Out of index");
            }
            else if (_someList[coord].GetType().GetProperty(n).GetValue(_someList[coord], null) != null)
            {
                e = _someList[coord].GetType().GetProperty(n).GetValue(_someList[coord], null).ToString();
            }
            else
            {
                Debug.Log("PROPERTY NOT FOUND! Check Spelling");
            }


            string v = "";

            if (e != null)
            {
                v = e.ToString();
            }

            Transform go = Instantiate(prefab) as Transform;

            go.GetComponent<EditorButton>().PopulateButton(typeof(T),coord, subcoord, n, v);

            go.SetParent(editorPanel2);

        }
    }

    //CREATES TARGET BUTTON FOR LIST DISPLAY METHOD : RIGHT
    public void CallingMethod<T>(List<T> someList, int coord, int subcoord)
    {
        List<T> _someList = someList as List<T>;

        DestroyAllBottons(3);

        int _coord = coord;

        if (typeof(T) == typeof(DialogLine))
        {
            _coord = subcoord;
        }
        
        foreach (var prop in _someList[_coord].GetType().GetProperties())
        {
            string n = prop.Name.ToString();
            string v = "";

            object e = prop.GetValue(_someList[_coord], null);

            if (DisplayMode(n))
            {

                if (e != null)
                {
                    v = ExtractValue(e);
                }

                Transform go = Instantiate(prefab) as Transform;

                go.GetComponent<EditorButton>().PopulateButton(typeof(T), coord, subcoord, n, v);

                go.SetParent(editorPanel3);
            }
        }
    }
    //ORVERLOAD FOR THIRD LIST : RIGHT : STORY ONLY
    public void CallingMethod<T>(T someList)
    {
        T _someList = someList;

        DestroyAllBottons(3);

        foreach (var prop in _someList.GetType().GetProperties())
        {
            string n = prop.Name.ToString();
            string v = "";

            object e = prop.GetValue(_someList, null);

            if (DisplayMode(n))
            {

                if (e != null)
                {
                    v = ExtractValue(e);
                }


                Transform go = Instantiate(prefab) as Transform;

                go.GetComponent<EditorButton>().PopulateButton(typeof(T), n, v);

                go.SetParent(editorPanel3);
            }
        }
    }

    //Extracts a value depending of the obj source
    private string ExtractValue(object e)
    {
        string v="";

        if (e.GetType() == typeof(List<string>))
        {
            foreach (string _string in e as List<string>)
            {
                v = v + _string + " | ";
            }
        }
        else if (e.GetType() == typeof(List<int>))
        {
            foreach (int _string in e as List<int>)
            {
                v = v + _string.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<float>))
        {
            foreach (float _string in e as List<float>)
            {
                v = v + _string.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<Character>))
        {
            foreach (Character _string in e as List<Character>)
            {
                v = v + _string.FirstName.ToString() + " " + _string.LastName.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<Room>))
        {
            foreach (Room _string in e as List<Room>)
            {
                v = v + _string.Name.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<BuildingUpgrade>))
        {
            foreach (BuildingUpgrade _string in e as List<BuildingUpgrade>)
            {
                v = v + _string.Name.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<Item>))
        {
            foreach (Item _string in e as List<Item>)
            {
                v = v + _string.Name.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<NPC>))
        {
            foreach (NPC _string in e as List<NPC>)
            {
                v = v + _string.FirstName.ToString() + " " + _string.LastName.ToString() + " | ";
            }
        }
        else if (e.GetType() == typeof(List<Client>))
        {
            foreach (Client _string in e as List<Client>)
            {
                v = v + _string.FirstName.ToString() + " " + _string.LastName.ToString() + " | ";
            }
        }
        else
        {

            v = e.ToString();

        }
        return v;
    }

    //LISTING OF BUTTONS ALL CLASSES: OUTPUT TYPE: LEFT SIDE BARS
    #region
    public void ListDialogLines(int coord)//this one uses a overload for posting listing on second listing box
    {
        ListingMethod(ContainerStory.ins.actStory.DialogsContainer[coord].DialogContainer, coord, "ID");
    }

    public void ListDialogs()
    {
        ListingMethod(ContainerStory.ins.actStory.DialogsContainer, "ID");    
        
    }

    public void ListCharacters()
    {
        ListingMethod(ContainerStory.ins.actStory.CharactersContainer, "FirstName");
    }

    public void ListNPCs()
    {
        ListingMethod(ContainerStory.ins.actStory.NPCsContainer,  "NickName");
    }

    public void ListClients()
    {
        ListingMethod(ContainerStory.ins.actStory.ClientsTemplates,  "NickName");
    }

    public void ListAchivements()
    {
        ListingMethod(ContainerStory.ins.actStory.AchivementsTemplates,  "Name");
    }

    public void ListRooms()
    {
        ListingMethod(ContainerStory.ins.actStory.RoomsTemplates,  "Name");
    }

    public void ListSlots()
    {
        ListingMethod(ContainerStory.ins.actStory.SlotsContainer,  "Name");
    }

    public void ListItems()
    {
        ListingMethod(ContainerStory.ins.actStory.ItemsTemplates,  "Name");
    }

    public void ListUpgrades()
    {
        ListingMethod(ContainerStory.ins.actStory.BuildingUpgradeContainer,  "Name");
    }

    public void ListModifiers()
    {
        ListingMethod(ContainerStory.ins.actStory.ModifiersTemplates,  "Name");
    }


    //LISTING BUTTONS OF A SINGLE CLASS: WITH TYPE AND VALUE: RIGHT SIDE
    public void CallStory()
    {
        CallingMethod(ContainerStory.ins.actStory);
    }


    public void CallDialog(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.DialogsContainer, coord, 0);
    }

    public void CallDialogLine(int coord, int subcoord)
    {
        CallingMethod(ContainerStory.ins.actStory.DialogsContainer[coord].DialogContainer, coord, subcoord);
    }

    public void CallCharacter(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.CharactersContainer, coord, 0);
    }

    public void CallNPC(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.NPCsContainer, coord, 0);
    }

    public void CallClient(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.ClientsTemplates, coord, 0);
    }

    public void CallAchivement(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.AchivementsTemplates, coord, 0);
    }

    public void CallRoom(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.RoomsTemplates, coord, 0);
    }

    public void CallSlot(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.SlotsContainer, coord, 0);
    }

    public void CallItem(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.ItemsTemplates, coord, 0);
    }

    public void CallUpgrade(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.BuildingUpgradeContainer, coord, 0);
    }

    public void CallModifier(int coord)
    {
        CallingMethod(ContainerStory.ins.actStory.ModifiersTemplates, coord, 0);
    }
    #endregion


    //-----------------------------------------------------------------------------


    //CREATES|ADDS NEW BUTTONS
    public void AddToStory()
    {
        
        if (selectedTypeByClass == typeof(Dialog))
        {
            
                //creates
                Dialog newDialog = new Dialog();
                ContainerStory.ins.actStory.DialogsContainer.Insert(selectedByCoord + 1, newDialog);

                DialogLine newDialogLine1 = new DialogLine();
                ContainerStory.ins.actStory.DialogsContainer[selectedByCoord + 1].DialogContainer.Insert(0, newDialogLine1);

            DestroyAllBottons(0);
            
            ListDialogs();
            ListDialogLines(selectedByCoord);


        }
        else if (selectedTypeByClass == typeof(Character))
        {
          
                //creates
                Character newCharacter = new Character();
                ContainerStory.ins.actStory.CharactersContainer.Insert(selectedByCoord + 1, newCharacter);


            DestroyAllBottons(0);

            ListCharacters();

        }
        else if (selectedTypeByClass == typeof(DialogLine))
        {

            //creates
            DialogLine newDialogLine2 = new DialogLine();
            ContainerStory.ins.actStory.DialogsContainer[selectedByCoord].DialogContainer.Insert(selectedBySubCoord + 1, newDialogLine2);


            DestroyAllBottons(0);

            ListDialogs();
            ListDialogLines(selectedByCoord);
        }
        selectedTypeByClass = null;
    }


    //DELETE|REMOVES BUTTONS
    public void DeleteFromStory()
    {

        if (selectedTypeByClass == typeof(Dialog))
        {

            //deletes
            ContainerStory.ins.actStory.DialogsContainer[selectedByCoord].DialogContainer.Clear();
            ContainerStory.ins.actStory.DialogsContainer.RemoveAt(selectedByCoord);

            DestroyAllBottons(0);

            ListDialogs();
            ListDialogLines(selectedByCoord);


        }
        else if (selectedTypeByClass == typeof(Character))
        {

            //deletes
            ContainerStory.ins.actStory.CharactersContainer.RemoveAt(selectedByCoord);


            DestroyAllBottons(0);

            ListCharacters();

        }
        else if (selectedTypeByClass == typeof(DialogLine))
        {

            //deletes
            ContainerStory.ins.actStory.DialogsContainer[selectedByCoord].DialogContainer.RemoveAt(selectedBySubCoord);

            DestroyAllBottons(0);

            ListDialogs();
            ListDialogLines(selectedByCoord);
        }
        selectedTypeByClass = null;

    }


    //-----------------------------------------------------------------------------


    //DESTROY|DELETES CHILDS OF SELECTED PANEL
    public void DestroyAllBottons(int i)
    {
        if (i==1)
        {
            foreach (Transform child in editorPanel1)
            {
                Destroy(child.gameObject);

            }
        }
        else if (i==2)
        {
            foreach (Transform child in editorPanel2)
            {
                Destroy(child.gameObject);

            }
        }
        else if (i==3)
        {
            foreach (Transform child in editorPanel3)
            {
                Destroy(child.gameObject);

            }
        }
        else {
            foreach (Transform child in editorPanel1)
            {
                Destroy(child.gameObject);

            }
            foreach (Transform child in editorPanel2)
            {
                Destroy(child.gameObject);

            }
            foreach (Transform child in editorPanel3)
            {
                Destroy(child.gameObject);

            }
        }
    }


    //----------------------------------------------------------------------------


    //what botton type is selected
    public void SelectedType(Type _class, int _coord, int _subcoord)
    {
        selectedTypeByClass = _class;
        selectedByCoord = _coord;
        selectedBySubCoord = _subcoord;
       
    }


    //----------------------------------------------------------------------------


    //sets what type of display mode is on
    public void SelectedMode(string m)
    {
        displayMode = m;
    }


    //check the type of the Display Mode and act on it 
    public bool DisplayMode(string n) {
        if (displayMode == "Basic")
        {
            if (n=="Name"|| n=="Content"||n== "Background" || n == "Body1" || n == "Body2" || n == "Body3" || n == "DialogDescription" || n == "IfTic " || n == "FileName" || n == "TimeStamp" || n == "ActTic")
            {
                return true;
            }
            else { return false; }
        }
        else if (displayMode == "Standard")
        {
            if (n == "IdLine" || n == "Name" || n == "Content" || n == "Background" || n == "Body1" || n == "Body2" || n == "Body3" || n == "IdDialog" || n == "DialogDescription" || n == "IfTic " || n == "FileName" || n == "TimeStamp" || n == "ActTic")
            {
                return true;
            }
            else { return false; }
        }
        else if (displayMode == "Complete")
        {
            return true;
        }

        return true;
    }

    
  

}
