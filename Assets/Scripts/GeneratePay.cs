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

//		try{
			userDataBehaviour.Load();
			TransactionData transdata = new TransactionData();
			if( InputFieldAmount.text != "" )//Validar el Banco
			{
				if(AmountislessToAmountUser(userDataBehaviour.data,System.Convert.ToDouble(InputFieldAmount.text)) == true){
					transdata.value = System.Convert.ToDouble(InputFieldAmount.text);
					transdata.currency = "COP";
//					transdata.id = "1";
					transdata.reference = "102297798";
					transdata.state = "todo";
					transdata.typeService = "food";
					transdata.day = System.DateTime.Now.ToString("d-MMM-yyyy-HH-mm-ss-f");
					transdata.description = "vaca yisus";	
					transdata.typeTransaction ="Pay";
					transdata.targetUser ="+573003268650";

					StartCoroutine(RegisterTransactionOnServer(transdata));
				}
				else{
					Debug.Log("You  hasn't money");
				}
			}
			else{
				Debug.Log("Enter the correct");
			}

//		}catch{
//			Debug.Log("Error Createtransantion");
//		}
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

	private IEnumerator RegisterTransactionOnServer(TransactionData data){
		string url = GameSettings.Instance.registerTransactionURL + "?" +
			"ownerPhone="+ WWW.EscapeURL (GameSettings.Instance.phoneNumber)+
			"&typeTransaction="+WWW.EscapeURL (data.typeTransaction)+
			"&typeService="+WWW.EscapeURL (data.typeService)+
			"&state="+WWW.EscapeURL (data.state)+
			"&value="+WWW.EscapeURL (data.value.ToString())+
			"&currency="+WWW.EscapeURL (data.currency)+
			"&description="+WWW.EscapeURL (data.description)+
			"&targetUserPhone="+WWW.EscapeURL (data.targetUser);
		Debug.Log ("Send data to " + url);
		WWW getData = new WWW (url);
		yield return getData;
		Debug.Log (getData.text);
		ReadDataFromJsonAndSaveLocalData (getData.text);
	}

	
	private void ReadDataFromJsonAndSaveLocalData (string json){
		JsonTransactionParser parser = new JsonTransactionParser();
		TransactionData transaction = new TransactionData ();
		parser.JSONString = json;
		transaction = parser.Data;
		
		UserData userdata = UserPersistence.userData;
		userdata.transactions.Add(transaction);
		UpdateAmountUser(userdata,transaction);
		userDataBehaviour.Save (userdata);
		Debug.Log(userdata.amount);
	}

}
