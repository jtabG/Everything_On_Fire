using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Target;

    [SerializeField]
    private float m_LerpSpeed = 1.0f;

    private float m_xOffset;
    private float m_yOffset;
    private float m_zOffset;

	// Use this for initialization
	void Start ()
    {
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
        Vector2 targetPosition = new Vector2(   m_Target.transform.position.x + m_xOffset,
                                                m_Target.transform.position.y + m_yOffset);

        targetPosition = Vector2.Lerp(transform.position, targetPosition, m_LerpSpeed * Time.deltaTime);
        transform.position = new Vector3(targetPosition.x, targetPosition.y, m_zOffset);
    }
}
