using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_MoveSpeed = 1.0f;

    [SerializeField]
    private float m_Jumpforce = 1.0f;

    [SerializeField]
    private bool m_AffectedByGravity = true;

    private Rigidbody2D m_RigidBody;

    #region CONST VALUES
    const string MoveHorStr = "Horizontal";
    const string MoveVertStr = "Vertical";
    const string JumpStr = "Jump";

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

    private void updateMovement()
    {
        if (Input.GetAxis(MoveHorStr) > IgnoreInputValue || Input.GetAxis(MoveHorStr) < -IgnoreInputValue)
        {
            float moveVal = m_MoveSpeed * Input.GetAxis(MoveHorStr);
            m_RigidBody.AddForce(new Vector2(moveVal, 0.0f));
        }

    }

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
