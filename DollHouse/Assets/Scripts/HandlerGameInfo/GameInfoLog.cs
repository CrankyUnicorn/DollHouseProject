using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoLog  {

    public List<string> hopperInfoLog = new List<string>();

    private List<string> storyInfoLog = new List<string>();

    private List<string> finalInfoLog = new List<string>();

	
	public List<string> CreateLog () {

        finalInfoLog.Clear();

        storyInfoLog.Clear();


        if (ContainerStory.ins.actStory.ClientsContainer.Count==0)
        {
            storyInfoLog.Add("There's no clients in the building.");

        }
        else if (ContainerStory.ins.actStory.ClientsContainer.Count == 1)
        {
            storyInfoLog.Add("There's " + ContainerStory.ins.actStory.ClientsContainer.Count + " client in the building.");

        }
        else
        {
            storyInfoLog.Add("There're " + ContainerStory.ins.actStory.ClientsContainer.Count + " clients in the building.");

        }


        foreach (Client client in ContainerStory.ins.actStory.ClientsContainer)
        {
            string mood = client.Happiness >= 50 ? "Happy" : "Unhappy";

            storyInfoLog.Add("Client '"+ client.NickName +"' is "+mood+".");
        }


        finalInfoLog.AddRange(hopperInfoLog);

        finalInfoLog.AddRange(storyInfoLog);

        hopperInfoLog.Clear();

        return finalInfoLog;
    }
	
	
}
