using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HistoryBehaviour : MonoBehaviour {

	public GameObject panelPrefabTransaction;
	public GameObject listTransaction;
	public UserDataBehaviour userDataBehaviour;

	public void UpdateListTransaction(){
		List<TransactionData> transactions = userDataBehaviour.data.transactions;
		foreach(TransactionData transaction in transactions){
			DrawTransaction(transaction);
		}
	}

	private void DrawTransaction (TransactionData transaction){
		GameObject newItem = Instantiate(panelPrefabTransaction) as GameObject;
		newItem.transform.FindChild("Image").GetComponent<Image>().sprite = null;
		newItem.transform.FindChild("Text").GetComponent<Text>().text = transaction.reference +"\n "+ transaction.value;
		newItem.transform.SetParent(listTransaction.gameObject.transform, false);	
	}
}
