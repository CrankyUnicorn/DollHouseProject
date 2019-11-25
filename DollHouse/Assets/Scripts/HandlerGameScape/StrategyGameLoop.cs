using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyGameLoop
{

    public int actIncome;
    public int actExpenses;
    public int actSells;
    public int actClients;
    public int possibleClients;
    public int dayClients;
    public int actClientsHappiness;
    public int dayClientsHappiness;


    private List<int> roomsWorking;
    private List<int> charsWorking;

    private int sellingMultiplier;//quantity of rooms able to sell stuff


    //MAIN METHOD
    public void StartLoop()
    {
        //VALUES RESET
        sellingMultiplier = 0;


        //METHODS SEQUENCE
       
        CheckRooms();

        CheckWorkers();

        StartRepairs();

        StartWorking();//work as PRODUCTION and other SERVICES like SELLING AND SHOWBUISNESS are under here

        UpdateCharactersStatus();//check for exaustion on every character

        CalculateClients();

        SellToClients();

        UpdateClientsStatus();

        TickBalance();

        ExecuteDailyBalance();

        ExecuteMonthlyBalance();

        PlayerStatus();//update players status

        BuildingStatus();//upgrade building status

        
    }

    //----------------------------------------------------------------------------

  
    //METHOD CHECK ROOMS
    private void CheckRooms()
    {
        roomsWorking = new List<int>();
        for (int i = 0; i < ContainerStory.ins.actStory.SlotsContainer.Count; i++)
        {
            if (ContainerStory.ins.actStory.SlotsContainer[i].Unlock == true)
            {
                if (ContainerStory.ins.actStory.SlotsContainer[i].Able == true)
                {
                    if (ContainerStory.ins.actStory.SlotsContainer[i].WorkersList.Count!=0)
                    {
                        roomsWorking.Add(i);

                    }
                }
            }

        }


    }


    //METHOD CHECK WORKERS
    private void CheckWorkers()
    {
        charsWorking = new List<int>();
        for (int i = 0; i < ContainerStory.ins.actStory.CharactersContainer.Count; i++)
        {
            if (ContainerStory.ins.actStory.CharactersContainer[i].Unlock == true)
            {
                if (ContainerStory.ins.actStory.CharactersContainer[i].Able == true)
                {
                    if (ContainerStory.ins.actStory.CharactersContainer[i].Stamina > 0)
                    {
                        if (ContainerStory.ins.actStory.CharactersContainer[i].Resting !=true)
                        {
                            if (ContainerStory.ins.actStory.CharactersContainer[i].Slot != 0)
                            {
                                charsWorking.Add(i);

                            }
                        }

                    }
                    
                }
            }

        }
    }


    //METHOD CHECK IF THERE IS ENOUTH MONEY TO START WORKING MONEY
    private bool CheckMoney()
    {
        if (ContainerStory.ins.actStory.ActMoney > 0)
        {
            return true;
        }

        return false;
    }


    //REPAIR ROOMS IF NEEDED
    private void StartRepairs()
    {
        for (int r = 0; r < roomsWorking.Count; r++)
        {
            if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairLevel<100f && ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairOrder == true)
            {
                for (int c = 0; c < charsWorking.Count; c++)
                {
                    if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].HouseSlot == ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Slot)
                    {
                        if (ContainerStory.ins.actStory.ActMoney >= ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairCost * ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Proficiency)
                        {
                       
                            ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairLevel += ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Proficiency;
                            ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Stamina -= ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Proficiency;

                            ContainerStory.ins.actStory.ActMoney -= ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairCost * ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Proficiency;
                        }
                    }
                }
            }

            if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairLevel > 100f)
            {
                ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairLevel = 100f;
                ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairOrder = false;
            }
        }
    }


    //METHOD CHECK HOW IS WORKING AND WHAT THEY PRODUCE, CHANGES STAMINA AND ADD EXPENESES
    private void StartWorking()
    {
        for (int r = 0; r < roomsWorking.Count; r++)
        {

            if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairLevel >= 80 && ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].RepairOrder!=true )
            {
                for (int c = 0; c < charsWorking.Count; c++)
                {
                    if (ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Stamina>0)
                    {

                        //if character is in room
                        if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].HouseSlot == ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Slot)
                        {
                            //pass info about room and character that is in that room
                            string rnam = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].Name;
                            int rtier = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].Tier;

                            string p;//Product


                            string clw = ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].LovesToWorkIn;
                            string chw = ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].LovesToWorkIn;
                            int cpro = ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Proficiency;

                            if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].WorkType == ContainerStory.ins.actStory.RoomWorkTypesList[1])
                            {

                                if (CheckMoney() == true)
                                {

                                    //resolve work depending on room level and character abilities
                                    if (rtier == 1)//if room lvl is 1
                                    {
                                        p = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].ProductionItems[0];

                                        StockProduction(rnam, rtier, p, clw, chw, cpro);
                                    }
                                    else if (rtier == 2)//if room level is 2
                                    {
                                        p = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].ProductionItems[0];

                                        StockProduction(rnam, rtier, p, clw, chw, cpro);

                                        p = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].ProductionItems[1];

                                        StockProduction(rnam, rtier, p, clw, chw, cpro);
                                    }
                                    else if (rtier == 3)//if room level is 3
                                    {
                                        p = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].ProductionItems[0];

                                        StockProduction(rnam, rtier, p, clw, chw, cpro);

                                        p = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].ProductionItems[2];

                                        StockProduction(rnam, rtier, p, clw, chw, cpro);

                                        p = ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].ProductionItems[3];

                                        StockProduction(rnam, rtier, p, clw, chw, cpro);
                                    }
                                }
                                else
                                {

                                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Not enought money to produce!");
                                }
                            }
                            else if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].WorkType == ContainerStory.ins.actStory.RoomWorkTypesList[2])
                            {
                               
                                //selling spots
                                sellingMultiplier++;

                                //buff for each extra sell for each 2 characters on the room
                                int actualWorkers=0;
                                foreach (var _workerName in ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].WorkersList)
                                {
                                    if (_workerName != null)
                                    {
                                        actualWorkers++;
                                    }
                                }
                                sellingMultiplier += Mathf.FloorToInt(actualWorkers/2);

                                //use character proeficiency
                                sellingMultiplier += Mathf.FloorToInt(ContainerStory.ins.actStory.CharactersContainer[charsWorking[c]].Proficiency / 10);


                            }
                            else if (ContainerStory.ins.actStory.SlotsContainer[roomsWorking[r]].WorkType == ContainerStory.ins.actStory.RoomWorkTypesList[3])
                            {
                               //services room
                                    //services

                            }

                            if (chw == rnam)//HATES)
                            {
                                ContainerStory.ins.actStory.CharactersContainer[c].Loyalty -= 1;
                                ContainerStory.ins.actStory.CharactersContainer[c].Stamina -= 2;
                                ContainerStory.ins.actStory.CharactersContainer[c].Experience += 1;
                            }
                            else if (clw == rnam)//HATES
                            {
                                ContainerStory.ins.actStory.CharactersContainer[c].Loyalty += 3;
                                ContainerStory.ins.actStory.CharactersContainer[c].Stamina -= 1;
                                ContainerStory.ins.actStory.CharactersContainer[c].Experience += 3;
                            }
                            else //Normal
                            {
                                ContainerStory.ins.actStory.CharactersContainer[c].Loyalty += 1;
                                ContainerStory.ins.actStory.CharactersContainer[c].Stamina -= 2;
                                ContainerStory.ins.actStory.CharactersContainer[c].Experience += 2;
                            }

                            //Cost worker

                            actExpenses += ContainerStory.ins.actStory.CharactersContainer[c].WorkCost;//is set here so the player knows how mutch does it cost the production
                            ContainerStory.ins.actStory.CharactersContainer[c].WorkPayDebt += ContainerStory.ins.actStory.CharactersContainer[c].WorkCost;//characters are payed at the end of the day

                        }
                    }

                }
            }

        }

    }


    //METHOD CREATES THE PRODUCT DEPENDING ON ROOM AND CHARACTER STATS
    private void StockProduction(string roomName, int buildingTier, string product, string charLovesWork, string charHatesWork, int charPro)
    {
        bool itemOnContainer = false;
        bool itemOnTemplate = false;
        int itemContainerLocation = 0;
        int itemTemplateLocation = 0;

        int productionQuantity=0;

        int productBatch=0;//Product Batch as in the data structure
        int productCost=0;//Product Cost

        //BuildingInventory is the inventory to the stock items
        //Cleans Stock of non stock items if needed
        foreach (Item item in ContainerStory.ins.actStory.BuildingInventory)
        {
            if (item.InventoryType != ContainerStory.ins.actStory.BuildingInventoryType)
            {
                ContainerStory.ins.actStory.BuildingInventory.Remove(item);//Deletes if item is not supose to be an stock item
               
            }

        }

        //Find if item is already in the inventory and takes note of it (place, batch and cost)
        for (int i = 0; i < ContainerStory.ins.actStory.BuildingInventory.Count; i++)
        {
            if (ContainerStory.ins.actStory.BuildingInventory[i].Name == product)
            {
                    itemContainerLocation = i;
                    itemOnContainer = true;
                    productBatch = ContainerStory.ins.actStory.BuildingInventory[i].ProductionBatch;
                    productCost = ContainerStory.ins.actStory.BuildingInventory[i].ProductionCost;
                    break;
                
            }
        }

        //serch in the templates if item is NOT in the ItemContainer already
        if (itemOnContainer != true)
        {
            itemOnTemplate = false;
            for (int i = 0; i < ContainerStory.ins.actStory.ItemsTemplates.Count; i++)
            {
                if (ContainerStory.ins.actStory.ItemsTemplates[i].InventoryType == ContainerStory.ins.actStory.BuildingInventoryType)
                {
                    if (ContainerStory.ins.actStory.ItemsTemplates[i].Name == product)
                    {
                        itemTemplateLocation = i;
                        itemOnTemplate = true;
                        productBatch = ContainerStory.ins.actStory.ItemsTemplates[i].ProductionBatch;
                        productCost = ContainerStory.ins.actStory.ItemsTemplates[i].ProductionCost;
                        break;
                    }
                }
            }
        }

        //calculate the quantity of product generated based on the character stats
        if (charHatesWork == roomName)//HATES
        {
            productionQuantity = Mathf.CeilToInt(charPro * buildingTier * productBatch);
        }
        else if (charLovesWork == roomName)//LOVES
        {
            productionQuantity = Mathf.CeilToInt(charPro * 4 * buildingTier * productBatch);
        }
        else//NORMAL
        {
            productionQuantity = Mathf.CeilToInt(charPro * 2 * buildingTier * productBatch);
        }
        
        //if item does NOT exist inside the ItemContainer of the Inventory then pass the template necessary and add quantity
        if (itemOnTemplate = true && itemOnContainer == false)
        {
            
            Item itemNew = new Item();
            itemNew=ContainerStory.ins.actStory.ItemsTemplates[itemTemplateLocation].ShallowCopy();
         
            itemNew.Quantity = productionQuantity;
           
            ContainerStory.ins.actStory.BuildingInventory.Add(itemNew);

            GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(productionQuantity + " '" + itemNew.Name + "s' were added to stock and now total " + itemNew.Quantity+".");
        }
        //if item already exist inside the ItemContainer just add quantity
        else if (itemOnContainer == true)
        {
            
            ContainerStory.ins.actStory.BuildingInventory[itemContainerLocation].Quantity += productionQuantity;

            GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(productionQuantity + " '" + ContainerStory.ins.actStory.BuildingInventory[itemContainerLocation].Name + "s' were added to stock."+ ContainerStory.ins.actStory.BuildingInventory[itemContainerLocation].Quantity + ".");
        }

        //COST Produce //CHANGE THIS! Make it that you have to buy resources to construct things
        actExpenses += productionQuantity * productCost;//just for info
        ContainerStory.ins.actStory.ActMoney -= productionQuantity * productCost;//production resources costs are taken instatly but characters paychecks are diferent

    }


    //METHOD TO UPDATE WORKERS AFTER WORK 
    private void UpdateCharactersStatus()
    {

        //Incapacitation via exaustion
        foreach (Character charac in ContainerStory.ins.actStory.CharactersContainer)
        {

        
            if (charac.Stamina < 1 && charac.IncapacitatedTicks==0)//if exhausted Stamina only replenish once a day bacause character is sick
            {
                
                charac.IncapacitatedTicks = Mathf.Abs(charac.Stamina);

                charac.Stamina = 1;

                GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(charac.NickName.ToString() + " is exhausted and needs " + charac.IncapacitatedTicks + "days to recover");

                charac.Resting = true;

                
            }
            else if(charac.IncapacitatedTicks > 0)
            {

                if (ContainerStory.ins.actStory.ActHour == 6)
                {

                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(charac.NickName.ToString() + " is still exhausted and needs " + charac.IncapacitatedTicks + "days to recover");

                    charac.IncapacitatedTicks--;
                }

                charac.Resting = true;

            }
            else if (charac.TimeOff == true)//Doubles Stamina replenisment on resting but is unreachable
            {
                charac.Stamina += charac.Proficiency*2 + 2;//Double stamina

                if (charac.Stamina == 100)
                {
                    charac.TimeOff = false;
                    charac.Resting = false;
                    charac.Able = true;

                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(charac.NickName + " came back and is fully rested.");
                }
            }
            else if (charac.Resting == true)//Normal Stamina replenisment on resting
            {
                charac.Stamina += charac.Proficiency+2;

                if (charac.Stamina==100)
                {
                    charac.Resting = false;
                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(charac.NickName + " is fully rested.");
                }
            }
            else if (charac.Resting == false)//Normal Stamina replenisment on resting
            {
                if (charac.Stamina < 20)
                {
                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add(charac.NickName + "is getting tierd and needs to rest");
                    
                }
                else if(charac.Stamina > 20)
                {
                    charac.Stamina--;
                }
            }
            //character only gain stamina if resting



        }

        /*
        //level up //CHANGE THIS! TO CLASS STORY LOGIC!
        for (int i = 0; i < ContainerStory.ins.actStory.CharactersContainer.Count; i++)
        {

            if (ContainerStory.ins.actStory.CharactersContainer[i].Experience > Mathf.Pow(100, ContainerStory.ins.actStory.CharactersContainer[i].Level))
            {
                ContainerStory.ins.actStory.CharactersContainer[i].Level++;
                ContainerStory.ins.actStory.CharactersContainer[i].Proficiency += ContainerStory.ins.actStory.CharactersContainer[i].Level;

            }
        }*/
    }

    //METHOD TO SIMULATE HOW MANY CLIENTS THERE IS AT THE GIVEN TIME
    private void CalculateClients()
    {
        if (ContainerStory.ins.actStory.BuildingOpen!=false)
        {
            //generate number of possible clients
            for (int i = 0; i < ContainerStory.ins.actStory.WeekdayNames.Count; i++)
            {
                if (ContainerStory.ins.actStory.ActWeekday == ContainerStory.ins.actStory.WeekdayNames[i])
                {
                    for (int d = 0; d < ContainerStory.ins.actStory.DayPartNames.Count; d++)
                    {
                        if (ContainerStory.ins.actStory.ActDayPart == ContainerStory.ins.actStory.DayPartNames[d])
                        {
                            possibleClients = Mathf.CeilToInt(Random.Range(1, ContainerStory.ins.actStory.ClientsDynamics[i*4+d] * ContainerStory.ins.actStory.BuildingNotoriety));
                        }
                    }
                }
            }
        }

        //KICK OUT 
        if (ContainerStory.ins.actStory.ClientsContainer.Count> 0)
        {
            for (int i = ContainerStory.ins.actStory.ClientsContainer.Count-1; i >= 0; i--)
            {
                
                //erase clients with no time to spend aka money or wish to be in the building
                if (ContainerStory.ins.actStory.ClientsContainer[i].ConsuptionCycle <= 0)
                {
                    string _mood = ContainerStory.ins.actStory.ClientsContainer[i].Happiness > 50 ? "Happy" : "Unhappy";

                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Client '" + ContainerStory.ins.actStory.ClientsContainer[i].NickName + "' left the building "+ _mood + ".");

                    ContainerStory.ins.actStory.ClientsContainer.RemoveAt(i);

                }
                //erase unhappy clients
                else if (ContainerStory.ins.actStory.ClientsContainer[i].Happiness <= 0)
                {
                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Client '" + ContainerStory.ins.actStory.ClientsContainer[i].NickName + "' left the building unhappy.");

                    ContainerStory.ins.actStory.ClientsContainer.RemoveAt(i);

                }
                //erase broke clients
                else if (ContainerStory.ins.actStory.ClientsContainer[i].Money <= 0)
                {
                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Client '" + ContainerStory.ins.actStory.ClientsContainer[i].NickName + "' left the building broke.");

                    ContainerStory.ins.actStory.ClientsContainer.RemoveAt(i);

                }

               
            }
        }

        //KICK EVERYONE ON DEMAND AS SOON AS POSSIBLE
        if (ContainerStory.ins.actStory.KickoutOrder == true)
        {
            ContainerStory.ins.actStory.ClientsContainer.Clear();
            ContainerStory.ins.actStory.BuildingOpen = false;
            ContainerStory.ins.actStory.KickoutOrder = false;
        }

        actClients = ContainerStory.ins.actStory.ClientsContainer.Count;


        if (ContainerStory.ins.actStory.BuildingOpen != false)
        {
            //GENERATE NEW CLIENTS
            for (int i = 0; i < possibleClients; i++)
            {
                int pickRandomClient = Mathf.CeilToInt(Random.Range(0, ContainerStory.ins.actStory.ClientsTemplates.Count));

                foreach (string _clientSchedual in ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].Schedual)
                {
                    if (_clientSchedual == ContainerStory.ins.actStory.ActDayPart)
                    {
                        if (ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].RequiredNotoriety <= ContainerStory.ins.actStory.BuildingNotoriety)
                        {
                            if (ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].RequiredReputation <= ContainerStory.ins.actStory.BuildingReputation)
                            {
                                if (ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].RequiredLuxury <= ContainerStory.ins.actStory.BuildingLuxury)
                                {
                                    if (ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].RequiredTier <= ContainerStory.ins.actStory.BuildingTier)
                                    {
                                        Client newClient = new Client();

                                        newClient = ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].ShallowCopy();

                                        newClient.ID = (int)Time.time;

                                        ContainerStory.ins.actStory.ClientsContainer.Add(newClient);

                                        actClients++;

                                        GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Client '" + ContainerStory.ins.actStory.ClientsTemplates[pickRandomClient].NickName + "' entered the building.");

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        ContainerStory.ins.actStory.ActDayClients = actClients;

    }


    //METHOD TO SIMULATE HOW MANY SELLS THERE ARE DEPENDING ON CLIENTS
    private void SellToClients()
    {

        //FOR CLIENTS
        foreach (Client _client in ContainerStory.ins.actStory.ClientsContainer)
        {

            bool foundItem = false;

            bool satisfied = false;

            int satisfaction = 0;


            //RIGHT TIME
            if (_client.ConsuptionCounter >= _client.ConsuptionDelay)
            {

                //SHOP ABLE
                for (int i = 0; i < sellingMultiplier; i++)
                {

                    //SELECT RANDOM WISH
                    string _clientWish = _client.WishesProducts[Random.Range(0, _client.WishesProducts.Count - 1)];

                    //FOR ITEMS
                    foreach (Item _item in ContainerStory.ins.actStory.BuildingInventory)
                    {
                        //COMPARE ITEM TO WISH
                        if (_clientWish == _item.Name)
                        {

                            foundItem = true;//ALREADY PRODUCED THIS ITEMS ONCE


                            if (_item.Quantity <= 0)//NOT IN STOCK
                            {
                                
                                GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Client '" + _client.NickName + "' wants '" + _item.Name + "'.");

                            }
                            else if (_item.Quantity > 0)//IN STOCK
                            {
                                satisfied = true;

                                _item.Quantity--;
                                actSells++;
                                actIncome += _item.SellPrice;
                                _client.Money -= _item.SellPrice;

                                _client.ConsuptionCounter = 0;
                                _client.ConsuptionCycle--;

                                satisfaction += _item.RisesHappines;
                               
                                GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Client '" + _client.NickName + "' is happy with '" + _item.Name + "'.");


                            }
                        }
                    }
                   
                }

                //ITEM NOT FOUND IN STOCK
                if (foundItem == false)
                {
                    //gets sad if can not find item he/she wants
                    satisfaction -= Mathf.Clamp(20 - _client.Resilience, 0, 100);
                    _client.ConsuptionCycle--;

                }

                //NO ITEM SOLD
                if (satisfied == false)
                {
                    //gets sad if can not find item he/she wants
                    satisfaction -= Mathf.Clamp(10 - _client.Resilience, 0, 100);
                    _client.ConsuptionCycle--;

                }

            }

            _client.ConsuptionCounter++;

            _client.Happiness += satisfaction;

            ContainerStory.ins.actStory.ActDayClientsHappiness += satisfaction;

        }
        
    }


    //METHOD TO UPDATE CLIENTES MOOD AND MONEY
    private void UpdateClientsStatus()
    {
        foreach (Client _client in ContainerStory.ins.actStory.ClientsContainer)
        {
            bool satisfied = false;
            foreach (string _clientWishe in _client.WishesRooms)
            {
                foreach (Room _room in ContainerStory.ins.actStory.SlotsContainer)
                {
                    if (_clientWishe==_room.Name)
                    {
                        satisfied = true;
                    }
                }

                foreach (BuildingUpgrade _upgrade in ContainerStory.ins.actStory.BuildingUpgradeContainer)
                {
                    if (_clientWishe == _upgrade.Name && _upgrade.Able==true)
                    {
                        satisfied = true;
                    }
                }
            }
            if (satisfied==false && _client.WishesRooms.Count!=0)
            {
                int insatisfaction = Mathf.Abs(10 - _client.Resilience);
                _client.Happiness-= insatisfaction;
                ContainerStory.ins.actStory.ActDayClientsHappiness-= insatisfaction;
            }
        }
    }


    //METHOD TO UPDATE AND CALCULATE HOW MUCH WAS EARN AND SPEND LAST HOUR
    private void TickBalance()
    {
        ContainerStory.ins.actStory.ActDayIncome += actIncome;
        ContainerStory.ins.actStory.ActDayExpenses += actExpenses;//just for info
        ContainerStory.ins.actStory.ActDayClients += actClients;//just for info
        ContainerStory.ins.actStory.ActDayClientsHappiness += actClientsHappiness;//just for info
        ContainerStory.ins.actStory.ActDaySells += actSells;//just for info

        actIncome = 0;
        actExpenses = 0;
        actClients = 0;
        actClientsHappiness = 0;
        actSells = 0;
    }


    private void PlayerStatus()
    {

    }


    private void BuildingStatus()
    {

    }


    //METHOD TO UPDATE AND CALCULATE HOW MUCH WAS EARN AND SPEND LAST DAY
    private void ExecuteDailyBalance()
    {
        if (ContainerStory.ins.actStory.ActHour == 6)
        {
            ContainerStory.ins.actStory.ActMoney += ContainerStory.ins.actStory.ActDayIncome;

            foreach (Character charac in ContainerStory.ins.actStory.CharactersContainer)
            {
                if (ContainerStory.ins.actStory.ActMoney < charac.WorkPayDebt)
                {
                    charac.Loyalty -= Mathf.CeilToInt(charac.WorkPayDebt / 10);

                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Unable to pay the work day to  '" + charac + "'." );
                }
                else
                {
                    ContainerStory.ins.actStory.ActMoney -= charac.WorkPayDebt;
                    charac.Loyalty += Mathf.CeilToInt(charac.WorkPayDebt / 100);
                    charac.WorkPayDebt = 0;

                    GameInfoMarquee.ins.gameLog.hopperInfoLog.Add("Payed " + charac.WorkPayDebt + "$ for work day '" + charac + "'.");

                }
            }

            ContainerStory.ins.actStory.ActMonthIncome += ContainerStory.ins.actStory.ActDayIncome;
            ContainerStory.ins.actStory.ActMonthExpenses += ContainerStory.ins.actStory.ActDayExpenses;
            ContainerStory.ins.actStory.ActMonthClients += ContainerStory.ins.actStory.ActDayClients;
            ContainerStory.ins.actStory.ActMonthClientsHappiness += ContainerStory.ins.actStory.ActDayClientsHappiness;
            ContainerStory.ins.actStory.ActMonthSells += ContainerStory.ins.actStory.ActDaySells;



            ContainerStory.ins.actStory.LastDayIncome = ContainerStory.ins.actStory.ActDayIncome;
            ContainerStory.ins.actStory.LastDayExpenses = ContainerStory.ins.actStory.ActDayExpenses;
            ContainerStory.ins.actStory.LastDayClients = ContainerStory.ins.actStory.ActDayClients;
            ContainerStory.ins.actStory.LastDayClientsHappiness = ContainerStory.ins.actStory.ActDayClientsHappiness;
            ContainerStory.ins.actStory.LastDaySells = ContainerStory.ins.actStory.ActDaySells;


            ContainerStory.ins.actStory.ActDayIncome = 0;
            ContainerStory.ins.actStory.ActDayExpenses = 0;

            ContainerStory.ins.actStory.ActDayClients = 0;
            ContainerStory.ins.actStory.ActDayClientsHappiness = 0;
            ContainerStory.ins.actStory.ActDaySells = 0;


        }

    }


    //METHOD TO UPDATE AND CALCULATE HOW MUCH WAS EARN AND SPEND LAST MONTH
    private void ExecuteMonthlyBalance()
    {
        if (ContainerStory.ins.actStory.ActHour == 6 && ContainerStory.ins.actStory.ActDay == 1)
        {

            ContainerStory.ins.actStory.LastMonthIncome = ContainerStory.ins.actStory.ActMonthIncome;
            ContainerStory.ins.actStory.LastMonthExpenses = ContainerStory.ins.actStory.ActMonthExpenses;
            ContainerStory.ins.actStory.LastMonthClients = ContainerStory.ins.actStory.ActMonthClients;
            ContainerStory.ins.actStory.LastMonthClientsHappiness = ContainerStory.ins.actStory.ActMonthClientsHappiness;
            ContainerStory.ins.actStory.LastMonthSells = ContainerStory.ins.actStory.ActMonthSells;

            ContainerStory.ins.actStory.ActMonthIncome = 0;
            ContainerStory.ins.actStory.ActMonthExpenses = 0;
            ContainerStory.ins.actStory.ActMonthClients = 0;
            ContainerStory.ins.actStory.ActMonthClientsHappiness = 0;
            ContainerStory.ins.actStory.ActMonthSells = 0;
        }

    }

}
