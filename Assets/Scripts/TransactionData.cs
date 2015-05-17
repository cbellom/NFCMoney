using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class TransactionData {
	public string id;
	public string reference;//phone
	public string typeTransaction;
	public string typeService;
	public string state;
	public double value;
	public string currency;
	public string day;
	public string description;
	public string targetUser;
}
