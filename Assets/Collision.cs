using UnityEngine;
using System.Collections;
using System;

public class Collision
{
    public Vector3 subjectPosition;
    public Vector2 subjectSize;
    public Vector3 subjectPreviousPosition;

    public Vector3 testPosition;
    public Vector2 testSize;

    private Vector3 subjectCornerPos;
    private Vector3 testCornerPos;

    private Vector3 getBottomLeftCoord(Vector3 position, Vector2 size)
    {
        return new Vector3(position.x - (size.x / 2), position.y - (size.y / 2), 0);
    }

    public bool isColliding()
    {
        if (isXOverlap() && isYOverlap())
            return true;
        else
            return false;
    }

    private bool isXOverlap()
    {
        subjectCornerPos = getBottomLeftCoord(subjectPosition, subjectSize);
        if (subjectCornerPos.x < testPosition.x + (testSize.x / 2) && subjectCornerPos.x > testPosition.x - (testSize.x / 2))
            return true;
        else if (subjectCornerPos.x + subjectSize.x < testPosition.x + (testSize.x / 2) && subjectCornerPos.x + subjectSize.x > testPosition.x - (testSize.x / 2))
            return true;
        else
            return false;
    }

    private bool isYOverlap()
    {
        subjectCornerPos = getBottomLeftCoord(subjectPosition, subjectSize);
        if (subjectCornerPos.y < testPosition.y + (testSize.y / 2) && subjectCornerPos.y > testPosition.y - (testSize.y / 2))
            return true;
        else if (subjectCornerPos.y + subjectSize.y < testPosition.y + (testSize.y / 2) && subjectCornerPos.y + subjectSize.y > testPosition.y - (testSize.y / 2))
            return true;
        else if(subjectCornerPos.y + (subjectSize.y/2) < testPosition.y + (testSize.y / 2) && subjectCornerPos.y + (subjectSize.y / 2) > testPosition.y - (testSize.y / 2))
            return true;
        else
            return false;
    }

    public bool isCollidingHorizontal()
    {
        if (isXFaceCollision() < isYFaceCollision())
            return true;
        else
            return false;
    }
    private float isXFaceCollision()
    {
        if (calculateDistanceLeftOfSubjectToRightOfTest() > calculateDistanceRightOfSubjectToLeftOfTest())
            return calculateDistanceRightOfSubjectToLeftOfTest();
        else
            return calculateDistanceLeftOfSubjectToRightOfTest();
    }
    private float isYFaceCollision()
    {
        if (calculateDistanceTopOfSubjectToBottomOfTest() > calculateDistanceBottomOfSubjectToTopOfTest())
            return calculateDistanceBottomOfSubjectToTopOfTest();
        else
            return calculateDistanceTopOfSubjectToBottomOfTest();
    }

    private float calculateDistanceLeftOfSubjectToRightOfTest()
    {
        subjectCornerPos = getBottomLeftCoord(subjectPreviousPosition, subjectSize);
        testCornerPos = getBottomLeftCoord(testPosition, testSize);
        return Vector3.Distance(new Vector3(subjectCornerPos.x, 0, 0), new Vector3(testCornerPos.x + testSize.x, 0, 0));
    }

    private float calculateDistanceRightOfSubjectToLeftOfTest()
    {
        subjectCornerPos = getBottomLeftCoord(subjectPreviousPosition, subjectSize);
        testCornerPos = getBottomLeftCoord(testPosition, testSize);
        return Vector3.Distance(new Vector3(subjectCornerPos.x + subjectSize.x, 0, 0), new Vector3(testCornerPos.x, 0, 0));
    }

    private float calculateDistanceTopOfSubjectToBottomOfTest()
    {
        subjectCornerPos = getBottomLeftCoord(subjectPreviousPosition, subjectSize);
        testCornerPos = getBottomLeftCoord(testPosition, testSize);
        return Vector3.Distance(new Vector3(0, subjectCornerPos.y + subjectSize.y, 0), new Vector3(0, testCornerPos.y, 0));
    }

    private float calculateDistanceBottomOfSubjectToTopOfTest()
    {
        subjectCornerPos = getBottomLeftCoord(subjectPreviousPosition, subjectSize);
        testCornerPos = getBottomLeftCoord(testPosition, testSize);
        return Vector3.Distance(new Vector3(0, subjectCornerPos.y, 0), new Vector3(0, testCornerPos.y + testSize.y, 0));
    }
}