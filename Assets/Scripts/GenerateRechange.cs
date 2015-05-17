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
			CreateTransantion();

		});
	}

	public void CreateTransantion ()	{
		userDataBehaviour.Load ();
		UserData userdata = UserPersistence.userData;
		TransactionData transdata = new TransactionData ();
		try{

			if( InputFieldamount.text != "" || InputFieldIDuser.text != ""||InputFieldPhone.text != "" || InputFieldIDuser.text != "")//Validar el Banco
			{
				transdata.value = System.Convert.ToDouble(InputFieldamount.text);
				transdata.currency = "COP";
				transdata.id =InputFieldIDuser.text;
				transdata.reference =InputFieldPhone.text; 
				transdata.state = "done";
				transdata.typeService = "Bank";
				transdata.typeTransaction ="Rechangue";
				transdata.day = System.DateTime.Now.ToString("d-MMM-yyyy-HH-mm-ss-f");
				userdata.transactions.Add(transdata);
				userdata.Setamount(userdata.getamount()+transdata.value);
				userDataBehaviour.Save (userdata);
				Debug.Log("Monto"+ userdata.amount+ transdata.day);
			} else
			{
				Debug.Log("Enter the correct");
			}
		}catch {
			Debug.Log("Error Createtransantion");
		}
	}

}
