using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;


public class JsonTransactionParser {
	
	private TransactionData data;
	
	public TransactionData Data {
		get {
			return data;
		}
	}
	
	public string JSONString {
		set {
			data = CreateTransactionDataObject (Json.Deserialize (value)as Dictionary<string, object>);
		}
	}

	private TransactionData CreateTransactionDataObject (Dictionary<string, object> transaction)	{
		TransactionData data = new TransactionData ();
		data.id = transaction ["id"].ToString();
		data.reference = transaction ["reference"].ToString();
		data.typeTransaction = transaction ["typetransaction"].ToString();
		data.typeService =  transaction ["typeService"].ToString();
		data.state = transaction ["state"].ToString();
		data.value = double.Parse( transaction ["value"].ToString());
		data.currency = transaction ["currency"].ToString();
		data.day = transaction ["day"].ToString();
		data.description = transaction ["description"].ToString();
		return data;
	}

}
