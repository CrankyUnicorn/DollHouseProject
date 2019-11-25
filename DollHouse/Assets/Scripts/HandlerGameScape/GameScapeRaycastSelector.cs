using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScapeRaycastSelector : MonoBehaviour {

    public static GameScapeRaycastSelector ins;
    private void Awake()
    {
        ins = this;
    }

    public List<RaycastResult> raycastRaycastList;


    private void Start()
    {
        raycastRaycastList = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update () {

        ObjsUnderPointerGameScape();
      
    }

    //LIST OBJECTS UNDER POINTER 
    private void ObjsUnderPointerGameScape()
    {

        if (GameScapeReferencesHandler.ins.disableRaycast ==false)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            raycastRaycastList.Clear();
            EventSystem.current.RaycastAll(pointer, raycastRaycastList);
        }
    }

   
}
