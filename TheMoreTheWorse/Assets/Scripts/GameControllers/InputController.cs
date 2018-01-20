using UnityEngine;

public class InputController : MonoBehaviour {
    public static InputController GetInput;

    void Awake()
    {
        // Call this in another script, example: InputController.GetInput.Left(0);
        GetInput = this;
    }

    // ----------> Input <---------- \\
    public bool Left(int playerNumber) { if (PressingInput(playerNumber, 0)) return true; return false; }
    public bool Right(int playerNumber) { if (PressingInput(playerNumber, 1)) return true; return false; }
    public bool Up(int playerNumber) { if (PressingInput(playerNumber, 2)) return true; return false; }
    public bool Down(int playerNumber) { if (PressingInput(playerNumber, 3)) return true; return false; }
    public bool Weapon1(int playerNumber) { if (PressingInput(playerNumber, 4)) return true; return false; }
    public bool Weapon2(int playerNumber) { if (PressingInput(playerNumber, 5)) return true; return false; }
    public bool Shoot(int playerNumber) { if (PressingInput(playerNumber, 10)) return true; return false; }

    // ----------> Input Function <---------- \\
    private bool PressingInput(int playerNumber, int inputNumber)
    {
        switch (playerNumber)
        {
            case 1:
                switch (inputNumber)
                {
                    case 0: if (Input.GetKey(KeyCode.A)) return true; return false;
                    case 1: if (Input.GetKey(KeyCode.D)) return true; return false;
                    case 2: if (Input.GetKey(KeyCode.W)) return true; return false;
                    case 3: if (Input.GetKey(KeyCode.S)) return true; return false;
                    case 4: if (Input.GetKeyDown(KeyCode.Alpha1)) return true; return false;
                    case 5: if (Input.GetKeyDown(KeyCode.Alpha2)) return true; return false;
                    case 10: if (Input.GetKey(KeyCode.J)) return true; return false;
                }
                break;
            case 2:
                switch (inputNumber)
                {
                    case 0: break;
                    case 1: break;
                    case 2: break;
                    case 3: break;
                }
                break;
        }
        return false;
    }
}
