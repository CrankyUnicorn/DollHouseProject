using UnityEngine;



public class ContainerPreferences : MonoBehaviour {

    public static ContainerPreferences ins = null;

    void Awake()//overkill
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

    public Preferences loadedPreferences; //holds preferences to game during scene


}
