using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner {
    
    float xCoord;
    float yCoord;
    ObjectManager objectManager;
    private float bricksInLine;

    public BrickSpawner(ObjectManager instance)
    {
        objectManager = instance;
    }

    public void generateLineOfBricks()
    {
        checkBricksListEmpty();
        
        bricksInLine = GenerateLineLength();
        yCoord = 250;
        xCoord = 0 - (objectManager.screenModel.ScreenWidth/4) - (bricksInLine / 2) - numberOfBricksInLine();

        for (int x = 0; x < bricksInLine; x++){
            objectManager.brick.CreateBrick(xCoord, yCoord);
            xCoord += (objectManager.brickSettings.BrickWidth);
        }
    }
    public void spawnBricks()
    {
        DescendBrickLine();
        generateLineOfBricks();
    }
    public void spawnTimerForBricks()
    {
        int numberChecker = 0;

        if (Time.frameCount < 200)
            numberChecker = Random.Range(0, 1000);
        else if (Time.frameCount < 400)
            numberChecker = Random.Range(0, 500);
        else
            numberChecker = Random.Range(0, 250);

        if (numberChecker == 1)
        {
            spawnBricks();
        }
    }
    public void DescendBrickLine()
    {
        foreach (GameObject Brick in objectManager.brick.bricks)
        {
            if (Brick.activeInHierarchy)
            {
                Brick.transform.Translate(0, -objectManager.brickSettings.BrickHeight, 0);
            }
        }
    }

    public bool CheckBrickLocation() // this is for end game message
    {
        foreach (GameObject Brick in objectManager.brick.bricks)
        {
            if (Brick.activeInHierarchy)
            {
                if (Brick.transform.position.y + objectManager.brickSettings.BrickHeight <= (-objectManager.screenModel.ScreenHeight/2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
    private void checkBricksListEmpty()
    {
        if (objectManager.brick.bricks == null)
        {
            objectManager.brick.bricks = new List<GameObject>();
        }
    }
    private int GenerateLineLength()
    {
        int[] LineLength = new int[3];
        LineLength[0] = 5;
        LineLength[1] = 7;
        LineLength[2] = 9;

        return LineLength[Random.Range(0, 3)];
    }
    private float numberOfBricksInLine()
    {
        if (bricksInLine == 5)
            return -53;
        else if (bricksInLine == 7)
            return -4;
        else
            return 45;
    }

}



