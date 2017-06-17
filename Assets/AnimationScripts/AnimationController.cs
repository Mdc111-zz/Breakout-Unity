using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController {

	private static AnimationController instance;

	public static AnimationController GetInstance(){ //singleton
		if(instance == null)
			instance = new AnimationController();

		return instance;
	}
    

	public void StartNeighborDestroyerBrickAnimation(Vector3 BrickPosition, ObjectManager objectManager){
		new NeighborDestroyAnim(BrickPosition, objectManager);
	}
	public void StartVerticalNeighborDestroyerBrickAnimation(Vector3 BrickPosition, ObjectManager objectManager)
    {
        new NeighborVerticalDestroyerAnim(BrickPosition, objectManager);
    }
    public void StartHorizontalNeighborDestroyerBrickAnimation(Vector3 BrickPosition, ObjectManager objectManager)
    {
        new NeighborHorizontalDestroyerAnim(BrickPosition, objectManager);
    }

}
