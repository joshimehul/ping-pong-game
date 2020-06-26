using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    public float speed;
    float radius;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction =  Vector2.one.normalized;
        radius = transform.localScale.x / 2;//half the width 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed*Time.deltaTime);
        //bouncing the ball 
        if(transform.position.y<GameManager.bottomLeft.y +radius &&direction.y <0)
        {
            direction.y = -direction.y;
        }
        if(transform.position.y> GameManager.topRight.y-radius &&direction.y>0)
        {
            direction.y = -direction.y;
        }
        //Game Over
        if(transform.position.x <GameManager.bottomLeft.x +radius && direction.x<0)
        {
            Debug.Log("Right PLayer won");
            Time.timeScale = 0;
            enabled = false; //stop updating the script
        }
        if(transform.position.x > GameManager.topRight.x -radius && direction.x>0)
        {
            Debug.Log("Left Player Won");
            Time.timeScale = 0;
            enabled = false; //stop updating the script 
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;
            //ball hit the right paddle
            if(isRight == true && direction.x>0)
            {
                direction.x = -direction.x;
            }
            //ball hit the left paddle
            if(isRight == false && direction.x<0)
            {
                direction.x = -direction.x;
            }
        }
        
    }
}
