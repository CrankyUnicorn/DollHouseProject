using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CreatorStory
{
    //STUFF TO IMPLEMENT IN HERE
    //ROOMS: Winery, Destillary, Bootlegging, Brewery, Gambling Room, Makeshift Laboratory, Photography Studio, Massage Parlor, Bathhouse, Sauna, Ballroom, Stage, Bar, Fighting Pit, Opiom Den, Cabaret, Brothel, Sex Store
        //ITEMS: TijuanaBible, DirtyPictures, SpicyFlick, CheapWine, RedWine, Champagne, Cider, Beer, PremiumBeer, Moonshine, Bourbon, Whisky, Weed, Cocaine, Opium, StolenGoods, 
        //ACHIVEMENTS: PaidDebt, SyndicateMember, Racing Champion, PeepingTom, DrunkKing, CardShark, SugarDaddy, Gigolo, Romeo, UpstandingCitizen, Kingpin, DrugLord, Fence,
        //BUILDING UPGRADES: PaintFacade, CleanGarden, FixRoof, WallPaper, NeonSign, ChangePipes, SecretRoom, KillPests, MultipleEscapes, SecurityDoor, , ,
        //OTHER FenceGoods, MoneyLaundry, Bootlegging


    public Story newStory = new Story(); //this is the full story once it is created write it as a XML


    public void MakeStory()
    {


        #region//STORY head of data structure
        //newStory.FileName = ;//
        //newStory.TimeStamp = ;//
        //newStory.DisableStrategicGame = ;//
        //newStory.DisableOption = ;//
        newStory.ActTick = 0;//set first day at the begining of the game
        newStory.ActHour = 0;
        newStory.ActDay = 1;
        newStory.WeekdayNames = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        newStory.ActWeekday = newStory.WeekdayNames[0];
        newStory.MonthNames = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        newStory.ActMonth = newStory.MonthNames[0];
        newStory.ActYear = 1920;
        newStory.DayPartNames = new List<string>() { "Morning", "Afternoon", "Evening", "Night" };
        newStory.ActDayPart = newStory.DayPartNames[0];
        newStory.ActMoney = 10;

        //newStory.ActDayIncome = ;//
        //newStory.ActMonthIncome = ;//
        //newStory.ActDayExpenses = ;//
        //newStory.ActMonthExpenses = ;//
        newStory.ActTotalDebt = 0;
        //newStory.DebtNames = new List<string>(){};//
        //newStory.DebtValues = new List<int>(){};//
        //newStory.ActDayClients = ;//
        //newStory.ActMonthClients = ;//
        //newStory.ActDayClientsHappiness = ;//
        //newStory.ActMonthClientsHappiness = ;//
        //newStory.PlayerName = ;//
        //newStory.FamilyName = ;//
        newStory.PlayerCharisma = 0;//
        newStory.PlayerFame = 0;//
        newStory.PlayerFlatter = 0;//
        newStory.PlayerWit = 0;//
        //newStory.PlayerPersuasion = ;//
        //newStory.PlayerBargain = ;//
        //newStory.BirthdayDay = ;//
        //newStory.BirthdayMonth = ;//
        //newStory.Bloodtype = ;//
        //newStory.Zodiac = ;//
        //newStory.IncapacitatedTicks = ;//
        newStory.InventoryTypesList = new List<string> { "PersonalItem", "StockItem" };//
        newStory.InventoryType = newStory.InventoryTypesList[0];//
        //newStory.BuildingInventory //
        newStory.BuildingInventoryType = newStory.InventoryTypesList[0];//
        //newStory.InventoryNames = new List<string>() { newStory.PlayerInventoryName, newStory.BuildingInventoryType };//
        //newStory.BuildingName = ;//
        newStory.BuildingSlotLayout = 0;//pick the building layout configuration
        newStory.BuildingOpen = false;//if building is open to buisness
        newStory.BuildingReputation = 1;//
        newStory.BuildingNotoriety = 1;//
        newStory.BuildingLuxury = 0;//
        newStory.BuildingTier = 1;//
        newStory.RoomWorkTypesList = new List<string> { "None", "Production", "Selling", "Services"};
        newStory.ClientsDynamics = new List<int>() { 2, 5, 10, 2, 3, 6, 11, 3, 4, 7, 12, 4, 7, 12, 17, 5, 8, 18, 28, 17, 13, 26, 35, 28, 11, 18, 13, 6 };
        //newStory.SelectedCharacter;//
        //newStory.SelectedSlotName ;//
        //newStory.SelectedSlotIndex;//
        //newStory.AvaibleCharacters = new List<string>() { };//

        #endregion

        #region//CHARACTERS------------------------------------------------------------------------

        //creates first character 
        Character CharacterVessel = new Character();

        CharacterVessel.FirstName = "Brackey";
        CharacterVessel.NickName = "Brackey";

        CharacterVessel.Unlock = true;
        CharacterVessel.Able = true;

        CharacterVessel.Stamina = 100;

        CharacterVessel.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        CharacterVessel.ModifiersValues = new List<float>() { 1f, 1f, 1f };
        newStory.CharactersContainer.Add(CharacterVessel);
        #endregion

        #region//SLOTS LAYOUT------------------------------------------------------------------------

        //creates building configuration
        SlotLayout HouseLayout = new SlotLayout();

        HouseLayout.SlotLayoutId = 0;
        HouseLayout.SlotLayoutName = "Small Manson";
        HouseLayout.SlotLayoutMaxSlots = 12;
        HouseLayout.SlotLayoutSlotX = new List<int>() { };
        HouseLayout.SlotLayoutSlotY = new List<int>() { };
        // HouseLayout.ConfigurationInBG = "";
        // HouseLayout.ConfigurationOutBG = "";

        newStory.SlotLayoutTemplate.Add(HouseLayout);

        HouseLayout = new SlotLayout();

        HouseLayout.SlotLayoutId = 1;
        HouseLayout.SlotLayoutName = "Medium Manson";
        HouseLayout.SlotLayoutMaxSlots = 18;
        HouseLayout.SlotLayoutSlotX = new List<int>() { };
        HouseLayout.SlotLayoutSlotY = new List<int>() { };
        // HouseLayout.ConfigurationInBG = "";
        // HouseLayout.ConfigurationOutBG = "";

        newStory.SlotLayoutTemplate.Add(HouseLayout);
        HouseLayout = new SlotLayout();
        HouseLayout.SlotLayoutId = 2;
        HouseLayout.SlotLayoutName = "Large Manson";
        HouseLayout.SlotLayoutMaxSlots = 24;
        HouseLayout.SlotLayoutSlotX = new List<int>() { };
        HouseLayout.SlotLayoutSlotY = new List<int>() { };
        // HouseLayout.ConfigurationInBG = "";
        // HouseLayout.ConfigurationOutBG = "";
        newStory.SlotLayoutTemplate.Add(HouseLayout);
        #endregion

        #region//ROOMS templantes------------------------------------------------------------------------
        Room RoomNew = new Room();//create a room 

        RoomNew.Name = "Outside";
        RoomNew.Description = "Elsewhere";
        RoomNew.SlotInImage = "None";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = false;
        RoomNew.ConstructionCost = 0;
        RoomNew.DeconstructionCost = 0;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 0;
        RoomNew.RepairLevel = 100f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = true;
        RoomNew.Able = true;
        RoomNew.Locked = false;
        RoomNew.Empty = false;
        RoomNew.Tier = 0;
        //RoomNew.InventoryName;
        RoomNew.WorkersCapacity = 20;
        //RoomNew.WorkersList;
        //RoomNew.ProductionItems;
        RoomNew.WorkType = newStory.RoomWorkTypesList[0];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };
        newStory.RoomsTemplates.Add(RoomNew);


        RoomNew = new Room();//create a room 

        RoomNew.Name = "Locked Room";
        RoomNew.Description = "Seams that this door is shut tight, I wander what is in the other side";
        RoomNew.SlotInImage = "None";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = true;
        RoomNew.ConstructionCost = 0;
        RoomNew.DeconstructionCost = 0;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 0;
        RoomNew.RepairLevel = 100f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = false;
        RoomNew.Able = false;
        RoomNew.Locked = true;
        RoomNew.Empty = true;
        RoomNew.Tier = 0;
        //RoomNew.RoomInventoryName;
        RoomNew.WorkersCapacity = 0;
        //RoomNew.WorkersList;

        //RoomNew.RoomProductionItems;
        RoomNew.WorkType = newStory.RoomWorkTypesList[0];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };
        newStory.RoomsTemplates.Add(RoomNew);


        RoomNew = new Room();//create a room 

        RoomNew.Name = "Empty Room";
        RoomNew.Description = "Just a dusty room full of spider webs. Boy sis is going to have a lot of work cleaning this up.";
        RoomNew.SlotInImage = "emptyroom";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = true;
        RoomNew.ConstructionCost = 100;
        RoomNew.DeconstructionCost = 0;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 1;
        RoomNew.RepairLevel = 82f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = true;
        RoomNew.Able = false;
        RoomNew.Locked = false;
        RoomNew.Empty = true;
        RoomNew.Tier = 0;
        //RoomNew.RoomInventoryName;
        RoomNew.WorkersCapacity = 3;
        //RoomNew.WorkersList;
        //RoomNew.RoomProductionItems;
        RoomNew.WorkType = newStory.RoomWorkTypesList[0];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };

        newStory.RoomsTemplates.Add(RoomNew);


        RoomNew = new Room();//create a room 

        RoomNew.Name = "Office";
        RoomNew.Description = "It's a simple office. Nothing special but slightful less gloomy then the rest of the house.";
        RoomNew.SlotInImage = "office";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = false;
        RoomNew.ConstructionCost = 100;
        RoomNew.DeconstructionCost = 50;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 12;
        RoomNew.RepairLevel = 82f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = true;
        RoomNew.Able = true;
        RoomNew.Locked = false;
        RoomNew.Empty = false;
        RoomNew.Tier = 0;
        //RoomNew.RoomInventoryName;
        RoomNew.WorkersCapacity = 1;
        //RoomNew.WorkersList;
        //RoomNew.RoomProductionItems;
        RoomNew.WorkType = newStory.RoomWorkTypesList[3];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };

        newStory.RoomsTemplates.Add(RoomNew);


        RoomNew = new Room();//create a room 

        RoomNew.Name = "Destillary";
        RoomNew.Description = "The heart of this operation. I'm getting drunk just entering here";
        RoomNew.SlotInImage = "destillary";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = true;
        RoomNew.ConstructionCost = 500;
        RoomNew.DeconstructionCost = 250;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 2;
        RoomNew.RepairLevel = 81f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = true;
        RoomNew.Able = true;
        RoomNew.Locked = false;
        RoomNew.Empty = false;
        RoomNew.Tier = 1;
        //RoomNew.InventoryName;
        RoomNew.WorkersCapacity = 3;
        //RoomNew.WorkersList;
        RoomNew.ProductionItems.Add("Moonshine");
        RoomNew.WorkType = newStory.RoomWorkTypesList[1];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };

        newStory.RoomsTemplates.Add(RoomNew);


        RoomNew = new Room();//create a room 

        RoomNew.Name = "Winery";
        RoomNew.Description = "For the blood of Christ just squize those grapes.";
        RoomNew.SlotInImage = "None";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = true;
        RoomNew.ConstructionCost = 600;
        RoomNew.DeconstructionCost = 300;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 5;
        RoomNew.RepairLevel = 75f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = true;
        RoomNew.Able = true;
        RoomNew.Locked = false;
        RoomNew.Empty = false;
        RoomNew.Tier = 1;
        //RoomNew.InventoryName;
        RoomNew.WorkersCapacity = 3;
        //RoomNew.WorkersList;
        RoomNew.ProductionItems.Add("Cheap Wine");
        RoomNew.WorkType = newStory.RoomWorkTypesList[1];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };

        newStory.RoomsTemplates.Add(RoomNew);


        RoomNew = new Room();//create a room 

        RoomNew.Name = "Speak Easy";
        RoomNew.Description = "Everyone enjoys a good cup of tea.";
        RoomNew.SlotInImage = "speakeasy";
        RoomNew.SlotOutImage = "None";
        RoomNew.Icon = "None";
        RoomNew.Removable = true;
        RoomNew.ConstructionCost = 800;
        RoomNew.DeconstructionCost = 400;
        RoomNew.RepairOrder = false;
        RoomNew.RepairCost = 7;
        RoomNew.RepairLevel = 91f;
        RoomNew.HouseSlot = 0;
        RoomNew.Unlock = true;
        RoomNew.Able = true;
        RoomNew.Tier = 1;
        //RoomNew.InventoryName;
        RoomNew.WorkersCapacity = 3;
        //RoomNew.WorkersList;
        RoomNew.WorkType = newStory.RoomWorkTypesList[2];
        RoomNew.Modifiers = new List<string>() { "Reputation", "Notoriety", "Luxury" };
        RoomNew.ModifiersValues = new List<float>() { 1f, 1f, 1f };

        newStory.RoomsTemplates.Add(RoomNew);
        #endregion

        #region//SLOTS populate------------------------------------------------------------------------

        //populate house slots with base rooms
        for (int i = 0; i < newStory.SlotLayoutTemplate[newStory.BuildingSlotLayout].SlotLayoutMaxSlots; i++)
        {

            RoomNew = newStory.RoomsTemplates[1].ShallowCopy();
            newStory.SlotsContainer.Add(RoomNew);
           
        }

        //the next operation can also be done by name or id number but for practical resons I did this.
        newStory.SlotsContainer[0] = (newStory.RoomsTemplates[0]);//inserts OUTSIDE in slot 0
        newStory.SlotsContainer[4] = (newStory.RoomsTemplates[3]);//inserts OFFICE in slot 1
        newStory.SlotsContainer[1] = (newStory.RoomsTemplates[6]);//inserts OFFICE in slot 1
        newStory.SlotsContainer[2] = (newStory.RoomsTemplates[4]);//inserts DESTILLERY in slot 2
        newStory.SlotsContainer[3] = (newStory.RoomsTemplates[5]);//inserts WINERY in slot 3
        newStory.SlotsContainer[5] = (newStory.RoomsTemplates[2]);//inserts EMPTY ROOM in slot 4

        //updates info on rooms in the container, applies new index number to propriaty "HouseSlot" value
        for (int d = 0; d < newStory.SlotsContainer.Count; d++)
        {
            newStory.SlotsContainer[d].HouseSlot = d;
        }
        #endregion

        #region//BUILDING UPGRADES MotherFuckers!------------------------------------------------------------------------

        BuildingUpgrade buildingUpgradeVessel = new BuildingUpgrade();//creates first building upgrade 

        buildingUpgradeVessel.Name = "Door Holder";
        buildingUpgradeVessel.Description = "A big rock holding the door. What did you expected, a fucking Hordor?";
        buildingUpgradeVessel.Unlock = true;
        //buildingUpgradeVessel.BuildingUpgradePrice = ;
        //buildingUpgradeVessel.BuildingUpgradeReputation = ;
        //buildingUpgradeVessel.BuildingUpgradeNotoriety = ;
        //buildingUpgradeVessel.BuildingUpgradeLuxury = ;
        //buildingUpgradeVessel.BuildingUpgradeTier = ;

        newStory.BuildingUpgradeContainer.Add(buildingUpgradeVessel);
        #endregion

        #region//ITEMS------------------------------------------------------------------------

        //creates items templates
        Item ItemVessel = new Item();//creates item template


        ItemVessel.Name = "Lint Ball";
        ItemVessel.Description = "It's a simple lint ball. Nothing special about it";
        ItemVessel.Unlock = true;
        ItemVessel.Able = true;
        ItemVessel.InventoryType = newStory.InventoryType;
        ItemVessel.Quantity = 1;
        ItemVessel.BuyPrice = 0;
        ItemVessel.SellPrice = 0;

        newStory.ItemsTemplates.Add(ItemVessel);



        ItemVessel = new Item();//creates item template


        ItemVessel.Name = "Empty Bottle";
        ItemVessel.Description = "Yeah! Perfect to be fill up with booze.";
        ItemVessel.Unlock = true;
        ItemVessel.Able = true;
        ItemVessel.InventoryType = newStory.BuildingInventoryType;
        ItemVessel.Quantity = 1;
        ItemVessel.BuyPrice = 0;
        ItemVessel.SellPrice = 0;

        newStory.ItemsTemplates.Add(ItemVessel);


        ItemVessel = new Item();//creates item template


        ItemVessel.Name = "Moonshine";
        ItemVessel.Description = "Best way to wake up in the morning with an hangover and a fresh tattoo.";
        ItemVessel.Unlock = true;
        ItemVessel.Able = true;
        ItemVessel.InventoryType = newStory.BuildingInventoryType;
        ItemVessel.Quantity = 1;
        ItemVessel.BuyPrice = 0;
        ItemVessel.SellPrice = 3;
        ItemVessel.ProductionBatch = 10;
        ItemVessel.ProductionCost = 1;
        ItemVessel.RisesHappines = 3;

        newStory.ItemsTemplates.Add(ItemVessel);


        ItemVessel = new Item();//creates item template


        ItemVessel.Name = "Cheap Wine";
        ItemVessel.Description = "Was good as the price.";
        ItemVessel.Unlock = true;
        ItemVessel.Able = true;
        ItemVessel.InventoryType = newStory.BuildingInventoryType;
        ItemVessel.Quantity = 1;
        ItemVessel.BuyPrice = 0;
        ItemVessel.SellPrice = 5;
        ItemVessel.ProductionBatch = 10;
        ItemVessel.ProductionCost = 2;
        ItemVessel.RisesHappines = 4;

        newStory.ItemsTemplates.Add(ItemVessel);


        //creates items templates
        ItemVessel = new Item();//creates item template


        ItemVessel.Name = "Key";
        ItemVessel.Description = "Looks like a door key";
        ItemVessel.Unlock = true;
        ItemVessel.Able = true;
        ItemVessel.InventoryType = newStory.InventoryType;
        ItemVessel.Quantity = 1;
        ItemVessel.BuyPrice = 0;
        ItemVessel.SellPrice = 0;

        newStory.ItemsTemplates.Add(ItemVessel);

        #endregion

        #region//ACHIVEMENTS------------------------------------------------------------------------
        Achivement AchivementVessel = new Achivement();

        AchivementVessel.Name = "Loud mouth";//
        AchivementVessel.Description = "You don't know when to shut the fuck up. ";//
        AchivementVessel.Icon = "";//
        AchivementVessel.Unlock = true;//
        AchivementVessel.Able = true;//
        AchivementVessel.Modifiers = new List<string>() { };//
        AchivementVessel.ModifiersValues = new List<float> { };//

        newStory.AchivementsTemplates.Add(AchivementVessel);


        AchivementVessel = new Achivement();

        AchivementVessel.Name = "Cocky";//
        AchivementVessel.Description = "You're too smart for your own good.";//
        AchivementVessel.Icon = "";//
        AchivementVessel.Unlock = true;//
        AchivementVessel.Able = true;//
        AchivementVessel.Modifiers = new List<string>() { };//
        AchivementVessel.ModifiersValues = new List<float> { };//


        newStory.AchivementsTemplates.Add(AchivementVessel);


        AchivementVessel = new Achivement();

        AchivementVessel.Name = "Smart Lazy Ass";//
        AchivementVessel.Description = "You manipulate others to do your work.";//
        AchivementVessel.Icon = "";//
        AchivementVessel.Unlock = true;//
        AchivementVessel.Able = true;//
        AchivementVessel.Modifiers = new List<string>() { };//
        AchivementVessel.ModifiersValues = new List<float> { };//

        newStory.AchivementsTemplates.Add(AchivementVessel);


        //ACHIVEMENTS populate------------------------------------------------------------------------

        newStory.AchivementsContainer.Add(newStory.AchivementsTemplates[0]);
        newStory.AchivementsContainer.Add(newStory.AchivementsTemplates[1]);
        newStory.AchivementsContainer.Add(newStory.AchivementsTemplates[2]);
        #endregion

        #region//CLIENTS------------------------------------------------------------------------

        Client ClientVessel = new Client();

        ClientVessel.NickName = "Lazy Drunk";//
        ClientVessel.Description = "Some lazy ass drunk. 'Hey pal! Don't you dare fall at sleep in here this ain't your home.' ";//
        ClientVessel.RequiredReputation = 0;//
        ClientVessel.RequiredNotoriety = 0;//
        ClientVessel.RequiredLuxury = 0;//
        ClientVessel.RequiredTier = 0;//
        ClientVessel.Schedual = new List<string>() { newStory.DayPartNames[0], newStory.DayPartNames[1], newStory.DayPartNames[2], newStory.DayPartNames[3], };//
        ClientVessel.WishesRooms = new List<string>();//
        ClientVessel.WishesProducts = new List<string>() { "Moonshine" };// and free booze XD
        ClientVessel.MoneyStartMin = 5;//
        ClientVessel.MoneyStartMax = 25;//
        ClientVessel.Money =  Mathf.CeilToInt(Random.Range(ClientVessel.MoneyStartMin, ClientVessel.MoneyStartMax));//
        ClientVessel.ConsuptionCycle = 5;//
        ClientVessel.ConsuptionDelay = 3;//
        ClientVessel.ConsuptionCounter = 1;//
        ClientVessel.Happiness = 50;//
        ClientVessel.Resilience = 5;//

        newStory.ClientsTemplates.Add(ClientVessel);

        ClientVessel = new Client();

        ClientVessel.NickName = "Old Pro Skirt";//
        ClientVessel.Description = "Some old prostitute. 'For those who ain't picky about their women anything will do.'";//
        ClientVessel.RequiredReputation = 0;//
        ClientVessel.RequiredNotoriety = 1;//
        ClientVessel.RequiredLuxury = 0;//
        ClientVessel.RequiredTier = 0;//
        ClientVessel.Schedual = new List<string>() { newStory.DayPartNames[0], newStory.DayPartNames[1], newStory.DayPartNames[2], newStory.DayPartNames[3], };//
        ClientVessel.WishesRooms = new List<string>();//
        ClientVessel.WishesProducts = new List<string>() { "Cheap Wine" };// and free booze XD
        ClientVessel.MoneyStartMin = 5;//
        ClientVessel.MoneyStartMax = 25;//
        ClientVessel.Money = Mathf.CeilToInt(Random.Range(ClientVessel.MoneyStartMin, ClientVessel.MoneyStartMax));//
        ClientVessel.ConsuptionCycle = 2;//
        ClientVessel.ConsuptionDelay = 1;//
        ClientVessel.ConsuptionCounter = 1;//
        ClientVessel.Happiness = 50;//
        ClientVessel.Resilience = 1;//

        newStory.ClientsTemplates.Add(ClientVessel);

        ClientVessel = new Client();

        ClientVessel.NickName = "Skid Rogue";//
        ClientVessel.Description = "A suspicious bum. 'Don't try anything funny pal or you get beefed.'";//
        ClientVessel.RequiredReputation = 0;//
        ClientVessel.RequiredNotoriety = 0;//
        ClientVessel.RequiredLuxury = 0;//
        ClientVessel.RequiredTier = 0;//
        ClientVessel.Schedual = new List<string>() { newStory.DayPartNames[0], newStory.DayPartNames[1], newStory.DayPartNames[2], newStory.DayPartNames[3], };//
        ClientVessel.WishesRooms = new List<string>();//
        ClientVessel.WishesProducts = new List<string>() { "Cheap Wine" };// and free booze XD
        ClientVessel.MoneyStartMin = 3;//
        ClientVessel.MoneyStartMax = 5;//
        ClientVessel.Money = Mathf.CeilToInt(Random.Range(ClientVessel.MoneyStartMin, ClientVessel.MoneyStartMax));//
        ClientVessel.ConsuptionCycle = 2;//
        ClientVessel.ConsuptionDelay = 5;//
        ClientVessel.ConsuptionCounter = 5;//
        ClientVessel.Happiness = 50;//
        ClientVessel.Resilience = 3;//

        newStory.ClientsTemplates.Add(ClientVessel);

        ClientVessel = new Client();

        ClientVessel.NickName = "Tough Guy";//
        ClientVessel.Description = "Low life criminal. 'Some guy from the streets looking for some poor bastard to mug'";//
        ClientVessel.RequiredReputation = 0;//
        ClientVessel.RequiredNotoriety = 0;//
        ClientVessel.RequiredLuxury = 0;//
        ClientVessel.RequiredTier = 0;//
        ClientVessel.Schedual = new List<string>() { newStory.DayPartNames[0], newStory.DayPartNames[1], newStory.DayPartNames[2], newStory.DayPartNames[3], };//
        ClientVessel.WishesRooms = new List<string>();//
        ClientVessel.WishesProducts = new List<string>() { "Beer" };// and free booze XD
        ClientVessel.MoneyStartMin = 5;//
        ClientVessel.MoneyStartMax = 20;//
        ClientVessel.Money = Mathf.CeilToInt(Random.Range(ClientVessel.MoneyStartMin, ClientVessel.MoneyStartMax));//
        ClientVessel.ConsuptionCycle = 4;//
        ClientVessel.ConsuptionDelay = 5;//
        ClientVessel.ConsuptionCounter = 5;//
        ClientVessel.Happiness = 50;//
        ClientVessel.Resilience = 2;//

        newStory.ClientsTemplates.Add(ClientVessel);

        ClientVessel = new Client();

        ClientVessel.NickName = "Crazy";//
        ClientVessel.Description = "Bat shit crazy spook. 'I bet I could sell this guy on a pot of piss ah ah ah.'";//
        ClientVessel.RequiredReputation = 0;//
        ClientVessel.RequiredNotoriety = 0;//
        ClientVessel.RequiredLuxury = 0;//
        ClientVessel.RequiredTier = 0;//
        ClientVessel.Schedual = new List<string>() { newStory.DayPartNames[0], newStory.DayPartNames[1], newStory.DayPartNames[2], newStory.DayPartNames[3], };//
        ClientVessel.WishesRooms = new List<string>();//
        ClientVessel.WishesProducts = new List<string>() { "Beer" };// and free booze XD
        ClientVessel.MoneyStartMin = 5;//
        ClientVessel.MoneyStartMax = 50;//
        ClientVessel.Money = Mathf.CeilToInt(Random.Range(ClientVessel.MoneyStartMin, ClientVessel.MoneyStartMax));//
        ClientVessel.ConsuptionCycle = 2;//
        ClientVessel.ConsuptionDelay = 1;//
        ClientVessel.ConsuptionCounter = 1;//
        ClientVessel.Happiness = 50;//
        ClientVessel.Resilience = 7;//

        newStory.ClientsTemplates.Add(ClientVessel);

        ClientVessel = new Client();

        ClientVessel.NickName = "Drunk Sailor";//
        ClientVessel.Description = "This guy can barelly stand. 'Hey ther matty, what can I serve you?'";//
        ClientVessel.RequiredReputation = 0;//
        ClientVessel.RequiredNotoriety = 0;//
        ClientVessel.RequiredLuxury = 0;//
        ClientVessel.RequiredTier = 0;//
        ClientVessel.Schedual = new List<string>() { newStory.DayPartNames[0], newStory.DayPartNames[1], newStory.DayPartNames[2], newStory.DayPartNames[3], };//
        ClientVessel.WishesRooms = new List<string>();//
        ClientVessel.WishesProducts = new List<string>() { "Moonshine" };// and free booze XD
        ClientVessel.MoneyStartMin = 5;//
        ClientVessel.MoneyStartMax = 15;//
        ClientVessel.Money = Mathf.CeilToInt(Random.Range(ClientVessel.MoneyStartMin, ClientVessel.MoneyStartMax));//
        ClientVessel.ConsuptionCycle = 3;//
        ClientVessel.ConsuptionDelay = 1;//
        ClientVessel.ConsuptionCounter = 1;//
        ClientVessel.Happiness = 50;//
        ClientVessel.Resilience = 2;//

        newStory.ClientsTemplates.Add(ClientVessel);

        //CLIENTS populate------------------------------------------------------------------------

        newStory.ClientsContainer.Add(newStory.ClientsTemplates[0]);
        #endregion

        #region//NPCs------------------------------------------------------------------------

        NPC NPCVessel = new NPC();


        NPCVessel.FirstName = "Officer";//
        NPCVessel.LastName = "Winer";//
        NPCVessel.Description = "A pestering fellow with a bad habbit to barge in uninvited. Luckly he's also a drunk.";//
        NPCVessel.Unlock = true;//
        NPCVessel.Able = true;//
        NPCVessel.Icon = "";//
        NPCVessel.Avatar = "";//
        //NPCVessel.NPCBirthdayDay = 0;//
        //NPCVessel.NPCBirthdayMonth = "";//
        NPCVessel.Relationship = 0;//
        NPCVessel.FavoriteGifts = new List<string> { "Bribe" };//
        NPCVessel.PlaceInMap = "Street";//
      
        NPCVessel.ShowAtDays = new List<string>() { "Friday", "Monday" };//

        newStory.NPCsContainer.Add(NPCVessel);
        #endregion

        #region//DIALOGS------------------------------------------------------------------------

        Dialog DialogVessel = new Dialog();//creates first dialog vessel

        DialogVessel.ID = 1;
        //DialogVessel.DialogDescription = ;
        //DialogVessel.LockedDialog = ;
        //DialogVessel.TypeEvent = ;
        DialogVessel.IfTick = 1;//sets the condition to play this dialog at the first game tick
        //DialogVessel.IfHour = ;
        //DialogVessel.IfDayPart = ;
        //DialogVessel.IfDay = ;
        //DialogVessel.IfWeekDay = ;
        //DialogVessel.IfMonth = ;
        //DialogVessel.IfYear = ;
        //DialogVessel.ShowTimes = ;
        //DialogVessel.ShowTimesX = ;
        //DialogVessel.TimesShown = ;
        //DialogVessel.SetAchivement = ;
        //DialogVessel.IfAchivement1 = ;
        //DialogVessel.IfAchivement2 = ;
        //DialogVessel.IfAchivement3 = ;
        //DialogVessel.IfCharisma = ;
        //DialogVessel.IfFame = ;
        //DialogVessel.IfFlatter = ;
        //DialogVessel.IfWit = ;
        //DialogVessel.IfPersuasion = ;
        //DialogVessel.IfBargain = ;
        //DialogVessel.IfBirthdayDay = ;
        //DialogVessel.IfBloodtype = ;
        //DialogVessel.IfZodiac = ;
        //DialogVessel.IfCharacterName = ;
        //DialogVessel.IfCharacterLastName = ;
        //DialogVessel.IfCharacterUnlock = ;
        //DialogVessel.IfCharacterAble = ;
        //DialogVessel.IfCharacterBirthdayDay = ;
        //DialogVessel.IfCharacterRelationship = ;
        //DialogVessel.IfCharacterIntimacy = ;
        //DialogVessel.IfCharacterLoyalty = ;
        //DialogVessel.IfCharacterWorkPlace = ;
        //DialogVessel.IfCharacterFavoriteJob = ;
        //DialogVessel.IfCharacterNormalJob = ;
        //DialogVessel.IfCharacterHateJob = ;
        //DialogVessel.IfFavoriteGift = ;
        //DialogVessel.IfCharacterStamina = ;
        //DialogVessel.IfCharacterExperience = ;
        //DialogVessel.IfCharacterLevel = ;
        //DialogVessel.IfCharacterProficiency = ;
        //DialogVessel.IfCharacterResting = ;
        //DialogVessel.IfExtra1Name = ;
        //DialogVessel.IfExtra1LastName = ;
        //DialogVessel.IfExtra1Unlock = ;
        //DialogVessel.IfExtra1Able = ;
        //DialogVessel.IfExtra2Name = ;
        //DialogVessel.IfExtra2LastName = ;
        //DialogVessel.IfExtra2Unlock = ;
        //DialogVessel.IfExtra2Able = ;
        //DialogVessel.IfMoneyUnder = ;
        //DialogVessel.IfMoneyOver = ;
        //DialogVessel.IfDebtUnder = ;
        //DialogVessel.IfDebtOver = ;
        //DialogVessel.IfBuildingReputation = ;
        //DialogVessel.IfBuildingNotoriety = ;
        //DialogVessel.IfBuildingTier = ;
        //DialogVessel.IfBuildingUpgradeName = ;
        //DialogVessel.IfBuildingUpgradeAble = ;
        //DialogVessel.IfBuildingUpgradeUnlock = ;
        //DialogVessel.IfBuildingUpgradeLevel = ;
        //DialogVessel.IfRoomExist = ;
        //DialogVessel.IfRoomExistLevel = ;
        //DialogVessel.IfItemInStock = ;
        //DialogVessel.IfItemInStockQuantity = ;
        newStory.DialogsContainer.Add(DialogVessel); //add first dialog to story

        //DIALOG LINES------------------------------------------------------------------------

        DialogLine DialogLineVesel = new DialogLine();
        DialogLineVesel.Name = "Brackey";
        DialogLineVesel.Content = "Hello and welcome. \nReady to start creating your own story? '_'";
        DialogLineVesel.Background="TestBG";
        //DialogLineVesel.TextColor=;
        //DialogLineVesel.EndConversation=;
        //DialogLineVesel.Body1=;
        //DialogLineVesel.Face1=;
        //DialogLineVesel.Transition1=;
        //DialogLineVesel.ColorFilter1=;
        //DialogLineVesel.Animation1=;
        //DialogLineVesel.Position1=;
        //DialogLineVesel.Body2=;
        //DialogLineVesel.Face2=;
        //DialogLineVesel.Transition2=;
        //DialogLineVesel.ColorFilter2=;
        //DialogLineVesel.Animation2=;
        //DialogLineVesel.Position2=;
        DialogLineVesel.Body3="char";
        //DialogLineVesel.Face3=;
        //DialogLineVesel.Transition3=;
        //DialogLineVesel.ColorFilter3=;
        //DialogLineVesel.Animation3=;
        //DialogLineVesel.Position3=;
        //DialogLineVesel.TextOption1=;
        //DialogLineVesel.OptionFunction1=;
        //DialogLineVesel.OptionValue1=;
        //DialogLineVesel.OptionCondition1=;
        //DialogLineVesel.OptionConditionValue1=;
        //DialogLineVesel.TextOption2=;
        //DialogLineVesel.OptionFunction2=;
        //DialogLineVesel.OptionValue2=;
        //DialogLineVesel.OptionCondition2=;
        //DialogLineVesel.OptionConditionValue2=;
        //DialogLineVesel.TextOption3=;
        //DialogLineVesel.OptionFunction3=;
        //DialogLineVesel.OptionValue3=;
        //DialogLineVesel.OptionCondition3=;
        //DialogLineVesel.OptionConditionValue3=;
        //DialogLineVesel.TextOption4=;
        //DialogLineVesel.OptionFunction4=;
        //DialogLineVesel.OptionValue4=;
        //DialogLineVesel.OptionCondition4=;
        //DialogLineVesel.OptionConditionValue4=;
        newStory.DialogsContainer[0].DialogContainer.Add(DialogLineVesel);

        
        DialogLineVesel = new DialogLine();
        DialogLineVesel.Name = "Brackey";
        DialogLineVesel.Content = "Are you up to it? >.<";
        DialogLineVesel.Background = "TestBG";
        //DialogLineVesel.TextColor=;
        //DialogLineVesel.EndConversation=;
        //DialogLineVesel.Body1=;
        //DialogLineVesel.Face1=;
        //DialogLineVesel.Transition1=;
        //DialogLineVesel.ColorFilter1=;
        //DialogLineVesel.Animation1=;
        //DialogLineVesel.Position1=;
        //DialogLineVesel.Body2=;
        //DialogLineVesel.Face2=;
        //DialogLineVesel.Transition2=;
        //DialogLineVesel.ColorFilter2=;
        //DialogLineVesel.Animation2=;
        //DialogLineVesel.Position2=;
        DialogLineVesel.Body3 = "char";
        //DialogLineVesel.Face3=;
        //DialogLineVesel.Transition3=;
        //DialogLineVesel.ColorFilter3=;
        //DialogLineVesel.Animation3=;
        //DialogLineVesel.Position3=;
        //DialogLineVesel.TextOption1=;
        //DialogLineVesel.OptionFunction1=;
        //DialogLineVesel.OptionValue1=;
        //DialogLineVesel.OptionCondition1=;
        //DialogLineVesel.OptionConditionValue1=;
        //DialogLineVesel.TextOption2=;
        //DialogLineVesel.OptionFunction2=;
        //DialogLineVesel.OptionValue2=;
        //DialogLineVesel.OptionCondition2=;
        //DialogLineVesel.OptionConditionValue2=;
        //DialogLineVesel.TextOption3=;
        //DialogLineVesel.OptionFunction3=;
        //DialogLineVesel.OptionValue3=;
        //DialogLineVesel.OptionCondition3=;
        //DialogLineVesel.OptionConditionValue3=;
        //DialogLineVesel.TextOption4=;
        //DialogLineVesel.OptionFunction4=;
        //DialogLineVesel.OptionValue4=;
        //DialogLineVesel.OptionCondition4=;
        //DialogLineVesel.OptionConditionValue4=;
        newStory.DialogsContainer[0].DialogContainer.Add(DialogLineVesel);


        DialogLineVesel = new DialogLine();
        DialogLineVesel.Name = "Brackey";
        DialogLineVesel.Content = "Of course you are, just be careful with typos -_-'";
        DialogLineVesel.Background = "TestBG";
        //DialogLineVesel.TextColor=;
        //DialogLineVesel.EndConversation=;
        //DialogLineVesel.Body1=;
        //DialogLineVesel.Face1=;
        //DialogLineVesel.Transition1=;
        //DialogLineVesel.ColorFilter1=;
        //DialogLineVesel.Animation1=;
        //DialogLineVesel.Position1=;
        //DialogLineVesel.Body2=;
        //DialogLineVesel.Face2=;
        //DialogLineVesel.Transition2=;
        //DialogLineVesel.ColorFilter2=;
        //DialogLineVesel.Animation2=;
        //DialogLineVesel.Position2=;
        DialogLineVesel.Body3 = "char";
        //DialogLineVesel.Face3=;
        //DialogLineVesel.Transition3=;
        //DialogLineVesel.ColorFilter3=;
        //DialogLineVesel.Animation3=;
        //DialogLineVesel.Position3=;
        //DialogLineVesel.TextOption1=;
        //DialogLineVesel.OptionFunction1=;
        //DialogLineVesel.OptionValue1=;
        //DialogLineVesel.OptionCondition1=;
        //DialogLineVesel.OptionConditionValue1=;
        //DialogLineVesel.TextOption2=;
        //DialogLineVesel.OptionFunction2=;
        //DialogLineVesel.OptionValue2=;
        //DialogLineVesel.OptionCondition2=;
        //DialogLineVesel.OptionConditionValue2=;
        //DialogLineVesel.TextOption3=;
        //DialogLineVesel.OptionFunction3=;
        //DialogLineVesel.OptionValue3=;
        //DialogLineVesel.OptionCondition3=;
        //DialogLineVesel.OptionConditionValue3=;
        //DialogLineVesel.TextOption4=;
        //DialogLineVesel.OptionFunction4=;
        //DialogLineVesel.OptionValue4=;
        //DialogLineVesel.OptionCondition4=;
        //DialogLineVesel.OptionConditionValue4=;
        newStory.DialogsContainer[0].DialogContainer.Add(DialogLineVesel);
        #endregion

        #region//INVENTORY------------------------------------------------------------------------

       
        //CHANGE THIS! Remove this or replace it to set inicial items
        //INITIAL ITEMS ALLOCATION
        
            foreach (Item item in newStory.ItemsTemplates)
            {
                    if (item.InventoryType == newStory.InventoryType)
                    {
                         newStory.Inventory.Add(item);
                    }
            }

        #endregion


        #region//ID------------------------------------------------------------------------
        int IdEvery = 0;
        foreach (var item in newStory.RoomsTemplates)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.SlotsContainer)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.BuildingUpgradeContainer)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.ItemsTemplates)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.AchivementsTemplates)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.AchivementsContainer)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.BuildingInventory)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.Inventory)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.CharactersContainer)
        {
            item.ID = IdEvery;
            IdEvery++;
            foreach (var itemB in item.Inventory)
            {
                itemB.ID = IdEvery;
                IdEvery++;
            }
        }
        foreach (var item in newStory.NPCsContainer)
        {
            item.ID = IdEvery;
            IdEvery++;
            foreach (var itemB in item.Inventory)
            {
                itemB.ID = IdEvery;
                IdEvery++;
            }
        }
        foreach (var item in newStory.ModifiersTemplates)
        {
            item.ID = IdEvery;
            IdEvery++;
        }
        foreach (var item in newStory.ModifiersContainer)
        {
            item.ID = IdEvery;
            IdEvery++;
        }

        int IdDialogs = 0;
        int IdDialogLine = 0;
        foreach (Dialog dialogs in newStory.DialogsContainer)
        {
            dialogs.ID = IdDialogs;
            IdDialogs++;
            foreach (DialogLine dialogLine in dialogs.DialogContainer)
            {
                dialogs.ID = IdDialogLine;
                IdDialogLine++;
            }
        }
        #endregion

    }

}

