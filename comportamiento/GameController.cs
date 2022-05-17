using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameController : MonoBehaviour
{

    public float esperaAsteroide;
    public int enemigoCount;
    public int potenciadoresSpeed;
    public int potenciadoresArma;
    public int potenciadoresRot;
    //ArrayEnemigos meteoritos o naves
    public GameObject enemigo;
    public GameObject nave;
    //Potenciadores
    public GameObject potenciadorSpeed;
    public GameObject PotenciadorRayo;
     public GameObject Potenciador3;
    //posicion donde se instanciaran meteoritos
    public Vector3 spawnValues;
    public float esperaInicial;
    public float tiempoEntreOleada;

    public int puntuacion;
    public Text puntuacionText;
    // Start is called before the first frame update

  public string arrayItem;
  public string arrayItems;
    //ArrayList Puntuaciones 
   public static ArrayList puntuaciones = new ArrayList();
    void Start()
    {
        puntuacion=0;
        UpdatePuntuacion();
       // setPuntuacionFinal();
        //llamamos al metodo de corutina
        StartCoroutine(SpawnWaves());
    }

    // corutina que instancia enemigos según la cantidad definida
    IEnumerator SpawnWaves()
    {
        //Definimos la espera inicial
          yield return new WaitForSeconds(esperaInicial);
          while(true){

    
            //Meteoritos
        for (int i=0;i<enemigoCount;i++){
     
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
       Instantiate(enemigo,spawnPosition,Quaternion.identity);
        yield return new WaitForSeconds(esperaAsteroide);
        }
        
        //Potenciador Rotation
         for (int i=0;i<potenciadoresRot;i++){
     
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
       Instantiate(Potenciador3,spawnPosition,Quaternion.identity);
        yield return new WaitForSeconds(esperaAsteroide);
        }

           //Potenciador Arma 
         for (int i=0;i<potenciadoresArma;i++){
     
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
       Instantiate(PotenciadorRayo,spawnPosition,Quaternion.identity);
        yield return new WaitForSeconds(esperaAsteroide);
        }

        //NAVES
        for (int i=0;i<enemigoCount;i++){
    
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
       Instantiate(nave,spawnPosition,Quaternion.identity); 
        yield return new WaitForSeconds(esperaAsteroide);
        }

        //Potenciador Speed 
         for (int i=0;i<potenciadoresSpeed;i++){
     
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
       Instantiate(potenciadorSpeed,spawnPosition,Quaternion.identity);
        yield return new WaitForSeconds(esperaAsteroide);
        }



          yield return new WaitForSeconds(tiempoEntreOleada);
        }
    }

    //Metodo que suma la puntuacion del jugador
    public void AddPuntuacion(int value){

        puntuacion +=value;
        UpdatePuntuacion();
        setPuntuacionFinal();
    }
    void UpdatePuntuacion(){
        puntuacionText.text = "Press R to restart or SPACE to mute - Score: "+puntuacion;
       
        //setPuntuacionFinal();
    }

    public void setPuntuacionFinal()
    {
       string msg = "Puntuacion: " + puntuacion;
        puntuaciones.Add(msg);
    }

    public string getPuntuacionFinal()
    { 
     

     foreach (string item in puntuaciones)  
            { 

                arrayItem = string.Format($"{item}");  
                arrayItems+="Sergio: "+arrayItem+"\n";
              // return arrayItem;
                
           }

      return arrayItems;
    }

}
