using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CounterUI counterUI;
    [SerializeField] private PlayerView _playerViewPrefab;
    private Rigidbody _rigidbody;
    private PlayerView _playerView;
    private readonly float _moveForce = 60f;
    
    private void Start()
    {
        _rigidbody = _playerView.GetComponent<Rigidbody>();
    }

    public void Initialize(PositionGenerator positionGenerator)
    {
        var player = Instantiate(_playerViewPrefab);
        player.transform.position = positionGenerator.GetRandomPosition();
        _playerView = player;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.forward * _moveForce, ForceMode.Impulse);
            counterUI.ShowNumberSteps(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.back * _moveForce, ForceMode.Impulse);
            counterUI.ShowNumberSteps(1);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left * _moveForce, ForceMode.Impulse);
            counterUI.ShowNumberSteps(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right * _moveForce, ForceMode.Impulse);
            counterUI.ShowNumberSteps(1);
        }
    }
}
