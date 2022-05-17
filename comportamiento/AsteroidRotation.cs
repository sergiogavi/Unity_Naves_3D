using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
  
    private Rigidbody rig;
    //velocidad de giro
    public float tumble;
    void Awake()
    {
        rig= GetComponent<Rigidbody>();
    }


    void Start(){
        //Solo afectara a la rotacion del objeto en este caso el asteroide
        //Se hace random para que el giro sea diferente 
      Vector3 angularVelocity = new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1)).normalized;
      rig.angularVelocity = angularVelocity*tumble;
    }
}


