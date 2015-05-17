using UnityEngine;
using System.Collections;

public class UserDataBehaviour : MonoBehaviour {	
	public TextAsset json;
	public UserData data = new UserData();

	public string getUserDataURL = "http://dev.ateos.co/Transacciones/web/app_dev.php/servicio/getUserData";

	void Awake(){
		StartCoroutine(LoadUserData());
	}

	private void ReadDataFromJson (string json){
		// TODO get from WebService
		//Local
		JsonUserParser parser = new JsonUserParser();
		data = new UserData ();
		parser.JSONString = json;
		data = parser.Data;
		UserPersistence.Save (data);
	}

	private IEnumerator LoadUserData(){
		string url = getUserDataURL + "?userId=1&phone=angie";
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
