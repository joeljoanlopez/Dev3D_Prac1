using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    public Transform m_PitchController;
    float m_Yawn;
    float m_Pitchn;
    public float m_PitchSpeed;
    public float m_YawnSpeed;
    
    public float m_MinnPich;
    public float m_MaxnPich;
   
    void Start()
    {
        m_Yawn = transform.eulerAngles.y;
        m_Pitchn = m_PitchController.eulerAngles.x;
    }

    
    void Update()
    {
        float l_HorizontalValue = Input.GetAxis("Mouse X");
        float l_VerticalValue = Input.GetAxis("Mouse Y");

        m_Yawn = m_Yawn+l_HorizontalValue*m_YawnSpeed*Time.deltaTime;
        m_Pitchn = m_Pitchn+l_VerticalValue*m_PitchSpeed*Time.deltaTime;
        m_Pitchn = Mathf.Clamp(m_Pitchn,m_MinnPich, m_MaxnPich);

        transform.rotation = Quaternion.Euler(0.0f, m_Yawn, 0.0f);
        m_PitchController.localRotation = Quaternion.Euler(m_Pitchn, 0.0f, 0.0f);
    }
}
