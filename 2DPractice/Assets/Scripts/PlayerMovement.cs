using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_MoveSpeed = 1.0f;

    [SerializeField]
    private bool m_AffectedByGravity = true;

    private Rigidbody2D m_RigidBody;

    const string MoveHor = "Horizontal";
    const string MoveVert = "Vertical";
    const float IgnoreInputValue = 0.1f;

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

        if (m_AffectedByGravity) { updateGravity(); }
	}

    private void updateMovement()
    {
        if (Input.GetAxis(MoveHor) > IgnoreInputValue || Input.GetAxis(MoveHor) < -IgnoreInputValue)
        {
            float moveVal = m_MoveSpeed * Input.GetAxis(MoveHor);
            m_RigidBody.AddForce(new Vector2(moveVal, 0.0f));
        }

    }

    private void updateGravity()
    {

    }

}
