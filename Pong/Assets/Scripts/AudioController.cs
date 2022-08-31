using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public GameObject Audio;

    public AudioSource BGMusic;
    public AudioSource StartSFX;
    public AudioSource InGameBGMusic;
    public AudioSource BounceSFX;
    public AudioSource ScoreSFX;
    public AudioSource GameOverSFX;
    
    public void startBTNClicked(){
        StartSFX.Play();
        DontDestroyOnLoad(Audio);
        SceneManager.LoadScene(1);

        if(!BGMusic.mute){
            BGMusic.mute = true;
            InGameBGMusic.Play();
        }
    }

    public void onMusicClicked(){
        BGMusic.mute = !BGMusic.mute;
        InGameBGMusic.playOnAwake = !InGameBGMusic.playOnAwake;
    }

    public void newGameClicked(){
        StartSFX.Play();
    }

    public void MainMenuClicked(){
        InGameBGMusic.Pause();
    }

    public void onBounce(){
        BounceSFX.Play();
    }

    public void onScoreSFX(){
        ScoreSFX.Play();
    }

    public void onGameOverSFX(){
        GameOverSFX.Play();
    }
}
