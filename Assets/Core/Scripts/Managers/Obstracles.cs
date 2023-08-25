using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.VFX;
using System;

namespace TheColorBall.Core
{
    public class Obstracles : MonoBehaviour
    {
        [SerializeField] float scaleMultiply;
        [SerializeField] float animDuration;
        [SerializeField] VisualEffect _obstracleDestroy;
        public ObstracleType obstracleType;
        public Ease ease;
        public float _vfxWaitTime = 1;
        [SerializeField] int _health;
        Vector3 originalScale;
        SpriteRenderer _obstracleSpriteRenderer;
        private void Start()
        {
            _obstracleSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            _obstracleDestroy.SetFloat("LifeTime", _vfxWaitTime);
            originalScale = transform.localScale;
            _health = ObstracleManager.Instance.ObstracleHealthSetter(obstracleType);
            _canDisable = true;
            readyForTween = true;
        }
        private bool _canDisable;
        private bool readyForTween;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Bullet" &&
                            BallProperties.instance.PlayerSpriteRenderer.color ==
                                        _obstracleSpriteRenderer.color)
            {
                if (readyForTween)
                {
                    readyForTween = false;
                    transform.DOPunchScale(transform.localScale * scaleMultiply, animDuration, 0, 1).OnComplete(() => readyForTween = true);
                }
                _health -= GameManager.instance.gameProperties.IntialBulletDamage;
            }
        }
        private void Update()
        {
            if (_health == 0)
            {
                //Destroy this
                //Destroy(this.gameObject);

                //Disable this
                if (_canDisable)
                    StartCoroutine(DisableObstracle());
            }
        }

        private IEnumerator DisableObstracle()
        {
            _canDisable = false;
            SetVfxProperties();
            SetColliderProperties();
            yield return new WaitForSeconds(_vfxWaitTime);
            this.gameObject.SetActive(false);
        }

        private void SetColliderProperties()
        {
            _obstracleSpriteRenderer.enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        private void SetVfxProperties()
        {
            _obstracleDestroy.SetVector4("MainColor", _obstracleSpriteRenderer.color);
            _obstracleDestroy.Play();
        }
    }
}