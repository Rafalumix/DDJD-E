// Adapted from: https://gist.github.com/reunono/efea18bed03fa83dec651fb18beea3bd 


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Add this component to your Cinemachine Virtual Camera to have it shake when calling its ShakeCamera methods.
/// </summary>
public class CinemachineCameraShaker : MonoBehaviour
{
	public static CinemachineCameraShaker instance;

	/// the amplitude of the camera's noise when it's idle
	public float IdleAmplitude = 0.1f;
	/// the frequency of the camera's noise when it's idle
	public float IdleFrequency = 1f;
	
	/// The default amplitude that will be applied to your shakes if you don't specify one
	public float DefaultShakeAmplitude = .5f;
	/// The default frequency that will be applied to your shakes if you don't specify one
	public float DefaultShakeFrequency = 10f;

	protected Vector3 _initialPosition;
	protected Quaternion _initialRotation;

	public Cinemachine.CinemachineBasicMultiChannelPerlin _perlinT;
	public Cinemachine.CinemachineBasicMultiChannelPerlin _perlinM;
	public Cinemachine.CinemachineBasicMultiChannelPerlin _perlinB;
	public Cinemachine.CinemachineFreeLook _freeLook;
	// public Cinemachine.CinemachineVirtualCamera _virtualCamera;
	public Cinemachine.CinemachineVirtualCamera _virtualCameraT;
	public Cinemachine.CinemachineVirtualCamera _virtualCameraM;
	public Cinemachine.CinemachineVirtualCamera _virtualCameraB;

	private Coroutine coroutine;

	/// <summary>
	/// On awake we grab our components
	/// </summary>
	protected virtual void Awake () 
	{
		_freeLook = GameObject.FindObjectOfType<Cinemachine.CinemachineFreeLook>();

		_virtualCameraT = _freeLook.GetRig(0);
		_virtualCameraM = _freeLook.GetRig(1);
		_virtualCameraB = _freeLook.GetRig(2);
		_perlinT = _virtualCameraT.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin> ();
		_perlinM = _virtualCameraM.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin> ();
		_perlinB = _virtualCameraB.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin> ();
		if(instance == null)
			instance = this;
		
	}		

	/// <summary>
	/// On Start we reset our camera to apply our base amplitude and frequency
	/// </summary>
	protected virtual void Start()
	{		
		CameraReset ();
		instance.ShakeCamera(3,1,5);

	}

	/// <summary>
	/// Use this method to shake the camera for the specified duration (in seconds) with the default amplitude and frequency
	/// </summary>
	/// <param name="duration">Duration.</param>
	public virtual void ShakeCamera (float duration)
	{
		ShakeCamera(duration, DefaultShakeAmplitude, DefaultShakeFrequency);
	}

	/// <summary>
	/// Use this method to shake the camera for the specified duration (in seconds), amplitude and frequency
	/// </summary>
	/// <param name="duration">Duration.</param>
	/// <param name="amplitude">Amplitude.</param>
	/// <param name="frequency">Frequency.</param>
	public virtual void ShakeCamera (float duration, float amplitude, float frequency)
	{
		if(coroutine != null)
			StopCoroutine(coroutine);
		coroutine = StartCoroutine (ShakeCameraCo (duration, amplitude, frequency));
	}

	/// <summary>
	/// This coroutine will shake the 
	/// </summary>
	/// <returns>The camera co.</returns>
	/// <param name="duration">Duration.</param>
	/// <param name="amplitude">Amplitude.</param>
	/// <param name="frequency">Frequency.</param>
	protected virtual IEnumerator ShakeCameraCo(float duration, float amplitude, float frequency)
	{
		Debug.Log("SHAKING");

		_perlinT.m_AmplitudeGain = amplitude;
		_perlinM.m_AmplitudeGain = amplitude;
		_perlinB.m_AmplitudeGain = amplitude;
		_perlinT.m_FrequencyGain = frequency;
		_perlinM.m_FrequencyGain = frequency;
		_perlinB.m_FrequencyGain = frequency;

		
		
		
		yield return new WaitForSeconds (duration);
		CameraReset ();
	}

	/// <summary>
	/// Resets the camera's noise values to their idle values
	/// </summary>
	public virtual void CameraReset()
	{
		_perlinT.m_AmplitudeGain = IdleAmplitude;
		_perlinM.m_AmplitudeGain = IdleAmplitude;
		_perlinB.m_AmplitudeGain = IdleAmplitude;
		_perlinT.m_FrequencyGain = IdleFrequency;
		_perlinM.m_FrequencyGain = IdleFrequency;
		_perlinB.m_FrequencyGain = IdleFrequency;
	}

}