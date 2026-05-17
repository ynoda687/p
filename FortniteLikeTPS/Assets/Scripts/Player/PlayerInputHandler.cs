using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputHandler : MonoBehaviour
{
    public bool isPlayer1 = true; // Player1 / Player2 を分ける用
    public PlayerCameraController cameraController;
    public WeaponController weaponController;

    PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleKeyboardAndMouse();
#else
        HandleTouch();
#endif
    }

    void HandleKeyboardAndMouse()
    {
        // 移動
        float h = isPlayer1 ? Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal2");
        float v = isPlayer1 ? Input.GetAxis("Vertical")   : Input.GetAxis("Vertical2");
        Vector2 move = new Vector2(h, v);

        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool crouch = Input.GetKey(KeyCode.LeftShift);

        playerController.TickMove(move, jump, crouch);

        // エイム（マウス）
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        cameraController.TickLook(new Vector2(mouseX, mouseY));

        // 射撃（左クリック）
        if (Input.GetMouseButtonDown(0))
        {
            weaponController.Shoot();
        }

        // 武器切り替え
        if (Input.GetKeyDown(KeyCode.Alpha1)) weaponController.SetWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) weaponController.SetWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) weaponController.SetWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) weaponController.SetWeapon(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) weaponController.SetWeapon(4);
    }

    void HandleTouch()
    {
        Vector2 move = Vector2.zero;
        bool jump = false;
        bool crouch = false;

        // 左半分：移動、右半分：エイム＋タップで射撃、の超シンプル版
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            if (t.position.x < Screen.width / 2f)
            {
                // 移動（スティック風）
                Vector2 center = new Vector2(Screen.width * 0.25f, Screen.height * 0.25f);
                Vector2 dir = (t.position - center).normalized;
                move = dir;
            }
            else
            {
                // エイム
                if (t.phase == TouchPhase.Moved)
                {
                    Vector2 delta = t.deltaPosition * 0.1f;
                    cameraController.TickLook(new Vector2(delta.x, delta.y));
                }

                // ほぼ動いてないタップ → 射撃
                if (t.phase == TouchPhase.Ended && t.deltaPosition.magnitude < 10f)
                {
                    weaponController.Shoot();
                }
            }
        }

        playerController.TickMove(move, jump, crouch);
    }
}

