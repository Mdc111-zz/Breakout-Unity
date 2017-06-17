using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animation {

	public GameObject[] particles;
	public abstract void CycleAnimation();
	public abstract bool IsFinished();
}
