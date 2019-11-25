using UnityEngine;

public class ControlTimer 
{
    
    public string timeDisplay;

    SetTimer timerSet = new SetTimer();
   

    public void InitializeTimer()
    {

        timerSet.SetTime();

       

    }


    public void AdvanceTimer()
    {
        
        ContainerStory.ins.actStory.ActTick++;

        timerSet.TimeController();

        
      
    }



}
