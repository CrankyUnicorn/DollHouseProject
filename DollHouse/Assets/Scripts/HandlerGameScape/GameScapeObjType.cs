using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*This Class is a data holder ingame temporaly storing and processing transitive 
 * information about the object that is place onto.
 this information is passed from GameScapeActions to GameScapeReferenceHandler */
public class GameScapeObjType : MonoBehaviour 
{

    public Type objClass;


    public Room room;
    public Character charac;
    public NPC npc;
    public Client client;

   
    
    public bool objUnlock;
    public bool objAble;
    public bool objLocked;
    public bool objEmpty;
    public bool objResting;
    

    public string objIconImage;
    public string objAvatarImage;
    public string objSlotImage;
    public Sprite objIconSprite;
    public Sprite objAvatarSprite;
    public Sprite objSlotSprite;

    public bool atRoom;

    public string objTitleText;
    public string objDescriptionText;
    public List<string> objDropdown1Text = new List<string>();
    public bool objListActive;
    public bool objListButtonsActive;

    public GameObject objOverheadBar;
    public GameObject objOverheadText;
    
 


    private void Start()
    {
        RefreshItem();

    }


    public void RefreshItem()
    {

        if (objClass == typeof(Room))
        {
            int i = 0;

            foreach (Room actSlot in ContainerStory.ins.actStory.SlotsContainer)
            {
                if (actSlot.HouseSlot!=i)//redundant correction
                {
                    actSlot.HouseSlot = i;
                }

                //if (room.HouseSlot == actSlot.HouseSlot && !(room.Name!=actSlot.Name || room.Tier!=actSlot.Tier))
                if (room.HouseSlot == i)
                {
                    if (room.Name!=actSlot.Name || room.Tier != actSlot.Tier)
                    {
                        Debug.Log("Room replaced!");
                        PopulateItem(actSlot);
                        
                        break;
                    }
                   
                }

                i++;
            }

            OverHeadInfoRoom();

        }
        else if (objClass == typeof(Character))
        {
          
            PopulateItem(charac);

            OverHeadInfoPerson();

        }
        else if (objClass == typeof(NPC))
        {
            PopulateItem(npc);

            OverHeadInfoPerson();

        }
        else if (objClass == typeof(Client))
        {
            PopulateItem(client);

            OverHeadInfoPerson();
        }
        else
        {
            //do nothing
        }


        if (objLocked == true)
        {
            GetComponent<Image>().color = Color.gray;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
            //do something
        }

        if (objAble == true)
        {
            
        }

        //do something


    }


    public void PopulateItem<T>(T sendedObject) 
    {
        if (objClass==null)
        {
            objClass = typeof(T);
        }
        
        
       
        objDropdown1Text.Clear();
        
       

        //ROOM INFO BOX COMPOSSER
        if (objClass == typeof(Room))
        {
            room = sendedObject as Room;

            objUnlock = room.Unlock;
            objAble = room.Able;
            objLocked = room.Locked;
            objEmpty = room.Empty;

            //Show Parameter in the infobox
            objIconImage = room.Icon;
            objSlotImage = room.SlotInImage;

            
           
             if(room.RepairOrder == true)
            {
                objTitleText = room.Name + " (REPAIRING)";
            }
            else if (room.ConstructionOrder == true)
            {
                objTitleText = room.Name + " (CONSTRUCTING)";
            }
            else if (room.DeconstructionOrder == true)
            {
                objTitleText = room.Name + " (DECONSTRUCTING)";
            }
            else if (room.UpgradingOrder == true)
            {
                objTitleText = room.Name + " (UPGRADING)";
            }
            else
            {
                objTitleText = room.Name;
            }


            objDescriptionText = room.Description;

            objDropdown1Text.Add("SELECT AN ACTION");

            objDropdown1Text.Add("Visit");

            if (room.SlotInImage != null && room.SlotInImage != "None")
            {
                objSlotSprite = ImageFinder(objSlotImage);
                GetComponent<Image>().sprite = objSlotSprite;
            }

            if (room.Locked == true)
            {

                objDropdown1Text.Add("Use Key");
                objDropdown1Text.Add("Use Lockpick");//buy them from the shady locksmith

            }
            else {
                if (room.Empty == true)
                {
                    if (room.RepairLevel == 100)
                    {
                        objDropdown1Text.Add("Construct");
                    }
                    else if (room.RepairLevel < 100)
                    {
                        objDropdown1Text.Add("Repair");
                    }
                   
                }
                else
                {
                    if (room.RepairLevel == 100)
                    {
                        objDropdown1Text.Add("Upgrade");
                    }
                    else if (room.RepairLevel < 100)
                    {
                        objDropdown1Text.Add("Repair");
                    }

                    objDropdown1Text.Add("Deconstruct");

                }
                
                
            }

            if (room.Locked == true)
            {

                //sets list to true or false depending on what is needed
                objListActive = false;
                objListButtonsActive = false;
            }
            else
            {
                //sets list to true or false depending on what is needed
                objListActive = true;
                objListButtonsActive = true;
            }
           
        }
        //CHARACTER INFO BOX COMPOSSER
        else if (typeof(T) == typeof(Character))
        {
            charac = sendedObject as Character;

            //
            objUnlock = charac.Unlock;
            objAble = charac.Able;
            objResting = charac.Resting;

            //Show Parameter in the infobox
            objIconImage = charac.Icon;
            objAvatarImage = charac.Avatar;

            objTitleText = charac.FirstName + " " + charac.LastName;
            objDescriptionText = charac.Description;

            objDropdown1Text.Add("SELECT AN ACTION");

            objDropdown1Text.Add("Talk");

            if (charac.Able == false)
            {
                objDropdown1Text.Add("Give");

                //sets list to true or false depending on what is needed
                objListActive = false;
                objListButtonsActive = false;


            }
            else if (charac.Able == true)
            {
                objDropdown1Text.Add("Give");
                objDropdown1Text.Add("Time Off");

                if (charac.Slot!=0)
                {
                    objDropdown1Text.Add("Rest");
                }

                //sets list to true or false depending on what is needed
                objListActive = true;
                objListButtonsActive = true;

            }



            //move into slot or out of it 
            GameObject[] allSlotsGO = GameObject.FindGameObjectsWithTag("GameScapeSlot");
            GameObject streetLayer = GameObject.FindGameObjectWithTag("GameScapeStreetLayer");

            if (charac.Able == true && charac.Resting != true)
            {
                foreach (GameObject slotGO in allSlotsGO)
                {
                    if (charac.Slot == slotGO.GetComponent<GameScapeObjType>().room.HouseSlot)
                    {
                        if (!this.transform.IsChildOf(slotGO.transform))
                        {
                            this.transform.SetParent(slotGO.transform, false);
                            this.transform.SetAsLastSibling();
                            this.transform.position = slotGO.transform.position;

                            atRoom = true;
                        }
                    }
                }

                if (charac.Slot == 0)
                {
                    if (!this.transform.IsChildOf(streetLayer.transform))
                    {

                        this.transform.SetParent(streetLayer.transform, false);
                        this.transform.SetAsFirstSibling();
                        RectTransform rt = (RectTransform)streetLayer.transform;

                        //compensate to street heigh
                        this.transform.localPosition = new Vector3(0f, rt.rect.height / 2, 0f);

                        //make sure image component is rendering
                        Image[] images = streetLayer.gameObject.GetComponentsInChildren<Image>();
                        foreach (Image ima in images)
                        {
                            ima.gameObject.GetComponent<Image>().enabled = true;
                        }

                        //set walk to street mode
                        atRoom = false;
                    }
                }
            }

        }
        //NPC INFO BOX COMPOSSER
        else if (typeof(T) == typeof(NPC))
        {
            npc = sendedObject as NPC;
            //nothing yet
        }
        //CLIENT INFO BOX COMPOSSER
        else if (typeof(T) == typeof(Client))
        {
            client = sendedObject as Client;
            //nothing yet
        }
        //VEHICLE INFO BOX COMPOSSER
        /*else if (objType == typeof(Vehicle))
        {
            //nothing yet
        }*/

        //SET UP IMAGES, got ot be posted where since it only can receive image info after having abouve references
        objIconSprite = ImageFinder(objIconImage);

        objAvatarSprite = ImageFinder(objAvatarImage);

    }


    //OVERHEAD INFO
    private void OverHeadInfoRoom()
    {
        Vector3 disp = new Vector3(0f, -50f, 0f);
        Vector3 scal = new Vector3(room.RepairLevel/100, 1f, 1f);

        Color red = new Color(1f, 0f, 0f, 1f);
        Color orange = new Color(1f, 0.5f, 0f, 1f);
        Color yellow = new Color(1f, 1f, 0f, 1f);

        if (this.transform.childCount != 0)
        {
            foreach (Transform childTransform in this.transform)
            {
                
                if (childTransform.name=="OverHeadBar(Clone)")
                {
                    childTransform.position = this.transform.position + disp;
                    childTransform.GetChild(0).localScale = scal;

                    if (room.RepairLevel < 40)
                    {
                        childTransform.gameObject.SetActive(true);
                        childTransform.GetChild(0).GetComponent<Image>().color = red;
                    }
                    else if (room.RepairLevel < 80)
                    {
                        childTransform.gameObject.SetActive(true);
                        childTransform.GetChild(0).GetComponent<Image>().color = orange;
                    }
                    else if (room.RepairLevel < 100)
                    {
                        childTransform.gameObject.SetActive(true);
                        childTransform.GetChild(0).GetComponent<Image>().color = yellow;
                    }
                    else if (room.RepairLevel == 100)
                    {
                        childTransform.gameObject.SetActive(false);
                        childTransform.GetChild(0).GetComponent<Image>().color = Color.green;
                    }
                }
            }
            
        }
        else
        {
            GameObject thisObj = Instantiate(objOverheadBar);
            thisObj.transform.GetChild(0).localScale = scal;
            thisObj.transform.SetParent(this.transform);
            thisObj.transform.position = this.transform.position + disp;

            if (room.RepairLevel < 40)
            {
                thisObj.SetActive(true);
                thisObj.transform.GetChild(0).GetComponent<Image>().color = red;
            }
            else if (room.RepairLevel < 80)
            {
                thisObj.SetActive(true);
                thisObj.transform.GetChild(0).GetComponent<Image>().color = orange;
            }
            else if (room.RepairLevel < 100)
            {
                thisObj.SetActive(true);
                thisObj.transform.GetChild(0).GetComponent<Image>().color = yellow;
            }
            else if (room.RepairLevel == 100)
            {
                thisObj.SetActive(false);
                thisObj.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            }
        }

       
    }

    //OVERHEAD INFO
    private void OverHeadInfoPerson()
    {
        Vector3 disp = new Vector3(0f, 45f, 0f);
        Vector3 disp2 = new Vector3(0f, 35f, 0f);
        Vector3 scal = new Vector3(charac.Stamina / 100f, 1f, 1f);

        if (this.transform.childCount != 0)
        {
            foreach (Transform childTransform in this.transform)
            {

                if (childTransform.name == "OverHeadText(Clone)")
                {
                    childTransform.position = this.transform.position + disp;
                }


                if (childTransform.name == "OverHeadBar(Clone)")
                {
                    childTransform.position = this.transform.position + disp2;
                    childTransform.GetChild(0).localScale = scal;

                    if (charac.Stamina < 100)
                    {
                        childTransform.gameObject.SetActive(true);
                        childTransform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    }
                   
                    else if (charac.Stamina == 100)
                    {
                        childTransform.gameObject.SetActive(true);
                        childTransform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    }
                }
            }
        }
        else
        {
            GameObject thisObj = Instantiate(objOverheadText);
            thisObj.GetComponentInChildren<Text>().text = charac.NickName;
            thisObj.transform.SetParent(this.transform);
            thisObj.transform.position = this.transform.position + disp;


            GameObject thisObj2 = Instantiate(objOverheadBar);
            thisObj2.transform.GetChild(0).localScale = scal;
            thisObj2.transform.SetParent(this.transform);
            thisObj2.transform.position = this.transform.position + disp2;

            if (room.RepairLevel < 100)
            {
                thisObj2.SetActive(true);
                thisObj2.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
            }
            
            else if (room.RepairLevel == 100)
            {
                thisObj2.SetActive(true);
                thisObj2.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
            }
        }


    }


    //Find image to pass to the game info box
    private Sprite ImageFinder(string imageName)
    {
        Sprite sendSprite;
        if (imageName != null)
        {
            //IMPORT PNG IMAGES FROM RESOURCES SPRITES FILE AND PLACE THEM IN GAME

            if (Resources.Load<Sprite>("Sprite/" + imageName) != null)
            {
                sendSprite = Resources.Load<Sprite>("Sprite/" + imageName) as Sprite;

                return sendSprite;


            }
            else
            {
                //IMPORT PNG IMAGES FROM SPRITES FILE AND PLACE THEM IN GAME

                for (int id = 0; id < IOStory.ins.importedSprite.Count; id++)
                {

                    if (imageName == IOStory.ins.importedSprite[id])
                    {

                        sendSprite = IOStory.ins.spriteList[id];
                        return sendSprite;

                    }
                  
                }

                sendSprite = Resources.Load<Sprite>("Sprite/" + "NoImage") as Sprite;

                return sendSprite;

            }
        }


        sendSprite = Resources.Load<Sprite>("Sprite/" + "NoImage") as Sprite;

        return sendSprite;

    }
}
