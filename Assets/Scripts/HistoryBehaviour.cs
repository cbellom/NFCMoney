using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HistoryBehaviour : MonoBehaviour {

	public GameObject panelPrefabTransaction;
	public GameObject listTransaction;
	public UserDataBehaviour userDataBehaviour;
	public Sprite social;
	public Sprite food;
	public Sprite transport;	
	public Sprite defaultIcon;

	public List<Color> colorByTransactionState;

	public void UpdateListTransaction(){
		ClearList ();
		List<TransactionData> transactions = userDataBehaviour.data.transactions;
		foreach(TransactionData transaction in transactions){
			DrawTransaction(transaction);
		}
	}

	private void ClearList () {
		foreach(Transform  child in listTransaction.transform ) {
			Destroy (child.gameObject);
		}
	}

	private void DrawTransaction (TransactionData transaction){
		GameObject newItem = Instantiate(panelPrefabTransaction) as GameObject;
		newItem.transform.FindChild("Image").GetComponent<Image>().sprite = getImageByTransactionType(transaction.typeService);
		newItem.transform.FindChild ("Day").GetComponent<Text> ().text = transaction.day;
		newItem.transform.FindChild ("Reference").GetComponent<Text> ().text = "Reference: " + transaction.reference;
		newItem.transform.FindChild ("Value").GetComponent<Text> ().text = "$ " +transaction.value.ToString();
		newItem.GetComponent<Image> ().color = getColorByTransactionState (transaction.state);
		newItem.transform.SetParent(listTransaction.gameObject.transform, false);	
	}

	private Color getColorByTransactionState(string state){
		Color color;
		if (state == "todo") {
			color = colorByTransactionState[0];
		} else if (state == "done") {
			color = colorByTransactionState[1];
		} else if (state == "reject") {
			color = colorByTransactionState[2];
		} else {
			color = colorByTransactionState[3];
		}
		return color;
	}

	private Sprite getImageByTransactionType(string type){
		Sprite img;
		if (type == "social") {
			img = social;
		} else if (type == "food") {
			img = food;
		} else if (type == "transport") {
			img = transport;
		} else {
			img = defaultIcon;
		}
		return img;
	}
}
