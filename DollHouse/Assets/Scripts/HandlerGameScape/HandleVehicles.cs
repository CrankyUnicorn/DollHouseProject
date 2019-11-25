using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleVehicles : MonoBehaviour {
    public string typeViecle;
   private string directionTram;
    private Vector3 moveVehicle = new Vector3();

    // Use this for initialization
    void Start () {
        moveVehicle = this.transform.localPosition;

        int randomDirection = Mathf.RoundToInt(Random.Range(0f, 2f));
        if (randomDirection==0)
        {
            directionTram = "left";
        }
        else
        {
            directionTram = "right";
        }
	}
	
	// Update is called once per frame
	void Update () {
        //util

        if (typeViecle == "Tram")
        {
            
            
            if (directionTram == "left")
            {
                if (this.transform.localPosition.x < -4000)
                {
                    directionTram = "right";
                }
                moveVehicle += new Vector3(-1f, 0f, 0f);
            }
            else if (directionTram == "right")
            {
                if (this.transform.localPosition.x > 4000)
                {
                    directionTram = "left";
                }
                moveVehicle += new Vector3(1f, 0f, 0f);
            }
            this.transform.localPosition = moveVehicle;
        }

        if (typeViecle == "Car")
        {
            
            if (directionTram == "left")
            {
                Vector3 carScale = new Vector3(1f, 1f, 1f);
                this.transform.localScale = carScale;
                moveVehicle += new Vector3(-2f, 0f, 0f);
                if (this.transform.localPosition.x < -4000)
                {
                    directionTram = "right";
                  
                }
                
            }
            else if (directionTram == "right")
            {
                Vector3 carScale = new Vector3(-1f, 1f, 1f);
                this.transform.localScale = carScale;
                moveVehicle += new Vector3(2f, 0f, 0f);
                if (this.transform.localPosition.x > 4000)
                {
                    directionTram = "left";
                    
                }
               
            }
            float bumpEffectAble = Random.Range(0f, 10f);
            Vector3 bumpEffectV=new Vector3(0f, 0f, 0f); ;

            if (bumpEffectAble>8)
            {
                float bumpEffect = Random.Range(-1f, 1f);
                bumpEffectV = new Vector3(0f, bumpEffect, 0f);
                moveVehicle += bumpEffectV;
            }

            this.transform.localPosition = moveVehicle;

            if (bumpEffectAble > 8)
            {
                moveVehicle -= bumpEffectV;
            }
        }


    }
}
