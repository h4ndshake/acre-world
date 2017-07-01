using UnityEngine;

public class Weapon : MonoBehaviour {
  #region VARIAVEIS
  Animator anim;
  AudioSource _AudioSource;
  float timer;
  bool isReloading = false;
  bool shootInput;
  Vector3 originalPosition;
  bool isAiming;

  [HideInInspector] public int totalBullets;

  public float aimSpeed;
  public Vector3 aimPosition;
  public int bulletsPerMag = 30; // Quantidade de balas no pente
  public int currentBullets; // Quantas balas restam no pente
  public int bulletsLeft; // Quantas balas, no total, restam
  public Transform ignitionPoint; // O ponto de onde o raycast será iniciado
  public float shootDelay = 0.1f; // O intervalo entre um tiro e outro
  public float distance = 100f; // O alcance da arma, em metros
  public ParticleSystem muzzleParticle; // A particula a ser gerada pelo ano da arma ao atirar
  public AudioClip shootsound; // O som que será tocado ao atirar
  public float damage;
  public shootMode shootingMode;
  public GameObject hitParticles;
  public GameObject bulletHole;
  public enum shootMode {
    Auto,
    Semi
  }
  #endregion


  // Use this for initialization
  void Start() {
    totalBullets = currentBullets;

    anim = GetComponent<Animator>();
    _AudioSource = GetComponent<AudioSource>();
    currentBullets = bulletsPerMag;

    originalPosition = transform.localPosition;
  }

  // Update is called once per frame
  void Update() {
    AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
    isReloading = info.IsName("Reload");

    anim.SetBool("Aim", isAiming);

    switch(shootingMode) {
      case shootMode.Auto:
        shootInput = Input.GetButton("Fire1");
        break;
      case shootMode.Semi:
        shootInput = Input.GetButtonDown("Fire1");
        break;
    }

    if (shootInput) {
      if(currentBullets > 0)
        Fire();
      else if (bulletsLeft > 0) {
        DoReload();
      }
    }

    if (Input.GetKeyDown(KeyCode.R)) {
      if (currentBullets < bulletsPerMag && bulletsLeft > 0)
        DoReload();
    }
      

    if (timer < shootDelay)
      timer += Time.deltaTime;

    aimDownSights();
  }

  void aimDownSights () {
    if (Input.GetButton("Fire2") && !isReloading) {
      transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * aimSpeed);
      isAiming = true;
    } else {
      transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * aimSpeed);
      isAiming = false;
    }
  }

  void Fire() {
    if (timer < shootDelay || currentBullets <= 0 || isReloading)
      return;

    RaycastHit hit;

    if(Physics.Raycast(ignitionPoint.position, ignitionPoint.transform.forward, out hit, distance)) {
      GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
      hitParticleEffect.transform.SetParent(hit.transform);

      GameObject bulletHoleEffect = Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
      bulletHoleEffect.transform.SetParent(hit.transform);

      Destroy(hitParticleEffect, 1);
      Destroy(bulletHoleEffect, 3);

      if (hit.transform.GetComponent<HealthController>()) {
        hit.transform.GetComponent<HealthController>().ApplyDamage(damage);
      }
    }

    anim.CrossFadeInFixedTime("Shoot", shootDelay); // Toca a animação de tiro
    muzzleParticle.Play(); // Cria a particula de faísca no cano da arma
    tocarSomDeTiro(); // Toca o som do tiro

    currentBullets--; // Reduz o número de balas
    timer = 0.0f; // Reseta o timer do tiro
  }

  public void Reload() {
    if (bulletsLeft <= 0)
      return;

    int balasASeremCarregadas = bulletsPerMag - currentBullets;
    int balasASeremDeduzidas = (bulletsLeft >= balasASeremCarregadas) ? balasASeremCarregadas : bulletsLeft;

    bulletsLeft -= balasASeremDeduzidas;
    currentBullets += balasASeremDeduzidas;
  }

  void DoReload() {
    if (isReloading)
      return;
    
    anim.CrossFadeInFixedTime("Reload", 0.01f);

  }

  void tocarSomDeTiro(){
    _AudioSource.PlayOneShot(shootsound);
  }
}