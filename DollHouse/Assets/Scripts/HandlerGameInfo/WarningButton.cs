using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningButton : MonoBehaviour {
    public Text warningText;

    public void DestroyThis()
    {
        if (GameInfoDisplay.ins.infoPanelOpen!=false)
        {
            GameInfoDisplay.ins.RefeshStatus();
        }
      
        Destroy(this.gameObject);
    }

    public void PopulateMessageBotton(string _passString)
    {
        warningText.text = _passString;
    }
}
