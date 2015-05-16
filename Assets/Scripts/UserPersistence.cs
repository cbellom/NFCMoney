using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class UserPersistence : MonoBehaviour {

	public static UserData userData = new UserData();
	
	public static void Save(UserData data) {
		SetEnvironment ();
		BinaryFormatter buffer = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + Path.DirectorySeparatorChar + "easyMoney.gd"); 		
		UserPersistence.userData = data;
		buffer.Serialize(file, UserPersistence.userData);
		file.Close();
	}	
	
	public static void Load() {
		SetEnvironment ();
		if(File.Exists(Application.persistentDataPath +  Path.DirectorySeparatorChar + "easyMoney.gd")) {
			BinaryFormatter buffer = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "easyMoney.gd", FileMode.Open);
			UserPersistence.userData = (UserData)buffer.Deserialize(file);
			file.Close();
		}
	}
	
	public static void ClearData (){		
		UserData data = new UserData();
		Save(data);
	}	

	private static void SetEnvironment ()	{
		Environment.SetEnvironmentVariable ("MONO_REFLECTION_SERIALIZER", "yes");
	}
}
