using UnityEngine;
    public class RotatingObstacle : MonoBehaviour
    {
		public float rotationSpeed = 5;

		private void Update()
		{
			transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
		}
	}

