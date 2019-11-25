using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerButton : MonoBehaviour {

    public GameObject _gameScapeDisplay;
    public string workerName;
    public bool workingHere;
    public string workingAt;

    private void Start()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = workerName+" at "+workingAt;

        if (workingHere) { this.transform.GetChild(0).GetComponent<Text>().color = Color.red; }
        else { this.transform.GetChild(0).GetComponent<Text>().color = Color.white; }
    }

    public void OnButtonClick()
    {
        foreach (Room _slot in ContainerStory.ins.actStory.SlotsContainer)
        {
            if (_slot.Name== workerName)
            {
                GameScapeReferencesHandler.ins.selectedSlot = _slot;
            }
        }
        foreach (Character _char in ContainerStory.ins.actStory.CharactersContainer)
        {
            if (_char.FirstName == workerName)
            {
                GameScapeReferencesHandler.ins.selectedCharacter = _char;
            }
        }
        

    }

    public void PopulateWorkerButton(string n, bool wH, string wA)
    {
        workerName = n;
        workingHere = wH;
        workingAt = wA;
    }
}
