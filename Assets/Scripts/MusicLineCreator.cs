using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLineCreator : MonoBehaviour {

	public AudioSource audioSource;
	public LineBehaviour activeLine;
	public Rigidbody2D shipRb;

	public float graphMagnitude;
	public float graphPointX, graphPointY;
	Vector2 graphPosition;

	public float[] samples = new float[512];

	void Start () {
		if (shipRb.isKinematic) shipRb.bodyType = RigidbodyType2D.Dynamic;
			Camera.main.GetComponent<CameraBehaviour> ().cameraFollow ();
	}

	void Update () {
		audioSource.GetSpectrumData(samples,0,FFTWindow.Blackman);

		if (activeLine != null) {
			graphPointY= (samples[0] + samples[1] + samples[2]) * graphMagnitude;
			graphPointX = Mathf.Max(shipRb.velocity.x, graphPointY);
			graphPosition = new Vector2 (graphPosition.x + (graphPointX * Time.deltaTime), graphPointY);
			activeLine.updateLine (graphPosition);
		}
	}

	public void restartScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}