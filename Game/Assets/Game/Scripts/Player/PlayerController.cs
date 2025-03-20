using UnityEngine;
using UnityEngine.AI;

public partial class PlayerController : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 10f;
    
    [Header("Animation")]
    [SerializeField] private float animationDampTime = 0.1f;
    private static readonly int Speed = Animator.StringToHash("Speed");

    [Header("NavMeshAgent Settings")]
    [SerializeField] private float immediateAcceleration = 100f;
    [SerializeField] private float stoppingDistance = 0.2f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private Camera _mainCamera;
    
    public float MoveSpeed => GetStat(PlayerStat.MoveSpeed);
    
    private void Start()
    {
        if(EntityManager.Instance)
            EntityManager.Instance.SetPlayerController(this);
        
        InitPlayerStats();
        InitNavMeshAgent();

        _animator = GetComponent<Animator>();

        _mainCamera = Camera.main;
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
        
        if (_agent.velocity.sqrMagnitude > 0.1f)
        {
            var targetRotation = Quaternion.LookRotation(_agent.velocity.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        var currentSpeed = _agent.velocity.magnitude * MoveSpeed;
        _agent.speed = MoveSpeed;
        _animator.SetFloat(Speed, currentSpeed, animationDampTime, Time.deltaTime);
    }

    private void InitNavMeshAgent()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_agent)
        {
            _agent.updateRotation = false;
            _agent.acceleration = immediateAcceleration;
            _agent.stoppingDistance = stoppingDistance;
        }
    }
}
