using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] private float gravity = 9.81f;

    private Vector3 _move;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
            _move += Vector3.down * gravity;

        characterController.Move(_move * Time.deltaTime);
    }    

    public void SetMove(float x, float z)
    {
        //  Vector3 x와 z에다 moveSpeed 를 곱해준다.
        _move.x = x * moveSpeed;
        _move.z = z * moveSpeed;
    }

    public void SetMove(float y)
    {
        _move.y = y;
    }
    public void SetMove(Vector3 move)
    {

        _move = new Vector3( move.x * moveSpeed,
                             move.y,
                             move.z * moveSpeed);
    }

}
