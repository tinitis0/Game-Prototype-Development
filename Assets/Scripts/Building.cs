using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    public GameObject turret;
    public TurretBP BP;
    public bool isUpgraded = false;

   
    private Renderer RR;
    private Color startingColor;

    GameManager gameManager;


    void Start()
    {
        RR = GetComponent<Renderer>();
        startingColor = RR.material.color;

        gameManager = GameManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
        if (turret != null) // this checks if there is turret on the building and  if there is the player is unavailable to place new turret there
        {
            gameManager.SelectBuilding(this);
             return;
        }

        if (!gameManager.CanBuild)
            return;

        BuildTurret(gameManager.GetTurretToBuild());
       
    }

    void BuildTurret(TurretBP BluePrint)
    {
            if (Currency.Gold < BluePrint.costAmount) // if player has less gold then the cost of turret, they cant build it
            {
                Debug.Log("Not enough money to build!");
                return;
            }

            Currency.Gold -= BluePrint.costAmount; // takes away the amount of gold the turret costs from players total gold when buying turret

            GameObject TUR = (GameObject)Instantiate(BluePrint.Turret, GetBuildPosition(), Quaternion.identity);
            turret = TUR;

            BP = BluePrint;

       
    }

    public void Upgrade()
    {
            if (Currency.Gold < BP.upgradeCost)
            {
                Debug.Log("Not enough money to Upgrade!");
                return;
            }

            Currency.Gold -= BP.upgradeCost; // takes away the amount of gold the turret costs from players total gold when buying turret

             Destroy(turret);// destroys old turret when upgrading to new one

            // builds upgraded turret
            GameObject TUR = (GameObject)Instantiate(BP.upgradedTurret, GetBuildPosition(), Quaternion.identity);
            turret = TUR;

            isUpgraded = true;
    }


    public void SellTurret()
    {
        Currency.Gold += BP.GetSellAmount();
        Destroy(turret);
        BP = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!gameManager.CanBuild)
            return;

        if (gameManager.EnoughMoney)
        {
            RR.material.color = hoverColor;
        }
        else
        {
            RR.material.color = notEnoughMoneyColor;
        }


        
    }
    

    void OnMouseExit()
    {
        RR.material.color = startingColor;
    }



}
