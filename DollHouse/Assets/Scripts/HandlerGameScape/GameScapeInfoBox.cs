using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameScapeInfoBox : MonoBehaviour {
    
    public static GameScapeInfoBox ins;
    private void Awake()
    {
        ins = this;
    }

    //INFO BOX
    public GameObject infoBox;

    public Transform infoBoxTitle;
    public Transform infoBoxSprite;
    public Dropdown infoBoxDropdown1;
    public Transform infoBoxDescriptionBox;
   
    public Transform infoBoxWorkersBox;
    public Transform infoBoxWorkerBoxButtonSelect;
    public Transform infoBoxAddButton;
    public Transform infoBoxremoveButton;

    private RectTransform rt;

    //Coroutine
    private IEnumerator coroutineMove;

    //Marker
    private bool finishedCoroutine=true;

    //Dropdown Listing
    private List<string> infoBoxDropdown1List = new List<string>();

    private void OnEnable()
    {
        GameScapeReferencesHandler.OnOpenInfoBoxEvent += DisplayInfoBox;
        GameScapeReferencesHandler.OnCloseInfoBoxEvent += AbortInfoBox;
    }

    private void OnDisable()
    {
        GameScapeReferencesHandler.OnOpenInfoBoxEvent -= DisplayInfoBox;
        GameScapeReferencesHandler.OnCloseInfoBoxEvent -= AbortInfoBox;
    }
    //--------------------------------------

    //MANAGE INFOBOX DROPDOWN ACTION SELECTION
    // DEALS WITH INDEX PASSED BY THE TOP LEFT DROPDOWN MENU
    public void DropDown1_Index(int index)
    {
        string actionOrder;

        actionOrder = infoBoxDropdown1List[index];

      
        AbortInfoBox();

        switch (actionOrder)
        {
            case "Visit":
                GameScapeActions.ins.VisitRoom();
                break;

            case "Use Key":
                GameScapeActions.ins.UnlockDoor("Use Key");
                break;

            case "Use Lockpick":
                GameScapeActions.ins.UnlockDoor("Use Lockpick");
                break;

            case "Repair":
                GameScapeActions.ins.RepairRoom();
                break;

            case "Upgrade":
                GameScapeActions.ins.UpgradedRoom();
                break;

            case "Deconstruct":
                GameScapeActions.ins.DeconstructRoom();
                break;

            case "Construct":
                GameScapeActions.ins.ConstructRoom();
                break;

            case "Talk":
                GameScapeActions.ins.ChatWith();
                break;

            case "Give":
                GameScapeActions.ins.CharacterGive();
                break;

            case "Rest":
                GameScapeActions.ins.CharacterRest();
                break;

            case "Time Off":
                GameScapeActions.ins.CharacterTimeOff();
                break;

            default:
                break;
        }

       

    }



    //-------------------------------------

    //MANAGE DISPLAY OF  INFOBOX 
    void DisplayInfoBox()
    {
        GameObject _raycastObject = GameScapeReferencesHandler.ins.raycastObjSelected;
        
        if (_raycastObject!=null)
        {
            if (_raycastObject.GetComponent<GameScapeObjType>() != null)
            {
                Debug.Log(_raycastObject.GetComponent<GameScapeObjType>().objClass.ToString());
                if (GameScapeReferencesHandler.ins.infoBoxOpen != true)
                {
                    infoBox.SetActive(true);

                    //DROPDOWN REFRESHNER

                    infoBoxDropdown1List =_raycastObject.GetComponent<GameScapeObjType>().objDropdown1Text;
                    infoBoxDropdown1.ClearOptions();
                    infoBoxDropdown1.AddOptions(infoBoxDropdown1List);

                    infoBoxDropdown1.value = 0;
                    infoBoxDropdown1.Select(); // optional
                    infoBoxDropdown1.RefreshShownValue(); // this is the key


                    //TITLE TEXT
                    infoBoxTitle.GetChild(0).GetComponent<Text>().text = _raycastObject.GetComponent<GameScapeObjType>().objTitleText;

                    //ICON SPRITE
                    infoBoxSprite.GetComponent<Image>().sprite = _raycastObject.GetComponent<GameScapeObjType>().objIconSprite;
                    
                    //DESCRIPTION TEXT
                    infoBoxDescriptionBox.GetChild(0).GetComponent<Text>().text = _raycastObject.GetComponent<GameScapeObjType>().objDescriptionText;
                    

                    if (_raycastObject.GetComponent<GameScapeObjType>().objClass==typeof(Room))
                    {
                        ShowWorkerAble(_raycastObject.GetComponent<GameScapeObjType>().objListActive);
                    }
                    else if (_raycastObject.GetComponent<GameScapeObjType>().objClass == typeof(Character))
                    {
                        ShowRoomAble(_raycastObject.GetComponent<GameScapeObjType>().objListActive);
                    }
                    else
                    {
                        ShowRoomAble(false);//to be able to close and clean listing when passing to obj witout listing
                    }
                    

                    if (finishedCoroutine)
                    {
                        rt = (RectTransform)infoBox.transform;
                        coroutineMove = MoveInfoBox(infoBox, 0, (int)(-Screen.height/2+ (rt.rect.height/2)), false, false);
                        StopCoroutine(coroutineMove);
                        StartCoroutine(coroutineMove);

                        finishedCoroutine = false;
                    }

                    GameScapeReferencesHandler.ins.disableGameScapeMovement = true;
                }
            }

            //DISABLES MOVEMENT OF GAMESCAPE
            bool infoBoxOpenAlready = GameScapeReferencesHandler.ins.infoBoxOpen;
            foreach (GameObject _go in GameScapeReferencesHandler.ins.raycastObjList)
            {
                if (_go.GetComponent<GameScapeObjType>() != null  )
                {
                    GameScapeReferencesHandler.ins.infoBoxOpen = true;
                    break;
                }
                else if (_go.name == "BUILDING" || _go.name == "GameScapeInfoBox")//CHANGE THIS! make building have a component to identify it 
                {
                    GameScapeReferencesHandler.ins.infoBoxOpen = infoBoxOpenAlready;
                    break;
                }
                else 
                {
                    GameScapeReferencesHandler.ins.infoBoxOpen = false;
                }
            }
            

            //DELETES INFOBOX
            if (GameScapeReferencesHandler.ins.infoBoxOpen == false)
            {
                if (finishedCoroutine) {
                    rt = (RectTransform)infoBox.transform;
                    coroutineMove = MoveInfoBox(infoBox, (int)(-Screen.height / 2 + (rt.rect.height / 2)), 300, true, false);
                    StopCoroutine(coroutineMove);
                    StartCoroutine(coroutineMove);

                    finishedCoroutine = false;
                }

                GameScapeReferencesHandler.ins.disableGameScapeMovement = false;
            }
        }
    }

    //ABORT INFOBOX
    void AbortInfoBox() {
        
        GameScapeReferencesHandler.ins.infoBoxOpen = false;//set as false in the referenc instance of ref class

        //DELETES INFOBOX
        if (infoBox.activeInHierarchy==true)
        {

            if (GameScapeReferencesHandler.ins.infoBoxOpen == false)
            {
                if (finishedCoroutine)
                {
                    coroutineMove = MoveInfoBox(infoBox, (int)(-Screen.height / 2 + (rt.rect.height / 2)), 300, true, false);
                    StopCoroutine(coroutineMove);
                    StartCoroutine(coroutineMove);

                    finishedCoroutine = false;
                }

                GameScapeReferencesHandler.ins.disableGameScapeMovement = false;
            }

        }

    }

    //LIST WORKERS IN THE INFOBOX        
    void ShowWorkerAble(bool activate)
    {

        foreach (Transform child in infoBoxWorkersBox)
        {
            Destroy(child.gameObject);
        }

        if (activate)
        {
            foreach (Character charac in ContainerStory.ins.actStory.CharactersContainer)
            {
                if (charac.Able == true && charac.Unlock == true)
                {
                    if (charac.Resting == false)
                    {
                        bool inThisRoom;//check if this character is working in this room already
                        if (GameScapeReferencesHandler.ins.selectedSlot.HouseSlot == charac.Slot)
                        {
                            inThisRoom = true;
                        }
                        else
                        {
                            inThisRoom = false;
                        }

                        Transform go = Instantiate(infoBoxWorkerBoxButtonSelect) as Transform;

                        go.GetComponent<WorkerButton>().PopulateWorkerButton(charac.FirstName, inThisRoom, charac.Place);

                        go.SetParent(infoBoxWorkersBox);

                    }
                }
            }

            infoBoxAddButton.gameObject.GetComponent<Button>().enabled = true;
            infoBoxremoveButton.gameObject.GetComponent<Button>().enabled = true;
        }
        else
        {
            infoBoxAddButton.gameObject.GetComponent<Button>().enabled=false;
            infoBoxremoveButton.gameObject.GetComponent<Button>().enabled = false;
        }
    }


    //LIST WORKER IN THE INFOBOX        
    void ShowRoomAble(bool activate)
    {

        foreach (Transform child in infoBoxWorkersBox)
        {
            Destroy(child.gameObject);
        }

        if (activate)
        {
            foreach (Room room in ContainerStory.ins.actStory.SlotsContainer)
            {
                if (room.Locked != true && room.Empty != true)
                {
                    
                        bool inThisRoom;//check if this character is working in this room already
                        if (GameScapeReferencesHandler.ins.selectedCharacter.Slot == room.HouseSlot)
                        {
                            inThisRoom = true;
                        }
                        else
                        {
                            inThisRoom = false;
                        }


                    
                    int workSlotsCount=0;
                    foreach (string workslot in room.WorkersList)
                    {
                        if (workslot=="")
                        {
                            workSlotsCount++;
                        }
                    }
                    string workSlots = (workSlotsCount.ToString() + "work spaces of " + room.WorkersList.Count.ToString() + " total.");

                    Transform go = Instantiate(infoBoxWorkerBoxButtonSelect) as Transform;

                        go.GetComponent<WorkerButton>().PopulateWorkerButton(room.Name, inThisRoom, workSlots);

                        go.SetParent(infoBoxWorkersBox);

                    
                }
            }

            infoBoxAddButton.gameObject.GetComponent<Button>().enabled = true;
            infoBoxremoveButton.gameObject.GetComponent<Button>().enabled = true;
        }
        else
        {
            infoBoxAddButton.gameObject.GetComponent<Button>().enabled = false;
            infoBoxremoveButton.gameObject.GetComponent<Button>().enabled = false;
        }
    }



    //GENERAL UI MOVER 
    IEnumerator MoveInfoBox(GameObject go, int Y1, int Y2, bool disableThis, bool destroyThis)
    {
        Vector3 StartGOPos = new Vector3(go.transform.localPosition.x, Y1, go.transform.localPosition.z);

        Vector3 EndGOPos = new Vector3(go.transform.localPosition.x, Y2, go.transform.localPosition.z);

        go.transform.localPosition = StartGOPos;


        float DistanceGOPos =  Vector3.Distance(go.transform.localPosition, EndGOPos);


        while (Mathf.Abs(DistanceGOPos)>5)
        {
            DistanceGOPos = Vector3.Distance(go.transform.localPosition, EndGOPos);
            go.transform.localPosition = Vector3.Lerp(go.transform.localPosition,EndGOPos,0.3f);

            yield return new WaitForSeconds(0.03f);
        }
        
        go.transform.localPosition = EndGOPos;
       

        if (disableThis)
        {
            go.SetActive(false);
        }

        if (destroyThis)
        {
            Destroy(go);
        }

        finishedCoroutine = true;

        yield return null;
    }

    
}
