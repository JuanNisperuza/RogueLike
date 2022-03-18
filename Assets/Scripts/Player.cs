using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalPosition;
    private float verticalPosition;
    public float Speed;
    public Transform aim;
    private Vector3 facingDirection;
    public Transform bullet;
    private bool gunLoaded = true;
    public float fireSpeed;
    public int health;
    private bool powerShotEnabled;
    private bool vulnerability = true;
    public int damage = 1;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            UIManager.Instance.UpdateHealth(Health);
        }
    }

    private void Start()
    {
        Health = 10;
    }

    private void Update()
    {
        movePlayer();
        Shot();
    }

    public void TakeDamage(int damage)
    {
        if (vulnerability)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.gameOver = true;
                UIManager.Instance.ShowGameOverScreen();
            }
        }
        StartCoroutine(invulnerability());
    }

    private IEnumerator invulnerability()
    {
        vulnerability = false;
        yield return new WaitForSeconds(3);
        vulnerability = true;
    }

    public void movePlayer()
    {
        horizontalPosition = Input.GetAxis("Horizontal");
        verticalPosition = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalPosition, verticalPosition, 0) * Time.deltaTime * Speed;
    }

    public void Shot()
    {
        facingDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + new Vector3(facingDirection.normalized.x, facingDirection.normalized.y, 0);
        if (Input.GetMouseButton(0) && gunLoaded)
        {
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Transform bulletClone = Instantiate(bullet, transform.position, rotation);
            if (powerShotEnabled)
            {
                bulletClone.GetComponent<Bullet>().isPowerShot = true;
            }
            StartCoroutine(ReloadGun());
        }
    }

    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / fireSpeed);
        gunLoaded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            switch (collision.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.FireRateIncrease:
                    fireSpeed++;
                    break;

                case PowerUp.PowerUpType.PowerShot:
                    powerShotEnabled = true;
                    break;
            }
            Destroy(collision.gameObject, 0.1f);
        }
    }
}