using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour {
	public TextCore text;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextCore>();
		Invoke("EditText",2f);
	}
	
	void EditText(){
		if(text==null){
			print("text obj null");
		}
		else{
			text.editText("HICIB787899");
		}
	}
}
