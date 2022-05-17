using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
  public float speed;
        private Rigidbody rig;
    // Start is called before the first frame update
   
 void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }


    void Start()
    {
        //forward = z disparado hacia adelante
        rig.velocity = transform.forward *speed;
    }

    
}
