using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHUB : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI magText;

    public static AmmoHUB instance;

    void Awake()
    {
        instance = this;
    }

    public void updateAmmoText(int AmmoCount, int maxAmmo)
    {
        ammoText.text = $"Ammo : {AmmoCount}/{maxAmmo}";
    }

    public void updateMagText(int MagCount)
    {
        magText.text = $"Mag : {MagCount}";
    }

}
