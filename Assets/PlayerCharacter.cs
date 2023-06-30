using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float rollSpeed = 10;
    public Rigidbody bod;
    // Start is called before the first frame update
    public void move(Vector2 input, Vector3 forward)
    {
        print(input);
        bod.AddTorque(forward *rollSpeed *Time.deltaTime * input.magnitude, ForceMode.Acceleration);
    }
}
