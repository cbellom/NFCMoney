using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerateRecharge : MonoBehaviour {

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
			CreateTransantion();

		});
	}

	public void CreateTransantion ()	{
		userDataBehaviour.Load ();
		TransactionData transdata = new TransactionData ();
		try{

			if( InputFieldamount.text != "" || InputFieldIDuser.text != ""||InputFieldPhone.text != "" || InputFieldIDuser.text != "")//Validar el Banco
			{
				transdata.value = System.Convert.ToDouble(InputFieldamount.text);
				transdata.currency = "COP";
//				transdata.id =InputFieldIDuser.text;s
				transdata.reference =InputFieldPhone.text; 
				transdata.state = "done";
				transdata.typeService = "bank";
				transdata.typeTransaction ="rechangue";
				transdata.day = System.DateTime.Now.ToString("d-MMM-yyyy-HH-mm-ss-f");
				transdata.targetUser ="+573003268650";
				
				StartCoroutine(RegisterTransactionOnServer(transdata));
			} else
			{
				Debug.Log("Enter the correct");
			}
		}catch {
			Debug.Log("Error Createtransantion");
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
		ReadTransactionJsonAndSaveLocalData (getData.text);
	}
	
	
	private void ReadTransactionJsonAndSaveLocalData (string json){
		JsonTransactionParser parser = new JsonTransactionParser();
		TransactionData transaction = new TransactionData ();
		parser.JSONString = json;
		transaction = parser.Data;
		
		UserData userdata = UserPersistence.userData;
		userdata.transactions.Add(transaction);
		userdata.Setamount(userdata.getamount()+transaction.value);
		
		StartCoroutine(RegisterAmountOnServer(userdata));
		Debug.Log(userdata.amount);
	}

	private IEnumerator RegisterAmountOnServer(UserData data){
		string url = GameSettings.Instance.updateAmountUserURL + "?"+
			"phone="+ WWW.EscapeURL (GameSettings.Instance.phoneNumber)+
			"&amount="+WWW.EscapeURL (data.amount.ToString());
		Debug.Log ("Send data to " + url);
		WWW getData = new WWW (url);
		yield return getData;
		Debug.Log (getData.text);
		ReadAmountMessageJsonAndSaveLocalData (getData.text, data);
	}

	private void ReadAmountMessageJsonAndSaveLocalData (string json, UserData data){
		JsonDefaultMsgParser parser = new JsonDefaultMsgParser();
		string message = "";
		bool isOK = false;
		parser.JSONString = json;
		message = parser.Data;
		isOK = parser.isOK;

		if (isOK) {
			userDataBehaviour.Save (data);
			Debug.Log(data.amount);
			Debug.Log("Monto"+ data.amount);
		} else {
			Debug.Log("Error server comunication "+ message);
		}

	}

}
