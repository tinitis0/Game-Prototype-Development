using UnityEngine;

public class ShopPanel : MonoBehaviour {

    public TurretBP BulletTurret;
    public TurretBP RocketTurret;
    public TurretBP LaserTurret;

    GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	public void SelectRocketTurret ()
    {
        gameManager.SelectTurretToBuild(RocketTurret);
        Debug.Log("Rocket Turret Bought");
	}

    public void SelectBulletTurret()
    {
        gameManager.SelectTurretToBuild(BulletTurret);
        Debug.Log("Bullet Turret Bought");
    }

    public void SelectLaserTurret()
    {
        gameManager.SelectTurretToBuild(LaserTurret);
        Debug.Log("Laser Turret Bought");
    }
}
