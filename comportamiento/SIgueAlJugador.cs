using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIgueAlJugador : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Jugador; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Jugador.transform.position + new Vector3(0,1,-6);
    }
}
