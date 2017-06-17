using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSettings {

    ObjectManager objectManager;
    private int hitBrick;
    private float brickWidth;
    private float brickHeight;

    public BrickSettings(ObjectManager instance)
    {
        objectManager = instance;
        SetBrickVariables();
    }

    private void SetBrickVariables()
    {
        hitBrick = 50;
        brickWidth = 50;
        brickHeight = 30;
    }

    public int HitBrick
    {
        get
        {
            return hitBrick;
        }
    }

    public float BrickWidth
    {
        get
        {
            return brickWidth;
        }
    }

    public float BrickHeight
    {
        get
        {
            return brickHeight;
        }
    }

 
}
