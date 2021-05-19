using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameInitializer : MonoBehaviour
    {
        Stage _currentStage = null;

        private void Start()
        {
            ResourceLoader.Init();
            _currentStage = CreateStage(typeof(IntroStage));

            if (_currentStage != null)
            {
                _currentStage.Init();
            }
        }

        private Stage CreateStage(System.Type stageType)
        {
            if (stageType.IsSubclassOf(typeof(Stage)))
            {
                Stage newStage = Instantiate(ResourceLoader.Get(stageType)) as Stage;
                newStage.transform.parent = this.transform;
                newStage.transform.localPosition = Vector3.zero;
                newStage.transform.localRotation = Quaternion.identity;

                return newStage;
            }
            else
            {
                return null;
            }
        }

        private void Update()
        {
            if (_currentStage != null)
            {
                _currentStage.OnUpdate();

                if (_currentStage.nextStage != null)
                {
                    if (_currentStage.nextStage.IsSubclassOf(typeof(Stage)))
                    {
                        Destroy(_currentStage.gameObject);
                        _currentStage = CreateStage(_currentStage.nextStage);
                        _currentStage.Init();
                    }
                    else
                    {
                        _currentStage.nextStage = null;
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if (_currentStage != null)
            {
                _currentStage.OnFixedUpdate();
            }
        }
    }
}