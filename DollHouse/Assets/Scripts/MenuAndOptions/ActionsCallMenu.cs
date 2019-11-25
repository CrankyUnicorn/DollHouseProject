using UnityEngine;

public class ActionsCallMenu : MonoBehaviour {

    public GameObject miniMenu;

    private static bool closePopMenu = false;
    public GameObject refMainCanvas;
    public GameObject refGO;
   

    void Update()
    {

        if (Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.P))
        {
            CallMenu();
        }
        if (Input.GetKeyUp("escape") || Input.GetKeyUp(KeyCode.P))
        {
            CloseMenu();
        }

    }

    public void CallMenu()
    {
        if (refGO==null)
        {
            GameObject go = Instantiate(miniMenu) as GameObject;
            go.transform.SetParent(refMainCanvas.transform, false);
            go.transform.SetAsLastSibling();
            refGO = go.gameObject;
        }
           
    }

    public void CloseMenu()
    {
        if (refGO!=null && closePopMenu == true)
        {
            Destroy(refGO);

            closePopMenu = false;
        }
        else
        {
            closePopMenu = true;
        }
        
    }
}
