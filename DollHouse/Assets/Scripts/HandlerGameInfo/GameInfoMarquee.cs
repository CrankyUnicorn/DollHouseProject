using UnityEngine;
using System.Collections.Generic;

public class GameInfoMarquee : MonoBehaviour
{
    public static GameInfoMarquee ins;
    private void Awake()
    {
        ins = this;
    }

    /*
     This is a indirect aprouch to display and move a list of strings from the bottom up of the screen, 
     it can be adapted to other uses other then GUI, since it work similar to regular instanciation.
     Other then moving elements into defined position I opted to allow them to move dependent of a 
     selected list and being renew when not in the selected list. Not straight forward but allows for
     to be injected with a List of string on messageList and it will deal as a stand alone module.
    */

    public GameInfoLog gameLog = new GameInfoLog();

    private List<string> messageList = new List<string>() { "First Message", "Second Message", "Third Message","Fourth Message","Fifth Message","Sixth Message","Seventh Message"};
    private int messageListPreviousCount = 0;//used to transit from diferent lenght list INJECTION. EXTRA STUFF
    private List<Rect> messageRectList = new List<Rect>();//list to store Rect previeous position and data
    private string message;//used to store message in use from the messageList List

    public int messageSpace = 0;//distance between messages

    public float scrollSpeed = 30;//speed at of the Rect movement

    public float moveTime = 5;//at each time should the Rects move. this is indirectly done
    private float moveClock = 0;//time counter that goes from 0 to 10 and back to 0 once reaches 10
    
    public int messageMaxCapacity = 5;//used only to limit the max allowed ref int to allow Rect movement
    private int messageCapacity = 0;//used to limit the real ref int to allow Rect movement. the var above only caps this one being this one the real important one

    private bool messagesMove = false;//allows or denies the Rects to move

    private float moveToken = 0f;//switcher counter that allows or not the movement phase based in the amount of time to run the distance stored in the var bellow
    private float moveMaxDistance = 0;//stores the distance that the Rect should move. this done indirectly since they only move when allowed by the var above
   
    private List<int> messageSelectedList = new List<int>();//list to store what messages should move

    private int messageNextInLine = 0;//what message should be placed in the selected messageSelectedList list

    private int messageLastSelected;//used to disable duplicade messages on 0 at the beginning of the process

    private bool messageAdvance = true;//used to limit movement when capacity is reached and when there are fewer messages then messageMaxCapacity

    private int lastTick = -1;//used to check if already called the INJECTION this turn. EXTRA STUFF

    GUIStyle newGuiStyle = new GUIStyle();//GUI Style

    public Font SelectedFont;


    void MessagesCapacity()
    {
        if (messageList.Count==1)
        {
            messageCapacity = 1;
        }
        else if (messageList.Count > messageMaxCapacity)
        {
            messageCapacity = messageMaxCapacity;
        }
        else
        {
            messageCapacity = messageList.Count;
        }
        

    }


    void Timer()
    {

        moveClock += Time.deltaTime;

        if (moveTime < moveClock)
        {
            moveClock = 0;

            messagesMove = true;
        }
        
    }


    void MessageRectIniciator()
    {
        
        if (messageRectList.Capacity == 0 )
        {

            for (int i = 0; i < messageList.Count; i++)
            {
                Rect _messageRect = new Rect();

                messageRectList.Add(_messageRect);

            }

        }
        else if (lastTick != ContainerStory.ins.actStory.ActTick)
        {

            messageRectList.Clear();

            for (int i = 0; i < messageList.Count; i++)
            {
                Rect _messageRect = new Rect();

                messageRectList.Add(_messageRect);

            }

            messageAdvance = true;

        }

    }


    void MessageSelectorIniciation()
    {

        if (messageSelectedList.Capacity == 0)
        {
            for (int i = 0; i < messageCapacity; i++)
            {
                messageSelectedList.Add(0);

            }
        }
        else if (lastTick != ContainerStory.ins.actStory.ActTick)
        {
            messageSelectedList.Clear();

            for (int i = 0; i < messageCapacity; i++)
            {
                messageSelectedList.Add(0);

            }
        }

    }

    


    void MessageCycler()
    {
        if (moveToken==0)
        {
            moveToken=0.001f;

            if (messageNextInLine >= messageList.Count)
            {
                
                messageNextInLine =0;

                if (messageMaxCapacity>= messageList.Count)
                {
                    
                    messageAdvance = false;
                }

            }


            //this 2 lines under renew the reference int on the list used to call what rect should move 
            messageSelectedList.RemoveAt(0);
            messageSelectedList.Add(messageNextInLine);

            messageNextInLine++;
            
        }

    } 


    void MoverToken(float _moveMaxDistance)
    {
        if (messagesMove==true)
        {
        
            moveToken+= Time.deltaTime * scrollSpeed;

            if (moveToken>=_moveMaxDistance)
            {
                moveToken = 0;

                messagesMove = false;
            }
        }
    }


    void OnGUI()
    {
        //extra injection point helper
        messageListPreviousCount = messageList.Count;

        //INJECTION RELATED - EXTRA STUFF
        if (lastTick != ContainerStory.ins.actStory.ActTick)
        {
            

            //INJECTION POINT
            messageList = gameLog.CreateLog();
        }

        if (messageList.Count==0)
        {
            return;
        }

        //Sets the amount of messages to be displayed 
        MessagesCapacity();

        //timer for next message move
        Timer();

        //popluate List with new Rect
        MessageRectIniciator();

        //populate both lists for use
        MessageSelectorIniciation();


        

        //RECT SETTER
        for (int i = 0; i < messageList.Count; i++)
        {

            Rect messageRect = new Rect();

            messageRect = messageRectList[i];

            message = messageList[i];


            // Set up the message's rect if we haven't already
            if (messageRect.width == 0 || lastTick != ContainerStory.ins.actStory.ActTick)//Second part is EXTRA STUFF
            {
                Vector2 dimensions = GUI.skin.label.CalcSize(new GUIContent(message));

                // Use this to set the starting point of the RECTS
                messageRect.x = Screen.width - 10 - dimensions.x;
                messageRect.y = Screen.height;
                messageRect.width = dimensions.x;
                messageRect.height = dimensions.y;
                

                moveMaxDistance = messageRect.height + messageSpace;
            }


            
            //SET UP FONT AND ALIGMENT
            newGuiStyle.alignment=TextAnchor.MiddleRight;
            newGuiStyle.normal.textColor = Color.white;
            newGuiStyle.font = SelectedFont;
            newGuiStyle.fontSize = 14;

            //create labels
            GUI.Label(messageRect, message,newGuiStyle);

            //save rect into list
            messageRectList[i] = messageRect;

        }

        //ACTUAL MOVER
        if (messageAdvance)
        {

            messageLastSelected = 100000;//for disabling multiplication of movement at the beginning


            foreach (int id in messageSelectedList)
            {
                for (int i = 0; i < messageList.Count; i++)
                {

                    Rect messageRect = new Rect();

                    messageRect = messageRectList[i];

                    message = messageList[i];


                    if (i == id)
                    {
                        if (messageLastSelected != i)
                        {
                            messageLastSelected = i;

                            if (messagesMove == true)
                            {

                                messageRect.y -= Time.deltaTime * scrollSpeed;

                            }

                        }
                    }
                    else
                    {
                        if (messageLastSelected != i)
                        {

                            if (!messageSelectedList.Contains(i))
                            {

                                messageRect.y = Screen.height;
                            }
                        }
                    }


                    if (lastTick != ContainerStory.ins.actStory.ActTick)
                    {
                        messageRect.y = Screen.height;
                    }


                    messageRectList[i] = messageRect;
                }
                
            }

            lastTick = ContainerStory.ins.actStory.ActTick;//EXTRA STUFF
        }

        //allows or disalows movement of the rects
        MoverToken(moveMaxDistance);

        //cycles if there are more messages then the max allowed
        MessageCycler();


    }
}