using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerateRechange : MonoBehaviour {

	public InputField InputFieldName;
	public InputField InputFieldIDuser;
	public InputField InputFieldamount;
	public InputField InputFieldPhone;
	public Button ButtonRechange;
	public Button ButtonBack;
	public Button ButtonSelectBank;

	public UserDataBehaviour userDataBehaviour;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		ButtonRechange.onClick.AddListener (delegate {
			Createtransantion();

		});
	}

	public void Createtransantion ()	{
		userDataBehaviour.Load ();
		UserData userdata = UserPersistence.userData;
		TransactionData transdata = new TransactionData ();
		//try{
			
			transdata.value = System.Convert.ToDouble(InputFieldamount.text);
			transdata.currency = "COP";
			transdata.id = 1;
			transdata.reference = InputFieldIDuser.text;
			transdata.state = "done";
			transdata.type = "Bank";
			transdata.typetransaction ="Rechangue";
			transdata.day = "00/00/0000";
			userdata.transactions.Add(transdata);
			userdata.Setamount(userdata.getamount()+transdata.value);
			userDataBehaviour.Save (userdata);
			Debug.Log("Monto"+ userdata.amount);
	/*	}catch (Exception e){
			Debug.Log("Error Createtransantion"+e);
		}*/
	}

}
