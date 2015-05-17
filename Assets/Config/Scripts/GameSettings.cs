using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class GameSettings : ScriptableObject {
	public const string ASSET_NAME = "GameSettings";
	
	public string getUserDataURL;
	public string registerTransactionURL;
	public string updateStateTransactionURL;
	public string findTransactionURL;
	public string updateAmountUserURL;
	public string phoneNumber;

	private static GameSettings instance; 
	
	public static GameSettings Instance 
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load (ASSET_NAME) as GameSettings;
			}
			
			
			return instance;
		}
	}
}
