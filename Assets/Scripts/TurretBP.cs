using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBP {

    public GameObject Turret;
    public int costAmount;

    public GameObject upgradedTurret;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return costAmount / 2;
    }

}
