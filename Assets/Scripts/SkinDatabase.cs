using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SkinDatabase : ScriptableObject
{
   public SpriteData[] sp;
   public int skinLength{
       get { return sp.Length;}
       
    }
    
   public SpriteData SelectSkinAt(string str){
       int i;
       for ( i = 0; i < skinLength; i++){
           if (sp[i].skin_Name == str){
               
               break;
           }
       }
       return sp[i];
       
   }
}
