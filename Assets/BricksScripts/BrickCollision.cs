using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision {

    ObjectManager objectManager;
	public BrickCollision(ObjectManager instance)
    {
        objectManager = instance;
    }

	public void CheckCollision(){
        bool hasChangedDirection = false;

        foreach (GameObject Brick in objectManager.brick.bricks.ToArray())
        {
            Collision collisionTest = new Collision()
            {
                subjectPosition = objectManager.gameBall.Ball.transform.position,
                subjectSize = objectManager.gameBall.Ball.GetComponent<SpriteRenderer>().bounds.size,
                subjectPreviousPosition = objectManager.gameBall.Ball.transform.position,
                testPosition = Brick.transform.position,
                testSize = Brick.GetComponent<SpriteRenderer>().bounds.size
            };
            if (collisionTest.isColliding() && !hasChangedDirection)
            {
                hasChangedDirection = true;
                if (collisionTest.isCollidingHorizontal()){
                    EffectOnBrick(Brick);
                    objectManager.gameBall.ChangeDirectionX();
                }else{
                    EffectOnBrick(Brick);
                    objectManager.gameBall.ChangeDirectionY();
                }
            }
        }
    }

	public void EffectOnBrick(GameObject Brick){
        int temp = Random.Range(0, 30);
        objectManager.gameScore.addToScore(objectManager.brick.brickScore);

        switch (temp)
        {
            case 1:
                objectManager.deleteInactiveGameObjects(Brick);
                NeighborDestroyer.RunNeighborDestroyer(Brick, objectManager);
                AnimationController.GetInstance().StartNeighborDestroyerBrickAnimation(Brick.transform.position, objectManager);
                break;
            case 2:
                objectManager.deleteInactiveGameObjects(Brick);
                NeighborVerticalDestroyer.RunNeighborVerticalDestroyer(Brick, objectManager);
                AnimationController.GetInstance().StartVerticalNeighborDestroyerBrickAnimation(Brick.transform.position, objectManager);
                break;
            case 3:
                objectManager.deleteInactiveGameObjects(Brick);
                NeighborHorizontalDestroyer.RunNeighborHorizontalDestroyer(Brick, objectManager);
                AnimationController.GetInstance().StartHorizontalNeighborDestroyerBrickAnimation(Brick.transform.position, objectManager);
                break;
            default:
                objectManager.deleteInactiveGameObjects(Brick);
                break;
        }

	}
}
