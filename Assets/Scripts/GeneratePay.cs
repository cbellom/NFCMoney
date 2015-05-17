using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GeneratePay : MonoBehaviour {


	public Button buttongenerate;
	public InputField InputFieldAmount;
	public Button buttonSave;
	public Button buttonEmail;
	public UserDataBehaviour userDataBehaviour;

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

	void Createtransantion ()	{
		userDataBehaviour.Load ();
		UserData userdata = UserPersistence.userData;
		TransactionData transdata = new TransactionData ();
		try{
			transdata.value = 1f;
			transdata.currency = "COP";
			transdata.id = 1;
			transdata.reference = "102297798";
			transdata.state = "todo";
			transdata.type = "food";
			transdata.day = "00/00/0000";
			transdata.description = "vaca yisus";	
			userdata.transactions.Add(transdata);
			userDataBehaviour.Save (userdata);
		}catch{
			Debug.Log("Error Createtransantion");
		}
	}
}
