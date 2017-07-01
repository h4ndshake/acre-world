using UnityEngine;

public class HealthController : MonoBehaviour {
  [SerializeField] float health;

  public void ApplyDamage(float damage) {
    Debug.Log("Dano de: " + damage + " Recebido");

    health -= damage;

    if (health <= 0f) {
      Component[] renderers = GetComponentsInChildren(typeof(Renderer));
      foreach(Renderer childRenderer in renderers)
      {
        foreach (Material mat in childRenderer.materials) {
          mat.color = Color.red;
        }
      }
      Destroy(gameObject, 2);
    }
  }
}
