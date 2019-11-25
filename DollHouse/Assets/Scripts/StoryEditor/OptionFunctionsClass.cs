using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionFunctionsClass  {

    public List<string> optionFunctions=new List<string>() { "","JumpToDialogId", "JumpToLine", "EndThisDialog","GiveMoney","GainMoney","UnlockCharacter","UnlockDialog","GainCharisma","GainFame","GainFlatter","GainWit","PlayerPersuasion","GainBargain","Incapacitate" };
    public List<string> optionConditions = new List<string>() { "", "PlayerCharisma","PlayerFame","PlayerFlatter","PlayerWit","PlayerPersuasion","PlayerBargain"};
}
