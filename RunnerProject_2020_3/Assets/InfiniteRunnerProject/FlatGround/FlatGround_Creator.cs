using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGround_Creator : UnitCreator
    {
        public FlatGround_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public GameObject GetGroundUnit()
        {
            GameObject groundObj = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(UnitType.FLAT_GROUND)) as GameObject;
            groundObj.transform.parent = _parentTransform;
            groundObj.transform.localRotation = Quaternion.identity;
            groundObj.transform.localPosition = Vector3.zero;

            SpriteRenderer renderer = groundObj.GetComponentInChildren<SpriteRenderer>();

            //should be done early (resourceloader)
            Sprite[] arrSprites = Resources.LoadAll<Sprite>(StaticRefs.swampParallaxData.Swamp_GroundTile25_SpriteName);

            if (arrSprites.Length != 0)
            {
                renderer.sprite = arrSprites[0];
                renderer.gameObject.transform.localScale = new Vector3(3.13f, 3.13f, 1f);
            }
            else
            {
                //should be done early (resourceloader)
                arrSprites = Resources.LoadAll<Sprite>("Texture_White100x100");
                renderer.sprite = arrSprites[0];
            }

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

            CompositeCollider2D c2d = objComposite.AddComponent<CompositeCollider2D>();
            Rigidbody2D r2d = objComposite.GetComponent<Rigidbody2D>();
            r2d.bodyType = RigidbodyType2D.Static;

            c2d.sharedMaterial = StaticRefs.gameData.physicsMaterial_NoFrictionNoBounce;
            r2d.sharedMaterial = StaticRefs.gameData.physicsMaterial_NoFrictionNoBounce;

            objComposite.AddComponent<Ground>();

            for (int i = 0; i < 100; i++)
            {
                GameObject obj = GetGroundUnit();
                obj.transform.parent = objComposite.transform;
                obj.transform.localPosition = new Vector3(i * 1, obj.transform.localPosition.y, obj.transform.localPosition.z);
            }
        }
    }
}