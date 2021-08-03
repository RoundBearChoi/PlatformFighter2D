using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TrailEffect : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer = null;
        public Unit rootUnit = null;

        float _decreaingAlpha = 0.9f;

        public float ALPHA
        {
            get
            {
                if (spriteRenderer != null)
                {
                    return spriteRenderer.color.a;
                }
                else
                {
                    return 0f;
                }
            }
        }

        public void OnUpdate()
        {
            _decreaingAlpha = Mathf.Lerp(spriteRenderer.color.a, 0f, Time.deltaTime * GameInitializer.current.fighterDataSO.TrailFadeSpeed);

            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, _decreaingAlpha);
        }
    }
}