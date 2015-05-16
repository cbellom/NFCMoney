using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class UserData  {
	public int id;
	public string phone;
	public double amount;
	public List<TransactionData> transactions;
}
