using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall {

    private static float ballSize;
    private static int scoreDeductionPenalty;
    private float moveSpeed;
    public int dirX;  
    public int dirY;
    public GameObject Ball;
    public float ballWidth;
    public float ballHeight;
    ObjectManager objectManager;
    public Vector3 currentBallPos;
    public Vector3 previousFrameBallPos;

    public GameBall(ObjectManager instance)
    {
        objectManager = instance;
        Ball = GameObject.FindGameObjectWithTag("Ball");
        SetSizeOfBall();
        SetPositionBall();
        SetBallLimits();
        dirX = 30;
        dirY = -30;
        moveSpeed = 3f;
        scoreDeductionPenalty = -200;
        
    }
    private void SetBallLimits()
    {
        ballWidth = Ball.GetComponent<SpriteRenderer>().bounds.size.x;
        ballHeight = Ball.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    public void SetSizeOfBall()
    {
        ballSize = 30;
        float differenceInX = 1 / GameObject.FindGameObjectWithTag("Ball").GetComponent<SpriteRenderer>().bounds.size.x;
        float differenceInY = 1 / GameObject.FindGameObjectWithTag("Ball").GetComponent<SpriteRenderer>().bounds.size.y;
        Ball.transform.localScale = new Vector3(ballSize * differenceInX, ballSize * differenceInY, 0);
    }
    public void SetPositionBall()
    {
        Ball.transform.position = new Vector3(0, 0, -1);
    }
    public void MoveBall()
    {
        Ball.transform.Translate(moveSpeed * Time.deltaTime * dirX, moveSpeed * Time.deltaTime * dirY, 0);
    }
    public void CollisionWithBoarder()
    {
        if (Ball.transform.position.x >= objectManager.screenModel.ScreenWidth / 2 - (ballSize / 2))
            ChangeDirectionX();

        if (Ball.transform.position.x <= -objectManager.screenModel.ScreenWidth / 2 + objectManager.screenModel.BorderOffset + (ballSize / 2))
            ChangeDirectionX();

        if (Ball.transform.position.y >= objectManager.screenModel.ScreenHeight /2 - (ballSize / 2))
        {
            ChangeDirectionY();
            objectManager.gameScore.addToScore(scoreDeductionPenalty);
        }
        if (Ball.transform.position.y <= (-objectManager.screenModel.ScreenHeight /2) + objectManager.screenModel.MenuOffset)
            ChangeDirectionY();
    }
    public float GetXPositionOfBall()
    {
        return Ball.transform.position.x;
    }
    public float GetYPositionOfBall()
    {
        return Ball.transform.position.y;
    }
    public void ChangeDirectionX()
    {
        dirX = -dirX;
    }
    public void ChangeDirectionY()
    {
        dirY = -dirY;
    }

    public void storeBallCoordsOfPreviousFrame()
    {
        previousFrameBallPos = currentBallPos;
        currentBallPos = Ball.transform.position;
    }

    public void checkCollisionWithBat()
    {
        storeBallCoordsOfPreviousFrame();
        Collision collisionTest = new Collision()
        {
            subjectPosition = Ball.transform.position,
            subjectSize = Ball.GetComponent<SpriteRenderer>().bounds.size,
            subjectPreviousPosition = previousFrameBallPos,
            testPosition = objectManager.gameBat.Bat.transform.position,
            testSize = objectManager.gameBat.Bat.GetComponent<SpriteRenderer>().bounds.size
        };

        if (collisionTest.isColliding())
        {
            if (collisionTest.isCollidingHorizontal())
                ChangeDirectionX();
            else
                ChangeDirectionY();
        }
    }

    
}
