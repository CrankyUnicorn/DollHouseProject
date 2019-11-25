using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour {

    public float roamRadius = 1000;
    public float difVectorX = 0f;
    public float difVectorY = 0f;
    public bool changDir = false;

    private Vector3 moveVector;

   
	
	// Update is called once per frame
	void Update () {
        FreeRoam();

    }

    void FreeRoam()
    {
        float movVector = Random.Range(-roamRadius, roamRadius);
        if (changDir==true)
        {
            difVectorX -= 0.1f;
            if (movVector < 0)
            {
                difVectorY += 0.1f;
            }
            else { difVectorY -= 0.1f; }
        }
        else if (changDir == false)
        {
            difVectorX += 0.1f;
            if (movVector < 0)
            {
                difVectorY -= 0.1f;
            }
            else { difVectorY += 0.1f; }
           
        }

        if (transform.position.x < -roamRadius)
        {
            difVectorX = 1f;
        }
        else if(transform.position.x > roamRadius)
        {
            difVectorX = -1f;
        }

        if (transform.position.y < -roamRadius)
        {
            difVectorY = 1f;
        }
        else if (transform.position.y > roamRadius)
        {
            difVectorY = -1f;
        }

        if (difVectorX < movVector) { changDir = false; }
        else if (difVectorX > movVector) { changDir = true; }
        moveVector = new Vector3(difVectorX,difVectorY,0);
        
        transform.position += moveVector;
        


    }
}
