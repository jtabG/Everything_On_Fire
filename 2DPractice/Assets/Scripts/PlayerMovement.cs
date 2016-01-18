using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    /// [SerializeField] allows you to view and alter the variable within the Unity editor, while still
    /// keeping the variable private an inacceable through code outside this class' scope
    
    /// <summary>
    /// Value which modifies the input to determine how quickly to move the character
    /// </summary>
    [SerializeField]
    private float m_MoveSpeed = 1.0f;

    /// <summary>
    /// Value which modifies how much force goes into a player jump
    /// </summary>
    [SerializeField]
    private float m_Jumpforce = 1.0f;

    /// <summary>
    /// Whether to have the player ignore gravity or not NOT CURRENT IN USE
    /// </summary>
    [SerializeField]
    private bool m_AffectedByGravity = true;

    /// <summary>
    /// Reference to player's rigidbody component.
    /// </summary>
    private Rigidbody2D m_RigidBody;

    #region CONST VALUES
    /// <summary>
    /// string literals used to avoid typos when looking at input axis
    /// </summary>
    const string MoveHorStr = "Horizontal";
    const string MoveVertStr = "Vertical";
    const string JumpStr = "Jump";

    /// <summary>
    /// Small input buffer used to ignore very small input values
    /// </summary>
    const float IgnoreInputValue = 0.1f;
    #endregion

	// Use this for initialization
	void Start ()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        if (m_RigidBody == null)
        {
            Debug.LogError("no RigidBody2D found on PlayerMovement " + GetInstanceID());
        }
	}
	
	void FixedUpdate ()
    {
        updateMovement();
        updateJump();
	}

    /// <summary>
    /// Resolve input from the user to move the player
    /// </summary>
    private void updateMovement()
    {
        if (Input.GetAxis(MoveHorStr) > IgnoreInputValue || Input.GetAxis(MoveHorStr) < -IgnoreInputValue)
        {
            float moveVal = m_MoveSpeed * Input.GetAxis(MoveHorStr);
            m_RigidBody.AddForce(new Vector2(moveVal, 0.0f));
        }

    }

    /// <summary>
    /// Resolve input from the user to cause the player to jump
    /// </summary>
    private void updateJump()
    {
        if (m_RigidBody.velocity.y < IgnoreInputValue && m_RigidBody.velocity.y > -IgnoreInputValue)
        {
            //not falling or currently jumping; therefore you can jump
            if (Input.GetButtonDown(JumpStr))
            {
                Debug.Log("jump pressed");
                float jumpVal = m_Jumpforce * 100;
                m_RigidBody.AddForce(new Vector2(0.0f, jumpVal));
            }
        }
    }


    private void updateGravity()
    {
        
    }

}
