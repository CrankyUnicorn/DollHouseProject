using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCharMov : MonoBehaviour {
    public float tickChange;
    private bool moveRight;
    private int roomSize=60;
    
    private Vector3 actPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        

        if (tickChange <= 0f)
        {
            tickChange = Random.Range(15f, 30f);

            moveRight = Random.value < 0.5f ? false : true;
        }
        else
        {
            tickChange -= Time.deltaTime;
        }

        if (tickChange > 5f && gameObject.GetComponent<GameScapeObjType>().atRoom != true)
        {
            float waveMovement = Mathf.Sin(transform.localPosition.x * 0.5f) * 0.5f + Mathf.Sin(transform.localPosition.x * 0.1f);//wave motion

            //leach effect
            if (transform.localPosition.y > 125)
            {
                waveMovement -= (transform.localPosition.y- 125) / 250;
            }
            else if (transform.localPosition.y < 125)
            {
                waveMovement += (125 - transform.localPosition.y) / 250;
            }

            if (moveRight == true)
            {
                transform.localPosition += new Vector3(1f, waveMovement, 0f);

            }
            else
            {
                transform.localPosition += new Vector3(-1f, waveMovement, 0f);
            }

        }
        else if(tickChange > 5f && gameObject.GetComponent<GameScapeObjType>().atRoom == true)
        {
            if (moveRight == true)
            {
                transform.localPosition += new Vector3(0.5f, 0f, 0f);
            }
            else
            {
                transform.localPosition += new Vector3(-0.5f, 0f, 0f);
            }

        }

        if (  gameObject.GetComponent<GameScapeObjType>().atRoom != true)
        {

            
            if (transform.localPosition.x > Screen.width * 2)
            {
                moveRight = false;
            }
            else if (transform.localPosition.x < -Screen.width * 2)
            {
                moveRight = true;
            }
        }
        else
        {
            if (transform.localPosition.x > roomSize)//roomsize pos
            {
                moveRight = false;
            }
            else if (transform.localPosition.x < -roomSize)//roomsize neg
            {
                moveRight = true;
            }

        }


        // Debug.Log(tickChange);
    }
}
