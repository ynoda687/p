using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform player1Spawn;
    public Transform player2Spawn;
    public Camera player1Camera;
    public Camera player2Camera;

    void Start()
    {
        // Player1
        GameObject p1 = Instantiate(playerPrefab, player1Spawn.position, player1Spawn.rotation);
        var input1 = p1.GetComponent<PlayerInputHandler>();
        input1.isPlayer1 = true;
        input1.cameraController = player1Camera.GetComponent<PlayerCameraController>();
        input1.weaponController = p1.GetComponentInChildren<WeaponController>();
        player1Camera.GetComponent<PlayerCameraController>().target = p1.transform;

        // Player2
        GameObject p2 = Instantiate(playerPrefab, player2Spawn.position, player2Spawn.rotation);
        var input2 = p2.GetComponent<PlayerInputHandler>();
        input2.isPlayer1 = false;
        input2.cameraController = player2Camera.GetComponent<PlayerCameraController>();
        input2.weaponController = p2.GetComponentInChildren<WeaponController>();
        player2Camera.GetComponent<PlayerCameraController>().target = p2.transform;

        // 画面分割（上下）
        player1Camera.rect = new Rect(0, 0.5f, 1, 0.5f);
        player2Camera.rect = new Rect(0, 0f, 1, 0.5f);
    }
}

