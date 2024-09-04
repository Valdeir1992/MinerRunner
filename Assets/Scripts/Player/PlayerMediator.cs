using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMediator : MonoBehaviour, IPlayerMediator
{
    private const float MOVE_DISTANCE_HORIZONTAL = 2;
    private const float JUMP_FORCE = 5;
    private int _currentLane =0;
    private bool _canChangeLane = true;
    public bool _isGrounded;
    private bool _isJumping;
    private bool _isInvulnerable;
    private Rigidbody _rb;
    private PlayerHealth _playerHealth;
    [SerializeField] private LayerMask _groundLayer; 

    private void Awake(){
        _rb = GetComponent<Rigidbody>();
        _playerHealth = GetComponent<PlayerHealth>();
    }
    private void Update(){
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
        } 
    }
    #region POWER UPs 
    public IEnumerator Coroutine_PowerUPs(IPowerUp  powerUp){
        yield return powerUp.Apply(this);
    }
    public void ToggleInvulnerability(bool status){
        _isInvulnerable = status;
    }
    #endregion
    private IEnumerator Coroutine_JumpCooldown(){
        _isJumping = true;
        yield return new WaitUntil(()=>!_isGrounded);
        yield return new WaitForSeconds(0.175f);
        _isJumping = false;
    }

    public void MoveLeft()
    {
        _currentLane = Mathf.Clamp(_currentLane-1,-1,1);
        Move();
    }

    public void MoveRight()
    {
        _currentLane = Mathf.Clamp(_currentLane+1,-1,1);
        Move();
    }
    private void Move(){
        if(!_canChangeLane)
            return;
        transform.position = new Vector3(_currentLane * MOVE_DISTANCE_HORIZONTAL,transform.position.y,transform.position.z);
        StartCoroutine(Coroutine_MoveCooldown());
    }

    private IEnumerator Coroutine_MoveCooldown()
    {
        _canChangeLane = false;
        yield return new WaitForSeconds(0.5f);
        _canChangeLane = true;
    }

    public void TakeDamage(int damage)
    {
        if(_isInvulnerable)
            return;
        StartCoroutine(FindAnyObjectByType<GameplayManager>().Coroutine_CameraShake(2,damage));
        _playerHealth.TakeDamage(damage);
    }
}
public interface IPlayerMediator{
    public void Jump();
    public void MoveLeft();
    public void MoveRight();
    public void Crouch();
}
