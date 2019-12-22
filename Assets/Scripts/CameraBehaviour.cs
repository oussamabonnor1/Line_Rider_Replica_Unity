using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public float speed;
	public Vector3 offset;
	public bool follow;
	public Transform target;

	// Use this for initialization
	void Start () {
	}

	public void cameraFollow () {
		if(!follow){
		offset = transform.position - target.position;
		follow = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(follow)
		transform.position = Vector3.Lerp (transform.position, target.position + offset , speed * Time.fixedDeltaTime);
	}
}