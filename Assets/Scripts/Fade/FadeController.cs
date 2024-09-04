using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private static FadeController _instance;
    [SerializeField] private CanvasGroup _canvas;

private void Awake(){
    if(ReferenceEquals(_instance,null)){
        _instance = this; 
        DontDestroyOnLoad(gameObject);
    }else if(_instance != this){
        Destroy(gameObject);
    }
}
    public void FadeOut(Action Callback){
        StartCoroutine(Coroutine_FadeOut(1,Callback));
    }
    
    public void FadeIn(Action Callback){
        StartCoroutine(Coroutine_FadeIn(1,Callback));
    }
    private IEnumerator Coroutine_FadeIn(float time,Action Callback){
        for(float elapsedTime = 0;elapsedTime/time < 1;elapsedTime +=Time.deltaTime){
            _canvas.alpha = 1 - elapsedTime/time;
            yield return null;
        }
        _canvas.alpha =0;
        _canvas.blocksRaycasts = false;
        Callback?.Invoke();
    }
    private IEnumerator Coroutine_FadeOut(float time,Action Callback){
        for(float elapsedTime = 0;elapsedTime/time < 1;elapsedTime +=Time.deltaTime){
            _canvas.alpha = elapsedTime/time;
            yield return null;
        }
        _canvas.alpha =1;
        _canvas.blocksRaycasts = true;
        Callback?.Invoke();
    }
}
