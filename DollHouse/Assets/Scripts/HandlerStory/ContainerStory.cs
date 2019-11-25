using UnityEngine;



public class ContainerStory : MonoBehaviour  {

    public static ContainerStory ins =null;

    void Awake()//overkill just need but is easier this way to ref and help so there arent duplicates
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

    public Story actStory; // Holds all the information related to the game on game story monolithic class agregation... Crazy isn't it!


}


