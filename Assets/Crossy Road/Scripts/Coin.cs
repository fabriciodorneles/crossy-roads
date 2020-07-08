using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public GameObject coin = null;
    public AudioClip audioClip = null;

    void OnTriggerEnter ( Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(" Player pegou uma moeda! ");

            Manager.instance.UpdateCoinCount(coinValue); //faz o update do coin lá no Manager

            coin.SetActive(false);

            this.GetComponent<AudioSource> ().PlayOneShot(audioClip);

            Destroy(this.gameObject, audioClip.length);
            
         }
    }
}
