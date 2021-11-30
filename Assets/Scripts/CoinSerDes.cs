using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class CoinSerDes : MonoBehaviour
{
    public static CoinSerDes coinSerDes;
    /* COINDATA FORMATTER */
    void Awake(){
        coinSerDes = this;
    }
    public void SaveCoin(CoinData x)
    {
        string coinStoragePath = Application.persistentDataPath + "/xxxx.rvc";
        Debug.Log(coinStoragePath);
       FileStream  fileStream = new FileStream(coinStoragePath,FileMode.Create,FileAccess.Write);
       BinaryFormatter bf = new BinaryFormatter();
        Debug.Log("CoinSave Line Executed");
        bf.Serialize(fileStream,x);
        fileStream.Close();
       
    }

    public CoinData LoadCoin()
    {
        
        string coinStoragePath = Application.persistentDataPath + "/xxxx.rvc";
        Debug.Log(coinStoragePath);
       FileStream  fileStream = File.Open(coinStoragePath,FileMode.OpenOrCreate,FileAccess.Read);
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log("LoadFile Executed Successfully");
        if (File.Exists(coinStoragePath) && fileStream.Length > 0) {
            CoinData coinData = bf.Deserialize(fileStream) as CoinData;
            fileStream.Close();
            return coinData;
        } else {
            fileStream.Close();

            Debug.Log("No coin file was found");
            return null;
        }
        
        
        
    }


    
}
