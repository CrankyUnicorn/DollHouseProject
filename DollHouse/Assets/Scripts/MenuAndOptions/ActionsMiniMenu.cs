using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsMiniMenu : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey("escape")) { }
    }

    public void destroyThis()
    {
        Destroy(this.transform.gameObject);
    }
}
