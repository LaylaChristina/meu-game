﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    
    GameObject parent;

    public GameObject prefab;

    public GameObject spawnPoint;

    public float waitTime = 3f;

    public float projectileSpeed = 3f;

    public Vector3[] directions;

    bool naCamera = false;

    void Start()
    {
        parent = GameObject.Find("Tape");
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn (){
        while(true){
            yield return new WaitForSeconds(waitTime);
            if (naCamera) {
                for (int i=0; i<directions.Length; i++){
                    GameObject projectile = Instantiate (prefab, spawnPoint.transform.position, Quaternion.identity);
                    projectile.transform.SetParent(parent.transform);
                    projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * directions[i];
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Area")){
            Debug.Log("Entrou");
            naCamera = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Area")){
            Debug.Log("Saiu");
            naCamera = false;
        }
    }


}