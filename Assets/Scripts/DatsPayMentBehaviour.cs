using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DatsPayMentBehaviour : MonoBehaviour {


	public Text Texttypetransation;
	public Text TextValue;
	public Text TextRef;
	public Text Textdate;

	// Use this for initialization
	void Start () {
	

	}


	// Update is called once per frame
	void Update () {
	
	}


	public IEnumerator FindTransactionOnServer(string reference){
		string url = GameSettings.Instance.findTransactionURL + "?" +
			"reference=" + WWW.EscapeURL (reference);
		Debug.Log (url);
		WWW getData = new WWW (url);
		yield return getData;
		Debug.Log (getData.text);
		ReadDataFromJsonAndSaveLocalData (getData.text);

	}
	
	
	private void ReadDataFromJsonAndSaveLocalData (string json){
		JsonTransactionParser parser = new JsonTransactionParser();
		TransactionData transaction = new TransactionData ();
		parser.JSONString = json;
		transaction = parser.Data;
		getdatstransactions (transaction);
	}

	public void getdatstransactions(TransactionData transationuser)
	{
      
		Texttypetransation.text = transationuser.typeTransaction;
		TextValue.text = System.Convert.ToString(transationuser.value);
		TextRef.text = transationuser.reference;
		Textdate.text = transationuser.day;

	}

}
