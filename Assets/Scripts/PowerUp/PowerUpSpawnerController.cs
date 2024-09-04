using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpSpawnerController : MonoBehaviour
{
     [SerializeField] private List<Collectible> _listPowerUpPrefabs;
     [SerializeField] private float _speed;
     private List<Collectible> _listPowerUp = new List<Collectible>();
    private Vector3[] _ways = new []{new Vector3(-2,1,50), new Vector3(2,1,50), new Vector3(0,1,50)};
     private void Start(){
        StartCoroutine(Coroutine_Spawn());
     }
     private void Update(){
        foreach(var powerUp in _listPowerUp){
            powerUp.transform.position += Time.deltaTime * _speed * -Vector3.forward;
        }
    }
     private IEnumerator Coroutine_Spawn(){
        int random = UnityEngine.Random.Range(10,30);
        while(true){
            yield return new WaitForSeconds(random);
            var powerUp = Instantiate(_listPowerUpPrefabs.OrderBy(x=>Guid.NewGuid()).First(),_ways[UnityEngine.Random.Range(0,_ways.Length)],Quaternion.identity);
            powerUp.OnRelease += ()=>{
                _listPowerUp.Remove(powerUp);
                Destroy(gameObject);
                };
            _listPowerUp.Add(powerUp);

        }
     }
}
