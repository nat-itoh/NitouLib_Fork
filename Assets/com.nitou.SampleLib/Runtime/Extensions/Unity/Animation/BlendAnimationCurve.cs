using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [�Q�l]
//  kan�̃�����: ������AnimationCurve�̔g�`���u�����h(����)���Ďg�� BlendAnimationCurve https://kan-kikuchi.hatenablog.com/entry/BlendAnimationCurve

namespace nitou {

    [System.Serializable]
    public class BlendAnimationCurve{

        //�J�[�u�Ƃ��̏d�݂̃y�A
        [System.Serializable]
        public struct CurveWeightPair {
            
            [SerializeField] AnimationCurve _curve;
            [SerializeField] float _weight;

            public AnimationCurve Curve => _curve;
            public float Weight => _weight;

            public CurveWeightPair(AnimationCurve curve, float weight) {
                _curve = curve;
                _weight = weight;
            }
        }


        [SerializeField] List<CurveWeightPair> _curveWeightPairs = new ();


        /// ----------------------------------------------------------------------------
        // Public Method

        public BlendAnimationCurve() { }

        public BlendAnimationCurve(params AnimationCurve[] curves) {
            _curveWeightPairs = curves.Select(curve => new CurveWeightPair(curve, 1)).ToList();
        }

        public BlendAnimationCurve(params CurveWeightPair[] curveWeightPairs) {
            _curveWeightPairs = curveWeightPairs.ToList();
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �d�݂��w�肵�ăJ�[�u��ǉ�
        /// </summary>
        public void Add(AnimationCurve curve, float weight = 1.0f) {
            _curveWeightPairs.Add(new CurveWeightPair(curve, weight));
        }

        /// <summary>
        /// �w�莞�Ԃ̒l���擾
        /// </summary>
        public float Evaluate(float time) {
            if (_curveWeightPairs.Count == 0) {
                Debug.LogError($"CurveWeightPair���ݒ肳��Ă��܂���");
                return 0;
            }

            var totalWeight = 0f;
            var blendedValue = 0f;

            foreach (var curveWeightPair in _curveWeightPairs) {
                totalWeight += curveWeightPair.Weight;
                blendedValue += curveWeightPair.Curve.Evaluate(time) * curveWeightPair.Weight;
            }

            if (totalWeight > 0f) {
                blendedValue /= totalWeight;
            } else {
                Debug.LogWarning($"Weight�̍��v��0�ȉ��ł� : {totalWeight}");
            }

            return blendedValue;
        }

        /// <summary>
        /// Dotween��Ease�p�̎擾���\�b�h
        /// </summary>
        public float EaseEvaluate(float time, float duration, float overshootOrAmplitude, float period) {
            if (duration <= 0) {
                return 0f;
            }
            return Evaluate(time / duration);
        }
    }
}
