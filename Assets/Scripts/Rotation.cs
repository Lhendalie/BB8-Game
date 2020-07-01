using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	void Update () 
	{
		//45 degree rotation
		transform.Rotate (new Vector3 (45, 0, 0) * Time.deltaTime);
	}
}
