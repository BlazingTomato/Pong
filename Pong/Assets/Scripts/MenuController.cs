using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    
    public GameObject AudioController;
    public GameObject audioMuteButton;
    

    
    
    public void onStartClicked(){
        AudioController.GetComponent<AudioController>().startBTNClicked();
    }

    public void onMusicClicked(){
        
        ColorBlock cb = audioMuteButton.GetComponent<Button>().colors; 

        if(AudioController.GetComponent<AudioController>().BGMusic.mute){
            cb.selectedColor = Color.white;
        }
        else{
            cb.selectedColor = Color.red;
        }
        
        AudioController.GetComponent<AudioController>().onMusicClicked();
        audioMuteButton.GetComponent<Button>().colors = cb;

    }

    public void playNewGameSFX(){
        AudioController.GetComponent<AudioController>().newGameClicked();
    }

    public void onExitClicked(){
        Application.Quit();
    }
    
}
