using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FlatGround_Creator : UnitCreator
    {
        private Transform _parentTransform;

        public FlatGround_Creator(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public override Unit GetUnit()
        {
            Unit flatGround = GameObject.Instantiate(ResourceLoader.GetResource(typeof(Ground))) as Ground;
            flatGround.unitData = new UnitData(flatGround.transform);

            flatGround.transform.parent = _parentTransform;
            flatGround.transform.localRotation = Quaternion.identity;
            flatGround.transform.localPosition = Vector3.zero;

            return flatGround;
        }

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

            objComposite.AddComponent<Ground>();

            for (int i = 0; i < 10; i++)
            {
                Unit obj = GetUnit();
                obj.transform.parent = objComposite.transform;
                obj.transform.localPosition = new Vector3(i * 1, obj.transform.localPosition.y, obj.transform.localPosition.z);
                listUnits.Add(obj);
            }
        }
    }
}