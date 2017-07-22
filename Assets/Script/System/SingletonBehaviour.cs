using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance = null;
    public static T Instance
    {
        get
        {
            if ( m_instance == null )
            {
                m_instance = FindObjectOfType<T>();
                if ( m_instance == null )
                {
                    // Error.
                }
            }
            return m_instance;
        }
    }

    void Awake()
    {
        if ( m_instance != null )
        {
            // Error.
            Destroy( this );
            return;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
