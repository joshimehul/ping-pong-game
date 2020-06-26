using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float speed;
    float height;
    public bool isRight;
    string input;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }
    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos =  Vector2.zero;

        
        if(isRightPaddle)
        {
            pos = new Vector2(GameManager.topRight.x, 0);
            pos += Vector2.left * transform.localScale.x;
            input = "RightPaddle";
        }
        else
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "LeftPaddle";
        }
        //updating the paddle position
        transform.position = pos;
        transform.name = input;
        
    }

    // Update is called once per frame
    void Update()
    {
        //lets move the paddles
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        //restricting the paddle movement 
        if(transform.position.y<GameManager.bottomLeft.y +height/2 &&move <0 )
        {
            move = 0;
        }
        if(transform.position.y>GameManager.topRight.y-height/2 && move>0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
