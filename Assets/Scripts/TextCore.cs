using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCore : MonoBehaviour {
	public string text;
	public float kerning = 1f;
	public Vector3 origin;
	public Material mat;
	public bool waveMotion = false;
	public float waveSpeed = 1f;
	public enum WaveDirection {x,y,z};
	public WaveDirection waveDirection = WaveDirection.y;
	public float waveAmplitude = 0.5f;	
	private float offset = 0;

	private GameObject[] characters; // contains references to prefabs of all characters

	// for editing text
	private int[] textRepresentation;
	private int[] newString;
	public GameObject[] instantiatedLetters; // array of references to letters 




	void Start () {
		// print(mat);
		origin = transform.position;
		characters = Resources.LoadAll<GameObject>("alphanumeric");

		// assigning default material here because cannot make calls
		// to Shader.Find outside of functions
		if (mat == null){
			mat = new Material(Shader.Find("Standard"));
		}

		// for text replacement
		textRepresentation = new int[text.Length];
		instantiatedLetters = new GameObject[text.Length];

		ParseText(text.ToUpper());
	}
	
	public void GetInstantiatedLetters(){
		int i = 0;
		print("instantiated letters len: "+instantiatedLetters.Length);
		print("children: "+transform.childCount);

		instantiatedLetters = new GameObject[transform.childCount];
		foreach (GameObject child in transform)
		{
			print("Child: "+child);
			instantiatedLetters[i] = child;
			i += 1;
		}
	}
	void ParseText(string txt){
		// instantiates .obj letters based off strings
		// txt := the string to instantiate
		// txtArray := an int index representation of the text for later editing

		textRepresentation = new int[text.Length];
		instantiatedLetters = new GameObject[text.Length];


		int charIndex;
		float oX = origin.x;
		float oY = origin.y;
		float oZ = origin.z;
		float lastX = oX;

		for (int i = 0; i < txt.Length; i++)
		{
			charIndex = LookupText(txt[i]);
			textRepresentation[i] = charIndex;
			// print("found: "+charIndex);
			// instantiates characters
				GameObject c = Instantiate(characters[charIndex], new Vector3(lastX, oY, oZ), transform.rotation, this.transform);
				instantiatedLetters[i] = c;
				c.transform.GetChild(0).GetComponent<Renderer>().material = mat;
				if (txt[i] == ' '){
					clearMesh(i);
				}
				
			// wavy motion
				if (waveMotion){
					// print("found space");
					c.AddComponent<WaveMotion>();
					WaveMotion wm = c.GetComponent<WaveMotion>();

					wm.setDirection(waveDirection);



					// set parameters
					wm.offset = offset*-1;
					wm.amplitude = waveAmplitude;
					wm.speed = waveSpeed;


				}
			offset += 0.5f; 

			
			lastX = lastX+kerning;
		}
	}

	public void editText(string newText){
		// use editText if the two strings are the same length
		newText = newText.ToUpper();
		newString = new int[newText.Length];
		for (int i=0; i<newText.Length; i++){
			if(newText[i]==' '){
				clearMesh(i);
			}
			else{
				int newCharIndex = LookupText(newText[i]);
				if (textRepresentation[i] != newCharIndex){
					textRepresentation[i] = newCharIndex;
					UpdateMesh(i,newCharIndex);
				}
			}
		}
	}

	public void addText(string newText){
		for (int i = 0; i < newText.Length; i++)
		{
			int newCharIndex = LookupText(newText[i]);	
			if (textRepresentation[i] != newCharIndex){
				textRepresentation[i] = newCharIndex;
				UpdateMesh(i,newCharIndex);	

			}	
		}
	}

	public void UpdateText(string newText){

		for (int i = 0; i < this.instantiatedLetters.Length; i++)
		{
			Destroy(this.instantiatedLetters[i]);
		}
		textRepresentation = new int[newText.Length];
		instantiatedLetters = new GameObject[newText.Length];
		ParseText(newText.ToUpper());

	}

	void UpdateMesh(int index, int newChar){
		Mesh newMesh = characters[newChar].transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh;
		instantiatedLetters[index].transform.GetChild(0).GetComponent<MeshFilter>().mesh = newMesh;
	}

	void clearMesh(int index){
		instantiatedLetters[index].transform.GetChild(0).GetComponent<MeshFilter>().mesh.Clear();

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
				case '#':
					return 20;
				case '.':
					return 23;
				case ':':
					return 13;
				case '\'':
					return 10;
				case ',':
					return 14;
				case '$':
					return 16;
				default:
					return 25;
			}					
		}
		else
		{
			return c - '0';
		}
		

	}


}