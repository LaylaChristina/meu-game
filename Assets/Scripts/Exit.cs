using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
   public void doExit( ){
       Debug.Log ("exit game");
       Application.Quit();
   }


}
