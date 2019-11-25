using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameScapeDisplay : MonoBehaviour
{
    public static GameScapeDisplay ins;
    private void Awake()
    {
        ins = this;
    }

    public GameObject gameScapePanel;
    public GameObject gameScapeSlider;

    public GameObject gameScapeSkyCycle;
    public GameObject gameScapeSkyClouds;
    
    public Transform[] parallaxLayers;
    public float[] multiplierLayer;

    private float actScale=5;

    private int minX = -300;
    private int maxX = 300;
    private int minY = -300;
    private int maxY = 300;

    private float hAxis;
    private float vAxis;
    private float zAxis;

    private float dynaForceX;
    private float dynaForceY;

    private float scaleLerp=1f;

    private bool mouseDownCheck;//working

    private float targetSkyHour;
    private float actSkyHour;

    IEnumerator ChangeSky;


    // Use this for initialization
    void Start()
    {
        gameScapePanel.SetActive(false);
        gameScapePanel.SetActive(true);//delete this after prototyping
    }

    
    void Update() //deals with movement and sky updates
    {
        //sets fine tune of the mouse moving force
            hAxis = 2 * Input.GetAxis("Mouse X");
            vAxis = 4 * Input.GetAxis("Mouse Y");
        
       
        //zoom
        zAxis = 10 * Input.GetAxis("Mouse ScrollWheel");
        //secundary input for zoom
        if (Input.GetKey(KeyCode.PageDown) == true) { zAxis = 1; }
        if (Input.GetKey(KeyCode.PageUp) == true) { zAxis = -1; }


        //check if mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownCheck = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDownCheck = false;
        }
        
        //--------------------------------------------

        //Called Methods
        if (GameScapeReferencesHandler.ins.disableGameScapeMovement == false)
        {
            GameScapeMovement(); //MOVEMENT OF CAMERA, PARALLAX, ZOOM AND LIMITERS WITH DYNAMICS
        }

        SkyCycleMovement();//TURNS THE SKY

        CloudMovement();//CLOUD MOVEMENT
    }

    //----------------------------------------------------------

    //MOVEMENT OF CAMERA, PARALLAX, ZOOM AND LIMITERS WITH DYNAMICS
    void GameScapeMovement()
    {
        Vector3 _tempVectorX = new Vector3(0f, 0f, 0f);
        Vector3 _tempVectorY;


        if (mouseDownCheck == true)
        {
            dynaForceX += hAxis / 10;
            dynaForceY += vAxis / 10;

        }
        else
        {
            dynaForceX = Mathf.Lerp(dynaForceX, 0f, 0.05f);
            dynaForceY = Mathf.Lerp(dynaForceY, 0f, 0.05f);

        }


        _tempVectorX = new Vector3(dynaForceX, 0f, 0f);
        gameScapeSlider.transform.localPosition += _tempVectorX;

        _tempVectorY = new Vector3(0f, dynaForceY, 0f);
        gameScapeSlider.transform.localPosition += _tempVectorY;

        //PARALLAX EFFECTOR
        for (int i = 0; i < parallaxLayers.Length; i++)
        {

            Vector3 _tempVectorP = new Vector3(_tempVectorX.x * multiplierLayer[i], 0f, 0f);
            parallaxLayers[i].localPosition += _tempVectorP;
        }


        //X LIMIT CORRECTOR
        if (gameScapeSlider.transform.localPosition.x >= maxX)
        {
            if (dynaForceX < 5f) { dynaForceX = 5f; }
            dynaForceX = Mathf.Lerp(-dynaForceX / 2, 0f, 0.05f);

        }
        else if (gameScapeSlider.transform.localPosition.x <= minX)
        {
            if (dynaForceX > -5f) { dynaForceX = -5f; }

            dynaForceX = Mathf.Lerp(-dynaForceX / 2, 0f, 0.05f);
        }


        //Y LIMIT CORRECTOR
        if (gameScapeSlider.transform.localPosition.y <= minY)
        {
            if (dynaForceY > -5f) { dynaForceY = -5f; }
            dynaForceY = Mathf.Lerp(-dynaForceY / 2, 0f, 0.5f);
        }
        else if (gameScapeSlider.transform.localPosition.y >= maxY)
        {
            if (dynaForceY < 5f) { dynaForceY = 5f; }
            dynaForceY = Mathf.Lerp(-dynaForceY / 2, 0f, 0.5f);
        }


        //ZOOM ON MOUSE SCROLL
        if (zAxis > 0f) // forward
        {
            if (actScale < 10)
            {
                actScale++;
            }
        }
        else if (zAxis < 0f) // backwards
        {
            if (actScale > 1)
            {
                actScale--;
            }
        }
        //ACTUAL ZOOM ACTION
        scaleLerp = Mathf.Lerp(scaleLerp, actScale / 8 + 1, 0.05f);
        Vector3 _tempVector3 = new Vector3(scaleLerp, scaleLerp, 0f);
        gameScapeSlider.transform.localScale = _tempVector3;
    }


    //-------------------------------------------------------------------------------------

    //TURNS THE SKY AROUND
    public void SkyCycleMovement()
    {
        if (targetSkyHour != (float)ContainerStory.ins.actStory.ActHour)
        {
            actSkyHour = targetSkyHour;
            targetSkyHour = (float)ContainerStory.ins.actStory.ActHour;

            if(ChangeSky!=null)
            StopCoroutine(ChangeSky);

            ChangeSky = ChangeSkyMove();
            StartCoroutine(ChangeSky);
          //  Debug.Log(actSkyHour); Debug.Log(targetSkyHour);
        }
    }

    //CLOUD MOVEMENT
    void CloudMovement()
    {
        Vector3 cloudRotate = new Vector3(0f, 0f, 0.01f);
        gameScapeSkyClouds.transform.Rotate(cloudRotate);
    }

    //SKY MOVEMENT
    IEnumerator ChangeSkyMove()
    {

        while (actSkyHour<targetSkyHour) {
            actSkyHour += (targetSkyHour-actSkyHour)*0.05f;
            //Debug.Log(actSkyHour);
            Vector3 skyHourVector = new Vector3(0f, 0f, actSkyHour*15-180);
            gameScapeSkyCycle.transform.localEulerAngles = skyHourVector;

            yield return new WaitForSeconds(0.03f);
        }
        
    }
   
}
