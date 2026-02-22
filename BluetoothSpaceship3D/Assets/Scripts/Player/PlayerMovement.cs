using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки игрока")]
    [Space]
    [Header("Обьект игрока")]
    [SerializeField] private GameObject _playerObj;
    [Header("Rigidbody component игрока")]
    [SerializeField] private Rigidbody _playerRb;
    [Space]
    [Header("Настройки движения")]
    [Space]
    [Header("Скорость движения вперед")]
    [SerializeField] private float _forwardSpeed;
    [Header("Скорость движения налево/направо")]
    [SerializeField] private float _leftRightSpeed;
    [Header("Скорость движения вверх/вниз")]
    [SerializeField] private float _upDownSpeed;
    private Vector3 _directionPlayer;

    private void Update()
    {
        Movement(_directionPlayer);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _directionPlayer = context.ReadValue<Vector3>();
    }

    private void Movement(Vector3 directionPlayer)
    {
        if (directionPlayer.x != 0 || directionPlayer.y != 0)
        {
            float directionX = directionPlayer.x * _leftRightSpeed * Time.deltaTime;
            float directionY = directionPlayer.y * _upDownSpeed * Time.deltaTime;

            Vector3 angularVelocity = new Vector3(directionX, directionX, directionY);
            _playerRb.angularVelocity = angularVelocity;

        }else if (directionPlayer.z != 0)
        {
            float directionZ = directionPlayer.z * _forwardSpeed * Time.deltaTime;
            _playerRb.AddForce(new Vector3(_playerRb.linearVelocity.x, _playerRb.linearVelocity.y, directionZ), ForceMode.Force);
        }
    }
}
