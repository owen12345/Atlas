using UnityEngine; 
using System.Collections;  


public class DragAndRotateEarth : MonoBehaviour { 
	
	
	bool hasGrabbedPoint = false;
	Vector3 grabbedPoint;

	void Start () {

	}

	void Update () { //This is not running
		for (float i = 0; i < 100; i ++) {
			print (i);
		}   
		 

		if (Input.GetMouseButton (0)) { 
			if (!hasGrabbedPoint) { 
				hasGrabbedPoint = true; 
				grabbedPoint = getTouchedPoint (); 
			} else { 
				Vector3 targetPoint = getTouchedPoint (); 
				Quaternion rot = Quaternion.FromToRotation (grabbedPoint, targetPoint); 
				transform.rotation *= rot;
			} 
		} else { 
			hasGrabbedPoint = false; 
		}
	}
	
	
	Vector3 getTouchedPoint() { 
		RaycastHit hit; 

		Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
		
		
		return transform.InverseTransformPoint(hit.point);
		
	} } 