using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectInstantiator : MonoBehaviour
{
	[SerializeField]
	GameObject prefab;

	ARRaycastManager arRaycastManager;

	static List<ARRaycastHit> hits = new List<ARRaycastHit>();

	private void Awake()
	{
		arRaycastManager = GetComponent<ARRaycastManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = touch.position;

			if(touch.phase == TouchPhase.Began)
			{
				bool isOverUI = touchPos.IsPointOverUIObject();

				if(!isOverUI && arRaycastManager.Raycast(touchPos, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
				{
					var hitPose = hits[0].pose;
					Instantiate(prefab, hitPose.position, hitPose.rotation);
				}
			}
		}
    }
}
