using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
	[SerializeField] Transform followTarget;

	[SerializeField][Range(-15, 0)] private float minVerticalAngle = -15f;
	[SerializeField][Range(0, 90)] private float maxVerticalAngle = 45.0f;

    [SerializeField][Range(-90, 0)] private float minHorizontalAngle = -15f;
    [SerializeField][Range(0, 90)] private float maxHorizontalAngle = 45.0f;

    [SerializeField] Vector2 framingOffset;

	[SerializeField] private float targetdistance = 3.0f;
	[SerializeField] private float zoomSpeed = 10.0f;
	[SerializeField] private float rotationSpeed = 10f;
	[SerializeField] private float minDistance = 1;
	[SerializeField] private float maxDistance = 5;

	float rotationY = 0;
	float rotationX = 0;
	float scroll = 0;
	public Quaternion PlanarRotationY => Quaternion.Euler(0, rotationY, 0);

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
		// ���콺����Ʈ�� �¿�� �����̴� ���� �����´�.
		rotationY += Input.GetAxis("Mouse X");
		rotationY = rotationY % 360;
		// ���Ϸ� �����̴� ��
		rotationX += Input.GetAxis("Mouse Y");
		// ��ũ�� ��
		scroll = Input.GetAxis("Mouse ScrollWheel");
		// ��ũ�� ���� ���� ī�޶�� Ÿ���� �Ÿ��� ����(����, �ܾƿ�)
		targetdistance -= scroll * zoomSpeed * Time.deltaTime;
		targetdistance = Mathf.Clamp(targetdistance, minDistance, maxDistance);

		// �¿��� �ִ� �ּ� ������ �����Ѵ�.
		// rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
		// rotationY = Mathf.Clamp(rotationY, minHorizontalAngle,maxHorizontalAngle );
		float rotationYAmount = Mathf.Abs(rotationY);
;
        Vector2 targetframingOffset;
        if (rotationYAmount < 90 || rotationYAmount > 270)
		{
			targetframingOffset = framingOffset;
		}
		else
		{
			targetframingOffset = framingOffset;
			targetframingOffset.x *= -1;
		}
		Debug.Log("Y" + rotationY);
		// ���Ϸ� ������ ���ؼ� ���콺 �����ӿ� ���� ȸ������ ���Ѵ�.
		Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
		// Ÿ�� ��ġ�� fraimingOffset ���� ���Ѵ�.
		Vector3 focusPosition = followTarget.position + new Vector3(targetframingOffset.x, targetframingOffset.y, 0);
        //Vector3.MoveTowards(transform.position, followTarget.position + new Vector3(targetframingOffset.x, targetframingOffset.y), rotationSpeed*Time.deltaTime);
			//followTarget.position + 
			//new Vector3(targetframingOffset.x, targetframingOffset.y, 0);

		// ���Ϸ� ������ ���� ���� ȸ������ ���� �����Ѵ�.
		transform.position = 
			Vector3.Slerp(transform.position, (focusPosition - (targetRotation * new Vector3(0, 0, targetdistance))), rotationSpeed * Time.deltaTime);
			//focusPosition - 
			//(targetRotation * new Vector3(0, 0, targetdistance));
		// ������Ʈ ȸ���� ������Ʈ
		transform.rotation = targetRotation;
		//Debug.Log("Euler : " + Quaternion.Get());
    }

}
