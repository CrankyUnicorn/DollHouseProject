using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadePanel : MonoBehaviour {

    public static FadePanel fade;
    private void Awake()
    {
        fade = this;
    }

    public string targetScene;
    public bool EnableUpdate;

    // Use this for initialization
    void Start () {
        
        StartCoroutine(FadeImage(true));
    }

    private void Update()
    {
        if (EnableUpdate)
        {
            if (Input.anyKey || Input.GetMouseButtonDown(0))
            {
                OnButtonClick();
            }
        }
    }

    public void OnButtonClick()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime*4)
            {
                
                // set color with i as alpha
                this.GetComponent<Image>().color = new Color(0, 0, 0, i);
                yield return null;
            }

            this.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime*3)
            {
                // set color with i as alpha
                this.GetComponent<Image>().color = new Color(0, 0, 0, i);
                yield return null;
            }

            this.GetComponent<Image>().color = new Color(0, 0, 0, 1);

            //directs ask Scene Manager to go to passed in scene
            if (targetScene =="Quit")
            {
                Application.Quit();
            }
            else if (targetScene!=null)
            {
                SceneManager.LoadScene(targetScene);
            }
           
        }
    }
}

