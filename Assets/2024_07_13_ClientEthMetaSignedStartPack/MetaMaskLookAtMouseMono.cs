using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaMaskLookAtMouseMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public Transform m_defaulOrientation;

    public bool m_isTouching;
    public Vector3 m_lookAt;
    public Vector3 m_screenPos;
    public float m_cameraDistance = 1;
    public bool m_hasFocus;

    private void OnApplicationFocus(bool focus)
    {
        m_hasFocus = focus;
    }
    void Update()
    {
        m_isTouching = Input.GetMouseButton(0) || Input.touchCount>0;
        if(m_hasFocus)
        {
            Vector3 pos = Input.mousePosition;
            if(Input.touchCount>0)
            {
                pos = Input.GetTouch(0).position;
            }
            m_screenPos = pos;
            m_screenPos.z = m_cameraDistance;
            m_lookAt= Camera.main.ScreenToWorldPoint(m_screenPos);
            m_whatToMove.LookAt(m_lookAt, Vector3.up);
        }
        else
        {
            m_whatToMove.rotation =Quaternion.Lerp(m_whatToMove.rotation, m_defaulOrientation.rotation, Time.deltaTime*5);
            m_whatToMove.position = Vector3.Lerp(m_whatToMove.position, m_defaulOrientation.position, Time.deltaTime*5);
        }
        
    }
}
