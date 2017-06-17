using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBat {


    private float batMoveSpeed;
    ObjectManager objectManager;
    public GameObject Bat;
    public float batWidth;
    public float batHeight;

    public GameBat(ObjectManager instance)
    {
        objectManager = instance;
        Bat = GameObject.FindGameObjectWithTag("Bat");
        SetPositionBat();
        SetBallLimits();
        batMoveSpeed = 1.5f;
    }

    public void SetPositionBat()
    {
        Bat.transform.position = new Vector3(0, objectManager.brickSettings.BrickHeight * -10.5f, -1);
    }
    private void SetBallLimits()
    {
        batWidth = Bat.GetComponent<SpriteRenderer>().bounds.size.x;
        batHeight = Bat.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    public void MoveBat () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (CanMoveLeft()) { Bat.transform.Translate(Vector3.left * batMoveSpeed); }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (CanMoveRight()) { Bat.transform.Translate(Vector3.right * batMoveSpeed); }
        }
    }
    private bool CanMoveLeft() //make a function calculating new position, check if that position is where the bat should be, if not return false etc, then if it is move
    {
        if (Bat.transform.position.x - batMoveSpeed - (objectManager.brickSettings.BrickWidth * 2) <= (-objectManager.screenModel.ScreenWidth / 2))
        {
            return false;
        }
        else { return true; }
    }
    private bool CanMoveRight()
    {
        if(Bat.transform.position.x + objectManager.brickSettings.BrickWidth * 2 + batMoveSpeed >= (objectManager.screenModel.ScreenWidth / 2))
        {
            return false;
        }
        else { return true; }
    }

    public float GetXPositionOfBat()
    {
        return Bat.transform.position.x;
    }
    public float GetYPositionOfBat()
    {
        return Bat.transform.position.y;
    }
    
}
