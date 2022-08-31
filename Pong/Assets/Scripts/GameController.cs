using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject p1;
    public GameObject p2;
    public GameObject WinText;
    public GameObject NewGameBtn;
    public GameObject MainMenuBtn;

    public GameObject Audio;

    public bool isPlaying;

    void Start()
    {
        isPlaying = true;
        Audio = GameObject.FindGameObjectWithTag("Music");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlaying)
            return;
            
        checkWon();
    }

    void checkWon(){
        if(p2.GetComponent<PlayerController>().score == 5 || p1.GetComponent<PlayerController>().score == 5){
            Audio.GetComponent<AudioController>().onGameOverSFX();
            NewGameBtn.SetActive(true);
            MainMenuBtn.SetActive(true);
            WinText.SetActive(true);

            isPlaying = false;

            
            p1.GetComponent<PlayerController>().isPlaying = false;
            ball.GetComponent<BallController>().isPlaying = false;

            if(p2.GetComponent<PlayerController>().score == 5){
                NewGameBtn.GetComponent<RectTransform>().localPosition = new Vector2(190f, 30f);
                MainMenuBtn.GetComponent<RectTransform>().localPosition = new Vector2(190f, -60f);
                WinText.GetComponent<RectTransform>().localPosition = new Vector2(190f, 110f);
            }
        }
    }

    //BTN methods
    public void newGameClicked(){
        Audio.GetComponent<AudioController>().newGameClicked();
        DontDestroyOnLoad(Audio);
        SceneManager.LoadScene(1);

    }

    public void MainMenuBtnClicked(){
        SceneManager.LoadScene(0);
        Audio.GetComponent<AudioController>().MainMenuClicked();
        Destroy(Audio);
    }
}
