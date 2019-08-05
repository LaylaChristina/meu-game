using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
   
   public static AudioManager instance;

   public AudioSFX audioSFX;
   void Awake () {
       if (instance == null) {
           instance = this;
       }
   }
   public void PlaySoundCandy(GameObject obj) {
       AudioSource.PlayClipAtPoint(audioSFX.candy, obj.transform.position);
   }
   
   public void PlaySoundFail(GameObject obj) {
       AudioSource.PlayClipAtPoint(audioSFX.fail, obj.transform.position);
   }

   public void PlaySoundLevelComplete(GameObject obj) {
       AudioSource.PlayClipAtPoint(audioSFX.levelComplete, obj.transform.position);
   }

   public void PlaySoundPower(GameObject obj) {
       AudioSource.PlayClipAtPoint(audioSFX.power, obj.transform.position);
   }
}
