using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborVerticalDestroyer {

	private GameObject Brick;
    ObjectManager objectManager;

	public NeighborVerticalDestroyer(GameObject Brick, ObjectManager instance){
        objectManager = instance;
		this.Brick = Brick;
		DestroyAllNeighbor();
	}

	private void DestroyAllNeighbor(){
		foreach(GameObject Brick in objectManager.brick.bricks.ToArray())
        {
			if(this.Brick.transform.position.x == Brick.transform.position.x){
                objectManager.brickCollision.EffectOnBrick(Brick);
			}
		}
	}

	public static void RunNeighborVerticalDestroyer(GameObject Brick, ObjectManager instance){
		new NeighborVerticalDestroyer(Brick, instance);
	}
}
