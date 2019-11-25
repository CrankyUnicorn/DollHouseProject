using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/*This Class store ingame actions that on called modify the data-structure values 
 * ableing or disabling post processing in the StrategyGameLoop Class*/
public class GameScapeActions : MonoBehaviour
{

    public static GameScapeActions ins;
    private void Awake()
    {
        ins = this;
    }

    [Header("GO of interior")]
    public GameObject buildingInterior;//Layer that house the Rooms
    [Header("Prefab of rooms aparence")]
    public Transform SlotPrefab;//Room GameObject
    [Header("Character Prefav")]
    public Transform characterPrefab; //for instanciating chracters npc and vehicles 
    [Header("Go of Street")]
    public GameObject streetLayer; //layer for characters and npcs to start at
    [Header("Prefav of Warning Panel")]
    public Transform warningPrefab;//use the same from status


    //MARKERS
    private bool foundBuilding;
  
    private GameObject facadeObject;//holds targeted object for facade

    //DELEGATES
    public delegate void OnAction();
    public static event OnAction OnActionTigger;


    //----------------------------

    //START
    void Start()
    {
        facadeObject = new GameObject();//holds targeted object for facade
       
        InsertRoomsIntoSlots();//Must beincluded: infobox close, dialogs and time advancement

        InsertCharactersIntoWorld();//Must beincluded: infobox close, dialogs and time advancement

        TrackChange();//change the behaviour of char depending on location
    }

    //UPDATE
    void Update()
    {
        CheckPointerOverBuilding();//FIND IF MOUSE OVER BUILDING
    }



    //OTHER METHODS-------------------------------------------------------------


    //FIND IF MOUSE OVER BUILDINGS
    void CheckPointerOverBuilding()
    {
        if (GameScapeReferencesHandler.ins.raycastObjList != null)
        {
            foreach (var go in GameScapeReferencesHandler.ins.raycastObjList)
            {
                if (go != null)//needed because of dropdown menus that are destroyed when pressed but reference still exists in the raycaster list
                {


                    if (go.gameObject.name == "BUILDING")
                    {
                        facadeObject = buildingInterior;
                        foundBuilding = true;
                        break;
                    }
                    else
                    {
                        foundBuilding = false;
                    }
                }
            }
        }
        //turn visible or invisible
        if (foundBuilding == true)
        {
            Image[] images = facadeObject.gameObject.GetComponentsInChildren<Image>();
            foreach (Image ima in images)
            {
                ima.gameObject.GetComponent<Image>().enabled = true;
            }

        }
        else if (foundBuilding == false)
        {
            Image[] images = facadeObject.gameObject.GetComponentsInChildren<Image>();
            foreach (Image ima in images)
            {
                ima.gameObject.GetComponent<Image>().enabled = false;
            }

        }
    }


    //INSTANTIATE ROOMS AT SLOTS //Must beincluded: infobox close, dialogs and time advancement
    void InsertRoomsIntoSlots()
    {
        //deletiong part
        foreach (Transform slot in buildingInterior.transform)
        {
            Destroy(slot.gameObject);
        }

        //creates an instance of the room in a slot and populates it with information via class intanciation for later reference
        if (ContainerStory.ins.actStory.SlotsContainer.Count != 0)
        {
            int i = 0;
            foreach(Room room in ContainerStory.ins.actStory.SlotsContainer)
            {
                if (i!=0)//needed because 0 is not a slot but outside area
                {

                    if (room.HouseSlot != i)//SAFE GUARD second layer
                    {
                        Debug.Log("House Slot ERROR. Slot Number doesn't match with position on List");
                    }


                    Transform slotObject = Instantiate(SlotPrefab) as Transform;
                    slotObject.GetComponent<GameScapeObjType>().PopulateItem(room);
                    slotObject.SetParent(buildingInterior.transform, false);
                    slotObject.SetAsLastSibling();
                }
                i++;
            }
        }

    }


    //INSTANTIATE CHARACTERS //Must beincluded: infobox close, dialogs and time advancement
    void InsertCharactersIntoWorld()
    {
        //find all instances of characters in the Game Scape and delete them
        GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("GameScapeCharacter");
        foreach (GameObject charac in allCharacters)
        {
            Destroy(charac);
        }

        //creates instance and populates it with information via class intanciation for later reference
        if (ContainerStory.ins.actStory.CharactersContainer.Count != 0)
        {
           
            foreach (Character charac in ContainerStory.ins.actStory.CharactersContainer)
            {

                Transform slotObject = Instantiate(characterPrefab) as Transform;
                slotObject.GetComponent<GameScapeObjType>().PopulateItem(charac);
              
            }
        }
    }


    //TRACK CHARACTERS AND ROOMS CHANGES // needs updates to npc and vehicles
    public void TrackChange()
    {
        //rooms
        foreach (Transform slot in buildingInterior.transform)
        {
          
            slot.GetComponent<GameScapeObjType>().RefreshItem();
        }

        //characters
        GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("GameScapeCharacter");

        foreach (GameObject charac in allCharacters)
        {
            charac.GetComponent<GameScapeObjType>().RefreshItem();
        }
    }


    //ADD WORKER TO ROOM
    public void AddWorkerToRoom()
    {

        Character _charac = GameScapeReferencesHandler.ins.selectedCharacter;
        Room _roomWork = GameScapeReferencesHandler.ins.selectedSlot;

       

        if (_roomWork != null && _charac != null)
        {
            
            bool vacancy = false;
            
            for (int i = 0; i < _roomWork.WorkersList.Capacity; i++)
            {

                if (_roomWork.WorkersList[i] == null)
                {
                    _roomWork.WorkersList[i] = _charac.FirstName;

                    RemoveCharOtherRoomsSlots(_charac.FirstName, _roomWork.HouseSlot, i);//(who,slot,roomslot)

                    _charac.Slot = _roomWork.HouseSlot;//had info to this character about in what slot he/she is 
                    _charac.Place = _roomWork.Name;//had info to this character about the name of the room he/she is

                    TrackChange();//change the behaviour of char depending on location

                    vacancy = true;

                    PostWarning("Character Placed In " + _roomWork.Name);

                    break;
                }
            }
            if (vacancy == false)
            {
                PostWarning("No Work Space Avaible!");

            }
        }
    }


    //REMOVE WORKER TO ROOM
    public void RemoveWorkerFromRoom()
    {
        Character charac = GameScapeReferencesHandler.ins.selectedCharacter;

        if (charac!=null)
        {
            for (int i = 0; i < ContainerStory.ins.actStory.SlotsContainer[0].WorkersList.Capacity; i++)
            {

                if (ContainerStory.ins.actStory.SlotsContainer[0].WorkersList[i] == null)
                {
                    PostWarning("Character Send Outside!");
                    RemoveCharOtherRoomsSlots(charac.FirstName, 0, i);//(who,slot,roomslot)

                    charac.Slot = ContainerStory.ins.actStory.SlotsContainer[0].HouseSlot;
                    charac.Place = ContainerStory.ins.actStory.SlotsContainer[0].Name;

                    TrackChange();//change the behaviour of char depending on location

                    break;

                }else if  (ContainerStory.ins.actStory.SlotsContainer[0].WorkersList[i] == charac.FirstName)
                { PostWarning("Character Already Outside!"); break; }
            }
        }
    }


    //REMOVES CHARACTER FROM ALL OTHER SLOTS OTHER THEN THE LAST TRANSFERED
    public void RemoveCharOtherRoomsSlots(string chara, int roomSlotIndex, int roomListIndex)
    {
        foreach (Room roomWork in ContainerStory.ins.actStory.SlotsContainer)
        {
            for (int i = 0; i < roomWork.WorkersList.Capacity; i++)
            {
                if (roomWork.HouseSlot != roomSlotIndex)
                {
                    if (roomWork.WorkersList[i] == chara)
                    {
                        roomWork.WorkersList[i] = null;
                    }

                }else if (roomWork.HouseSlot == roomSlotIndex)
                {
                    if (roomWork.WorkersList[i] == chara && i != roomListIndex)
                    {
                        roomWork.WorkersList[i] = null;
                    }

                }
            }
        }

    }
    

    //-----------------------
    
    //SHOWS WARNING ABOUT CHARACTER ROOM TRANSFER COMPLETIONS
    private void PostWarning(string _passString)
    {
        GameObject targetPanel = GameObject.FindGameObjectWithTag("MainCanvas");
        Transform go = Instantiate(warningPrefab) as Transform;

        go.GetComponent<WarningButton>().PopulateMessageBotton(_passString);

        go.SetParent(targetPanel.transform, false);
        go.SetAsLastSibling();

    }


    //---------------------------

    public void OpenOrCloseBuilding()
    {
        if (ContainerStory.ins.actStory.BuildingOpen != false)
        {
            ContainerStory.ins.actStory.BuildingOpen = false;
        }
        else
        {
            ContainerStory.ins.actStory.BuildingOpen = true;
        }

        //used to signal to Update GameInfo UI
        if (OnActionTigger != null)
            OnActionTigger();
    }


    public void KickoutClients()
    {
        if (ContainerStory.ins.actStory.KickoutOrder == false)
        {
            ContainerStory.ins.actStory.KickoutOrder = true;
            ContainerStory.ins.actStory.BuildingOpen = false;
        }

        //used to signal to Update GameInfo UI
        if (OnActionTigger != null)
            OnActionTigger();
    }


    //-----------------------------------

    //REPAIR ROOM
    public void RepairRoom()
    { 
        //set order to repair true
        if (GameScapeReferencesHandler.ins.selectedSlot!=null)
        {
            if (GameScapeReferencesHandler.ins.selectedSlot.ConstructionOrder!=true && GameScapeReferencesHandler.ins.selectedSlot.DeconstructionOrder != true && GameScapeReferencesHandler.ins.selectedSlot.UpgradingOrder != true)
            {


                if (GameScapeReferencesHandler.ins.selectedSlot.RepairOrder == false)
                {
                    GameScapeReferencesHandler.ins.selectedSlot.RepairOrder = true;

                    TrackChange();//change the behaviour of char depending on location
                    PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " is under repairs!");
                }
                else
                {
                    GameScapeReferencesHandler.ins.selectedSlot.RepairOrder = false;

                    TrackChange();//change the behaviour of char depending on location
                    PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " repairs were canceled!");
                }
            }
        }
        
       
    }

    //BUILD ROOM
    public void ConstructRoom()
    {
        //set room construction 
        if (GameScapeReferencesHandler.ins.selectedSlot != null)
        {
            if (GameScapeReferencesHandler.ins.selectedSlot.RepairOrder != true && GameScapeReferencesHandler.ins.selectedSlot.DeconstructionOrder != true && GameScapeReferencesHandler.ins.selectedSlot.UpgradingOrder != true)
            {
                if (GameScapeReferencesHandler.ins.selectedSlot.ConstructionOrder == false)
                {
                    GameScapeReferencesHandler.ins.selectedSlot.ConstructionOrder = true;

                    TrackChange();//change the behaviour of char depending on location
                    PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " is under constuction");
                }
                else
                {
                    GameScapeReferencesHandler.ins.selectedSlot.ConstructionOrder = false;

                    TrackChange();//change the behaviour of char depending on location
                    PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " constuction was canceled!");
                }
            }
        }

    }

    //BUILD ROOM
    public void UpgradedRoom()
    {
        if (GameScapeReferencesHandler.ins.selectedSlot != null)
        {
            if (GameScapeReferencesHandler.ins.selectedSlot.RepairOrder != true && GameScapeReferencesHandler.ins.selectedSlot.DeconstructionOrder != true && GameScapeReferencesHandler.ins.selectedSlot.ConstructionOrder != true)
            {
                if (GameScapeReferencesHandler.ins.selectedSlot.UpgradingOrder == false)
                {
                    GameScapeReferencesHandler.ins.selectedSlot.UpgradingOrder = true;

                    TrackChange();//change the behaviour of char depending on location
                    PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " started being upgraded!");
                }
                else
                {
                    GameScapeReferencesHandler.ins.selectedSlot.UpgradingOrder = false;

                    TrackChange();//change the behaviour of char depending on location
                    PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " upgrade was canceled!");
                }
            }
        }
    }

    //DESTROY ROOM
    public void DeconstructRoom()
    {
        //set room Deconstruction
        if (GameScapeReferencesHandler.ins.selectedSlot.RepairOrder != true && GameScapeReferencesHandler.ins.selectedSlot.UpgradingOrder != true && GameScapeReferencesHandler.ins.selectedSlot.ConstructionOrder != true)
        {
            if (GameScapeReferencesHandler.ins.selectedSlot.DeconstructionOrder == false)
            {
                GameScapeReferencesHandler.ins.selectedSlot.DeconstructionOrder = true;

                TrackChange();//change the behaviour of char depending on location
                PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " started being deconstructed!");
            }
            else
            {
                GameScapeReferencesHandler.ins.selectedSlot.DeconstructionOrder = false;

                TrackChange();//change the behaviour of char depending on location
                PostWarning(GameScapeReferencesHandler.ins.selectedSlot.Name + " deconstruction was canceled!");
            }
        }

    }

    //UNLOCK DOOR
    public void UnlockDoor(string method)
    {
        if (method == "Use Lockpick")
        {
            foreach (Item item in ContainerStory.ins.actStory.Inventory)
            {

                if (item.Name == "Lockpick" && item.Quantity > 0)
                {
                    if (Random.value < 0.5f)
                    {
                        int actualSLot = GameScapeReferencesHandler.ins.selectedSlot.HouseSlot;
                        ContainerStory.ins.actStory.SlotsContainer[actualSLot] = ContainerStory.ins.actStory.RoomsTemplates[2].ShallowCopy();
                        ContainerStory.ins.actStory.SlotsContainer[actualSLot].HouseSlot = actualSLot;
                        TrackChange();

                        PostWarning("You succed to lockpick this door!");
                    }
                    else
                    {

                        if (Random.value < 0.5f)
                        {
                            item.Quantity--;
                            PostWarning("You broke a lockpick trying to opening this door!");
                        }
                        else
                        {
                            PostWarning("You fail trying to lockpick this door!");
                        }

                    }

                    break;
                }
            }

        }
        else if (method == "Use Key")
        {
            foreach (Item item in ContainerStory.ins.actStory.Inventory)
            {

                if (item.Name == "Key" && item.Quantity > 0)
                {

                    item.Quantity--;

                    int actualSLot = GameScapeReferencesHandler.ins.selectedSlot.HouseSlot;
                    ContainerStory.ins.actStory.SlotsContainer[actualSLot] = ContainerStory.ins.actStory.RoomsTemplates[2].ShallowCopy();
                    ContainerStory.ins.actStory.SlotsContainer[actualSLot].HouseSlot = actualSLot;

                    TrackChange();
                    PostWarning("You used a key to unlock this door!");



                    break;
                }
            }
        }
    }

    //VISIT ROOM
    public void VisitRoom()
    {
        //set dialog at the beginning of next turn or at this moment
        PostWarning("Move main character here if you want to visit this room.");
    }

    //CHAT WITH CHARACTER
    public void ChatWith()
    {
        //set dialog at the beginning of next turn or at this moment
        PostWarning("Move main character here if you want to chat with character.");
    }

    //GIVE GIFT TO CHARACTER
    public void CharacterGive()
    {
        //set dialog at the beginning of next turn or at this moment
        //OR just post warning with info about stats and items
        PostWarning("You want to give a gift to " + GameScapeReferencesHandler.ins.selectedCharacter.NickName + " but you don't know what.");
    }

    //ASK CHARACTER TO REST
    public void CharacterTimeOff()
    {
        //faster then resting at club room
        //use selected Character
        //take character from all slot even street
        //should come back only when stamina is full

        GameScapeReferencesHandler.ins.selectedCharacter.TimeOff = true;
        GameScapeReferencesHandler.ins.selectedCharacter.Resting = true;
        GameScapeReferencesHandler.ins.selectedCharacter.Able = false;

        PostWarning(GameScapeReferencesHandler.ins.selectedCharacter.NickName + " is taking some time off.");

        RemoveWorkerFromRoom();
    } 
    
    //ASK CHARACTER TO REST
    public void CharacterRest()
    {
        //resting at club room
        //use selected Character
        //put character in a room or empty room
        //should come back once its stamina is full or action given
        if (GameScapeReferencesHandler.ins.selectedCharacter.Resting == false)
        {
            GameScapeReferencesHandler.ins.selectedCharacter.Resting = true;

            PostWarning(GameScapeReferencesHandler.ins.selectedCharacter.NickName + " is resting.");
        }
        else
        {
            GameScapeReferencesHandler.ins.selectedCharacter.Resting = false;

            PostWarning(GameScapeReferencesHandler.ins.selectedCharacter.NickName + " is back to work.");
        }
       
    }

    //------------------------------------


}
