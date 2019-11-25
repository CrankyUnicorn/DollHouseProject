using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*This Class is used to receive and temporarly store UI information and other non critical information
 * on what is being pressed on screen or selected. This ables actions implemented in GameScapeActions
 * to have a user defined target and also useful to solve or define resolutions to UI conflits*/
public class GameScapeReferencesHandler : MonoBehaviour {

    public static GameScapeReferencesHandler ins;
    private void Awake()
    {
        ins = this;
    }

    /*//REFERENCE from ObjType GameObject
    [Header("What object type is selected")]
    public string InfoBoxType;
    [Header("What is the index of the object related to type")]
     public int InfoBoxIndex;
    */

    [Header("What Objects are selected")]
    public List<GameObject> raycastObjList;
    [Header("What Object is selected")]
    public GameObject raycastObjSelected;

    [Header("Disable movement on the game scape")]
    public bool disableGameScapeMovement;//Disable Scroll Movement on Game Scape
    [Header("Disable Raycast on pointer")]
    public bool disableRaycast;//Disable Raycast on Game Scape
    [Header("InfoBox is Opened")]
    public bool infoBoxOpen;//tells if info box is in use or not

    [Header("Selected Character")]
    public Character selectedCharacter;//What character is selecter right now
    [Header("Selected Room Slot")]
    public Room selectedSlot;//What slot is selecter right now
    [Header("Selected NPC")]
    public NPC selectedNPC;//What slot is selecter right now
    [Header("Selected Client")]
    public Client selectedClient;


    public delegate void OpenInfoBoxEvent();
    public static event OpenInfoBoxEvent OnOpenInfoBoxEvent;

    public delegate void CloseInfoBoxEvent();
    public static event CloseInfoBoxEvent OnCloseInfoBoxEvent;

    // Use this for initialization
    void Start () {
        
    }

    private void OnEnable()
    {
        Sniffer.OnClicked += LockMovement;
        Sniffer.OnClicked += DisableRaycast;
        Sniffer.UnClicked += UnlockMovement;
        Sniffer.UnClicked += AbleRaycast;

        DialogDisplay.OnDialogDisplayEventTrue += DisableRaycast;
        DialogDisplay.OnDialogDisplayEventTrue += CloseInfoBox;
        DialogDisplay.OnDialogDisplayEventFalse += AbleRaycast;

        GameInfoDisplay.OnInfoDisplayEventTrue += DisableRaycast;
        GameInfoDisplay.OnInfoDisplayEventFalse += AbleRaycast;
        GameInfoDisplay.OnInfoDisplayEventTrue += DisableNextButton;
        GameInfoDisplay.OnInfoDisplayEventFalse += AbleNextButton;
    }

    private void OnDisable()
    {
        Sniffer.OnClicked -= LockMovement;
        Sniffer.OnClicked -= DisableRaycast;
        Sniffer.UnClicked -= UnlockMovement;
        Sniffer.UnClicked -= AbleRaycast;

        DialogDisplay.OnDialogDisplayEventTrue-= DisableRaycast;
        DialogDisplay.OnDialogDisplayEventTrue -= CloseInfoBox;
        DialogDisplay.OnDialogDisplayEventFalse -= AbleRaycast;

        GameInfoDisplay.OnInfoDisplayEventTrue -= DisableRaycast;
        GameInfoDisplay.OnInfoDisplayEventFalse -= AbleRaycast;
        GameInfoDisplay.OnInfoDisplayEventTrue -= DisableNextButton;
        GameInfoDisplay.OnInfoDisplayEventFalse -= AbleNextButton;
    }


    private void LockMovement() { disableGameScapeMovement = true; }

    private void UnlockMovement() { disableGameScapeMovement = false; }

    private void DisableRaycast() { disableRaycast = true; }

    private void AbleRaycast() { disableRaycast = false; }

    private void CloseInfoBox() { if (OnCloseInfoBoxEvent != null) { OnCloseInfoBoxEvent(); } }

    private void AbleNextButton() { GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>().enabled = true; }

    private void DisableNextButton() { GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>().enabled = false; }

    // check mouse click and finds valid game object on top
    void Update()
    {
        if (disableRaycast!=true)
        {
            CheckMouseCLick();

            Converter();
        }
    }

    //Check if mouse is pressed
    private void CheckMouseCLick()
    {
        if (Input.GetMouseButtonUp(0) && disableRaycast != true)
        {
            Selector();

            GameScapeActions.ins.TrackChange();

            if (OnOpenInfoBoxEvent != null)
                OnOpenInfoBoxEvent();
        }
    }
    

    //coverts raycast list in a game object list
    private void Converter()
    {
        raycastObjList.Clear();

        foreach (var item in GameScapeRaycastSelector.ins.raycastRaycastList)
        {
            raycastObjList.Add(item.gameObject);
        }
    }


    //selects top valid object from raycast list now converted into a game object list
    private void Selector()
    {
        
        foreach (GameObject go in raycastObjList)
        {

            if (go.gameObject.GetComponent<GameScapeObjType>() != null)
            {
                raycastObjSelected = go.gameObject;

                var InfoBoxClass = raycastObjSelected.GetComponent<GameScapeObjType>().objClass;

                if (infoBoxOpen != true)
                {
                    selectedSlot = null;
                    selectedCharacter = null;
                    selectedNPC = null;
                    selectedClient = null;
                }

                if (InfoBoxClass == typeof(Room) && infoBoxOpen != true)
                {
                    selectedSlot = raycastObjSelected.GetComponent<GameScapeObjType>().room;
                    Debug.Log(selectedSlot.InventoryName);
                }
                else if (InfoBoxClass == typeof(Character) && infoBoxOpen != true)
                {
                    selectedCharacter = raycastObjSelected.GetComponent<GameScapeObjType>().charac;
                    Debug.Log(selectedCharacter.NickName);
                }
                else if (InfoBoxClass == typeof(NPC) && infoBoxOpen != true)
                {
                    selectedNPC = raycastObjSelected.GetComponent<GameScapeObjType>().npc;
                    Debug.Log(selectedNPC.NickName);
                }
                else if (InfoBoxClass == typeof(Client) && infoBoxOpen != true)
                {
                    selectedClient = raycastObjSelected.GetComponent<GameScapeObjType>().client;
                    Debug.Log(selectedClient.NickName);
                }

                break;
            }
            else
            {
                raycastObjSelected= go.gameObject;
                
            }
        }
    }
}
