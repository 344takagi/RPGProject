using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehaviour : SceneBaseBehaviour {

    private enum Step
    {
        LOGO_INIT,
        LOGO,
        MAIN,
        FADE_OUT,
        DOWNLOAD_INIT,
        DOWNLOAD,
        END,
    }

    private Step m_step;

	// Use this for initialization
	protected override void _Start () {
        m_step = Step.LOGO_INIT;
	}
	
	// Update is called once per frame
	protected override void _Update () {
        switch ( m_step ) {
            case Step.LOGO_INIT:
                m_step = Step.LOGO;
                break;

            case Step.LOGO:
                m_step = Step.MAIN;
                break;

            case Step.MAIN:
                break;
        }
	}
}
