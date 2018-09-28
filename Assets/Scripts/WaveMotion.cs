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
	public enum WaveDirection {x,y,z};
	private WaveDirection dir = WaveDirection.y;
	// Use this for initialization
	void Start () {
		Vector3 org = transform.localPosition;
		xPos = org.x;
		yPos = org.y;
		zPos = org.z;
	}
	
	public void setDirection(TextCore.WaveDirection direction){
		dir = (WaveDirection)direction;
	}
	// Update is called once per frame
	void FixedUpdate () {
		float mov = amplitude*Mathf.Sin((Time.time + offset)*speed);
		if(dir==WaveDirection.x){
			transform.localPosition = new Vector3(xPos+mov,yPos,zPos);
		}
		else if(dir==WaveDirection.z){
			transform.localPosition = new Vector3(xPos,yPos,zPos+mov);
		}
		else{
			transform.localPosition = new Vector3(xPos,yPos+mov,zPos);

		}
	}
}
