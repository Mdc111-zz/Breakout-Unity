using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenModel {

    ObjectManager objectManager;
    public ScreenModel(ObjectManager instance)
    {
        objectManager = instance;
        SetScreenValues();
    }
    private int borderOffset;
    private int menuOffset;
    private int screenWidth;
    private int screenHeight;

    public void SetScreenValues()
    {
        borderOffset = 3;
        menuOffset = 20;
        screenWidth = 600;
        screenHeight = 800;
    }
    public int MenuOffset
    {
        get
        {
            return menuOffset;
        }
    }

    public int ScreenWidth
    {
        get
        {
            return screenWidth;
        }
    }

    public int BorderOffset
    {
        get
        {
            return borderOffset;
        }
    }

    public int ScreenHeight
    {
        get
        {
            return screenHeight;
        }
    }

}

