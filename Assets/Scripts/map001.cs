using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map001 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Wait");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(120);

		Application.LoadLevel("scene002");
	}

}
