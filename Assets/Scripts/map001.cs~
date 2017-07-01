using System.Collections;
using UnityEngine;

public class map001 : MonoBehaviour {

	// Use this for initialization
	void Start() {
		StartCoroutine("Wait");
	}
	
	// Update is called once per frame
	void Update() {
    if (Input.GetKeyDown(KeyCode.V)) {
      Application.LoadLevel("scene002");
    }

    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.LoadLevel("UI");
    }
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(60);
    Application.LoadLevel("scene002");
	}

}
