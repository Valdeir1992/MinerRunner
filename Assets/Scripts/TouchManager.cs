using UnityEngine; 
using System;

public class TouchManager : MonoBehaviour
{     
    public Action OnMoveLeft;
    public Action OnMoveRight; 
    public Action OnMoveUp;
    public Action OnMoveDown;
    private GameInputs _gameInputs;      
    private const float SWIPE_DISTANCE = 30; 
    private void Start(){
        _gameInputs = new GameInputs();
        _gameInputs.Enable();
        _gameInputs.Gameplay.Swipe.performed += ctx=>{
            var direction = ctx.ReadValue<Vector2>(); 
            Debug.Log(direction);
            if(Mathf.Abs(direction.x) > SWIPE_DISTANCE){
                if(direction.x>0){
                    MoveRight();
                }
                if(direction.x<0){
                    MoveLeft();
                }
            }
            if(Mathf.Abs(direction.y) >SWIPE_DISTANCE){
                if(direction.y > 0){
                    MoveUp();
                }
                if(direction.y < 0)
                    MoveDown();
            }
            
        }; 
    } 
    private void MoveRight(){
        OnMoveRight?.Invoke();
    }
    private void MoveLeft(){
        OnMoveLeft?.Invoke();
    }
    private void MoveUp(){
        OnMoveUp?.Invoke();
    }
    private void MoveDown(){
        OnMoveDown?.Invoke();
    }

}


