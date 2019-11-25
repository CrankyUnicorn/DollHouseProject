using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sniffer : MonoBehaviour {

   
    
    //DEV TOOLS

    private Rect windowRect = new Rect(0, 0, Screen.width, Screen.height);

    private int mode;//sets what mode the IMGUI will be

    private Vector2 scrollPosition;

    private int currentPage=0;

    private bool containerOrTemplate=false;


    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    public delegate void UnclickAction();
    public static event UnclickAction UnClicked;

    private GUIStyle snifferStyle = new GUIStyle();


    private void Update()
    {
        //DEV TOOL
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetLayoutValues();
            mode = 1;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ResetLayoutValues();
            mode = 2;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ResetLayoutValues();
            mode = 3;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ResetLayoutValues();
            mode = 4;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetLayoutValues();
            mode = 5;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ResetLayoutValues();
            mode = 6;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ResetLayoutValues();
            mode = 7;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ResetLayoutValues();
            mode = 8;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ResetLayoutValues();
            mode = 9;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Backslash))//Escape
        {
            ResetLayoutValues();
            mode = 10;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (OnClicked != null)
                OnClicked();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))//Escape
        {
            ResetLayoutValues();
            mode = 0;
            currentPage = 0;
            scrollPosition = new Vector2(0f, 0f);

            if (UnClicked != null)
                UnClicked();
        }
       
    }

    void OnGUI()
    {

        //window style defenitions
       
        snifferStyle.normal.textColor = Color.white;
        snifferStyle.alignment = TextAnchor.UpperCenter;
        snifferStyle.normal.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 0.9f));

        GUI.skin.window = snifferStyle;

        switch (mode)
        {
            case 1:
                windowRect = GUI.Window(mode, windowRect, GameStats, "HEAD STATS");
                break;
            case 2:
                windowRect = GUI.Window(mode, windowRect, PersonalAndBuildingItems, "PLAYER PERSONAL AND STOCK ITEMS");
                break;
            case 3:
                windowRect = GUI.Window(mode, windowRect, CharactersStats, "CHARACTERS STATS");
                break;
            case 4:
                windowRect = GUI.Window(mode, windowRect, AchivementsStatsAndList, "ACHIVEMENTS STATS");
                break;
            case 5:
                windowRect = GUI.Window(mode, windowRect, SlotsAndRooms, "SLOTS STATS");
                break;
            case 6:
                 windowRect = GUI.Window(mode, windowRect, BuildingUpgradesStats, "BUILDING UPGRADE LIST");
                break;
            case 7:
                windowRect = GUI.Window(mode, windowRect, ItemsList, "ITEMS LIST");
                break;
            case 8:
                windowRect = GUI.Window(mode, windowRect, ClientsStatsAndList, "CLIENTS");
                break;
            case 9:
                windowRect = GUI.Window(mode, windowRect, GameOptions, "OPTIONS");
                break;
            case 10:
                windowRect = GUI.Window(mode, windowRect, DevToolBox, "DEV TOOL BOX");
                break;
            default:
                break;
        }
        
    }

    //METHODS-----------------------------------
    //PERSONAL AND BUILDING ITEMS 
    void DevToolBox(int windowID)
    {
        if (ContainerStory.ins.actStory != null)
        {
            GUILayout.Space(20);

            GUILayout.Button("MONEY: "+ContainerStory.ins.actStory.ActMoney.ToString());

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("+10"))
            {
                ContainerStory.ins.actStory.ActMoney += 10;

            }
            if (GUILayout.Button("+100"))
            {
                ContainerStory.ins.actStory.ActMoney += 100;

            }
            if (GUILayout.Button("+1000"))
            {
                ContainerStory.ins.actStory.ActMoney += 1000;

            }
            GUILayout.EndHorizontal();

            GUILayout.Button("SELECTED");
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(GameScapeReferencesHandler.ins.disableGameScapeMovement ? "GSM Disable" : "GSM Able")) {
                if (GameScapeReferencesHandler.ins.disableGameScapeMovement)
                {
                    GameScapeReferencesHandler.ins.disableGameScapeMovement = false;
                }
                else
                {
                    GameScapeReferencesHandler.ins.disableGameScapeMovement = true;
                }

            }
            if (GUILayout.Button(GameScapeReferencesHandler.ins.disableRaycast? "GSR Disable" : "GSR Able"))
            {
                if (GameScapeReferencesHandler.ins.disableRaycast)
                {
                    GameScapeReferencesHandler.ins.disableRaycast = false;
                }
                else
                {
                    GameScapeReferencesHandler.ins.disableRaycast = true;
                }

            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            GUILayout.Button(GameScapeReferencesHandler.ins.selectedSlot!=null? 
                "Selected Slot: " + GameScapeReferencesHandler.ins.selectedSlot.InventoryName:
                "Selected Slot: Null");

            GUILayout.Button(GameScapeReferencesHandler.ins.selectedCharacter!=null? 
                "Selected Character: " + GameScapeReferencesHandler.ins.selectedCharacter.FirstName:
                "Selected Character: Null");

            GUILayout.Button(GameScapeReferencesHandler.ins.selectedNPC!=null? 
                "Selected NPC: " + GameScapeReferencesHandler.ins.selectedNPC.FirstName:
                "Selected NPC: Null");

            GUILayout.EndHorizontal();
        }
    }


    //PERSONAL AND BUILDING ITEMS 
    void PersonalAndBuildingItems(int windowID)
    {
        GUILayout.Space(20);

        if (ContainerStory.ins.actStory != null)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(containerOrTemplate ? "Switch to Stock Items" : "Switch to Personal Items"))
            {
                if (containerOrTemplate)
                {
                    containerOrTemplate = false;
                    currentPage = 0;
                }
                else
                {
                    containerOrTemplate = true;
                    currentPage = 0;
                }
                
            }
            if (containerOrTemplate)
            {
                GUILayout.Button("Inventory Item: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.Inventory.Count.ToString());

            }
            else
            {
                GUILayout.Button("Stock Item: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.BuildingInventory.Count.ToString());

            }
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (containerOrTemplate)
                {
                    if (currentPage < ContainerStory.ins.actStory.Inventory.Count - 1)
                    {
                        currentPage++;
                    }
                }
                else
                {
                    if (currentPage < ContainerStory.ins.actStory.BuildingInventory.Count - 1)
                    {
                        currentPage++;
                    }
                }

            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (containerOrTemplate)
            {
                if (ContainerStory.ins.actStory.Inventory.Count!=0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.Inventory[currentPage].GetType().GetProperties())
                    {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.Inventory[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }
               
            }
            else
            {
                if (ContainerStory.ins.actStory.BuildingInventory.Count != 0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.BuildingInventory[currentPage].GetType().GetProperties())
                    {
                    GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.BuildingInventory[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }
            }

            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }


    //ACHIVEMENTS STATS AND LIST
    void AchivementsStatsAndList(int windowID)
    {
        if (ContainerStory.ins.actStory != null )
        {
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button(containerOrTemplate ? "Switch to Template" : "Switch to Container"))
            {
                if (containerOrTemplate)
                {
                    containerOrTemplate = false;
                    currentPage = 0;
                }
                else
                {
                    containerOrTemplate = true;
                    currentPage = 0;

                }
            }
            if (containerOrTemplate)
            {
                GUILayout.Button("Achivements: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.AchivementsTemplates.Count.ToString());

            }
            else
            {
                GUILayout.Button("Achivements: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.AchivementsContainer.Count.ToString());

            }
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (containerOrTemplate)
                {
                    if (currentPage < ContainerStory.ins.actStory.AchivementsTemplates.Count - 1)
                    {
                        currentPage++;
                    }
                }
                else
                {
                    if (currentPage < ContainerStory.ins.actStory.AchivementsContainer.Count - 1)
                    {
                        currentPage++;
                    }
                }

            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (containerOrTemplate)
            {
                if (ContainerStory.ins.actStory.AchivementsTemplates.Count!=0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.AchivementsTemplates[currentPage].GetType().GetProperties())
                    {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.AchivementsTemplates[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }
                
            }
            else
            {
                if (ContainerStory.ins.actStory.AchivementsContainer.Count != 0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.AchivementsContainer[currentPage].GetType().GetProperties())
                    {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.AchivementsContainer[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }
            }


            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }


    //BUILDING UPGRADE STATS
    void BuildingUpgradesStats(int windowID)
    {

        if (ContainerStory.ins.actStory != null)
        {
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            GUILayout.Button("Building Upgrade: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.BuildingUpgradeContainer.Count.ToString());
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (currentPage < ContainerStory.ins.actStory.BuildingUpgradeContainer.Count - 1)
                {
                    currentPage++;
                }
            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (ContainerStory.ins.actStory.BuildingUpgradeContainer.Count!=0)
            {
                foreach (var prop in ContainerStory.ins.actStory.BuildingUpgradeContainer[currentPage].GetType().GetProperties())
                {
                    GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.BuildingUpgradeContainer[currentPage]));
                }
            }
            else
            {
                GUILayout.Label("Empty");
            }
            

            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }


    //ITEMS LIST
    void ItemsList(int windowID)
    {
        if (ContainerStory.ins.actStory != null )
        {
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            GUILayout.Button("Item: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.ItemsTemplates.Count.ToString());
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (currentPage < ContainerStory.ins.actStory.ItemsTemplates.Count - 1)
                {
                    currentPage++;
                }
            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (ContainerStory.ins.actStory.ItemsTemplates.Count != 0)
            {
                foreach (var prop in ContainerStory.ins.actStory.ItemsTemplates[currentPage].GetType().GetProperties())
                {
                    GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.ItemsTemplates[currentPage]));
                }
            }
            else
            {
                GUILayout.Label("Empty");
            }
            

            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }


    //CLIENTS STATS AND LIST
    void ClientsStatsAndList(int windowID)
    {
        if (ContainerStory.ins.actStory != null )
        {
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button(containerOrTemplate?"Switch to Template": "Switch to Container"))
            {
                if (containerOrTemplate)
                {
                    containerOrTemplate=false;
                    currentPage = 0;
                }
                else
                {
                    containerOrTemplate = true;
                    currentPage = 0;

                }
            }
            if (containerOrTemplate)
            {
                GUILayout.Button("Client: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.ClientsTemplates.Count.ToString());

            }
            else
            {
                GUILayout.Button("Client: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.ClientsContainer.Count.ToString());

            }
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (containerOrTemplate)
                {
                    
                        if (currentPage < ContainerStory.ins.actStory.ClientsTemplates.Count - 1)
                        {
                            currentPage++;
                        }
                  
                   
                }
                else
                {
                    if (currentPage < ContainerStory.ins.actStory.ClientsContainer.Count - 1)
                    {
                        currentPage++;
                    }
                }
                
            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (containerOrTemplate)
            {
                if (ContainerStory.ins.actStory.ClientsTemplates.Count != 0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.ClientsTemplates[currentPage].GetType().GetProperties())
                    {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.ClientsTemplates[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }
            }
            else
            {
                if (ContainerStory.ins.actStory.ClientsContainer.Count != 0)
                {
                        foreach (var prop in ContainerStory.ins.actStory.ClientsContainer[currentPage].GetType().GetProperties())
                        {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.ClientsContainer[currentPage]));
                        }
                }
                else
                {
                    GUILayout.Label("Empty");
                }
            }
           

            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }
    

    //CHARACTERS STATS
    void CharactersStats(int windowID)
    {
        if (ContainerStory.ins.actStory != null  )
        {
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            GUILayout.Button("Character: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.CharactersContainer.Count.ToString());
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (currentPage < ContainerStory.ins.actStory.CharactersContainer.Count - 1)
                {
                    currentPage++;
                }
            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (ContainerStory.ins.actStory.CharactersContainer.Count != 0)
            {
                foreach (var prop in ContainerStory.ins.actStory.CharactersContainer[currentPage].GetType().GetProperties())
                {
                    GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.CharactersContainer[currentPage]));
                }
            }
            else
            {
                GUILayout.Label("Empty");
            }
            

            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }


    //SLOTS AND ROOMS STATS
    void SlotsAndRooms(int windowID)
    {
        if (ContainerStory.ins.actStory != null )
        {
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button(containerOrTemplate ? "Switch to Template" : "Switch to Container"))
            {
                if (containerOrTemplate)
                {
                    containerOrTemplate = false;
                    currentPage = 0;
                }
                else
                {
                    containerOrTemplate = true;
                    currentPage = 0;

                }
            }
            if (containerOrTemplate)
            {
                GUILayout.Button("Room: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.RoomsTemplates.Count.ToString());

            }
            else
            {
                GUILayout.Button("Slot: " + (currentPage + 1).ToString() + "/" + ContainerStory.ins.actStory.SlotsContainer.Count.ToString());

            }
            if (GUILayout.Button("<<"))
            {
                if (currentPage > 0)
                {
                    currentPage--;
                }
            }
            if (GUILayout.Button(">>"))
            {
                if (containerOrTemplate)
                {
                    if (currentPage < ContainerStory.ins.actStory.RoomsTemplates.Count - 1)
                    {
                        currentPage++;
                    }
                }
                else
                {
                    if (currentPage < ContainerStory.ins.actStory.SlotsContainer.Count - 1)
                    {
                        currentPage++;
                    }
                }

            }
            GUILayout.EndHorizontal();

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

            if (containerOrTemplate)
            {
                if (ContainerStory.ins.actStory.RoomsTemplates.Count != 0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.RoomsTemplates[currentPage].GetType().GetProperties())
                    {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.RoomsTemplates[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }


                
            }
            else
            {
                if (ContainerStory.ins.actStory.SlotsContainer.Count != 0)
                {
                    foreach (var prop in ContainerStory.ins.actStory.SlotsContainer[currentPage].GetType().GetProperties())
                    {
                        GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory.SlotsContainer[currentPage]));
                    }
                }
                else
                {
                    GUILayout.Label("Empty");
                }


               
            }


            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins' is null or empty");
        }
    }


    //GAME HEAD STATUS
    void GameStats(int windowID)
    {
        if (ContainerStory.ins != null || ContainerStory.ins.actStory!=null)
        {
            GUILayout.Space(20);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height-25));

            foreach (var prop in ContainerStory.ins.actStory.GetType().GetProperties())
            {
                GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerStory.ins.actStory));
            }
       
            GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins.actStory' is null or empty");
        }
    }


    //GAME OPTIONS
    void GameOptions(int windowID)
    {
        if (ContainerPreferences.ins != null || ContainerPreferences.ins.loadedPreferences != null)
        {
            GUILayout.Space(20);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 25));

        
            foreach (var prop in ContainerPreferences.ins.loadedPreferences.GetType().GetProperties())
            {
                GUILayout.Label(GetTypeAndPropertyValues(prop, ContainerPreferences.ins.loadedPreferences));
            }
       
        GUILayout.EndScrollView();
        }
        else
        {
            GUILayout.Label("'ContainerStory.ins.actStory' is null or empty");
        }
    }


    //SUB METHODS
    string GetTypeAndPropertyValues(System.Reflection.PropertyInfo prop, object containerRef)
    {
        string n = "";
        string v = "";

        object e = prop.GetValue(containerRef, null);

        if (e != null)
        {
            if (e.GetType() == typeof(List<string>))
            {
                n = prop.Name.ToString();
                foreach (string _string in e as List<string>)
                {
                    v = v + _string + " | ";
                }
            }
            else if (e.GetType() == typeof(List<int>))
            {
                n = prop.Name.ToString();
                foreach (int _string in e as List<int>)
                {
                    v = v + _string.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<float>))
            {
                n = prop.Name.ToString();
                foreach (float _string in e as List<float>)
                {
                    v = v + _string.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<Character>))
            {
                n = prop.Name.ToString();
                foreach (Character _string in e as List<Character>)
                {
                    v = v + _string.FirstName.ToString() + " " + _string.LastName.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<Room>))
            {
                n = prop.Name.ToString();
                foreach (Room _string in e as List<Room>)
                {
                    v = v + _string.Name.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<BuildingUpgrade>))
            {
                n = prop.Name.ToString();
                foreach (BuildingUpgrade _string in e as List<BuildingUpgrade>)
                {
                    v = v + _string.Name.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<Item>))
            {
                n = prop.Name.ToString();
                foreach (Item _string in e as List<Item>)
                {
                    v = v + _string.Name.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<NPC>))
            {
                n = prop.Name.ToString();
                foreach (NPC _string in e as List<NPC>)
                {
                    v = v + _string.FirstName.ToString() + " " + _string.LastName.ToString() + " | ";
                }
            }
            else if (e.GetType() == typeof(List<Client>))
            {
                n = prop.Name.ToString();
                foreach (Client _string in e as List<Client>)
                {
                    v = v + _string.FirstName.ToString() + " " + _string.LastName.ToString() + " | ";
                }
            }
            else
            {
                n = prop.Name.ToString();
                v = e.ToString();

            }
        }
        else
        {
            n = prop.Name.ToString();
            v = "";
        }

        string r = n + ": " + v;
        return r;
    }


    //AUX
    private void ResetLayoutValues()
    {
        scrollPosition = new Vector2(0f, 0f);
    }

    //makes textures 2D for background
    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }
}
