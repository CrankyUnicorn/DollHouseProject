using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.EventSystems;



public class EditorButton : MonoBehaviour {
    public Text textName;
    public InputField textValue;
    public Image spriteRef;

    public Dropdown dropdown;

    private List<string> _optionFunctions;
    private List<string> _optionConditions;

    public Type refType;

    public int refCoord;
    public int refSubCoord;

    public string valueName;
    public string stringValue;
    


    private void Awake()
    {
        OptionFunctionsClass tempClass = new OptionFunctionsClass();
        _optionFunctions = tempClass.optionFunctions;
        _optionConditions = tempClass.optionConditions;
    }


    //-------------------

    //LISTNERS
    void OnEnable()
    {
        //Register InputField Events
        textValue.onEndEdit.AddListener(delegate { RewriteStory("inputFieldType",null); });
    }

    void OnDisable()
    {
        //Un-Register InputField Events
        textValue.onEndEdit.RemoveAllListeners();
    }


    //-------------------
    //open and close lists of each topic 
    public void ButtonClick() {

        GameObject go = GameObject.FindGameObjectWithTag("EditorDisplayer");

        //send info about the selected object back to the displayer from a instance of this button
        go.transform.GetComponent<EditorDisplayer>().SelectedType(refType, refCoord, refSubCoord);

        //if child of panel3 then dont run
        if (transform != go.transform.GetComponent<EditorDisplayer>().editorPanel3.transform)
        {
           go.transform.GetComponent<EditorDisplayer>().CallSelectedTypeByIndex();
        }
    }


    //---------------------
    //Rewrites value of given var in the correct story place
    void RewriteStory(string inputType, string passValue) {

        if (inputType == "inputFieldType" && passValue==null)
        {
            stringValue = textValue.text;
        }
        else if (inputType == "dropdownType" && passValue != null)
        {
            stringValue = passValue;
        }
       

        if (stringValue==null)
        {
            stringValue = "";
        }

        Debug.Log("Pop: " + refType.ToString());


        // STORY check and rewrite
        if (refType == typeof(Story))
        {
            RewriterMethod(ContainerStory.ins.actStory);
        }


        // Dialog check and rewrite
        else if (refType == typeof(Dialog))
        {
            RewriterMethod(ContainerStory.ins.actStory.DialogsContainer[refCoord]);
        }


        //Dialog Line value rewrite
        else if (refType == typeof(DialogLine))
        {
            RewriterMethod(ContainerStory.ins.actStory.DialogsContainer[refCoord].DialogContainer[refSubCoord]);
        }


        //Character values rewrite
        else if (refType == typeof(Character))
        {
            RewriterMethod(ContainerStory.ins.actStory.CharactersContainer[refCoord]);
        }

        //NPCs values rewrite
        else if (refType == typeof(NPC))
        {
            RewriterMethod(ContainerStory.ins.actStory.NPCsContainer[refCoord]);
        }

        //Clients Templates values rewrite
        else if (refType == typeof(Client))
        {
            RewriterMethod(ContainerStory.ins.actStory.ClientsTemplates[refCoord]);
        }

        //Achivements Templates values rewrite
        else if (refType == typeof(Achivement))
        {
            RewriterMethod(ContainerStory.ins.actStory.AchivementsTemplates[refCoord]);
        }

        //Room Templates values rewrite
        else if (refType == typeof(Room))
        {
            RewriterMethod(ContainerStory.ins.actStory.RoomsTemplates[refCoord]);
        }

        //Slots values rewrite
        else if (refType == typeof(Room))
        {
            RewriterMethod(ContainerStory.ins.actStory.SlotsContainer[refCoord]);
        }

        //Items Template values rewrite
        else if (refType == typeof(Item))
        {
            RewriterMethod(ContainerStory.ins.actStory.ItemsTemplates[refCoord]);
        }

        //Building Upgrades values rewrite
        else if (refType == typeof(BuildingUpgrade))
        {
            RewriterMethod(ContainerStory.ins.actStory.BuildingUpgradeContainer[refCoord]);
        }

        //Modifiers values rewrite
        else if (refType == typeof(Modifier))
        {
            RewriterMethod(ContainerStory.ins.actStory.ModifiersTemplates[refCoord]);
        }

        //TURN OUTPUT MESSAGE IF VALUE IS UNDER X
        ExeptionsValueOutput();

    }


    //REWRITING METHOD
    public void RewriterMethod<T>(T someList)
    {
        T _someList = someList;

        var prop = _someList.GetType().GetProperty(valueName);
        object e = prop.GetValue(_someList, null);
        
        if (prop.GetValue(_someList, null) != null)
        {

            //BOOLEANS
            if (prop.GetValue(_someList, null).GetType() == typeof(bool))
            {
                if (stringValue == "true" || stringValue == "True")
                {
                    prop.SetValue(_someList, true, null);
                }
                else if (stringValue == "false" || stringValue == "False")
                {
                    prop.SetValue(_someList, false, null);
                }
                else
                {
                    //if invalid
                    stringValue = "False";
                    textValue.text = stringValue;
                }
            }

            //INTEGER
            else if (prop.GetValue(_someList, null).GetType() == typeof(int))
            {
                int tempnum;

                    if (int.TryParse(stringValue, out tempnum))
                    {
                    tempnum = int.Parse(stringValue);
                        prop.SetValue(_someList, tempnum, null);
                    
                }
                else
                {
                    //if invalid
                    stringValue = "0";
                    textValue.text = stringValue;
                }

            }

            //FLOATS
            else if (prop.GetValue(_someList, null).GetType() == typeof(float))
            {
                    float tempnum;

                    if (float.TryParse(stringValue, out tempnum))
                    {
                        tempnum = float.Parse(stringValue);
                        prop.SetValue(_someList, tempnum, null);
                   
                }
                else
                {
                    //if invalid
                    stringValue = "0";
                    textValue.text = stringValue;
                }

            }

            /*
            else if (prop.GetValue(_someList, null).GetType() == typeof(List<>))
            {
                if (IsDigitsOnly(stringValue) == true)
                {
                    int tempnum = int.Parse(stringValue);
                    prop.SetValue(_someList, tempnum, null);
                }
                else
                {
                    //if invalid
                    stringValue = "0";
                    textValue.text = stringValue;
                }

            }*/

            else if (prop.GetValue(_someList, null).GetType() == typeof(string))
            {
                prop.SetValue(_someList, stringValue, null);
            }
        }
        else
        {
            Debug.Log("is undefined or null type");
        }
    }
    

    //-----------------------------------------------------------------------------------------------------
    //DROPDOWNs MUCH MORE TO ADD!!!!!
    public void InsertDropdown()
    {

        if (valueName == "OptionCondition1" || valueName == "OptionCondition2" || valueName == "OptionCondition3" || valueName == "OptionCondition4")
        {

            dropdown.ClearOptions();
            dropdown.value = 1;
            dropdown.value = 0;
            dropdown.AddOptions(_optionConditions);

            dropdown.gameObject.SetActive(true);

            textValue.gameObject.SetActive(false);

            for (int i = 0; i < _optionConditions.Count; i++)
            {
                if (_optionFunctions[i] == stringValue)
                {
                    dropdown.value = i;
                }
            }


        }
        else if (valueName == "OptionFunction1" || valueName == "OptionFunction2" || valueName == "OptionFunction3" || valueName == "OptionFunction4")
        {

            dropdown.ClearOptions();
            dropdown.value = 1;
            dropdown.value = 0;
            dropdown.AddOptions(_optionFunctions);

            dropdown.gameObject.SetActive(true);

            textValue.gameObject.SetActive(false);

            for (int i = 0; i < _optionFunctions.Count; i++)
            {
                if (_optionFunctions[i] == stringValue)
                {
                    dropdown.value = i;
                }
            }


        }
        else if (stringValue=="True"|| stringValue == "true"|| stringValue == "False"|| stringValue == "false")
        {

            List<string> boolStringList = new List<string>() { "True", "False" };
            dropdown.ClearOptions();
            dropdown.value = 1;
            dropdown.value = 0;
            dropdown.AddOptions(boolStringList);

            dropdown.gameObject.SetActive(true);

            textValue.gameObject.SetActive(false);

            for (int i = 0; i < boolStringList.Count; i++)
            {
                if (boolStringList[i]==stringValue)
                {
                    dropdown.value = i;
                }
            }

        }
        else { dropdown.gameObject.SetActive(false); }

    }

    public void DropDown_Index(int index)
    {
       
            RewriteStory("dropdownType", dropdown.options[index].text.ToString());

    }


    //----------------------------------------------------
    //BASIC BUTTON POPULATE
    public void PopulateButton(Type type , string name, string value)
    {
        refType = type;
                
        valueName = name;
        stringValue = value;

        textName.text = valueName;
        textValue.text = stringValue;

        //TURN OUTPUT MESSAGE IF VALUE IS UNDER X
        ExeptionsValueOutput();

        //CHECK IF IS A DROP DOWN AND APPLY IT
        InsertDropdown();

    }
    //METHOD OVERLOAD
    public void PopulateButton(Type type, int coord, string name, string value)
    {
        refType = type;

        refCoord = coord;
        valueName = name;
        stringValue = value;

        textName.text = valueName;
        textValue.text = stringValue;

        //TURN OUTPUT MESSAGE IF VALUE IS UNDER X
        ExeptionsValueOutput();

        //CHECK IF IS A DROP DOWN AND APPLY IT
        InsertDropdown();

    }
    //METHOD OVERLOAD
    public void PopulateButton(Type type, int coord, int subcoord, string name, string value)
    {

        refType = type;

        refCoord = coord;
        refSubCoord = subcoord;
        valueName = name;
        stringValue = value;

        textName.text = valueName;
        textValue.text = stringValue;

        //TURN OUTPUT MESSAGE IF VALUE IS UNDER X
        ExeptionsValueOutput();

        //CHECK IF IS A DROP DOWN AND APPLY IT
        InsertDropdown();

    }


    //-------------------------------------------------------------------------
    public void ExeptionsValueOutput()
    {

        //EXCEPTIONS
        if (stringValue == "0" && valueName != "ActTick" && valueName != "ActHour")
        {
            textValue.text = "Disabled";
        }
        else
        {
            
        }

    }

    //-------------------------------------------------------------------------
  
}
