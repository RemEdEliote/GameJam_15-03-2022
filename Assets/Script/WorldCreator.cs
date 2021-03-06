using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCreator : MonoBehaviour
{

    // --- The  game is not end -- //

    protected bool gameRunBool = true;

    // ----- Variables for Environment creation ----- // 

    [SerializeField] private GameObject worldCreatorTarget;
    private Vector3 _worldCreatorTargetVector3 = new Vector3(-100, 0f, 0f);
    private float _worldCreatorSpeed = 1f;

    [SerializeField] private GameObject _fioulGameObject;
    [SerializeField] private GameObject _dustPrefab;
    [SerializeField] private GameObject _planetPrefab;

    // --- variables rythme of fioul spawn --- // 

    private float[] _spawnRythmeTime = { 0.5f, 1f, 1.5f, 2f, 3f };
    private int _spawnRytmeNomber;
    private int _spawnRytmeNomberRests;



    void Start()
    {

        StartCoroutine(FioulDelayAndSpawn());
        StartCoroutine(DustDelayAndSpawn());
        StartCoroutine(PlanetDelayAndSpawn());
    }

    void FixedUpdate()
    {

        WorldCreationMove(); // Fonction us to move the world Creation Asset; 

    }

    private void WorldCreationMove() // Fonction us to move the world Creation Asset; 
    {
        gameObject.transform.position =
            (gameObject.transform.position + Vector3.Normalize(_worldCreatorTargetVector3)) * _worldCreatorSpeed;
        Debug.Log(Vector3.Normalize(_worldCreatorTargetVector3));
    }


    IEnumerator FioulDelayAndSpawn() // Delay and spown of FioulSpawn with random nomber
    {

        while (gameRunBool)
        {

            Vector3 _randomSpawnPosition = new Vector3(gameObject.transform.position.x + 600f,
                gameObject.transform.position.y,
                Random.Range(-8, 8));

            float _randomSpawnTime = Random.Range(2f, 4f);


            GameObject _fioul = Instantiate(_fioulGameObject, _randomSpawnPosition, Quaternion.identity);

            _spawnRytmeNomberRests--;

            if (_spawnRytmeNomberRests < 0)
            {
                _spawnRytmeNomberRests = Random.Range(1, 10);
                _spawnRytmeNomber = Random.Range(0, 4);
            }


            yield return new WaitForSeconds(_spawnRythmeTime[_spawnRytmeNomber]);
        }
    }

    IEnumerator DustDelayAndSpawn() // Delay and spawn of dust for a space contemplative experience
    {

        while (gameRunBool)
        {
            Vector3 _randomSpawnPosition = new Vector3(gameObject.transform.position.x, Random.Range(-300, 300),
                Random.Range(-300, 300));

            float _randomSpawnTime = Random.Range(0.01f, 0.1f);


            GameObject _dust = Instantiate(_dustPrefab, _randomSpawnPosition, Quaternion.identity);
            _dust.transform.localScale =
                new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));


            yield return new WaitForSeconds(_randomSpawnTime);
        }
    }

    IEnumerator PlanetDelayAndSpawn() // Daley and spawn of Planet for a space contemplative experience
    {
        while (gameRunBool)
        {
            Vector3 _randomSpawnPosition = new Vector3(gameObject.transform.position.x + -1000f,
                Random.Range(Random.Range(-1000, -800), Random.Range(800, 1000)),
                Random.Range(Random.Range(-1000, -800), Random.Range(800, 1000)));

            float _randomSpawnTime = Random.Range(5, 20);

            GameObject _newPlanet = Instantiate(_planetPrefab, _randomSpawnPosition, Quaternion.identity);

            int BigBlanetLuck = Random.Range(0, 20);

            if (BigBlanetLuck == 1)
            {
                _newPlanet.transform.position = new Vector3(_randomSpawnPosition.x + -4000,
                    Random.Range(Random.Range(-10000, -8000), Random.Range(1200, 1000)),
                    Random.Range(Random.Range(-10000, -8000), Random.Range(1200, 1000)));

                _newPlanet.transform.localScale = _newPlanet.transform.localScale * 100;

            }
            yield return new WaitForSeconds(_randomSpawnTime);
        }
        


    }
}
