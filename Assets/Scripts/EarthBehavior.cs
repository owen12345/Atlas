using UnityEngine;
using System.Collections;

public class EarthBehavior : MonoBehaviour {

	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;

	private Vector3 pastPos;
	private Vector3 currentPos;

	// Use this for initialization
	void Start () {
		_sensitivity = 0.4f;
		_rotation = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetButton ("Fire1")) {
			RaycastHit hit = new RaycastHit ();        
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (!Physics.Raycast (ray, out hit)) {
				if (_isRotating) {
					currentPos = Input.mousePosition;
					pastPos.x = pastPos.x - Screen.width / 2;
					pastPos.y = pastPos.y - Screen.height / 2; 
					currentPos.x = currentPos.x - Screen.width / 2;
					currentPos.y = currentPos.y - Screen.height / 2;
					float angle = Vector3.Angle (pastPos, currentPos);
					Vector3 cross = Vector3.Cross (pastPos, currentPos);
					
					//finds if obtuse angle
					if (cross.z < 0) {
						angle = 360 - angle;
					} 
					
					// apply rotation
					_rotation.z = angle;
					
					// rotate 
					transform.Rotate (_rotation, Space.World);
					
					// store mouse
					pastPos = Input.mousePosition;
				}
			}
		}

		if(Input.GetButtonDown("Fire1")){
			// rotating flag
			_isRotating = true;
			
			// store mouse
			pastPos = Input.mousePosition;
		}
		
		if(Input.GetButtonUp("Fire1")){
			// rotating flag
			_isRotating = false;
		}
	}



}

