using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesAnimation : MonoBehaviour 
{
	void Update () 
	{
		transform.Rotate (new Vector3 (0, 0, 45)* Time.deltaTime * 4 );
		transform.Translate(new Vector3(0,0,Mathf.Sin(Time.time*8)*Time.deltaTime));
	}
}
