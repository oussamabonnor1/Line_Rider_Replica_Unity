using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLineCreator : MonoBehaviour {

	public GameObject linePrefab;
	public LineBehaviour activeLine;
	public Rigidbody2D shipRb;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject line = Instantiate (linePrefab);
			activeLine = line.GetComponent<LineBehaviour> ();
		}

		if (activeLine != null) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			activeLine.updateLine (mousePosition);
		}

		if (Input.GetMouseButtonUp (0)){ 
			activeLine = null;
			Camera.main.GetComponent<CameraBehaviour>().cameraFollow();
			if(shipRb.isKinematic) shipRb.bodyType = RigidbodyType2D.Dynamic;
		}
	}


	public void restartScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
