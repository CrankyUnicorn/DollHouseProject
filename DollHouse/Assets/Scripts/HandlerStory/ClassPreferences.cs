using System.Collections.Generic;


[System.Serializable]
public class Preferences //...Used to store in game preferences like game options and saved games references
{
    public List<string> saveNameSlots = new List<string>();//IMPORTANT DONT MESS THIS UP

    public int slotToLoad { get; set; }//the index number of the file to be loaded on the start of the next scene IMPORTANT

    public string Language { get; set; }

    public string UITheme { get; set; }

    public bool muteSound { get; set; }
    public int masterVolume { get; set; }
    public int musicVolume { get; set; }
    public int effectVolume { get; set; }
    public int voiceVolume { get; set; }

    public bool fullScreen { get; set; }
    public int resolutionX { get; set; }
    public int resolutionY { get; set; }
    public int frameRate { get; set; } // 
    public string graphicQuality { get; set; } //

    public bool editorEnabled { get; set; }//humm only allow this as an option so player doesn't mess aroud the game to much
    public string editorType { get; set; }//classes that the player can see or change
    
    public bool hotEnabled { get; set; }
}
