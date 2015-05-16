using UnityEngine;
using System.Collections;

public class UserDataBehaviour : MonoBehaviour {	
	public TextAsset json;
	public UserData data = new UserData();

	void Awake(){
		ReadDataFromJson ();
	}

	private void ReadDataFromJson (){
		JsonUserParser parser = new JsonUserParser();
		data = new UserData ();
		parser.JSONString = json.text;
		data = parser.Data;
	}
}
