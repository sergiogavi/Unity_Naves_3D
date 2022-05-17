using UnityEngine;
using System.Collections;
/**
* Classe que permet moure i rotar un objecte.
* Utilitza atributs púlics per a la edición Unity
* sergi.grau@fje.edu
* 1.0 27.03.2015
*/

//Clase tipo que contendra variables de limite del mapa 
//Marcamos como serializable para que en Unity nos deje acceder a los datos
[System.Serializable]
public class Boundary{

    public float xMin,xMax,zMin,zMax;

}

public class Moviment : MonoBehaviour {
[Header("Movement")]
//public float velocitat = 10.0F;
public float velocitatRotacio = 10.0F;
public float speed;
public float boostSpeed;
public float boostTimeArma;
public float boostTimeRot;
public bool boosting;
public bool boostArma;
public bool boostRot;
//Inclinacion
public float tilt;
//Instanciamos la clase Boundary/limites mapa 
public Boundary boundary;



private Rigidbody rig;
[Header("Shooting")]
//Prefab de bala
public GameObject shot;
//Zona donde aparece la bala
public Transform shotSpawn; 
//Cada cuanto tiempo minimo se puede disparar
public float fireRate;
private float nextFire;
void Awake(){
    rig = GetComponent<Rigidbody>();
}

void Start(){
    boosting=false;
    boostSpeed=0;
    boostTimeArma=0;
    speed=14;
    fireRate=0.3f;
    velocitatRotacio = 30.0F;
}
void Update()
{
    //Instanciamos el prefab disparo en la posicion de spawn de bala
    if(Input.GetButton("Fire1") && Time.time > nextFire)
    {
        nextFire = Time.time+fireRate;
        Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
    }
    if(boosting){

        boostSpeed+=Time.deltaTime;
        if(boostSpeed>=5){
            speed=14;
            boostSpeed=0;
            boosting=false;
        }
    }
   if(boostArma){

        boostTimeArma+=Time.deltaTime;
        if(boostTimeArma>=5){
          fireRate=0.3f;
            boostTimeArma=0;
            boostArma=false;
        }
    }

      if(boostRot){

        boostTimeRot+=Time.deltaTime;
        if(boostTimeRot>=5){
          velocitatRotacio = 30.0F;
            boostTimeRot=0;
            boostRot=false;
        }
    }

}

  void OnTriggerEnter(Collider other){

       if(other.tag=="potenciadorSpeed"){
            boosting=true;
            speed=30;
             Destroy(other.gameObject);
       }
       if(other.tag=="PotenciadorArma"){
            boostArma=true;
            fireRate=0;
             Destroy(other.gameObject);
       }

       if(other.tag=="Potenciador3"){
            boostRot=true;
            velocitatRotacio = 150.0F;
             Destroy(other.gameObject);
       }
   }
void FixedUpdate() {

    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    //Moviemiento sobre el eje x, y ejece z la y no nos interesa
    Vector3 movement = new Vector3(moveHorizontal,0f,moveVertical);

    rig.velocity = movement *speed;


    //Mathf captura clamp valor minimo/maximo 
    rig.position = new Vector3(Mathf.Clamp(rig.position.x,boundary.xMin,boundary.xMax),0f,Mathf.Clamp(rig.position.z,boundary.zMin,boundary.zMax));

    //Moviemiento de rotacion al mover la nave iz o der 
    //*-tilt para que se gire al lado que nos interesa
    

float rotacio = Input.GetAxis("Horizontal") * velocitatRotacio;

rotacio *= Time.deltaTime;

transform.Rotate(0, rotacio, 0);
//rig.rotation = Quaternion.Euler(0f,0f,rig.velocity.x * -1);
}


}