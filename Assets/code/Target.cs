using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;       
    public GameObject waypointA;    
    public GameObject waypointB;    

    public float speed = 2f;       
    public float waitTime = 2f;     

    private float realTime;         
    private bool movingTowardsB = true;  
    private bool isWaiting = false;      

    void Update()
    {
        
        if (!isWaiting)
        {
            
            if (movingTowardsB)
            {
                target.transform.position = Vector3.MoveTowards(target.transform.position, waypointB.transform.position, speed * Time.deltaTime);

                
                if (Vector3.Distance(target.transform.position, waypointB.transform.position) < 0.1f)
                {
                    movingTowardsB = false;
                    StartCoroutine(Esperar()); 
                }
            }
            else
            {
                target.transform.position = Vector3.MoveTowards(target.transform.position, waypointA.transform.position, speed * Time.deltaTime);

                
                if (Vector3.Distance(target.transform.position, waypointA.transform.position) < 0.1f)
                {
                    movingTowardsB = true;
                    StartCoroutine(Esperar()); 
                }
            }
        }
    }

    
    IEnumerator Esperar()
    {
        isWaiting = true;              
        yield return new WaitForSeconds(waitTime);  
        isWaiting = false;             
    }
}

    

