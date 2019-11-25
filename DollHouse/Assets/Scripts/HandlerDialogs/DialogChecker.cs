using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogChecker {

    public List<int> displayArray = new List<int>();

    public void CheckForDialogs()//check if any Dialog event is able to happen at this date etc..
    {

        displayArray.Clear();

        for (int di = 0; di < ContainerStory.ins.actStory.DialogsContainer.Count; di++)
        {

            bool ableShow = CheckShow(di);//check if is a show once or more times dialog and if able
            bool ableAchive = CheckAchivement(di);
            bool ableTime = CheckTimer(di);
            bool ablePlayer = CheckPlayer(di);
            bool ableCharact = CheckCharacters(di);
            bool ableBuild = CheckBuilding(di);
            bool ableRooms = CheckRooms(di);
            bool ableStock = CheckStock(di);


            if (ableShow == true && ableAchive == true && ableTime == true && ablePlayer == true && ableCharact == true && ableBuild == true && ableRooms == true && ableStock == true)
            {
                ContainerStory.ins.actStory.DialogsContainer[di].TimesShown += 1;
                displayArray.Add(di);

            }

        }


        if (displayArray.Count > 0)
        {
            //DISPLAYS MESSAGE send to DisplayMessage to deal with it
            DialogDisplay.ins.MessageList(displayArray);
        }

    }


    //CHEKERs-------------
    private bool CheckShow(int i)//finds how many times this dialog have been played 
    {

        if (ContainerStory.ins.actStory.DialogsContainer[i].ShowTimes == true)
        {
            if (ContainerStory.ins.actStory.DialogsContainer[i].ShowTimesX <= ContainerStory.ins.actStory.DialogsContainer[i].TimesShown)
            {
                return true;
            }
        }
        else//if it should be played only one

        {
            if (ContainerStory.ins.actStory.DialogsContainer[i].TimesShown < 1)
            {
                return true;
            }
        }
        return false;//if it already played dont show any more
    }


    private bool CheckPlayer(int i)//Check if player this and that
    {
        if (ContainerStory.ins.actStory.ActMoney < ContainerStory.ins.actStory.DialogsContainer[i].IfMoneyUnder ||
            ContainerStory.ins.actStory.DialogsContainer[i].IfMoneyUnder == 0)
        {
            if (ContainerStory.ins.actStory.ActMoney > ContainerStory.ins.actStory.DialogsContainer[i].IfMoneyOver ||
                ContainerStory.ins.actStory.DialogsContainer[i].IfMoneyOver == 0)
            {
                if (ContainerStory.ins.actStory.ActTotalDebt < ContainerStory.ins.actStory.DialogsContainer[i].IfDebtUnder ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfDebtUnder == 0)
                {
                    if (ContainerStory.ins.actStory.ActTotalDebt > ContainerStory.ins.actStory.DialogsContainer[i].IfDebtOver ||
                        ContainerStory.ins.actStory.DialogsContainer[i].IfDebtOver == 0)
                    {
                        if (ContainerStory.ins.actStory.PlayerCharisma == ContainerStory.ins.actStory.DialogsContainer[i].IfCharisma ||
                            ContainerStory.ins.actStory.DialogsContainer[i].IfCharisma == 0)
                        {
                            if (ContainerStory.ins.actStory.PlayerFame == ContainerStory.ins.actStory.DialogsContainer[i].IfFame ||
                                ContainerStory.ins.actStory.DialogsContainer[i].IfFame == 0)
                            {
                                if (ContainerStory.ins.actStory.PlayerFlatter == ContainerStory.ins.actStory.DialogsContainer[i].IfFlatter ||
                                    ContainerStory.ins.actStory.DialogsContainer[i].IfFlatter == 0)
                                {
                                    if (ContainerStory.ins.actStory.PlayerWit == ContainerStory.ins.actStory.DialogsContainer[i].IfWit ||
                                        ContainerStory.ins.actStory.DialogsContainer[i].IfWit == 0)
                                    {
                                        if (ContainerStory.ins.actStory.PlayerPersuasion == ContainerStory.ins.actStory.DialogsContainer[i].IfPersuasion ||
                                            ContainerStory.ins.actStory.DialogsContainer[i].IfPersuasion == 0)
                                        {
                                            if (ContainerStory.ins.actStory.PlayerBargain == ContainerStory.ins.actStory.DialogsContainer[i].IfBargain ||
                                                ContainerStory.ins.actStory.DialogsContainer[i].IfBargain == 0)
                                            {
                                                if (ContainerStory.ins.actStory.Bloodtype == ContainerStory.ins.actStory.DialogsContainer[i].IfBloodtype ||
                                                    ContainerStory.ins.actStory.DialogsContainer[i].IfBloodtype == null)
                                                {
                                                    if (ContainerStory.ins.actStory.Zodiac == ContainerStory.ins.actStory.DialogsContainer[i].IfZodiac ||
                                                        ContainerStory.ins.actStory.DialogsContainer[i].IfZodiac == null)
                                                    {
                                                        if (ContainerStory.ins.actStory.DialogsContainer[i].IfBirthdayDay == true)
                                                        {
                                                            if (ContainerStory.ins.actStory.BirthdayDay == ContainerStory.ins.actStory.ActDay && ContainerStory.ins.actStory.BirthdayMonth == ContainerStory.ins.actStory.ActMonth)
                                                            { return true; }
                                                        }
                                                        else
                                                        {

                                                            { return true; }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        return false;
    }


    private bool CheckAchivement(int i)//NOT WORKING FULLY REVIEW
    {
        bool ach1 = false;
        bool ach2 = false;
        bool ach3 = false;

        //if container is emptry
        if (ContainerStory.ins.actStory.AchivementsContainer.Count == 0)
        {
            return true;
        }

        foreach (Achivement achivement in ContainerStory.ins.actStory.AchivementsContainer)
        {
            if (ContainerStory.ins.actStory.DialogsContainer[i].IfAchivement1 == achivement.Name ||
                ContainerStory.ins.actStory.DialogsContainer[i].IfAchivement1 == null)
            {
                ach1 = true;
            }
        
        
            if (ContainerStory.ins.actStory.DialogsContainer[i].IfAchivement2 == achivement.Name ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfAchivement2 == null)
            {
                ach2 = true;
            }
        

            if (ContainerStory.ins.actStory.DialogsContainer[i].IfAchivement3 == achivement.Name ||
               ContainerStory.ins.actStory.DialogsContainer[i].IfAchivement3 == null)
            {
                ach3 = true;
            }

            if (ach1 == true && ach2 == true && ach3 == true)
            {
                return true;
            }
            else
            {
                 ach1 = false;
                 ach2 = false;
                 ach3 = false;
            }

        }


        return false;
        
    }


    private bool CheckTimer(int i)//finds if is the correct time to display 
    {
        //ckeck by TICK
        if (ContainerStory.ins.actStory.DialogsContainer[i].IfTick == ContainerStory.ins.actStory.ActTick)
        {
           return true;
        }

        //check by HOUR DAY ETC the HOUR MUST be always specified
        if (ContainerStory.ins.actStory.DialogsContainer[i].IfYear == ContainerStory.ins.actStory.ActYear || ContainerStory.ins.actStory.DialogsContainer[i].IfYear == 0)
        {
            if (ContainerStory.ins.actStory.DialogsContainer[i].IfMonth == ContainerStory.ins.actStory.ActMonth || ContainerStory.ins.actStory.DialogsContainer[i].IfMonth == null)
            {
                if (ContainerStory.ins.actStory.DialogsContainer[i].IfWeekDay == ContainerStory.ins.actStory.ActWeekday || ContainerStory.ins.actStory.DialogsContainer[i].IfWeekDay == null)
                {
                    if (ContainerStory.ins.actStory.DialogsContainer[i].IfDay == ContainerStory.ins.actStory.ActDay || ContainerStory.ins.actStory.DialogsContainer[i].IfDay == 0)
                    {
                        if (ContainerStory.ins.actStory.DialogsContainer[i].IfDayPart == ContainerStory.ins.actStory.ActDayPart || ContainerStory.ins.actStory.DialogsContainer[i].IfDayPart == null)
                        {
                            if (ContainerStory.ins.actStory.DialogsContainer[i].IfHour == ContainerStory.ins.actStory.ActHour)
                            { return true; }
                        }
                    }
                }
            }
        }
        //
        return false;
    }



    private bool CheckCharacters(int i)//check if other characters exist
    {
        for (int c = 0; c < ContainerStory.ins.actStory.CharactersContainer.Count; c++)
        {
            if (ContainerStory.ins.actStory.CharactersContainer[c].Unlock == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterUnlock ||
             ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterUnlock == false)
            {
                if (ContainerStory.ins.actStory.CharactersContainer[c].Able == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterAble ||
               ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterAble == false)
                {
                    if (ContainerStory.ins.actStory.CharactersContainer[c].FirstName == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterName ||
               ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterName == null)
                    {

                        if (ContainerStory.ins.actStory.CharactersContainer[c].Resting == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterResting ||
               ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterResting == false)
                        {

                            if (ContainerStory.ins.actStory.CharactersContainer[c].Relationship >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterRelationship ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterRelationship == 0)
                            {

                                if (ContainerStory.ins.actStory.CharactersContainer[c].Intimacy >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterIntimacy ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterIntimacy == 0)
                                {
                                    if (ContainerStory.ins.actStory.CharactersContainer[c].Loyalty >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterLoyalty ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterLoyalty == 0)
                                    {

                                        if (ContainerStory.ins.actStory.CharactersContainer[c].Stamina >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterStamina ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterStamina == 0)
                                        {
                                            if (ContainerStory.ins.actStory.CharactersContainer[c].Experience >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterExperience ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterExperience == 0)
                                            {
                                                if (ContainerStory.ins.actStory.CharactersContainer[c].Level >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterLevel ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterLevel == 0)
                                                {
                                                    if (ContainerStory.ins.actStory.CharactersContainer[c].Proficiency >= ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterProficiency ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterProficiency == 0)
                                                    {
                                                        if (ContainerStory.ins.actStory.CharactersContainer[c].LovesToWorkIn == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterFavoriteJob ||
               ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterFavoriteJob == null)
                                                        {
                                                            
                                                                if (ContainerStory.ins.actStory.CharactersContainer[c].HatesToWorkIn == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterHateJob ||
               ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterHateJob == null)
                                                                {
                                                                    if (ContainerStory.ins.actStory.CharactersContainer[c].FirstName == ContainerStory.ins.actStory.DialogsContainer[i].IfExtra1Name ||
              ContainerStory.ins.actStory.DialogsContainer[i].IfExtra1Name == null)
                                                                    {

                                                                        if (ContainerStory.ins.actStory.CharactersContainer[c].Unlock == ContainerStory.ins.actStory.DialogsContainer[i].IfExtra1Unlock ||
          ContainerStory.ins.actStory.DialogsContainer[i].IfExtra1Unlock == false)
                                                                        {
                                                                            if (ContainerStory.ins.actStory.CharactersContainer[c].Resting == ContainerStory.ins.actStory.DialogsContainer[i].IfExtra1Able ||
          ContainerStory.ins.actStory.DialogsContainer[i].IfExtra1Able == false)
                                                                            {
                                                                                if (ContainerStory.ins.actStory.CharactersContainer[c].FirstName == ContainerStory.ins.actStory.DialogsContainer[i].IfExtra2Name ||
         ContainerStory.ins.actStory.DialogsContainer[i].IfExtra2Name == null)
                                                                                {

                                                                                    if (ContainerStory.ins.actStory.CharactersContainer[c].Unlock == ContainerStory.ins.actStory.DialogsContainer[i].IfExtra2Unlock ||
                      ContainerStory.ins.actStory.DialogsContainer[i].IfExtra2Unlock == false)
                                                                                    {
                                                                                        if (ContainerStory.ins.actStory.CharactersContainer[c].Able == ContainerStory.ins.actStory.DialogsContainer[i].IfExtra2Able ||
                      ContainerStory.ins.actStory.DialogsContainer[i].IfExtra2Able == false)
                                                                                        {

                                                                                            if (true == ContainerStory.ins.actStory.DialogsContainer[i].IfCharacterBirthdayDay)
                                                                                            {
                                                                                                if (ContainerStory.ins.actStory.CharactersContainer[c].BirthdayDay == ContainerStory.ins.actStory.ActDay &&
                                                                                    ContainerStory.ins.actStory.CharactersContainer[c].BirthdayMonth == ContainerStory.ins.actStory.ActMonth)
                                                                                                { return true; }

                                                                                            }
                                                                                            else { return true; }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        return false;
    }


    private bool CheckBuilding(int i)//finds the building status
    {
        bool step1 = false;
        bool step2 = false;

        if (ContainerStory.ins.actStory.BuildingReputation == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingReputation ||
            ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingReputation == 0)
        {
            if (ContainerStory.ins.actStory.BuildingNotoriety == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingNotoriety ||
           ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingNotoriety == 0)
            {
                if (ContainerStory.ins.actStory.BuildingLuxury == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingLuxury ||
           ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingLuxury == 0)
                {
                    if (ContainerStory.ins.actStory.BuildingTier == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingTier ||
           ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingTier == 0)
                    {

                        step1 = true;
                    }
                }
            }
        }

        //if container is emptry
        if (ContainerStory.ins.actStory.BuildingUpgradeContainer.Count == 0)
        {
            return true;
        }

        foreach (BuildingUpgrade buildUpg in ContainerStory.ins.actStory.BuildingUpgradeContainer)
        {
            if (buildUpg.Able == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeAble ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeAble == false)
            {
                if (buildUpg.Unlock == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeUnlock ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeUnlock == false)
                {
                    if (buildUpg.Name == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeName ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeName == null)
                    {
                        if (buildUpg.Tier == ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeLevel ||
                        ContainerStory.ins.actStory.DialogsContainer[i].IfBuildingUpgradeLevel == 0)
                        {
                            step2 = true;
                        }
                    }
                }
            }

            if (step1 == true && step2 == true)
            {
                return true;
            }
            else
            {
                step2 = false;
            }

        }

        return false;
    }

    private bool CheckRooms(int i)//finds if your running this type of buisnesses
    {
        //if container is emptry
        if (ContainerStory.ins.actStory.SlotsContainer.Count == 0)
        {
            return true;
        }

        foreach (Room room in ContainerStory.ins.actStory.SlotsContainer)
        {
            if (room.Able==true && room.Unlock==true)
            {

                if (room.Name == ContainerStory.ins.actStory.DialogsContainer[i].IfRoomExist ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfRoomExist == null)
                {
                    if (room.Tier == ContainerStory.ins.actStory.DialogsContainer[i].IfRoomExistLevel ||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfRoomExistLevel == 0)
                    {
                        return true;
                    }
                }
            }
        }
       
        return false;
    }

    private bool CheckStock(int i)
    {
        //if container is emptry
        if (ContainerStory.ins.actStory.BuildingInventory.Count == 0)
        {
            return true;
        }

        foreach (Item item in ContainerStory.ins.actStory.BuildingInventory)
        {
            if (ContainerStory.ins.actStory.DialogsContainer[i].IfItemInStock==item.Name ||
                ContainerStory.ins.actStory.DialogsContainer[i].IfItemInStock == null)
            {
                if (ContainerStory.ins.actStory.DialogsContainer[i].IfItemInStockQuantity ==item.Quantity||
                    ContainerStory.ins.actStory.DialogsContainer[i].IfItemInStockQuantity == 0)
                {
                    return true;
                }
            }
                
        }
       
        return false;
    }
}
