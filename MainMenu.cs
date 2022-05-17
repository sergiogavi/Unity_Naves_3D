using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
         public Text pt;
    GameController gc=new GameController();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

       public void EscenaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

      public void getPuntua()
    { 
        pt.text= gc.getPuntuacionFinal();
        
    }
}
