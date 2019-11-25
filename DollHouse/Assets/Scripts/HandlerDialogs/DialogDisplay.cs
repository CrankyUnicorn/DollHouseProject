using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogDisplay : MonoBehaviour
{

    public static DialogDisplay ins;
    private void Awake()
    {
        ins = this;
    }


    [Header("Select a text field")]
    public GameObject targetForName;
    [Header("Select a text field")]
    public GameObject targetForContent;
    [Header("Select a Background Box")]
    public GameObject targetForBG;
    [Header("Select a character Box")]
    public GameObject targetForCharacter1;
    public GameObject targetForCharacter2;
    public GameObject targetForCharacter3;
    [Header("Select a option box")]
    public GameObject targetForOptions;
    [Header("Select a option button")]
    public Transform OptionPrefab;

    private GameObject displayerPanel;

    private Coroutine actualRoutine;

    private List<int> DialogIndexs = new List<int>();

    private List<string> optionFunctions;
    
    private string sText;
    private string actualMessage;
    private string actualName;

    private int indexMessage=0;
    private bool completedMessage;
    private int indexDialog = 0;
    private bool completedDialog;
    private bool optionsPause;
    private int lm = 0;

    public delegate void DialogDisplayEventTrue();
    public static event DialogDisplayEventTrue OnDialogDisplayEventTrue;

    public delegate void DialogDisplayEventFalse();
    public static event DialogDisplayEventFalse OnDialogDisplayEventFalse;

    private void Start()
    {
        OptionFunctionsClass tempClass = new OptionFunctionsClass();
        optionFunctions = tempClass.optionFunctions;

        displayerPanel = targetForName.transform.parent.gameObject.transform.parent.gameObject;
        displayerPanel.SetActive(false);
        targetForOptions.SetActive(false);
    
    }


    //
    public void MessageList(List<int> da)//called externally by CoreLoop
    {
        DialogIndexs = da;
        MessageDisplayer();
    }
    

    public void MessageDisplayer()
    {

        if (DialogIndexs.Count != 0)
        {


            displayerPanel.SetActive(true); //opens the display panel to be sure to display the message

            int i = DialogIndexs[indexDialog];

            if (OnDialogDisplayEventTrue != null)
                OnDialogDisplayEventTrue();

            if (targetForContent != null && targetForName != null)//if thre is a place to display continue
            {
              
                 if (actualRoutine != null && completedMessage != true)//if you click and the message box while it is still playing then do this
                {
                    
                    StopCoroutine(actualRoutine);
                    DisplayTextNow(actualName, actualMessage);
                    

                }
                else if (ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[lm].TextOption1 != null && optionsPause != false)
                {
                    
                    DisplayOptions(i, lm);//this is the a impotant bit

                   
                }
                 else if (indexMessage < ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer.Count)
                {
                    actualName = ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Name;
                    actualMessage = ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Content;

                    //MESSAGE
                    if (actualName != null && actualMessage!=null)
                    {
                        actualRoutine = StartCoroutine(DisplayText(actualName, actualMessage));//show text via coroutine

                    }

                    //BG
                    if (ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Background != null)
                    {
                        
                        string imageName = ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Background;

                        if (Resources.Load<Sprite>("Sprite/" + imageName) != null)
                        {

                            Sprite spriteFromString = Resources.Load<Sprite>("Sprite/" + imageName) as Sprite;
                            targetForBG.GetComponent<Image>().sprite = spriteFromString;

                            var targetImage = targetForBG.GetComponent<Image>();
                            var tempImage = targetImage.color;
                            tempImage.a = 1f;
                            targetImage.color = tempImage;
                        }
                        else
                        {
                            //IMPORT PNG IMAGES FROM SPRITES FILE AND PLACE THEM IN GAME
                           
                            for (int id = 0; id < IOStory.ins.importedSprite.Count; id++)
                            {
                                
                                if (imageName== IOStory.ins.importedSprite[id])
                                {
                                    
                                    targetForBG.GetComponent<Image>().sprite = IOStory.ins.spriteList[id];
                                    var targetImage = targetForBG.GetComponent<Image>();
                                    var tempImage = targetImage.color;
                                    tempImage.a = 1f;
                                    targetImage.color = tempImage;
                                }

                            }


                        }

                    }
                    else
                    {

                        var targetImage = targetForBG.GetComponent<Image>();
                        var tempImage = targetImage.color;
                        tempImage.a = 0f;
                        targetImage.color = tempImage;
                    }
                    //char1
                    if (ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Body1 != null)
                    {

                        string imageName =  ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Body1;

                        if (Resources.Load<Sprite>("Sprite/" + imageName) != null)//CHANGE THIS!
                        {
                            Sprite spriteFromString = Resources.Load<Sprite>("Sprite/" + imageName) as Sprite;
                            targetForCharacter1.GetComponent<Image>().sprite = spriteFromString;

                            var targetImage = targetForCharacter1.GetComponent<Image>();
                            var tempImage = targetImage.color;
                            tempImage.a = 1f;
                            targetImage.color = tempImage;
                        }
                        else
                        {
                            //IMPORT PNG IMAGES FROM SPRITES FILE AND PLACE THEM IN GAME

                            for (int id = 0; id < IOStory.ins.importedSprite.Count; id++)
                            {

                                if (imageName == IOStory.ins.importedSprite[id])
                                {

                                    targetForCharacter1.GetComponent<Image>().sprite = IOStory.ins.spriteList[id];
                                    var targetImage = targetForCharacter1.GetComponent<Image>();
                                    var tempImage = targetImage.color;
                                    tempImage.a = 1f;
                                    targetImage.color = tempImage;
                                }

                            }


                        }
                    }
                    else
                    {

                        var targetImage = targetForCharacter1.GetComponent<Image>();
                        var tempImage = targetImage.color;
                        tempImage.a = 0f;
                        targetImage.color = tempImage;
                    }
                    //char2
                    if (ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Body2 != null)//CHANGE THIS!
                    {

                        string imageName =  ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Body2;
                        if (Resources.Load<Sprite>("Sprite/" + imageName) != null)
                        {
                            Sprite spriteFromString = Resources.Load<Sprite>("Sprite/" + imageName) as Sprite;
                            targetForCharacter2.GetComponent<Image>().sprite = spriteFromString;

                            var targetImage = targetForCharacter2.GetComponent<Image>();
                            var tempImage = targetImage.color;
                            tempImage.a = 1f;
                            targetImage.color = tempImage;
                        }
                        else
                        {
                            //IMPORT PNG IMAGES FROM SPRITES FILE AND PLACE THEM IN GAME

                            for (int id = 0; id < IOStory.ins.importedSprite.Count; id++)
                            {

                                if (imageName == IOStory.ins.importedSprite[id])
                                {

                                    targetForCharacter2.GetComponent<Image>().sprite = IOStory.ins.spriteList[id];
                                    var targetImage = targetForCharacter2.GetComponent<Image>();
                                    var tempImage = targetImage.color;
                                    tempImage.a = 1f;
                                    targetImage.color = tempImage;
                                }

                            }


                        }
                    }
                    else
                    {

                        var targetImage = targetForCharacter2.GetComponent<Image>();
                        var tempImage = targetImage.color;
                        tempImage.a = 0f;
                        targetImage.color = tempImage;
                    }
                    //char3
                    if (ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Body3 != null)//CHANGE THIS!
                    {

                        string imageName = ContainerStory.ins.actStory.DialogsContainer[i].DialogContainer[indexMessage].Body3;
                        if (Resources.Load<Sprite>("Sprite/" + imageName) != null)
                        {
                            Sprite spriteFromString = Resources.Load<Sprite>("Sprite/" + imageName) as Sprite;
                            targetForCharacter3.GetComponent<Image>().sprite = spriteFromString;

                            var targetImage = targetForCharacter3.GetComponent<Image>();
                            var tempImage = targetImage.color;
                            tempImage.a = 1f;
                            targetImage.color = tempImage;
                        }
                        else
                        {
                            //IMPORT PNG IMAGES FROM SPRITES FILE AND PLACE THEM IN GAME

                            for (int id = 0; id < IOStory.ins.importedSprite.Count; id++)
                            {

                                if (imageName == IOStory.ins.importedSprite[id])
                                {

                                    targetForCharacter3.GetComponent<Image>().sprite = IOStory.ins.spriteList[id];
                                    var targetImage = targetForCharacter3.GetComponent<Image>();
                                    var tempImage = targetImage.color;
                                    tempImage.a = 1f;
                                    targetImage.color = tempImage;
                                }

                            }


                        }
                    }
                    else
                    {

                        var targetImage=targetForCharacter3.GetComponent<Image>();
                        var tempImage = targetImage.color;
                        tempImage.a = 0f;
                        targetImage.color = tempImage;
                    }


                    lm = indexMessage;//last message index so this doesnt get affected by the increment under
                    indexMessage++;
                    completedMessage = false;
                        optionsPause = true;
                    

                }

                else//if there are NOT any more dialog lines on this dialog to play jump to next dialog on list or close dialog window/box
                {
                    indexMessage = 0;
                    lm = 0;
                   
                    if (indexDialog < DialogIndexs.Count)
                    {
                        indexDialog++;
                    }
                    if (indexDialog == DialogIndexs.Count)
                    {
                        optionsPause = false;

                        DialogIndexs.Clear();
                        indexDialog = 0;

                        if (OnDialogDisplayEventFalse != null)
                            OnDialogDisplayEventFalse();

                        displayerPanel.SetActive(false);//close the display panel

                    }

                }
            }

        }
    }

    //Display options if they are able
    public void DisplayOptions(int d, int i)
    {
        foreach (Transform child in targetForOptions.transform)
        {
            Destroy(child.gameObject);

        }

        
        targetForOptions.SetActive(true);
        if (ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption1 != null)
        {
           
            string op1Name = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption1;
            string op1Funct = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionFunction1;
            int op1Value = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionValue1;

            
            Transform op1 = Instantiate(OptionPrefab) as Transform;

            op1.GetComponent<OptionButton>().PopulateOptionButton(op1Name, op1Funct, op1Value);

            op1.SetParent(targetForOptions.transform);

        }else { targetForOptions.SetActive(false); }

        if (ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption2 != null)
        {
            string op2Name = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption2;
            string op2Funct = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionFunction2;
            int op2Value = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionValue2;

            
            Transform op2 = Instantiate(OptionPrefab) as Transform;

            op2.GetComponent<OptionButton>().PopulateOptionButton(op2Name, op2Funct, op2Value);

            op2.SetParent(targetForOptions.transform);

        }

        if (ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption3 != null)
        {
            string op3Name = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption3;
            string op3Funct = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionFunction3;
            int op3Value = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionValue3;

            
            Transform op3 = Instantiate(OptionPrefab) as Transform;

            op3.GetComponent<OptionButton>().PopulateOptionButton(op3Name, op3Funct, op3Value);

            op3.SetParent(targetForOptions.transform);

        }

        if (ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption4 != null)
        {
            string op4Name = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].TextOption4;
            string op4Funct = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionFunction4;
            int op4Value = ContainerStory.ins.actStory.DialogsContainer[d].DialogContainer[i].OptionValue4;

            
            Transform op4 = Instantiate(OptionPrefab) as Transform;

            op4.GetComponent<OptionButton>().PopulateOptionButton(op4Name, op4Funct, op4Value);

            op4.SetParent(targetForOptions.transform);

        }



    }

    public void DoFunction(string f, int v) //TONS OF WORK TO BE DONE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        Debug.Log(f+" | "+v);

        bool executable = false;

        if (f==optionFunctions[0])//jump to dialog
        {
            int tempindexdialog=0;
            for (int i = 0; i < ContainerStory.ins.actStory.DialogsContainer.Count; i++)
            {
                if (ContainerStory.ins.actStory.DialogsContainer[i].ID == v) { tempindexdialog = i; }

            }
            if (tempindexdialog!=0)
            {
                DialogIndexs.Insert(0, tempindexdialog);
                indexMessage = 0;
                lm = 0;
                executable = true;
            }

        }
        else if (f == optionFunctions[1])//jump to line
        {
            indexMessage = v;
            
            executable = true;
        }
        else if (f== optionFunctions[2])//end dialog
        {
            executable = true;
        }


        if (executable!=false)
        {
            foreach (Transform child in targetForOptions.transform)
            {
                Destroy(child.gameObject);

            }

            optionsPause = false;
            MessageDisplayer();
            targetForOptions.SetActive(false);
        }
       
    }


    // Coroutine
    IEnumerator DisplayText(string textN, string textC)
    {

        int d = 0;
        sText = "";
        targetForName.GetComponent<Text>().text = textN;
        while (d< textC.Length) {
            sText = sText + textC[d++];
            targetForContent.GetComponent<Text>().text=sText;
        yield return new WaitForSeconds(0.07f);
        }
        completedMessage = true;

        yield return null;
    }



    void DisplayTextNow(string textN, string textC)
    {
        targetForName.GetComponent<Text>().text = textN;
        targetForContent.GetComponent<Text>().text = textC;
            completedMessage = true;
    }
    //

 


}




