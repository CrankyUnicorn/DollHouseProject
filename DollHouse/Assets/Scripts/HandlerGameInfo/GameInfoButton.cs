using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoButton : MonoBehaviour {
    

    public Text textStatusBox;
    public Dropdown statusDropdown;
    public Transform warningPrefab;

    private List<string> roomsList = new List<string>();
    private List<int> roomsListInt = new List<int>();
    private string characterName;

    private GameObject targetPanel;


    public void PopulateStatusBotton(string t) {
        textStatusBox.text = t;
	}


    public void PopulateStatusDropDown()
    {
        roomsList.Add("None");
        roomsListInt.Add(0);

        statusDropdown.ClearOptions();
        statusDropdown.value = 1;
        statusDropdown.value = 0;
        foreach (Room roomsAble in ContainerStory.ins.actStory.SlotsContainer)
        {
            if (roomsAble.Able==true && roomsAble.Unlock==true)
            {
                roomsList.Add(roomsAble.Name);
                roomsListInt.Add(roomsAble.HouseSlot);
            }
        }
        statusDropdown.AddOptions(roomsList);
    }

    public void NominateCharacter(string _charN)
    {
        characterName = _charN;
        Debug.Log(characterName);
    }

   /* public void CharacterWorkRoom(int index)
    {
        
        foreach (Room roomWork in ContainerStory.ins.actStory.SlotsContainer)
        {
            if (roomWork.HouseSlot == roomsListInt[index])
            {
                foreach (Character charac in ContainerStory.ins.actStory.CharactersContainer)
                {
                    if (charac.FirstName==characterName)
                    {

                        bool vacancy = false;
                        for (int i = 0; i < _roomWork.WorkersCapacity; i++)
                        {

                            if (_roomWork.WorkersList[i] == null || _roomWork.WorkersList[i] == _charac.FirstName)
                            {
                                _roomWork.WorkersList[i] = _charac.FirstName;
                                PostWarning("Character placed in " + _roomWork.Name + " " + i + "# slot!");
                                GameScapeActions.ins.RemoveCharOtherRoomsSlots(_charac.FirstName, _roomWork.HouseSlot, i);//(who,slot,roomslot)
                                vacancy = true;
                                break;
                            }
                        }
                        if (vacancy == false)
                        {
                            PostWarning("No Work Slots Avaible!");

                        }
                        charac.Place = roomWork.Name;
                        charac.Slot = roomWork.HouseSlot;
                        
                    }
                }
                break;
            }
        }
    }

    private void RemoveCharOtherRoomsSlots(string who, int notwhere, string notAt)
    {
        foreach (Room roomWork in ContainerStory.ins.actStory.SlotsContainer)
        {
            if (roomWork.HouseSlot != notwhere)
            {
                if (roomWork.RoomWorkSlot1 == who)
                {
                    roomWork.RoomWorkSlot1 = null;
                }
                if (roomWork.RoomWorkSlot2 == who)
                {
                    roomWork.RoomWorkSlot2 = null;
                }
                if (roomWork.RoomWorkSlot3 == who)
                {
                    roomWork.RoomWorkSlot3 = null;
                }
            }
            if (roomWork.HouseSlot == notwhere)
            {
                if (roomWork.RoomWorkSlot1 == who && "Slot1"!=notAt)
                {
                    roomWork.RoomWorkSlot1 = null;
                }
                if (roomWork.RoomWorkSlot2 == who && "Slot2" != notAt)
                {
                    roomWork.RoomWorkSlot2 = null;
                }
                if (roomWork.RoomWorkSlot3 == who && "Slot3" != notAt)
                {
                    roomWork.RoomWorkSlot3 = null;
                }
            }
}

    }*/
    private void PostWarning(string _passString)
    {
        targetPanel = GameObject.FindGameObjectWithTag("MainCanvas");
        Transform go = Instantiate(warningPrefab) as Transform;

       go.GetComponent<WarningButton>().PopulateMessageBotton(_passString);
        
        go.SetParent(targetPanel.transform,false);
        go.SetAsLastSibling();

    }

}
