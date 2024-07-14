using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EthBooleanSpliterMono : MonoBehaviour
{
    public UnityEvent m_onIsTrue;
    public UnityEvent m_onIsFalse;
    public UnityEvent<bool> m_onIsTrueValue;
    public UnityEvent<bool> m_onIsFalseValue;

    public void PushBoolean(bool isTrue) { 
        m_onIsTrueValue.Invoke(isTrue);
        m_onIsFalseValue.Invoke(!isTrue);
        if (isTrue)
        {
            m_onIsTrue.Invoke();
        }
        else
        {
            m_onIsFalse.Invoke();
        }
    
    }
    
}
