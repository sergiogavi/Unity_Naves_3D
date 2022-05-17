using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class getPunt : MonoBehaviour
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

    public void getPuntua()
    { 
    pt.text= gc.getPuntuacionFinal();
    }
}
