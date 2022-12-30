using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Controller : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private string playerName;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;

    [Header("Controls")]
    [SerializeField] private KeyCode moveLeftKey;
    [SerializeField] private KeyCode moveRightKey;
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode defenseKey;

    [Header("References")]
    [SerializeField] private PlayerHUDController playerHUD;

    [Header("Debug")]
    [SerializeField] private float moveInput;
    [SerializeField] private float health;

    // Components
    private Rigidbody rb;

    // Variables
    private Vector3 movement;

    // Events
    public delegate void Defeated(string name);
    public static event Defeated OnDefeated;

    #region Unity methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        health = maxHealth;
        playerHUD.SetMaxHealthValue(maxHealth);
        playerHUD.SetHealthBarValue(health);
        playerHUD.SetPlayerName(playerName);
    }

    void Update()
    {
        // Check player inputs
        CheckInputs();

        // Calculate movement vector 
        CalculateMovement();
    }

    private void FixedUpdate()
    {
        // Move character
        MoveCharacter(movement);
    }

    #endregion

    #region Methods

    private void CheckInputs()
    {
        // Left movement control
        if (Input.GetKeyDown(moveLeftKey))
        {
            print("Left key pushed by " + name);

            moveInput = 1;
        }
        else if (Input.GetKeyUp(moveLeftKey))
        {
            print("Left key released by " + name);

            moveInput = 0;
        }

        // Right movement control
        if (Input.GetKeyDown(moveRightKey))
        {
            print("Right key pushed by " + name);

            moveInput = -1;
        }
        else if (Input.GetKeyUp(moveRightKey))
        {
            print("Right key released by " + name);

            moveInput = 0;
        }


        // Attack control
        if (Input.GetKeyDown(attackKey))
        {
            print("Attack key pushed by " + name);

            AttackTrigger();
        }

        // Defense control
        if (Input.GetKeyDown(defenseKey))
        {
            print("Defense key pushed  by " + name);
        }

        print("Move input: " + moveInput);
    }

    private void CalculateMovement()
    {
        movement = new Vector3(0, 0, moveInput).normalized;
    }

    private void MoveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        rb.velocity = - direction * movementSpeed * Time.fixedDeltaTime;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Method to receive damage from any source
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(float damage)
    {
        health = Mathf.Max(0, health - damage);
        playerHUD.SetHealthBarValue(health);

        if (health <= 0)
        {
            // Player defeated event
            if (OnDefeated != null)
            {
                OnDefeated(playerName);
            }
        }
    }

    /// <summary>
    /// Method to be called from the animator in the exact frame of the attack animation.
    /// </summary>
    public void AttackTrigger()
    {
        // Check targets on range
       Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);

        // If there are targets in range try to get IDamageable interface
        foreach (var collider in colliders)
        {
            // If collider has IDamageable interface
            if (collider.gameObject != gameObject)
            {
                // If collider is not the object try to get IDamageable
                var obj = collider.GetComponent<IDamageable>();

                // Apply damage to the target
                if (obj != null)
                {
                    obj.ApplyDamage(attackDamage);
                }
            }
        }
    }

    #endregion
}
