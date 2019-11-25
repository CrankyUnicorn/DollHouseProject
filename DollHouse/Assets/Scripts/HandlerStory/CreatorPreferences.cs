using System.Collections.Generic;


[System.Serializable]
public class CreatorPreferences
{
    public Preferences userPref = new Preferences(); // reference on game story

    public void StartingPref()
    {
        //Important don't mess this line up! Or you unlish a shit storm
        userPref.saveNameSlots = new List<string>() { GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty, GameVirtualEnums.Empty };

        userPref.slotToLoad = 0;

        userPref.Language = GameVirtualEnums.English; //Kinda XD
        userPref.UITheme = "Roaring20s"; //first theme

        userPref.muteSound = false;
        userPref.masterVolume = 30;
        userPref.musicVolume = 30;
        userPref.effectVolume = 30;
        userPref.voiceVolume = 30;
        userPref.fullScreen = true;
        userPref.frameRate = 30;
        userPref.graphicQuality = "Low";
        userPref.editorEnabled = true;
        userPref.editorType = "Standard";
        userPref.hotEnabled = false;
        
    }

}
