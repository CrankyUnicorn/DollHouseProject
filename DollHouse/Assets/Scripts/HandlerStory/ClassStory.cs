using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITag
{
    //ID
    int ID { get; set; }//Identification Number
}

    [System.Serializable]
public class PersonBasic
{
    //INFO
    public string FirstName { get; set; } // character name
    public string LastName { get; set; } // character last name
    public string NickName { get; set; } // character nick name
    public string Description { get; set; }//character Description

    public bool Unlock { get; set; } // if true character will appear in world and be used in dialogs
    public bool Able { get; set; } // if true character can works for you

    public string Icon { get; set; }//character image ref
    public string Avatar { get; set; }//character image ref

    public List<string> Schedual { get; set; }//what part of the day character shows up

    public int RequiredReputation { get; set; } // Building Reputaion Min requierd to the aparence of this character
    public int RequiredNotoriety { get; set; } //  Building Notoriaty Min requierd to the aparence of this character
    public int RequiredLuxury { get; set; } //  Building Luxury Min requierd to the aparence of this character
    public int RequiredTier { get; set; } // Building upgrade Tier Min requierd to the aparence of this character

    public int Happiness { get; set; }//character amount of happiness 0 to 100
    public int Resilience { get; set; }//character amount of happiness 0 to 10

    public int Money { get; set; }//character amount of money 

    //INVENTORY
    public string InventoryType { get; set; }//Type of the iventory alowed Items 
    public List<Item> Inventory { get; set; }
   
    public PersonBasic()
    {
        Inventory = Inventory ?? new List<Item>();
    }
}

[System.Serializable]
public class PersonExtended : PersonBasic
{
    public int BirthdayDay { get; set; } //character B day day
    public string BirthdayMonth { get; set; } // character B day Month
    public List<string> FavoriteGifts { get; set; } // character B Favorite Gifts

    public string Bloodtype { get; set; } // character Bloodtype
    public string Zodiac { get; set; } // character Zodiac

    public int IncapacitatedTicks { get; set; }//how many tics will the character be incapacitated
}


    [System.Serializable]
public class Story: PersonExtended, ITag
{
    public int ID { get; set; }

    private string fileName;// what name should be use to save
    public string FileName { get { return fileName; } set {fileName= value == null? string.Empty: value.Substring(0, Mathf.Min(150, value.Length)); } } // what name should be use to save

    public string TimeStamp { get; set; } // date of time when was saved
    
    public bool DisableStrategicGame { get; set; }//game is only a regular VNovel
    public bool DisableDialogOptions { get; set; }//remove options from dialog lines

    //TIME RELATED STATUS
    public int ActTick { get; set; } // actual elapsed hours
    public int ActHour { get; set; } // actual hour
    public int ActDay { get; set; } // actual day
    public List<string> WeekdayNames { get; set; } // actual weekday name
    public string ActWeekday { get; set; } // actual weekday name
    public List<string> MonthNames { get; set; } // actual month name
    public string ActMonth { get; set; } // actual month name
    public int ActYear { get; set; } // actual year name
    public string ActDayPart { get; set; } // actual paty of the day name 
    public List<string> DayPartNames { get; set; } // actual paty of the day name 

    //ACCOUNTING
    public int ActMoney { get; set; } // actual money 
    public int ActDayIncome { get; set; } // actual day money to come 
    public int ActMonthIncome { get; set; } // actual month money to come
    public int ActDayExpenses { get; set; } // actual money to loose
    public int ActMonthExpenses { get; set; } // actual money
    public int ActDayClients { get; set; } //
    public int ActMonthClients { get; set; } //
    public int ActDayClientsHappiness { get; set; } //
    public int ActMonthClientsHappiness { get; set; } //

    public int LastDayIncome { get; set; } // actual day money to come 
    public int LastMonthIncome { get; set; } // actual day money to come 
    public int LastDayExpenses { get; set; } // actual day money to come 
    public int LastMonthExpenses { get; set; } // actual day money to come 
    public int LastDayClients { get; set; } // actual day money to come 
    public int LastMonthClients { get; set; } // actual day money to come 
    public int LastDayClientsHappiness { get; set; } // actual day money to come 
    public int LastMonthClientsHappiness { get; set; } // actual day money to come 

    public int ActTotalDebt { get; set; } // actual dept paid at day one of each month 
    public List<string> DebtNames { get; set; } // actual money
    public List<int> DebtValues { get; set; } // actual money

    //SELLS
    public int ActDaySells { get; set; }
    public int LastDaySells { get; set; }
    public int ActMonthSells { get; set; }
    public int LastMonthSells { get; set; }

    //PLAYER extended STATUS
    public int PlayerCharisma { get; set; } // player influence
    public int PlayerFame { get; set; } // actual Good Neutral or Evil -100 to 100
    public int PlayerFlatter { get; set; }
    public int PlayerWit { get; set; }
    public int PlayerPersuasion { get; set; }
    public int PlayerBargain { get; set; }

    //BUILDING STATUS
    public string BuildingName { get; set; } //name of your club
    public int BuildingSlotLayout { get; set; }//slot layout Identification number

    public string BuildingIcon { get; set; }//name of the image to palece as buidlidn

    public bool BuildingOpen { get; set; }//true if building is open for Buisness

    public int BuildingReputation { get; set; } // 0 to 5 stars but is in reality a range from 0 to 100
    public int BuildingNotoriety { get; set; } // 0 to 5 stars but is in reality a range from 0 to 100
    public int BuildingLuxury { get; set; } // 0 to 5 stars but is in reality a range from 0 to 100
    public int BuildingTier { get; set; } // 0 to 5 stars
    
    //INVENTORY LISTING
    public List<string> InventoryTypesList { get; set; }//Listing of the types of inventory existing on the game

    //INVENTORY Building LIST
    public string BuildingInventoryType { get; set; }//Type of the Building Items
    public List<Item> BuildingInventory { get; set; }

    //WORK TYPES FOR ROOM CLASSIFICATION
    public List<string> RoomWorkTypesList { get; set; }//Listing of the names of the works types

    //ORDERS
    public bool KickoutOrder { get; set; }//Order to start kicking out all clients

    //CLIENTS indexed flow of clients on the week being 0 Mondey night and extending by 7*4 from 0 to 27 
    //works as a multiplier being one minimum and 1000 the max
    public List<int> ClientsDynamics { get; set; } //name of your club

    public Story()
    {
        BuildingInventory = BuildingInventory ?? new List<Item>();
    }

    //-----------
    public List<Dialog> DialogsContainer = new List<Dialog>();
    public List<Character> CharactersContainer = new List<Character>();//only needs this one to work right
    public List<SlotLayout> SlotLayoutTemplate = new List<SlotLayout>();//template of the layout of the building
    public List<Room> RoomsTemplates = new List<Room>();//rooms template
    public List<Room> SlotsContainer = new List<Room>();//rooms in the actual building
    public List<BuildingUpgrade> BuildingUpgradeContainer = new List<BuildingUpgrade>();//only needs this one to work right
    public List<Item> ItemsTemplates = new List<Item>();//items template
    public List<Modifier> ModifiersTemplates = new List<Modifier>();//Templates of modifiers
    public List<Modifier> ModifiersContainer = new List<Modifier>();//Templates of modifiers
    public List<Achivement> AchivementsTemplates = new List<Achivement>();//Achivements Templates
    public List<Achivement> AchivementsContainer = new List<Achivement>();//Achivements achived by the player
    public List<Client> ClientsTemplates = new List<Client>();//templates of the all the clients
    public List<Client> ClientsContainer = new List<Client>();//clients actually inside the building
    public List<NPC> NPCsContainer = new List<NPC>();//NPCS list only need this one
}



[System.Serializable]
public class Character : PersonExtended, ITag
{
    public int ID { get; set; }

    public bool MainCharacter { get; set; }//if true this character is the main character usually
    /* //PLAYER extended STATUS
    public int PlayerCharisma { get; set; } // player influence
    public int PlayerFame { get; set; } // actual Good Neutral or Evil -100 to 100
    public int PlayerFlatter { get; set; }
    public int PlayerWit { get; set; }
    public int PlayerPersuasion { get; set; }
    public int PlayerBargain { get; set; }*/
    public int Relationship { get; set; } //how much its okey with you
    public int Intimacy { get; set; } // how much is willing to do stuff for you
    public int Loyalty { get; set; } // how much loyal is to you
    public string Place { get; set; }// name of the room where the character works
    public int Slot { get; set; }// number of the room where the character works
    public string LovesToWorkIn { get; set; } //job that character loves to do
    public string HatesToWorkIn { get; set; } //job that this character hates to do
    public int WorkCost { get; set; } //How mutch does it cost to do the work
    public int WorkPayDebt { get; set; } //amount you are in debt with charact
    private int stamina { get; set; } //energy this character haves
    public int Stamina { get { return stamina; } set { stamina = Mathf.Clamp(value, -100, 100); } } //energy this character haves
    public int Experience { get; set; } //experience this character haves
    private int level { get; set; } //level of this character
    public int Level { get { return level; } set { level = Mathf.Clamp(value, 1, 100); } } //level of this character
    private int proficiency { get; set; } // set from 0 to 5 or 0 to 5 stars
    public int Proficiency { get { return proficiency; } set { proficiency = Mathf.Clamp(value, 1, 100); } } // set from 0 to 5 or 0 to 5 stars
    public bool Resting { get; set; } //true if character is restig set true
    public bool TimeOff { get; set; } //true if character is taking some days off

    //SEE "MODIFIER" CLASS  
    public List<string> Modifiers { get; set; } // list of modifier to  be aplied
    public List<float> ModifiersValues { get; set; } // OPTIONAL values to be implemented with the modifer
}


[System.Serializable]
public class SlotLayout : ITag
{
    public int ID { get; set; }

    //Layout of each building configuration
    public int SlotLayoutId { get; set; } // first Configuration Id

    public string SlotLayoutName { get; set; } // first Name
    public int SlotLayoutMaxSlots { get; set; } // maximum of slots in this house
    public List<int> SlotLayoutSlotX { get; set; } // positions on X 
    public List<int> SlotLayoutSlotY { get; set; } // positions on Y 
    public string SlotLayoutInBG { get; set; } // name of the image for the house inside bg
    public string SlotLayoutOutBG { get; set; } // name of the image for the house outisde bg

}


[System.Serializable]
public class Room : ITag
{
    public int ID { get; set; }

    public string Name { get; set; } // first Name
    public string Description { get; set; } // Description
    public string SlotInImage { get; set; } // Description
    public string SlotOutImage { get; set; } // Description
    public string Icon { get; set; } // Description

    public bool ConstructionOrder { get; set; }//if is under construction
    public int ConstructionTime { get; set; }//each unit represents a hour*character proficiency 
    public int ConstructionCost { get; set; }// price to build

    public bool DeconstructionOrder { get; set; }//if 
    public int DeconstructionTime { get; set; }//each unit represents a hour*character proficiency
    public int DeconstructionCost { get; set; }//price to sell or destroy

    public bool UpgradingOrder { get; set; }//if 

    public bool RepairOrder { get; set; }//if true repair room if not and value of room over 80 work
    public float RepairLevel { get; set; }//between 0 and 100 being 100 fully functional and under 80 non fuctinal
    public int RepairCost { get; set; }//cost to repair a single point

    public int HouseSlot { get; set; }//slot occupied by this room

    public bool Unlock { get; set; } // if unlock to be shown in game
    public bool Able { get; set; } // if able to be used, produced, played or alterated in any other way
    public bool Removable { get; set; }// true if can be modified after being build
    public bool Locked { get; set; } // if door to room is locked you need to open it
    public bool Empty { get; set; } // if this room is able to be modified into another room

    public string InventoryName
    {
        get
        {
            return Name+HouseSlot;
        }
    } //1 to 3 being 0 unable 

    private int tier; //1 to 3 being 0 unable 
    public int Tier
    {
        get
        {
            return tier;
        }
        set
        {
            tier = Mathf.Clamp(value, 0, 3);
        }
    } //1 to 3 being 0 unable 

    private int workersCapacity;// max number of slot being the max 100
    public int WorkersCapacity
    {
        get
        {
            return workersCapacity;
        }
        set
        {
            workersCapacity = Mathf.Clamp(value, 0, 100);
        }
    } // max number of slot being the max  3
  
    public int WorkersCalCap
    {
        get
        {
            return tier + WorkersCapacity;
        }
    }//adds number from tier and extra cap to an amount of total capacity

    private List<string> workersList; // who is this slot
    public List<string> WorkersList
    {
        get
        {
            //WARNING DONT MESS THIS GET ACESSOR!!!
            workersList = workersList ?? new List<string>();

            if (workersList.Capacity == WorkersCalCap)
            {
                return workersList;
            }
            else
            {
                List<string> newRoomWorkersList = new List<string>(new string[WorkersCalCap]);

                return newRoomWorkersList;
            }

        }
        set
        {
            workersList = workersList ?? new List<string>();

            if (workersList.Capacity != WorkersCalCap && WorkersCalCap != 0)
            {
                List<string> newRoomWorkersList = new List<string>(new string[WorkersCalCap]);
                if (workersList.Capacity != 0)
                {
                    Debug.Log("set workersList:" + workersList.Count);
                    for (int i = 0; i < workersList.Capacity; i++)
                    {
                        
                        newRoomWorkersList[i] = workersList[i];
                    }
                }
                workersList = newRoomWorkersList;
            }

            if (value !=null || value.Capacity!=0|| value.Count!=0 )
            {
                workersList = value;
            }
            

        }
    } // who is in this slot

    public string WorkType { get; set; }//what type of work is done in this room

    private List<string> productionItems;//
    public List<string> ProductionItems
    {
        get
        {
            productionItems = productionItems ?? new List<string>();
            return productionItems;
        }
        set
        {
            productionItems = productionItems ?? new List<string>();
            productionItems = value;
        }
    }//what does it produce
    
    //SEE "MODIFIER" CLASS  
    public List<string> Modifiers { get; set; } // list of modifier to  be aplied
    public List<float> ModifiersValues { get; set; } // OPTIONAL values to be implemented with the modifer

    public Room()
    {
        Modifiers = Modifiers ?? new List<string>();
        ModifiersValues = ModifiersValues ?? new List<float>();
    }

    public Room ShallowCopy()
    {
        return (Room)this.MemberwiseClone();
    }
}


[System.Serializable]
public class BuildingUpgrade : ITag
{
    public int ID { get; set; }

    public string Name { get; set; } // first Name
    public string Description { get; set; } // Description
    public bool Unlock { get; set; } // if able or not
    public bool Able { get; set; } // if able or not
    public int Price { get; set; }//
    public int Tier { get; set; } //1 to 3 being 0 unable 
    
    //SEE "MODIFIER" CLASS  
    public List<string> Modifiers { get; set; } // list of modifier to  be aplied
    public List<float> ModifiersValues { get; set; } // OPTIONAL values to be implemented with the modifer

}


[System.Serializable]
public class Item : ITag
{
    public int ID { get; set; }

    public string Name { get; set; } // first Name
    public string Description { get; set; } // Description
  
    public string Icon { get; set; } // Description

    public bool Unlock { get; set; } //need to be true to be shown 
    public bool Able { get; set; } // needs to be true to be produced
    public bool Unsellable { get; set; } // if true can't be sold

    private string inventoryType;
    public string InventoryType
    {
        get
        {
            return inventoryType;
        }
        set
        {
            inventoryType = value;
        }
    } // Type Inventory where it should allocate 

    public int Quantity { get; set; } // how many of this do exist
    public int BuyPrice { get; set; } // whats the price of the item if you have to buy it yourself
    public int SellPrice { get; set; } // what the price of this item sold to public
    public int ProductionBatch { get; set; } // how many items does a batch have
    public int ProductionCost { get; set; } // cost to produce a singel item

    public int RisesHappines { get; set; } // amount of happynes it rises on clients


    // this are to be used principally on the personal player items 
    //but can also be used elsewhere
    //SEE "MODIFIER" CLASS  
    public List<string> Modifiers { get; set; } //
    public List<float> ModifiersValues { get; set; } // OPTIONAL values to be implemented with the modifer

    public Item()
    {

    }

    public Item ShallowCopy()
    {
        return (Item)this.MemberwiseClone();
    }
}


[System.Serializable]
public class Modifier : ITag
{
    public int ID { get; set; }

    //MODIFIERS: Such as Effects, habilities, buffs and negative effects
   
    public string Name { get; set; } //
    public string Description { get; set; } //
    public bool Unlock { get; set; } //
    public bool Able { get; set; } //
    public bool Effect { get; set; } //
    public int EffectValue { get; set; } //

}


    [System.Serializable]
public class Achivement : ITag
{
    public int ID { get; set; }

    public string Name { get; set; } // first Name
    public string Description { get; set; } // Description
    public string Icon { get; set; } // Description
    public bool Unlock { get; set; } // if able or not
    public bool Able { get; set; } // if able or not
    
    // this are to be used principally on the personal player items 
    //but can also be used elsewhere
    //SEE "MODIFIER" CLASS  
    public List<string> Modifiers { get; set; } //
    public List<float> ModifiersValues { get; set; } // OPTIONAL values to be implemented with the modifer
}


[System.Serializable]
public class Client : PersonBasic, ITag
{
    public int ID { get; set; }

    //CLIENTS character are used as peons to calculate consumption and reveniu and come in a lot types

    public List<string> WishesRooms { get; set; } // Item that Client Wants to by from high to low
    public List<string> WishesService { get; set; } // Item that Client Wants to by from high to low
    public List<string> WishesProducts { get; set; } // Item that Client Wants to by from high to low

    public int MoneyStartMax { get; set; }//Max at Start Money it can hold
    public int MoneyStartMin { get; set; }//Min at Start Money it can hold

    public int ConsuptionCycle { get; set; } // how many times is this client going to spend is money and NOT the money he she have
    public int ConsuptionDelay { get; set; } // how fast will they spend money
    public int ConsuptionCounter { get; set; } // how fast will they spend money

    public Client()
    {

    }

    public Client ShallowCopy()
    {
        return (Client)this.MemberwiseClone();
    }
}


 [System.Serializable]
public class NPC : PersonExtended, ITag
{
    public int ID { get; set; }

    public int Relationship { get; set; } //how much its okey with you
    public string PlaceInMap { get; set; }// place the character in a room to make it work that job
    public List<string> ShowAtDays { get; set; }//what day does it show a specific day of the Month
    public List<string> ShowAtMonths { get; set; }//what day does it show a specific Month

    public NPC()
    {

    }

    public NPC ShallowCopy()
    {
        return (NPC)this.MemberwiseClone();
    }
}


[System.Serializable]
public class Dialog : ITag
{
    public int ID { get; set; }


    public string DialogDescription { get; set; }// use to identify the dialog
    public bool LockedDialog { get; set; }//starts false if true doesn't work

    //TYPE 
    public string TypeEvent { get; set; }// If true is a Start Game Event


    //CONDITIONS TIME
    public int IfTick { get; set; }//activate only on day x from start date
    public int IfHour { get; set; } // activate only at hour of day x
    public string IfDayPart { get; set; }
    public int IfDay { get; set; } // activate only on day x
    public string IfWeekDay { get; set; } // activate only on week day by name x
    public string IfMonth { get; set; }
    public int IfYear { get; set; }

    //VALUES 
    public bool ShowTimes { get; set; }//show x times or always
    public int ShowTimesX { get; set; }// how many times
    public int TimesShown { get; set; }// times allready shown 

    public string SetAchivement { get; set; }//

    //CONDITIONS NECESSARY ACHIVMENTS
    public string IfAchivement1 { get; set; }//necessary achivements
    public string IfAchivement2 { get; set; }//
    public string IfAchivement3 { get; set; }//

    //PLAYER conditions
    public int IfCharisma { get; set; } // player influence
    public int IfFame { get; set; } // actual Good Neutral or Evil -100 to 100
    public int IfFlatter { get; set; }
    public int IfWit { get; set; }
    public int IfPersuasion { get; set; }
    public int IfBargain { get; set; }

    public bool IfBirthdayDay { get; set; } //player B day day

    public string IfBloodtype { get; set; } // player last name
    public string IfZodiac { get; set; } // player last name

    //CHARACTERS conditions
    public string IfCharacterName { get; set; } // first Name
    public string IfCharacterLastName { get; set; } // last Name
    public bool IfCharacterUnlock { get; set; } // if able or not
    public bool IfCharacterAble { get; set; } // if able or not
    public bool IfCharacterBirthdayDay { get; set; } //day of birthday
    public int IfCharacterRelationship { get; set; } //how much its okey with you
    public int IfCharacterIntimacy { get; set; } // how much is willing to do stuff for you
    public int IfCharacterLoyalty { get; set; } // how much loyal is to you
    public string IfCharacterWorkPlace { get; set; } //job that character loves to do
    public string IfCharacterFavoriteJob { get; set; } //job that character loves to do
    public string IfCharacterNormalJob { get; set; } //job that character does mind doing
    public string IfCharacterHateJob { get; set; } //job that this character hates to do
    public string IfFavoriteGift { get; set; } //gift that this character would love
    public int IfCharacterStamina { get; set; } //energy this character haves
    public int IfCharacterExperience { get; set; } //experience this character haves
    public int IfCharacterLevel { get; set; } //level of this character
    public int IfCharacterProficiency { get; set; } // set from 0 to 100 or 0 to 5 stars
    public bool IfCharacterResting { get; set; } //if is restig set true 
    //EXTRA CHARACTERS
    public string IfExtra1Name { get; set; } // first Name
    public string IfExtra1LastName { get; set; } // last Name
    public bool IfExtra1Unlock { get; set; } // if able or not
    public bool IfExtra1Able { get; set; } // if able or not

    public string IfExtra2Name { get; set; } // first Name
    public string IfExtra2LastName { get; set; } // last Name
    public bool IfExtra2Unlock { get; set; } // if able or not
    public bool IfExtra2Able { get; set; } // if able or not

    //ACCOUNTING conditions
    public int IfMoneyUnder { get; set; } //if money is
    public int IfMoneyOver { get; set; } //if money is 
    public int IfDebtUnder { get; set; } //if debt is  
    public int IfDebtOver { get; set; } //if debt is 

    //BUILDING conditions
    public int IfBuildingReputation { get; set; } // 0 to 5 stars but is in reality a range from 0 to 100
    public int IfBuildingNotoriety { get; set; } // 0 to 5 stars but is in reality a range from 0 to 100
    public int IfBuildingLuxury { get; set; } // 0 to 5 stars but is in reality a range from 0 to 100
    public int IfBuildingTier { get; set; } // 0 to 5 stars

    //BUILDING Update related
    public string IfBuildingUpgradeName { get; set; }
    public bool IfBuildingUpgradeAble { get; set; }
    public bool IfBuildingUpgradeUnlock { get; set; }
    public int IfBuildingUpgradeLevel { get; set; }


    //Rooms buisness conditions
    public string IfRoomExist { get; set; }//look for item in stock 
    public int IfRoomExistLevel { get; set; }

    //Stock Conditions
    public string IfItemInStock { get; set; }//look for item in stock 
    public int IfItemInStockQuantity { get; set; }//look for item in stock 

    //-------------
    public List<DialogLine> DialogContainer = new List<DialogLine>();

}


[System.Serializable]
public class DialogLine : ITag
{
    public int ID { get; set; }

    //can hold only one message per Dialog Line
    public string Name { get; set; }
    public string Content { get; set; }
    public string Background { get; set; }
    public string TextColor { get; set; }
    public bool EndConversation { get; set; } //at the end of conversation ends dialog
    //can handle max of 3 characters per Dialog Line
    public string Body1 { get; set; }
    public string Face1 { get; set; }
    public string Transition1 { get; set; }
    public string ColorFilter1 { get; set; }
    public string Animation1 { get; set; }
    public string Position1 { get; set; }

    public string Body2 { get; set; }
    public string Face2 { get; set; }
    public string Transition2 { get; set; }
    public string ColorFilter2 { get; set; }
    public string Animation2 { get; set; }
    public string Position2 { get; set; }

    public string Body3 { get; set; }
    public string Face3 { get; set; }
    public string Transition3 { get; set; }
    public string ColorFilter3 { get; set; }
    public string Animation3 { get; set; }
    public string Position3 { get; set; }

    //can handle max of 4 options per Dialog Line
    public string TextOption1 { get; set; }
    public string OptionFunction1 { get; set; }
    public int OptionValue1 { get; set; }
    public string OptionCondition1 { get; set; }
    public int OptionConditionValue1 { get; set; }

    public string TextOption2 { get; set; }
    public string OptionFunction2 { get; set; }
    public int OptionValue2 { get; set; }
    public string OptionCondition2 { get; set; }
    public int OptionConditionValue2 { get; set; }

    public string TextOption3 { get; set; }
    public string OptionFunction3 { get; set; }
    public int OptionValue3 { get; set; }
    public string OptionCondition3 { get; set; }
    public int OptionConditionValue3 { get; set; }

    public string TextOption4 { get; set; }
    public string OptionFunction4 { get; set; }
    public int OptionValue4 { get; set; }
    public string OptionCondition4 { get; set; }
    public int OptionConditionValue4 { get; set; }


}
