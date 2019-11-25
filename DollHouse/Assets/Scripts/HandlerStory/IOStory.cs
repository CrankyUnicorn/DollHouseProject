using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class IOStory : MonoBehaviour {

    public static IOStory ins = null;

    private CreatorStory _newStory;

    private CreatorPreferences _newPreferences;

    public bool loadStory = false;

    private const int saveSlots = 9;
    public int saveSlotsRef = saveSlots;

    private string[] savePathSlots; 

    private string applicationPath;
    private string saveDirName;
    private string musicDirName;
    private string spriteDirName;
    private string saveFolder;
    private string musicFolder;
    private string spriteFolder;
    private string prefDirName;
    private string prefFolder;
    private bool checkedPath = false;

    private string[] importDir;

    public List<string> importedSprite = new List<string>();
    public List<Sprite> spriteList = new List<Sprite>();
    public AudioClip[] audioList;


    void Awake()
    {
        //Check if instance already exists
        if (ins == null)
        {

            //if not, set instance to this
            ins = this;
        }
        //If instance already exists and it's not this:
        else if (ins != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

    }


    //
    private void Start()
    {
        CheckPath();
        LoadGamePref();
        StartCoroutine(ImportMedia());

        if (loadStory==true)
        {
            RunStory();
        }
    }

    //defenitions to create folder for modding
    //for safety this are stored here
    private void PathDef()
    {
        savePathSlots = new string[saveSlots] { "NewGame.xml", "SaveSlot1.xml", "SaveSlot2.xml", "SaveSlot3.xml", "SaveSlot4.xml", "SaveSlot5.xml", "SaveSlot6.xml", "SaveSlot7.xml", "SaveSlot8.xml" };
        applicationPath = Application.dataPath;
        saveDirName = "/Save/";
        musicDirName= "/Music/";
        spriteDirName= "/Sprite/";
        prefDirName = "/UserPref/";
        saveFolder = applicationPath + saveDirName;
        musicFolder = applicationPath + musicDirName;
        spriteFolder = applicationPath + spriteDirName;
        prefFolder = applicationPath + prefDirName;
    }


    //This Method check and creates folder needed to mod the game
    private bool CheckPath()
    {
        PathDef();

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {


            // ... If the directory doesn't exist, create it.
            if (!Directory.Exists(prefFolder))
            {
                Directory.CreateDirectory(prefFolder);
            }
            if (!Directory.Exists(spriteFolder))
            {
                Directory.CreateDirectory(spriteFolder);
            }
            if (!Directory.Exists(musicFolder))
            {
                Directory.CreateDirectory(musicFolder);
            }
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
                return true;
            }
            else if(Directory.Exists(saveFolder))
            {
                return true;
            }

        }
        return false;
    }

    //SAVE PREFERENCES
    //Also indexes saved games references but not contend
    public void SaveAndLoadNewGamePref()
    {
        checkedPath = CheckPath();

        _newPreferences = new CreatorPreferences();
        _newPreferences.StartingPref();

        XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
        FileStream writer = new FileStream(prefFolder + "UserPref.xml", FileMode.Create);
        serializer.Serialize(writer, _newPreferences.userPref);
        writer.Close();

        Debug.Log("Created and Saved New UserPref.xml");

        LoadGamePref();
    }

    public void SaveGamePref()
    {
        checkedPath = CheckPath();

        XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
        FileStream writer = new FileStream(prefFolder + "UserPref.xml", FileMode.Create);
        serializer.Serialize(writer, ContainerPreferences.ins.loadedPreferences);
        writer.Close();

        Debug.Log("Saved UserPref.xml");

    }

    public void LoadGamePref()
    {
        
        checkedPath = CheckPath();

        if (File.Exists(prefFolder   + "UserPref.xml")==true)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
            FileStream reader = new FileStream(prefFolder + "UserPref.xml", FileMode.Open);
            ContainerPreferences.ins.loadedPreferences = serializer.Deserialize(reader) as Preferences;
            reader.Close();

            Debug.Log("Loaded UserPref.xml");
        }
        else
        {

            SaveAndLoadNewGamePref();
        }
        
    }
    
    //Load and runs a story from a reference index number on the User Preferences File
    public void RunStory() {
        if (loadStory == true)
        {
            int selectedSlotToLoad = ContainerPreferences.ins.loadedPreferences.slotToLoad;
            if (selectedSlotToLoad == 0)
            {
                SaveAndLoadNewStory();//creates a new story, saves and Load it right away
            }
            else
            {
                LoadCurrentStory(selectedSlotToLoad);
            }
        }
        else
        {
            Debug.Log("File Reference to be Loaded from PREFERENCES wasn't allowed to Load! Check IOSTORY for LOADSTORY bool permit");
        }
    }

    //LOAD AND SAVE FUNCTIONS
    //Save new games saves a template of the tutorial of the game in slot O 
    //this slot is dedicated only for the tutorial or the starting game
    //Other slots are for saving the game or loading it.
    public void SaveAndLoadNewStory()
    {
        checkedPath = CheckPath();

        if (checkedPath==true)
        {
            _newStory = new CreatorStory();
            _newStory.MakeStory();

                XmlSerializer serializer = new XmlSerializer(typeof(Story));
                FileStream writer = new FileStream(saveFolder + savePathSlots[0], FileMode.Create);
                serializer.Serialize(writer, _newStory.newStory);
                writer.Close();

            Debug.Log("Saved Slot 0");
            Debug.Log("Saved New Game");
            Debug.Log("Loading New Game");

            LoadCurrentStory(0);
        }
    }

    public void SaveCurrentStory(int ss)
    {
        checkedPath = CheckPath();

        if (checkedPath == true)
        {
            string actTimeStamp = DateTime.Now.ToString();//get date

            ContainerStory.ins.actStory.TimeStamp = actTimeStamp;//stamp date into saved file

            string tempName = ContainerStory.ins.actStory.FileName;//make a string for description
            string tempDate = ContainerStory.ins.actStory.TimeStamp;
            string nameSlot = "Slot " + ss + " | " + tempName + " | " + tempDate;

            ContainerPreferences.ins.loadedPreferences.saveNameSlots[ss] = nameSlot;//save preferences into the preferences class instace

            SaveGamePref();//save the preferences file into rom

            XmlSerializer serializer = new XmlSerializer(typeof(Story));
            FileStream stream = new FileStream(saveFolder + savePathSlots[ss], FileMode.Create);
            serializer.Serialize(stream, ContainerStory.ins.actStory);
            stream.Close();

            Debug.Log("Saved Slot "+ss);
        }
    }

    public void LoadCurrentStory(int ls)
    {
        checkedPath = CheckPath();
        
        if (checkedPath == true)
        {
            if (File.Exists(saveFolder + savePathSlots[ls]) == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Story));
                FileStream reader = new FileStream(saveFolder + savePathSlots[ls], FileMode.Open);
                ContainerStory.ins.actStory = serializer.Deserialize(reader) as Story;
                reader.Close();

                Debug.Log("Loaded Slot "+ls);
            }
            else
            {
                ContainerPreferences.ins.loadedPreferences.saveNameSlots[ls] = GameVirtualEnums.Empty;
                Debug.Log("Saved Slot " + ls +"was not found please. Object was deleted or missplaced. Now Deleting Reference.");
            }
        }
    }


    //MEDIA IMPORTER
    //This section is dedicated to import media from a folder on the game application tree
    //Right now only looks for PNG files and stores them in a List for in game use
    //In future I shall implement a image browser on the editor for easly reference
    //The game only actually use this outside the Unity Editor 
    //since there are no folder ref inside of it
    private IEnumerator ImportMedia()
    {
        checkedPath = CheckPath();

        string filePath = Application.dataPath+"/Sprite/";
        
        importDir = Directory.GetFiles(filePath, "*.png");
        
        
        foreach (string tstring in importDir)
        {

            string pathTemp = tstring;
            string fileName = Path.GetFileName(tstring);
            
            WWW www = new WWW(pathTemp);
            yield return www;

            Texture2D texTmp = new Texture2D(4, 4, TextureFormat.DXT5, false);
            www.LoadImageIntoTexture(texTmp);

            Sprite spriteFromTexture = Sprite.Create(texTmp, new Rect(0, 0, texTmp.width, texTmp.height), Vector2.zero);

            spriteList.Add(spriteFromTexture);

            importedSprite.Add(fileName);
            
            
        }

    }
}

