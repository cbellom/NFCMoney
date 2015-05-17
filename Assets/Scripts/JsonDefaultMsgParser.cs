using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;


public class JsonDefaultMsgParser  {

	public bool isOK;
	private string data;
	
	public string Data {
		get {
			return data;
		}
	}
	
	public string JSONString {
		set {
			data = CreateStringMessageObject (Json.Deserialize (value)as Dictionary<string, object>);
		}
	}
	
	private string CreateStringMessageObject (Dictionary<string, object> message)	{
		string messageJson;
		try{
			messageJson = message ["message"].ToString();
			isOK = true;
		}catch{
			messageJson = message ["error"].ToString();
			isOK = false;
		}
		return messageJson;
	}
	
}
