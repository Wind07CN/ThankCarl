using UnityEngine;

/*
 * This context contains the unique controllers of entities, such as player, enemy, and so on.
 * Its duty is to find and serve the controllers among the themselves.
 */
public class ControllerContext : MonoBehaviour
{
    [HideInInspector]
    public PlayerController PlayerController {get ; private set;}

    [HideInInspector]
    public PlayerSkillController PlayerSkillController {get ; private set;}

    // EnmeyController is not unique
    // private EnemyController enemyController;
    [HideInInspector]
    public EnemySpawnController EnemySpawnController {get ; private set;}

    [HideInInspector]
    public BattleSceneController BattleSceneController {get ; private set;}

    [HideInInspector]
    public MainCameraController MainCameraController {get ; private set;}

    public static ControllerContext GetContext()
    {
        return GameObject.FindWithTag("MainController").GetComponent<ControllerContext>();
    }

    private void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        PlayerController = playerObj.GetComponent<PlayerController>();
        PlayerSkillController = playerObj.GetComponent<PlayerSkillController>();
        // GameObject mainControlObj = GameObject.Find("MainController");
        EnemySpawnController = transform.GetComponent<EnemySpawnController>();
        BattleSceneController = transform.GetComponent<BattleSceneController>();
        GameObject mainCameraObj = GameObject.Find("MainCamera");
        MainCameraController = mainCameraObj.GetComponent<MainCameraController>();
    }
}