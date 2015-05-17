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

	public void Createtransantion ()	{

		try{
			userDataBehaviour.Load();
			UserData userdata = UserPersistence.userData;
			TransactionData transdata = new TransactionData();
			if( InputFieldAmount.text != "" )//Validar el Banco
			{
				if(AmountislessToAmountUser(userdata,System.Convert.ToDouble(InputFieldAmount.text)) == true){
					transdata.value = System.Convert.ToDouble(InputFieldAmount.text);
					transdata.currency = "COP";
					transdata.id = "1";
					transdata.reference = "102297798";
					transdata.state = "todo";
					transdata.type = "food";
					transdata.day = System.DateTime.Now.ToString("d-MMM-yyyy-HH-mm-ss-f");
					transdata.description = "vaca yisus";	
					transdata.typetransaction ="Pay";
					userdata.transactions.Add(transdata);
					UpdateAmountUser(userdata,transdata);
					userDataBehaviour.Save (userdata);
					Debug.Log(userdata.amount);
				}
				else{
					Debug.Log("You  hasn't money");
				}
			}
			else{
				Debug.Log("Enter the correct");
			}

		}catch{
			Debug.Log("Error Createtransantion");
		}
	}

	public void UpdateAmountUser(UserData userdata, TransactionData transdata)
	{
		userdata.Setamount(userdata.getamount()-transdata.value);
	}

	public bool AmountislessToAmountUser(UserData userdata,double AmountUser)
	{
		if (userdata.getamount() < AmountUser) {
			Debug.Log("qui tt");
			return false;

		} else {
			return true;
		}
	}
}
