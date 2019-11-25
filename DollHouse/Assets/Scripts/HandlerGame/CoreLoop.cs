using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreLoop : MonoBehaviour
{

    public static CoreLoop coreLoop;
    private void Awake()
    {
        coreLoop = this;

    }

    ControlTimer controlTimer = new ControlTimer();
    DialogChecker dialogChecker = new DialogChecker();
    StrategyGameLoop stategyLoop = new StrategyGameLoop();

    public delegate void OnCoreLoop();
    public static event OnCoreLoop OnCoreLoopTrigger;

    private void Start()
    {
        controlTimer.InitializeTimer();


    }

    //MAIN CHECKER---------------------------------------------------------------------------
    public void RunLoop()
    {
        controlTimer.AdvanceTimer();
        dialogChecker.CheckForDialogs();
        stategyLoop.StartLoop();

        //used to signal to Update GameInfo UI
        if (OnCoreLoopTrigger != null)
            OnCoreLoopTrigger();

    }

   

}
