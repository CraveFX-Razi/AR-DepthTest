using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class OcculusionChanger : MonoBehaviour
{
	AROcclusionManager OcclusionManager;
	int type = 1;
	[SerializeField]
	Text typeText;

	private void Awake()
	{
		OcclusionManager = GetComponent<AROcclusionManager>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ChangeOcclusion()
	{
		type++;
		if (type > 3)
			type = 1;

		OcclusionManager.requestedEnvironmentDepthMode = (UnityEngine.XR.ARSubsystems.EnvironmentDepthMode)type;
		typeText.text = ((UnityEngine.XR.ARSubsystems.EnvironmentDepthMode)type).ToString();
	}
}
