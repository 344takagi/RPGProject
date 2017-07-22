using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBaseBehaviour : MonoBehaviour
{
    protected virtual void _Start() { }
    protected virtual void _Load() { }
    protected virtual void _FixedUpdate() { }
    protected virtual void _Update() { }

    /// <summary>
    /// シーン切り替え.
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    protected void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }








    /// <summary>
    /// どのシーンからでも始められるようにするための初期化処理.
    /// 各要素調整のイテレーションを向上させるため.
    /// </summary>
    private void CommonInitialize()
    {
        // SystemBehaviourの初期化.
        string systemBehaviourName = "SystemBehaviour";
        GameObject systemBehaviour = GameObject.Find( systemBehaviourName );
        if ( systemBehaviour == null ) {
            systemBehaviour = new GameObject( systemBehaviourName );
            systemBehaviour.AddComponent<SystemBehaviour>();
            Object.DontDestroyOnLoad( systemBehaviour );
        }

        // InputBehaviourの初期化.
        string inputBehaviourName = "InputBehaviour";
        GameObject inputBehaviour = GameObject.Find( inputBehaviourName );
        if ( inputBehaviour == null )
        {
            inputBehaviour = new GameObject( inputBehaviourName );
            inputBehaviour.AddComponent<InputBehaviour>();
            Object.DontDestroyOnLoad( inputBehaviour );
        }
    }


    // Use this for initialization
    void Start()
    {
        CommonInitialize();

        _Start();
    }

    void FixedUpdate()
    {
        _FixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        switch ( m_updateStep) {
            case UpdateStep.LOAD:
                _Load();
                m_updateStep = UpdateStep.LOAD_WAIT;
                break;

            case UpdateStep.LOAD_WAIT:
                m_updateStep = UpdateStep.MAIN;
                break;

            case UpdateStep.MAIN:
                _Update();
                break;

            default:
                break;
        }
    }


    private enum UpdateStep
    {
        LOAD,
        LOAD_WAIT,
        MAIN,
    }

    private UpdateStep m_updateStep = UpdateStep.LOAD;
}
