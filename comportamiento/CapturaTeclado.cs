// Mutes-Unmutes the sound from this object each time the user presses space.
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CapturaTeclado : MonoBehaviour {
    AudioSource audio;
    
    void Start() {
        audio = GetComponent<AudioSource>();
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            if (audio.mute)
                audio.mute = false;
            else
                audio.mute = true;

        if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
    }
}