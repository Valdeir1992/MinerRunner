using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using FMOD.Studio;

public class PlayerMediator : MonoBehaviour, IPlayerMediator
{
    private const float MOVE_DISTANCE_RIGHT = 2.85f;
    private const float MOVE_DISTANCE_LEFT = 3.20f;
    private const float JUMP_FORCE = 5;
    private int _currentLane =0;
    private bool _canChangeLane = true;
    public bool _isGrounded;
    private bool _isJumping;
    private bool _isInvulnerable;
    private Rigidbody _rb;
    private PlayerHealth _playerHealth;
    private FMOD.Studio.EventInstance _kartSound;
    [SerializeField] private LayerMask _groundLayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerHealth = GetComponent<PlayerHealth>();
        if(FMODEvents.Instance != null && !FMODEvents.Instance.miningKartSFX.IsNull){
            _kartSound = AudioManager.instance.CreateEventInstance(FMODEvents.Instance.miningKartSFX);
        } 

    }
    private void Update()
    {
        CheckGround();
    }
    private void OnDrawGizmos(){
        if(!Application.isPlaying)
            return;
        Gizmos.color = (_isGrounded)?Color.green:Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.2f,Vector3.down);
    }
    private void CheckGround()
    {
        _isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.2f,Vector3.down,1,_groundLayer);
    }
 #region POWER UPs 
    public IEnumerator Coroutine_PowerUPs(IPowerUp  powerUp){
        yield return powerUp.Apply(this);
    }
    public void ToggleInvulnerability(bool status){
        _isInvulnerable = status;
    }
    #endregion
    private void OnEnable(){
        var inputManager = FindAnyObjectByType<TouchManager>();
        inputManager.OnMoveLeft += MoveLeft;
        inputManager.OnMoveRight += MoveRight;
        inputManager.OnMoveUp += Jump;
    }
    private void OnDisable(){
         var inputManager = FindAnyObjectByType<TouchManager>();
        inputManager.OnMoveLeft -= MoveLeft;
        inputManager.OnMoveRight -= MoveRight;
        inputManager.OnMoveUp += Jump;
    }
    public void Crouch()
    {
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        if(_isGrounded && !_isJumping){ 
            _rb.AddForce(Vector3.up * JUMP_FORCE,ForceMode.Impulse);
            StartCoroutine(Coroutine_JumpCooldown());

            AudioManager.instance.PlayOneShot(FMODEvents.Instance.jumpSFX, this.transform.position);
        } 
    }
    private IEnumerator Coroutine_JumpCooldown(){
        _isJumping = true;
        yield return new WaitUntil(()=>!_isGrounded);
        yield return new WaitForSeconds(0.175f);
        _isJumping = false;
    }

    public void MoveLeft()
    {
        _currentLane = Mathf.Clamp(_currentLane-1,-1,1);
        applyLeftMovement();
    }

    public void MoveRight()
    {
        _currentLane = Mathf.Clamp(_currentLane+1,-1,1);
        applyRightMovement();
    }
   
    private void applyLeftMovement(){
        if (!_canChangeLane)
         return;
        transform.position = new Vector3(_currentLane * MOVE_DISTANCE_LEFT,transform.position.y,transform.position.z);
        StartCoroutine(Coroutine_MoveCooldown());
        UpdateSound();
    }

    private void applyRightMovement()
    {
        if (!_canChangeLane)
            return;
        transform.position = new Vector3(_currentLane * MOVE_DISTANCE_RIGHT, transform.position.y, transform.position.z);
        StartCoroutine(Coroutine_MoveCooldown());
        UpdateSound();
    }

    private IEnumerator Coroutine_MoveCooldown()
    {
        _canChangeLane = false;
        yield return new WaitForSeconds(0.5f);
        _canChangeLane = true;
    }

    public void TakeDamage(int damage)
    {
        _playerHealth.TakeDamage(damage);      
    }

   //UpdateSound() � chamado em Move() mas n�o est� funcionando
    private void UpdateSound ()
    {
        if (_canChangeLane)
        {
            PLAYBACK_STATE _playbackState;
            _kartSound.getPlaybackState(out _playbackState);

            if (_playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                _kartSound.start();
            }
            else
            {
                _kartSound.stop(STOP_MODE.ALLOWFADEOUT);
            }

        }
    }
}
public interface IPlayerMediator { }


