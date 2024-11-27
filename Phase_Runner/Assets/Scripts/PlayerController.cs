using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		public float moveSpeed = 7f;        // 이동 속도
		public float runSpeed = 12f;         // 달리기 속도
		public float jumpHeight = 1f;       // 점프 높이
		public float gravity = -9.81f;      // 중력 가속도
		public float mouseSensitivity = 200f; // 마우스 민감도
		public Transform cameraTransform;   // 플레이어 카메라 Transform

		private CharacterController controller;
		private float verticalVelocity;     // Y축 속도 (중력 및 점프)
		private float xHeadRotation = 0f;    // 카메라 X축 회전 값

		public AudioSource WalkAudio = null;
		public AudioClip WalkSound;
		public float WalkPitch = 1f;
		public float RunPitch = 1.3f;

		public AudioSource JumpAudio = null;
		public AudioClip JumpSound;
		public float startJumpTime = 0.1f;
		public float JumpPitch = 1.1f;
		public bool isJump;

		void Start()
		{
			controller = GetComponent<CharacterController>();

			// 마우스 커서 잠금
			Cursor.lockState = CursorLockMode.Locked;
		}

		void Update()
		{
			MovePlayer();    // 플레이어 이동 처리
			HandleJump();    // 점프 및 중력 처리
			RotateCamera();  // 카메라 회전 처리
		}

		void MovePlayer()
		{
			float horizontal = Input.GetAxis("Horizontal"); // A/D 또는 좌/우 방향키
			float vertical = Input.GetAxis("Vertical");     // W/S 또는 위/아래 방향키

			// 입력 방향 계산 (로컬 좌표 기준)
			Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

			if (WalkAudio.isPlaying)
			{
				if (isJump || moveDirection == Vector3.zero)
				{
					WalkAudio.Stop();
				}
			}
			else
			{
				WalkAudio.clip = WalkSound;
				WalkAudio.Play();
			}

			// 이동 처리
			if (Input.GetKey(KeyCode.LeftShift))
			{
				controller.Move(moveDirection * runSpeed * Time.deltaTime);
				if (!isJump) { WalkAudio.pitch = RunPitch; }
				Debug.Log("Run");
			}
			else
			{
				controller.Move(moveDirection * moveSpeed * Time.deltaTime);
				if (!isJump) { WalkAudio.pitch = WalkPitch; }
			}
		}

		void HandleJump()
		{
			if (isJump)
			{
				if (verticalVelocity < 0 && Physics.Raycast(transform.position, Vector3.down, 0.8f))
				{
					isJump = false;
					JumpAudio.clip = JumpSound;
					JumpAudio.time = startJumpTime;
					JumpAudio.pitch = JumpPitch;
					JumpAudio.Play();
				}
			}

			if (IsGrounded())
			{
				// 땅에 닿아 있을 때
				if (Input.GetButtonDown("Jump"))
				{
					Debug.Log("Jump");
					verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity); // 점프 속도 설정
					isJump = true;
				}
			}
			else
			{
				// 중력 적용
				verticalVelocity += gravity * Time.deltaTime;
			}

			// Y축 이동 처리 (중력 및 점프)
			Vector3 gravityMove = new Vector3(0f, verticalVelocity, 0f);
			controller.Move(gravityMove * Time.deltaTime); // 중력 적용
		}

		void RotateCamera()
		{
			// 마우스 입력 받기
			float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

			// 플레이어 회전 (Y축)
			transform.Rotate(Vector3.up * mouseX);

			// 카메라 회전 (X축)
			xHeadRotation -= mouseY;
			xHeadRotation = Mathf.Clamp(xHeadRotation, -60f, 63f); // 위/아래 회전 제한
			cameraTransform.localRotation = Quaternion.Euler(xHeadRotation, 0f, 0f);
		}

		private bool IsGrounded()
		{
			return Physics.Raycast(transform.position, Vector3.down, 0.2f);
		}
	}
}
