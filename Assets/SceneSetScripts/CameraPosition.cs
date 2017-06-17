using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, 0, -311);
        Camera.main.orthographicSize = 397.6352f;
	}
	
}
