using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

  [SerializeField] float health;

  public void ApplyDamage(float damage) {
    Debug.Log("Dano de: " + damage + " Recebido");

    health -= damage;

    if (health <= 0f) {
      Destroy(gameObject, 3);
    }
  }
}
