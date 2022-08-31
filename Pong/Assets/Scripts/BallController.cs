using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float velX, velY;
    public GameObject ball;
    public GameObject p1Score;
    public GameObject p2Score;

    public GameObject p1;
    public GameObject p2;

    public bool isPlaying;
    Transform transform;

    public GameController gameController;
    public AudioController audio;

    [SerializeField] int negOrPosX, negOrPosY;

    public Camera camera;
    public float height, width,speed;
    
    void Start()
    {
        
        height = camera.orthographicSize;
        width = height * camera.aspect;

        audio = gameController.GetComponent<GameController>().Audio.GetComponent<AudioController>();
        velX = speed * Screen.width;
        velY = speed * Screen.width;

        negOrPosX = Random.Range(0,2) * 2 - 1;
        negOrPosY = Random.Range(0,2) * 2 - 1;

        velX *= negOrPosX;
        velY *= negOrPosY;
        transform = ball.GetComponent<Transform>();

        isPlaying = true;

    }

    // Update is called once per frame
    void Update()
    {

        if(!isPlaying)
            return;

        if(transform.localPosition.y >= height || transform.localPosition.y <= -height){
            velY *= -1;
            audio.onBounce();
        }
        
        if(transform.localPosition.x <= -width * 1.1f){
            transform.localPosition = new Vector2(0,0);
            Start();
            p2.GetComponent<PlayerController>().score++;
            p2Score.GetComponent<TMPro.TextMeshProUGUI>().text = "" + p2.GetComponent<PlayerController>().score;
            audio.onScoreSFX();
        }
        
        if(transform.localPosition.x >= width * 1.1f){
            transform.localPosition = new Vector2(0,0);
            Start();
            p1.GetComponent<PlayerController>().score++;
            p1Score.GetComponent<TMPro.TextMeshProUGUI>().text = "" + p1.GetComponent<PlayerController>().score;
            audio.onScoreSFX();
        }

        transform.localPosition = new Vector2(transform.localPosition.x + velX * Time.deltaTime, transform.localPosition.y + velY * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {

        audio.onBounce();

        velX *= -1;
        if(velX > 0)
            velX *= 1.1f;
        else   
            velX *= 1.1f;
    }

    
}
