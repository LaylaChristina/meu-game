using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public int lives = 3;
    public Text txtLife;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin")){
            SFXManager.instance.ShowCoinParticles(other.gameObject);
            AudioManager.instance.PlaySoundCandy(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementCoinCount();
            Impulse(14);
        }

        if (other.gameObject.CompareTag("Gift")){
            StopMusicAndTape();
            AudioManager.instance.PlaySoundLevelComplete(gameObject);
            DestroyPlayer();
            ////
            LevelManager.instance.ShowLevelCompletePanel();

        }

        
        
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            lives = lives - 1;
            txtLife.text = "x " + lives;
            SFXManager.instance.ShowEnemyParticles(other.gameObject);
            AudioManager.instance.PlaySoundDamage(gameObject);
            Destroy(other.gameObject);
            if (lives == 0) {
                KillPlayer();
            }
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Forbidden")) {
            KillPlayer();
        }

        void StopMusicAndTape(){
            Camera.main.GetComponentInChildren<AudioSource>().mute =true;
            LevelManager.instance.SetTapeSpeed(0);
        }

        void KillPlayer(){
            StopMusicAndTape();
            AudioManager.instance.PlaySoundFail(gameObject);
            SFXManager.instance.ShowDieParticles(gameObject);
            DestroyPlayer();
            LevelManager.instance.ShowGameOverPanel();
        }

        void Impulse(float force){
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up*force, ForceMode2D.Impulse);
        }

        void DestroyPlayer(){
            Camera.main.GetComponent<CameraFollow>().TurnOff();
            Destroy(gameObject);

        }


    }
}
