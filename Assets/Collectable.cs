using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectable : MonoBehaviour
{
    public AudioClip collect;
    public AudioSource sfxPlayer;

    public static event Action OnCollected;
    public static int total;

    void Awake() => total++;

    void Update()
    {
        // transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
            sfxPlayer.PlayOneShot(collect);
            

        }
    }
}