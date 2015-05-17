using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeneratePay : MonoBehaviour {


	public Button buttongenerate;
	public InputField InputFieldAmount;
	public Button buttonSave;
	public Button buttonEmail;
	public Sprite imageQR;
	public UserDataBehaviour userDataBehaviour;
	public Texture2D texture;
	
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

		StartCoroutine(GetQRCodeToFindTransaction12312 (transaction));

		Debug.Log(userdata.amount);
	}

	private IEnumerator GetQRCodeToFindTransaction(TransactionData data){
		string url = "http://qrickit.com/api/qr?d="+GameSettings.Instance.findTransactionURL+"?reference="+WWW.EscapeURL (data.reference);
		Texture2D texture = new Texture2D(1,1);
		WWW www = new WWW(url);
		yield return www;
		www.LoadImageIntoTexture(texture);
		
		Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		imageQR = image;
	}

	private IEnumerator GetQRCodeToFindTransaction12312(TransactionData data){
		string url = "http://qrickit.com/api/qr?d="+GameSettings.Instance.findTransactionURL+"?reference="+WWW.EscapeURL (data.reference);

		texture = new Texture2D(4, 4, TextureFormat.DXT1, false);
		while(true) {
			// Start a download of the given URL
			WWW www = new WWW(url);
			
			// wait until the download is done
			yield return www;
			
			// assign the downloaded image to the main texture of the object
			www.LoadImageIntoTexture(texture);
		}
	}

	
}
