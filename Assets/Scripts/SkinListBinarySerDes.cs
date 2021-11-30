using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public  class SkinListBinarySerDes : MonoBehaviour
{
    public static SkinListBinarySerDes skinListBinarySerDes;
    void Awake(){
        skinListBinarySerDes = this;
        
    }
    /* SKIN NAME LIST FORMATTER */
    public void SerNameList(List<string> newList){
        string namePath = Application.persistentDataPath + "/sknlsts.rvc";
        FileStream streamFile = new FileStream(namePath,FileMode.OpenOrCreate,FileAccess.ReadWrite);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(streamFile,newList);
        streamFile.Close();
    }
    
    public  List<string> DesNameList(){
        string namePath = Application.persistentDataPath + "/sknlsts.rvc";
        FileStream streamFile = new FileStream(namePath,FileMode.OpenOrCreate,FileAccess.ReadWrite);
        BinaryFormatter bf = new BinaryFormatter();
        if (streamFile.Length > 0)
        {List <string> extractedSkinNames = bf.Deserialize(streamFile) as List<string>;
        streamFile.Close();
        return extractedSkinNames;
        } else {
            Debug.Log("No list file was found.");
            streamFile.Close();
            return null;
        }
        
    }
    /* SKIN NAME LIST FORMATTER */


    
}
