using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EthRelayTickMono : MonoBehaviour
{

    public UnityEvent m_onTick;
    [ContextMenu("Push tick")]
    public void PushTick() { 
 
        m_onTick.Invoke();
    }

  
 
}
