using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Stores reference to the focus of the camera
    /// </summary>
    [SerializeField]
    private GameObject m_Target;

    /// <summary>
    /// The speed at which the camera will update its position in order to focus
    /// on its target
    /// </summary>
    [SerializeField]
    private float m_LerpSpeed = 1.0f;

    /// <summary>
    /// Initial x.y.z values of the camera relative to its target.
    /// </summary>
    private float m_xOffset;
    private float m_yOffset;
    private float m_zOffset;

	// Use this for initialization
	void Start ()
    {
        // ensure a target has been assigned before trying to get relative values
	    if (m_Target != null)
        {
            SetOffsetFromTarget(m_Target);
            m_zOffset = transform.position.z;
        }
	}
	
    private void SetOffsetFromTarget(GameObject aTarget)
    {
        m_xOffset = transform.position.x - aTarget.transform.position.x;
        m_yOffset = transform.position.y - aTarget.transform.position.y;
    }

	// Update is called once per frame
	void Update ()
    {
	    if (m_Target != null)
        {
            updatePosition();
        }
	}

    private void updatePosition()
    {
        // determine where the camera should be
        Vector2 targetPosition = new Vector2(   m_Target.transform.position.x + m_xOffset,
                                                m_Target.transform.position.y + m_yOffset);

        // ease towards the target position over time
        targetPosition = Vector2.Lerp(transform.position, targetPosition, m_LerpSpeed * Time.deltaTime);
        
        // the transform component's xyz are read only and cannot be modified individually. You can set the entire position
        // vec3 though which is why we need to assign the values in this way.
        transform.position = new Vector3(targetPosition.x, targetPosition.y, m_zOffset);
    }
}
