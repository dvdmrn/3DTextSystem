using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCore : MonoBehaviour {
	private GameObject[] characters;
	public string text;
	public float kerning = 1f;
	public Vector3 origin;
	public Material mat = new Material(Shader.Find("Standard"));
	public bool waveMotion = false;
	public float waveSpeed = 1f;
	public float waveAmplitude = 0.5f;	
	private float offset = 0;

	void Start () {
		print(mat);
		characters = Resources.LoadAll<GameObject>("alphanumeric");
		ParseText(text.ToUpper());
	}
	
	void ParseText(string txt){
		int charIndex;
		float oX = origin.x;
		float oY = origin.y;
		float oZ = origin.z;
		float lastX = oX;

		for (int i = 0; i < txt.Length; i++)
		{
			charIndex = LookupText(txt[i]);
			print("found: "+charIndex);
			// instantiates characters
			GameObject c = Instantiate(characters[charIndex], new Vector3(lastX, oY, oZ), Quaternion.identity);
			c.transform.GetChild(0).GetComponent<Renderer>().material = mat;
			
			// Material mat = c.GetComponentInChildren<Renderer>().material;
			// print(mat);
			// mat = material;
			if (waveMotion){
				c.AddComponent<WaveMotion>();
				WaveMotion wm = c.GetComponent<WaveMotion>();
				
				// set parameters
				wm.offset = offset*-1;
				wm.amplitude = waveAmplitude;
				wm.speed = waveSpeed;

				offset += 0.5f; 

			}
			lastX = lastX+kerning;
		}
	}

	int LookupText(char c){
		if (c < '0' || c > '9')
        {
		switch (c)
			{
				case 'A':
					return 29;
				case 'B':
					return 30;
				case 'C':
					return 31;
				case 'D':
					return 32;
				case 'E':
					return 33;
				case 'F':
					return 34;
				case 'G':
					return 35;
				case 'H':
					return 36;
				case 'I':
					return 37;
				case 'J':
					return 38;
				case 'K':
					return 39;
				case 'L':
					return 40;
				case 'M':
					return 41;
				case 'N':
					return 42;
				case 'O':
					return 43;
				case 'P':
					return 44;
				case 'Q':
					return 45;
				case 'R':
					return 46;
				case 'S':
					return 47;
				case 'T':
					return 48;
				case 'U':
					return 49;
				case 'V':
					return 50;
				case 'W':
					return 51;
				case 'X':
					return 52;
				case 'Y':
					return 53;
				case 'Z':
					return 54;
				default:
					return 25;
			}					
		}
		else
		{
			return c - '0';
		}
		

	}

	// Update is called once per frame
	void Update () {
		
	}
}
