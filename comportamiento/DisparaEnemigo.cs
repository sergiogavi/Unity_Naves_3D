using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaEnemigo : MonoBehaviour
{
    //Disparo y tiempo de aparicion
    public GameObject shot;
    public Transform shotSpawn;

    //tiempo de espera de disparo y ratio de disparo
    public float delay;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        //Comportamiento llama al metodo con este delay y con este ratio
        InvokeRepeating("Fire",delay,fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
    }
}
