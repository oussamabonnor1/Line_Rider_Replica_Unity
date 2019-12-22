using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLineCreator : MonoBehaviour {

	public AudioSource audioSource;
	public LineBehaviour activeLine;
	public Rigidbody2D shipRb;

	public float graphMagnitude;
	public float graphPointX, graphPointY, yLerpingSpeed;
	Vector2 graphPosition;

	public float[] samples = new float[512];

	void Start () {
		if (shipRb.isKinematic) shipRb.bodyType = RigidbodyType2D.Dynamic;
		Camera.main.GetComponent<CameraBehaviour> ().cameraFollow ();
	}

	void Update () {
		audioSource.GetSpectrumData (samples, 0, FFTWindow.Blackman);

		if (activeLine != null) {
			float samplesSum = 0;
			for (int i = 0; i < 4; i++) {
				samplesSum += samples[i];
			}

			graphPointY = (samplesSum) * graphMagnitude;
			graphPointX = Mathf.Max(shipRb.velocity.x, graphPointY);
			graphPosition = new Vector2 (graphPosition.x + (graphPointX * Time.deltaTime),
				Mathf.Lerp (graphPosition.y, graphPointY, yLerpingSpeed * Time.deltaTime));
			activeLine.updateLine (graphPosition);
		}
	}

	public void restartScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}