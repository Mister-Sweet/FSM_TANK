using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{ 
    public float health;


    public MyState patrolState;
    public MyState chaseState;
    public MyState attackState;
    public MyState deadState;
    public MyState recoverState;

    

    void Start()
    {
        patrolState.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        //Reduce health
        if (collision.gameObject.tag == "Bullet" && !recoverState.enabled)
        {
            health -= 25;
        } 
        else if(recoverState.enabled && collision.gameObject.tag== "Player")
        {
            Destroy(GetComponent<GameObject>());
        }
    }


}
