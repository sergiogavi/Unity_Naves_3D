using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionJugador;
  //  public GameObject = NavePrinc;GameObject.FindWithTag ("Respawn");
    private GameController gameController;
    public int puntuacionVal;
   

  


    void Start(){
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        //Referencia a game controller
     gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();


    //moviment=FindObjectOfType<Moviment>();

    }

    //Al entrar en la zona del objeto se destruye el objeto que entra
    //Y el mismo meteorito
   

   void OnTriggerEnter(Collider other){

   // if(other.CompareTag("Enemy")) return;

    if(other.tag=="Enemy" || other.tag=="potenciadorSpeed" || other.tag=="PotenciadorArma") return;
   // if(other.CompareTag("potenciadorSpeed"))  return;
    //Instanciamos la explosion del asteroide 
    Instantiate(explosion,transform.position,transform.rotation);
    //Si el componente que entra en el area del meteorito es el jugador
    if(other.CompareTag("Jugador"))
    { 
    //Instanciamos la explosion del jugador
     Instantiate(explosionJugador,other.transform.position, other.transform.rotation);
       
   }
    gameController.AddPuntuacion(puntuacionVal);
    Destroy(other.gameObject);
    Destroy(gameObject);

   }
}
