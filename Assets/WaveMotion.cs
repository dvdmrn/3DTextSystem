using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour {

	public float offset = 0;
	public float amplitude = 1;
	public float speed = 1;
	private float xPos;
	private float yPos;
	private float zPos;
	// Use this for initialization
	void Start () {
		Vector3 org = transform.position;
		xPos = org.x;
		yPos = org.y;
		zPos = org.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float mov = amplitude*Mathf.Sin((Time.time + offset)*speed);

		transform.position = new Vector3(xPos,yPos+mov,zPos);
	}
}
