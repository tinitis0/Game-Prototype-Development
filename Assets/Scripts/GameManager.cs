using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    
    private TurretBP turretToBuild;
    private Building selectedBuilding;

    public TurretUI turretUI;

    public bool CanBuild { get { return turretToBuild != null; } } // property, only allows it to get someonething from it.
    public bool EnoughMoney { get { return Currency.Gold >= turretToBuild.costAmount; } }

    
    public void SelectBuilding(Building building)
    {
        if (selectedBuilding == building)
        {
            DeselectBuilding();
            return;
        }

        selectedBuilding = building; // when building is selected, the turret is deselected
        turretToBuild = null;

        turretUI.TargetSet(building);
    }

    public void DeselectBuilding()
    {
        selectedBuilding = null;
        turretUI.Hide();
    }


    public void SelectTurretToBuild(TurretBP turret)
    {
        turretToBuild = turret;// when turret is selected the building is deselected
        DeselectBuilding();

    }

    public TurretBP GetTurretToBuild()
    {
        return turretToBuild;
    }


}