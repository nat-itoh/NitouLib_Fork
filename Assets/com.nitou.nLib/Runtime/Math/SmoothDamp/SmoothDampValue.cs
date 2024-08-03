using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  �˂�����炵�e�B: SmoothDamp�Ŋ��炩�ȒǏ]���������� https://nekojara.city/unity-smooth-damp
//  LIGHT11: Lerp��p�����X���[�W���O�̖��_��Mathf.SmoothDamp�ɂ������� https://light11.hatenadiary.com/entry/2021/06/01/203624
//  _ : SmoothDamp���\���̉����Ďg���₷������ https://tech.ftvoid.com/smooth-damp-struct

namespace nitou {

    /// ----------------------------------------------------------------------------
    #region Float

    /// <summary>
    /// �l��ڕW�l�Ɋ��炩�ɒǏ]������\����
    /// �i��Mathf.SmoothDamp�j
    /// </summary>
    public class SmoothDampFloat : ISmoothDampValue<float>{

        private float _current;
        private float _currentVelocity;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SmoothDampFloat(float initialValue) {
            _current = initialValue;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public float GetNext(float target, float smoothTime) {
            _current = Mathf.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime
                );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public float GetNext(float target, float smoothTime, float maxSpeed) {
            _current = Mathf.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed
            );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public float GetNext(float target, float smoothTime, float maxSpeed, float deltaTime) {
            _current = Mathf.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed,
                deltaTime
            );

            return _current;
        }

        /// <summary>
        /// �ϐ������Z�b�g����
        /// </summary>
        public void Reset(float value, float velocity) {
            _current = value;
            _currentVelocity = velocity;
        }
    }

    /// <summary>
    /// �p�x��ڕW�l�Ɋ��炩�ɒǏ]������\����
    /// �i��Mathf.SmoothDampAngle�j
    /// </summary>
    public class SmoothDampAngle : ISmoothDampValue<float>{

        private float _current;
        private float _currentVelocity;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SmoothDampAngle(float initialValue) {
            _current = initialValue;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public float GetNext(float target, float smoothTime) {
            _current = Mathf.SmoothDampAngle(
                _current,
                target,
                ref _currentVelocity,
                smoothTime
                );

            return _current;
        }
        
        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public float GetNext(float target, float smoothTime, float maxSpeed) {
            _current = Mathf.SmoothDampAngle(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed
            );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public float GetNext(float target, float smoothTime, float maxSpeed, float deltaTime) {
            _current = Mathf.SmoothDampAngle(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed,
                deltaTime
            );

            return _current;
        }
    }
    #endregion


    /// ----------------------------------------------------------------------------
    #region Vector2

    /// <summary>
    /// �l��ڕW�l�Ɋ��炩�ɒǏ]������\����
    /// �i��Mathf.SmoothDamp�j
    /// </summary>
    public class SmoothDampVector2 : ISmoothDampValue<Vector2>{

        private Vector2 _current;
        private Vector2 _currentVelocity;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SmoothDampVector2(Vector2 initialValue) {
            _current = initialValue;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public Vector2 GetNext(Vector2 target, float smoothTime) {
            _current = Vector2.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime
                );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public Vector2 GetNext(Vector2 target, float smoothTime, float maxSpeed) {
            _current = Vector2.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed
            );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public Vector2 GetNext(Vector2 target, float smoothTime, float maxSpeed, float deltaTime) {
            _current = Vector2.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed,
                deltaTime
            );

            return _current;
        }

        /// <summary>
        /// �ϐ������Z�b�g����
        /// </summary>
        public void Reset(Vector2 value, Vector2 velocity) {
            _current = value;
            _currentVelocity = velocity;
        }
    }
    #endregion


    /// ----------------------------------------------------------------------------
    #region Vector3

    /// <summary>
    /// �l��ڕW�l�Ɋ��炩�ɒǏ]������\����
    /// �i��Mathf.SmoothDamp�j
    /// </summary>
    public class SmoothDampVector3 : ISmoothDampValue<Vector3> {

        private Vector3 _current;
        private Vector3 _currentVelocity;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SmoothDampVector3(Vector3 initialValue) {
            _current = initialValue;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public Vector3 GetNext(Vector3 target, float smoothTime, float maxSpeed, float deltaTime) {
            _current = Vector3.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed,
                deltaTime
            );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public Vector3 GetNext(Vector3 target, float smoothTime, float maxSpeed) {
            _current = Vector3.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime,
                maxSpeed
            );

            return _current;
        }

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public Vector3 GetNext(Vector3 target, float smoothTime) {
            _current = Vector3.SmoothDamp(
                _current,
                target,
                ref _currentVelocity,
                smoothTime
                );

            return _current;
        }
    }
    #endregion

}