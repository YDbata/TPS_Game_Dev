using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rifle : MonoBehaviour
{

    [Header("Rifle Things")]
    [SerializeField] Camera cam;
    [SerializeField] float damage = 10f;
    [SerializeField] float shootingRange = 100f;

    [SerializeField] Animator animator;
    [SerializeField] PlayerController playerController;

    [Header("Rifle Effects")]
    [SerializeField] ParticleSystem muzzleSpark;
    [SerializeField] GameObject ImpactEffect;


    [Header("Rifle Shooting")]
    [SerializeField] private float fireCharge = 10f;

    private float nextTimeToShoot = 0;

    [Header("Rifle Ammunition")]
    [SerializeField] int maxAmmo = 20; // �ִ� �Ѿ� ����
    [SerializeField] int mag = 15; // ���� źâ ����
    [SerializeField] int curAmmo; // ���� �Ѿ� ����
    [SerializeField] float reloadingTime = 1.3f; // ������ �ð�
    [SerializeField] bool setReloading = false; // ������ ����

    private void Awake()
    {
        curAmmo = maxAmmo;
        //playerController = GetComponent<PlayerController>();

    }
    // Update is called once per frame
    void Update()
    {
        if (setReloading) return;

        if(curAmmo <= 0 && mag > 0)
        {
            // ������
            StartCoroutine(Reload());
            return;
        }

        bool onFire = Input.GetButton("Fire1");
        if (onFire && Time.time >= nextTimeToShoot) // ��Ŭ��
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);
            nextTimeToShoot = Time.time + 1/fireCharge;
            Shoot();
            
        }
        else if(!onFire) // ��Ŭ�� ���
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            nextTimeToShoot = 0;
        }
    }

    private void Shoot()
    {
        curAmmo--;
        RaycastHit hitinfo;
        muzzleSpark.Play();

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitinfo, shootingRange))
        {
            Debug.Log(hitinfo.collider.name);

            Damageable damageable = hitinfo.collider.gameObject.GetAroundComponent<Damageable>();
            Enemy enemy = hitinfo.collider.gameObject.GetAroundComponent<Enemy>();
            StandEnemy standEnemy = hitinfo.collider.gameObject.GetAroundComponent<StandEnemy>();
            Turrat turrat = hitinfo.collider.gameObject.GetAroundComponent<Turrat>();
            /*
                        if(damageable)
                        {
                            damageable.HitDamage(damage);
                        }
                        if(enemy)
                        {
                            enemy.HitDamage(damage);
                        }
                        if (standEnemy)
                        {
                            standEnemy.HitDamage(damage);
                        }
                        if (turrat)
                        {
                            turrat.HitDamage(damage);
                        }*/
            Damage<Damageable>(damageable, hitinfo);
            Damage<Enemy>(enemy, hitinfo);
            Damage<StandEnemy>(standEnemy, hitinfo);
            Damage<Turrat>(turrat, hitinfo);
            
        }
    }

    private void Damage<T>(T enemy, RaycastHit hitinfo) where T : IDamageable
    {
        if (enemy == null) return;
        enemy.HitDamage(damage);
        GameObject impact = Instantiate(ImpactEffect, hitinfo.point, Quaternion.LookRotation(hitinfo.normal)); //   Quaternion.identity
        Destroy(impact, 1.0f);
    }



    IEnumerator Reload()
    {
        playerController.CanMove = false;
        setReloading = true;
        Debug.Log("Reloading..");
        animator.SetBool("Reloading", true );
        yield return new WaitForSeconds(reloadingTime);
        animator.SetBool("Reloading", false);

        curAmmo = maxAmmo;
        playerController.CanMove = true;
        setReloading = false;
        mag--;
    }

}
