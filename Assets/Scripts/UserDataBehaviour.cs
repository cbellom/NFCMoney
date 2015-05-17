using UnityEngine;
using System.Collections;

public class UserDataBehaviour : MonoBehaviour {	
	public TextAsset json;
	public UserData data = new UserData();

	void Awake(){
		UserPersistence.ClearData ();
		StartCoroutine(LoadUserData());
	}

	private void ReadDataFromJson (string json){
		JsonUserParser parser = new JsonUserParser();
		data = new UserData ();
		parser.JSONString = json;
		data = parser.Data;
		UserPersistence.Save (data);
	}

	private IEnumerator LoadUserData(){
		string url = GameSettings.Instance.getUserDataURL + "?phone="+WWW.EscapeURL (GameSettings.Instance.phoneNumber);
		Debug.Log ("Get data from " + url);
		WWW getData = new WWW (url);
		yield return getData;
		Debug.Log (getData.text);
		
		ReadDataFromJson (getData.text);
	}

	public void Load(){
		UserPersistence.Load ();
	}

	public void Save(UserData data){
		this.data = data;
		UserPersistence.Save (data);
	}
}
