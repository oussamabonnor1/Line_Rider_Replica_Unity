using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour {

	Vector2 offset;
	Vector2 previousPosition;
	Material backgroundMat;

	public float speed;
 
	// Use this for initialization
	void Start () {
		backgroundMat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2(transform.position.x, transform.position.y) - previousPosition;
		backgroundMat.mainTextureOffset += offset * speed * Time.deltaTime;
		previousPosition = transform.position;
	}
}
