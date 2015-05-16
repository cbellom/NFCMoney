﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JsonWordsParser  {

	private int levelFilter; 
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
		data.id = user ["id"].ToString() as int;
		data.amount = user ["amount"].ToString() as double;
		data.phone = user ["phone"].ToString() as double;
		data.transactions = CreateTransactionList( user["transactions"] as List<object>);
		return data;
	}
	
	private List<string> CreateTransactionList (List<object> transactions)	{
		List<TransactionData> transactionsList = new List<TransactionData> ();
		foreach(Dictionary<string, object> transaction in transactions){
			transactionsList.Add(CreateTransactionObject(transaction));
		}
		return transactionsList;		
	}

	private TransactionData CreateTransactionObject (Dictionary<string, object> transaction)	{
		TransactionData data = new TransactionData ();
		data.id = transaction ["id"].ToString() as int;
		data.reference = transaction ["reference"].ToString() as double;
		data.type = transaction ["type"].ToString() as double;
		data.state = transaction ["state"].ToString() as double;
		data.value = transaction ["value"].ToString() as double;
		data.currency = transaction ["currency"].ToString() as double;
		return data;
	}
}
