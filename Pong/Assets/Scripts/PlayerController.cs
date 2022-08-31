using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    

    [SerializeField] float moveSpeed;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;

    public int score;
    public bool isPlaying;
    
    public Camera camera;
    public float width,height,speed;
    public float speedSet;

    void Start()
    {
        speed = speedSet * Screen.width;
        height = camera.orthographicSize;
        width = height * camera.aspect;

        moveSpeed = 0;
        score = 0;
        isPlaying = true;

        if(player.GetComponent<Transform>().localPosition.x > 0){
            player.GetComponent<Transform>().localPosition = new Vector2(width * 7/8, 0);
        }
        else{
            player.GetComponent<Transform>().position = new Vector2(-width * 7/8, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlaying)
            return;
        
        if(Input.GetKeyUp(up) || Input.GetKeyUp(down)){
            moveSpeed = 0;
        }

        if(Input.GetKey(up))
            moveSpeed = speed;
        
        if(Input.GetKey(down))
            moveSpeed = -speed;
        
    
        if(Mathf.Abs(player.GetComponent<Transform>().localPosition.y + moveSpeed * Time.deltaTime) < height - player.GetComponent<Transform>().localScale.y/2){
            player.GetComponent<Transform>().localPosition = new Vector2(player.GetComponent<Transform>().localPosition.x, player.GetComponent<Transform>().localPosition.y + moveSpeed * Time.deltaTime);
        }
        
    }

    
}
