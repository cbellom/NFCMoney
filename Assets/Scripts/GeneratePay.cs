using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GeneratePay : MonoBehaviour {


	public Button buttongenerate;
	public InputField InputFieldAmount;
	public Button buttonSave;
	public Button buttonEmail;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		buttongenerate.onClick.AddListener (delegate {
			Createtransantion ();
		});
	}

	void Createtransantion ()
	{
		UserPersistence.Load ();
		UserData userdata = UserPersistence.userData;
		TransactionData transdata = new TransactionData ();
		transdata.value = double.Parse(InputFieldAmount.text);
		transdata.currency = "COP";
		transdata.id = 1;
		transdata.reference = "102297798";
		transdata.state = "todo";
		transdata.type = "food";
		userdata.transactions.Add(transdata);
	}
}
