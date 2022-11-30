using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCount1 : MonoBehaviour
{
   TMPro.TMP_Text text;
   int count;

   void Awake()
   {
       text = GetComponent<TMPro.TMP_Text>();
   }

   void Start() => UpdateCount();

void OnEnable() => Collectable.OnCollected += OnCollectibleCollected;
void OnDisable() => Collectable.OnCollected -= OnCollectibleCollected;

   void OnCollectibleCollected()
   {
       count++;
       UpdateCount();
   }

   void UpdateCount()
   {
       text.text = $"{count}";
   }
}