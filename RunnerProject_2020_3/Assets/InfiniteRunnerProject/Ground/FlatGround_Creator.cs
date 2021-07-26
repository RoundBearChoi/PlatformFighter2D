using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGround_Creator : BaseUnitCreator
    {
        int _minGroundCount = 0;
        int _maxGroundCount = 0;

        public FlatGround_Creator(Transform parentTransform, int minGroundCount, int maxGroundCount)
        {
            _parentTransform = parentTransform;
            _minGroundCount = minGroundCount;
            _maxGroundCount = maxGroundCount;
        }

        public GameObject GetGroundObj()
        {
            GameObject groundObj = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.FLAT_GROUND)) as GameObject;
            groundObj.transform.parent = _parentTransform;
            groundObj.transform.localRotation = Quaternion.identity;
            groundObj.transform.localPosition = Vector3.zero;

            Sprite[] arrSprites = ResourceLoader.LoadSpriteByString(GameInitializer.current.GetParallaxData(ParallaxDataType.SWAMP).Swamp_GroundTile25_SpriteName);

            if (arrSprites.Length == 0)
            {
                arrSprites = ResourceLoader.LoadSpriteByString(GameInitializer.current.GetParallaxData(ParallaxDataType.SWAMP).Swamp_GroundTile_BackupSpriteName);
            }

            SpriteRenderer renderer = groundObj.GetComponentInChildren<SpriteRenderer>();
            renderer.sprite = arrSprites[0];
            renderer.gameObject.transform.localScale = new Vector3(3.13f, 3.13f, 1f);

            return groundObj;
        }

        //only composite is unit, individual ground blocks are not
        public override void AddUnits(List<Unit> listUnits)
        {
            GameObject objComposite = new GameObject();
            objComposite.transform.parent = _parentTransform;
            objComposite.transform.localPosition = Vector3.zero;
            objComposite.transform.localRotation = Quaternion.identity;
            objComposite.name = "CompositeGround";
            objComposite.layer = (int)LayerType.DEFAULT;

            Ground newGround = objComposite.AddComponent<Ground>();
            newGround.unitData = new UnitData(newGround.transform);

            newGround.unitData.compositeCollider2D = objComposite.AddComponent<CompositeCollider2D>();
            newGround.unitData.rigidBody2D = objComposite.GetComponent<Rigidbody2D>();
            newGround.unitData.rigidBody2D.bodyType = RigidbodyType2D.Static;

            //put elsewhere (other than runner)
            newGround.unitData.compositeCollider2D.sharedMaterial = GameInitializer.current.GetGameData(GameDataType.RUNNER).physicsMaterial_NoFrictionNoBounce;
            newGround.unitData.rigidBody2D.sharedMaterial = GameInitializer.current.GetGameData(GameDataType.RUNNER).physicsMaterial_NoFrictionNoBounce;

            newGround.unitUpdater = new DefaultUnitUpdater(newGround);
            newGround.unitData.spriteAnimations = new EmptySpriteAnimations();
            newGround.iStateController = new UnitStateController(newGround);
            newGround.iStateController.SetNewState(new FlatGround_DefaultState(newGround));

            GameInitializer.current.GetStage().units.AddUnit(newGround);

            int count = Random.Range(_minGroundCount, _maxGroundCount + 1);

            for (int i = 0; i < count; i++)
            {
                GameObject obj = GetGroundObj();
                obj.transform.parent = objComposite.transform;
                obj.transform.localPosition = new Vector3(i * 1, obj.transform.localPosition.y, obj.transform.localPosition.z);
            }
        }
    }
}