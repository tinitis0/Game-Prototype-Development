using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeAmount;
    public Button upgradeButton;

    public Text sellamount;

    private Building target;

    public void TargetSet (Building Ttarget)
    {
        target = Ttarget;

        transform.position = target.GetBuildPosition();

        
        if (!target.isUpgraded) // if the targated building is not upgraded then player can upgrade it
        {
            upgradeAmount.text = "£" + target.BP.upgradeCost;
            upgradeButton.interactable = true; // anables the button to be interactable with
        }
        else
        {
            upgradeAmount.text = "Done"; // upgrade text turns into done when fully upgraded
            upgradeButton.interactable = false; // disables the button to upgrade the turret when the turret is upgraded
        }
        sellamount.text = "£" + target.BP.GetSellAmount();

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void TurretUpgrade()
    {
        target.Upgrade();
        GameManager.instance.DeselectBuilding();
    }

    public void Sell()
    {
        target.SellTurret();
        GameManager.instance.DeselectBuilding();
    }

}
