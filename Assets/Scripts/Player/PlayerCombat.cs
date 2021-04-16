using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{

    public static PlayerCombat Instance;

    public Gun SelectedWeapon;

    private AudioSource audio;

    public float ReloadSpeed = 1.00f;

    public bool isReloading = false;
    public TextMeshProUGUI reloadingText;
    public TextMeshProUGUI AmmoText;

    public SpriteRenderer spriteRenderer;

    public GameObject bullet;
    public Transform bulletSpawn;

    private float nextTime;
    private float delay;

    public float ReloadTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        delay = GetFireRate(SelectedWeapon);
        ReloadTime = SelectedWeapon.ReloadTime;
        audio = GetComponent<AudioSource>();
        spriteRenderer.sprite = SelectedWeapon.GunImage;
        ReloadGun(SelectedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) return;
        if (SelectedWeapon.CurrentAmmo > 0)
        {
            if (SelectedWeapon.AmmoInClip <= 0 || (Input.GetKeyDown(KeyCode.R) && SelectedWeapon.AmmoInClip < SelectedWeapon.ClipSize))
            {
                StartCoroutine(Reload());
                return;
            }
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTime && !isReloading && SelectedWeapon.AmmoInClip > 0)
        {
            Shoot();
        }

        void Shoot()
        {
            nextTime = Time.time + 1f * delay / 2;
            SelectedWeapon.AmmoInClip--;
            AmmoText.SetText(SelectedWeapon.AmmoInClip.ToString() + "/" + SelectedWeapon.CurrentAmmo.ToString());


            GameObject SpawnedBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            SpawnedBullet.GetComponent<SpriteRenderer>().sprite = SelectedWeapon.ProjectileImage;
            Rigidbody2D rb = SpawnedBullet.GetComponent<Rigidbody2D>();
            audio.clip = SelectedWeapon.ShootSound;
            audio.Play();
            rb.velocity = SpawnedBullet.transform.right * SelectedWeapon.BulletSpeed;
            Destroy(SpawnedBullet, GetRange(SelectedWeapon));
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadingText.SetText("Reloading...");

        yield return new WaitForSeconds(ReloadTime / ReloadSpeed);
        int ammoReloaded = SelectedWeapon.ClipSize - SelectedWeapon.AmmoInClip;

        reloadingText.SetText(" ");

        if (SelectedWeapon.AmmoInClip >= SelectedWeapon.ClipSize)
        {
            SelectedWeapon.CurrentAmmo = SelectedWeapon.ClipSize;
            SelectedWeapon.AmmoInClip -= ammoReloaded;
        }
        else
        {
            int totalAmmo = SelectedWeapon.AmmoInClip + SelectedWeapon.CurrentAmmo;
            if (totalAmmo <= SelectedWeapon.ClipSize)
            {
                SelectedWeapon.AmmoInClip = totalAmmo;
                SelectedWeapon.CurrentAmmo = 0;
            }
            else
            {
                SelectedWeapon.AmmoInClip = SelectedWeapon.ClipSize;
                SelectedWeapon.CurrentAmmo = totalAmmo - SelectedWeapon.ClipSize;
            }
        }

        AmmoText.SetText(SelectedWeapon.AmmoInClip.ToString() + "/" + SelectedWeapon.CurrentAmmo.ToString());
        isReloading = false;
    }

    // METHODS
    public void ReloadGun(Gun gun)
    {
        gun.CurrentAmmo = gun.Ammo;
        gun.AmmoInClip = gun.ClipSize;
        AmmoText.SetText(SelectedWeapon.AmmoInClip.ToString() + "/" + SelectedWeapon.CurrentAmmo.ToString());
    }

    // RARITY METHODS
    public float GetDamage(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryDamage;
        }
        return 0;
    }

    public float GetFireRate(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryFireRate;
        }
        return 0;
    }

    public float GetRange(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryRange;
        }
        return 0;
    }

    public int GetCritChance(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonCritChance;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonCritChance;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareCritChance;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicCritChance;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryCritChance;
        }
        return 0;
    }

    public void UpgradeGunRarity(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            gun.Rarity = GunManager.RarityTypes.UnCommon;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            gun.Rarity = GunManager.RarityTypes.Rare;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            gun.Rarity = GunManager.RarityTypes.Epic;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            gun.Rarity = GunManager.RarityTypes.Legendary;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return;
        }
        ReloadGun(gun);
    }

    public float GetUpgradeCost(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonToUnCommonCost;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonToRareCost;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareToEpicCost;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicToLegendaryCost;
        }
        return 58353;
    }
}
