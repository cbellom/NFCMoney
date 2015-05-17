using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class TransactionData {
	public int id;
	public string reference;//phone
	public string typetransaction;
	public string type;
	public string state;
	public double value;
	public string currency;
	public string day;
	public string description;
}
