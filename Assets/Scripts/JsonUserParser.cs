using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JsonUserParser  {

	private UserData data;

	public UserData Data {
		get {
			return data;
		}
	}
		
	public string JSONString {
		set {
			data = CreateUserDataObject (Json.Deserialize (value)as Dictionary<string, object>);
		}
	}
	
	private UserData CreateWordsDataList(List<object> users) {
		UserData data = new UserData ();
		foreach(Dictionary<string, object> user in users){
			data = CreateUserDataObject(user);
		}
		return data;
	}

	private UserData CreateUserDataObject (Dictionary<string, object> user)	{
		UserData data = new UserData ();
		data.id = int.Parse(user ["id"].ToString());
		data.amount = double.Parse( user ["amount"].ToString() );
		data.phone = user ["phone"].ToString();
		data.transactions = CreateTransactionList( user["transactions"] as List<object>);
		return data;
	}
	
	private List<TransactionData> CreateTransactionList (List<object> transactions)	{
		List<TransactionData> transactionsList = new List<TransactionData> ();
		foreach(Dictionary<string, object> transaction in transactions){
			transactionsList.Add(CreateTransactionObject(transaction));
		}
		return transactionsList;		
	}

	private TransactionData CreateTransactionObject (Dictionary<string, object> transaction)	{
		TransactionData data = new TransactionData ();
		data.id = transaction ["id"].ToString();
		data.reference = transaction ["reference"].ToString();
		data.typetransaction = "default";
		data.type =  transaction ["type"].ToString();
		data.state = transaction ["state"].ToString();
		data.value = double.Parse(transaction ["value"].ToString());
		data.currency = transaction ["currency"].ToString();
		data.day = transaction ["date"].ToString();
		data.description = transaction ["description"].ToString();
		return data;
	}
}
