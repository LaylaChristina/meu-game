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
    public float TimeAfterHurt = 2;
    public Color flashColor;
    public Color regularColor;
    public float flashTime;
    public int numberFlashs;
    public SpriteRenderer hurtSprite;
    bool isHurting;



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

        else if (other.gameObject.CompareTag("Loli")){
            SFXManager.instance.ShowCoinParticles(other.gameObject);
            AudioManager.instance.PlaySoundCandy(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementCoinCount();
            LevelManager.instance.IncrementCoinCount();
            Impulse(16);
        }


        else if (other.gameObject.CompareTag("Power")){
            SFXManager.instance.ShowCoinParticles(other.gameObject);
            AudioManager.instance.PlaySoundCandy(other.gameObject);
            Destroy(other.gameObject);
            LevelManager.instance.IncrementCoinCount();
            LevelManager.instance.IncrementCoinCount();
            LevelManager.instance.IncrementCoinCount();
            LevelManager.instance.IncrementCoinCount();
            LevelManager.instance.IncrementCoinCount();
            Impulse(16);
        }


        else if (other.gameObject.CompareTag("Gift")){
            StopMusicAndTape();
            AudioManager.instance.PlaySoundLevelComplete(gameObject);
            DestroyPlayer();
            ////
            LevelManager.instance.ShowLevelCompletePanel();

        }

        
        
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            lives = lives - 1;
            txtLife.text = "x " + lives;
            AudioManager.instance.PlaySoundDamage(gameObject);
            anim.SetInteger ("state", 1);
            StartCoroutine(HurtBlinker());
            SFXManager.instance.ShowEnemyParticles(other.gameObject);
            Destroy(other.gameObject);
            if (lives == 0) {
                KillPlayer();
            }
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Forbidden")) {
            lives = lives - 1;
            txtLife.text = "x " + lives;
            AudioManager.instance.PlaySoundDamage(gameObject);
            anim.SetInteger ("state", 1);
            StartCoroutine(HurtBlinker());
            Impulse(16);
            if (lives == 0) {
                KillPlayer();
            }
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

    private IEnumerator HurtBlinker (){
        int temp = 0;
        Physics2D.IgnoreLayerCollision (8, 9, true);
        while(temp < numberFlashs){
            hurtSprite.color = flashColor;
            yield return new WaitForSeconds(flashTime);
            hurtSprite.color = regularColor;
            yield return new WaitForSeconds(flashTime);
            temp++;
        }
        Physics2D.IgnoreLayerCollision (8, 9, false);
        anim.SetInteger ("state", 0);
    }
}
