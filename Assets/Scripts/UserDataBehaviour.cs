using UnityEngine;
using System.Collections;

public class UserDataBehaviour : MonoBehaviour {	
	public TextAsset json;
	public UserData data = new UserData();

	void Awake(){
		ReadDataFromJson ();
	}

	private void ReadDataFromJson (){
		// TODO get from WebService
		//Local
		JsonUserParser parser = new JsonUserParser();
		data = new UserData ();
		parser.JSONString = json.text;
		data = parser.Data;
		UserPersistence.Save (data);
	}

	public void Load(){
		UserPersistence.Load ();
	}

	public void Save(UserData data){
		this.data = data;
		UserPersistence.Save (data);
	}
}
