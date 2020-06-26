using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Paddle paddle;
    public Ball ball;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    // Start is called before the first frame update
    void Start()
    {
        //setting the game screen as the world screen 
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //creating Ball
        Instantiate(ball);
        //creating two paddle
        Paddle paddle1 = Instantiate(paddle) as Paddle;//type casting
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true);//right paddle
        paddle2.Init(false);//left paddle

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
