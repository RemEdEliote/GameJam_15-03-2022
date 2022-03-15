using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCreator : MonoBehaviour
{
    
    // --- The  game is not end -- //

    protected bool gameRunBool = true; 
    
    [SerializeField] private GameObject worldCreatorTarget;
    private Vector3 _worldCreatorTargetVector3 = new Vector3(-100, 0f, 0f);
    private float _worldCreatorSpeed = 1f;
    
    // ----- Variables for Environment creation ----- // 

    [SerializeField] private GameObject _fioulGameObject;
    [SerializeField] private GameObject _dustPrefab;



    void Start()
    {
        gameObject.transform.position = new Vector3(-200, 0, 0);
        StartCoroutine(FioulDelayAndSpawn());
        StartCoroutine(DustDelayAndSpawn()); 
    }
    void FixedUpdate()
    {
      
        WorldCreationMove(); // Fonction us to move the world Creation Asset; 
     
    }
    
    private void WorldCreationMove() // Fonction us to move the world Creation Asset; 
    {
        gameObject.transform.position = (gameObject.transform.position + Vector3.Normalize(_worldCreatorTargetVector3)) * _worldCreatorSpeed ; 
        Debug.Log(Vector3.Normalize(_worldCreatorTargetVector3));
    }
    

    IEnumerator FioulDelayAndSpawn() // Delay and spown of FioulSpawn with random nomber
    {

        while (true)
        {
            Vector3 _randomSpawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                Random.Range(-8, 8));

            float _randomSpawnTime = Random.Range(2f, 4f);


            GameObject _fioul = Instantiate(_fioulGameObject, _randomSpawnPosition, Quaternion.identity);
        
            yield return new WaitForSeconds(_randomSpawnTime);
        }
    }
    
    IEnumerator DustDelayAndSpawn() // Delay and spown of dust for a space contemplative experience
    {

        while (true)
        {
            Vector3 _randomSpawnPosition = new Vector3(gameObject.transform.position.x, Random.Range(-100, 100),
                Random.Range(-100, 100));

            float _randomSpawnTime = Random.Range(0.01f, 0.1f);


            GameObject _dust = Instantiate(_dustPrefab, _randomSpawnPosition, Quaternion.identity);
        
            yield return new WaitForSeconds(_randomSpawnTime);
        }
    }
 
}