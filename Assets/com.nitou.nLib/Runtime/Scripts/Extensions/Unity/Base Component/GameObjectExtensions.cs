using System.Linq;
using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: GetComponentsInChildren�Ŏ������g���܂܂Ȃ��悤�ɂ���g�����\�b�h https://baba-s.hatenablog.com/entry/2014/06/05/220224
//  qiita: ������Ƃ����֗��ɂȂ邩������Ȃ��g�����\�b�h�W https://qiita.com/tanikura/items/ed5d56ebbfcad19c488d
//  kan�̃�����: �g�����\�b�h�Ƃ́A�S�Ă̎q�I�u�W�F�N�g�Ƀ��C���[�ƃ}�e���A���ݒ���s���Ă݂� https://kan-kikuchi.hatenablog.com/entry/GameObjectExtension

namespace nitou {

    /// <summary>
    /// <see cref="GameObject"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class GameObjectExtensions {

        /// ----------------------------------------------------------------------------
        #region �R���|�[�l���g (�L��)

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���A�^�b�`����Ă��邩�ǂ������m�F����g�����\�b�h
        /// </summary>
        public static bool HasComponent<T>(this GameObject self)
            where T : Component {
            return self.GetComponent<T>() != null;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���A�^�b�`����Ă��邩�ǂ������m�F����g�����\�b�h
        /// </summary>
        public static bool HasComponent(this GameObject self, System.Type type) {
            return self.GetComponent(type) != null;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���A�^�b�`����Ă��邩�ǂ������m�F����g�����\�b�h
        /// </summary>
        public static bool HasComponents<T1, T2>(this GameObject self)
            where T1 : Component where T2 : Component{
            return self.HasComponent<T1>() && self.HasComponent<T2>();
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region �R���|�[�l���g (�폜)

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���폜����g�����\�b�h
        /// </summary>
        public static GameObject RemoveComponent<T>(this GameObject self)
            where T : Component {
            T component = self.GetComponent<T>();
            if (component != null) Object.Destroy(component);
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���폜����g�����\�b�h
        /// </summary>
        public static GameObject RemoveComponents<T1, T2>(this GameObject self)
            where T1 : Component where T2 : Component {
            self.RemoveComponent<T1>();
            self.RemoveComponent<T2>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���폜����g�����\�b�h
        /// </summary>
        public static GameObject RemoveComponents<T1, T2, T3>(this GameObject self)
            where T1 : Component where T2 : Component where T3 : Component {
            self.RemoveComponents<T1, T2>();
            self.RemoveComponent<T3>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���폜����g�����\�b�h
        /// </summary>
        public static GameObject RemoveComponents<T1, T2, T3, T4>(this GameObject self)
            where T1 : Component where T2 : Component where T3 : Component where T4 : Component {
            self.RemoveComponents<T1, T2, T3>();
            self.RemoveComponent<T4>();
            return self;
        }

        /// <summary>
        /// �S�ẴR���|�[�l���g���폜����g�����\�b�h
        /// </summary>
        public static GameObject RemoveAllComponents(this GameObject self) {
            foreach (var component in self.GetComponents<Component>()) {
                if (!(component is Transform)) {
                    Object.Destroy(component);
                }
            }

            return self;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �R���|�[�l���g (�ǉ�)

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g��ǉ�����g�����\�b�h
        /// </summary>
        public static GameObject AddComponents<T1, T2>(this GameObject self)
            where T1 : Component where T2 : Component {
            self.AddComponentIfNotExists<T1>();
            self.AddComponentIfNotExists<T2>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g��ǉ�����g�����\�b�h
        /// </summary>
        public static GameObject AddComponents<T1, T2, T3>(this GameObject self)
            where T1 : Component where T2 : Component where T3 : Component {
            self.AddComponents<T1, T2>();
            self.AddComponentIfNotExists<T3>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g��ǉ�����g�����\�b�h
        /// </summary>
        public static GameObject AddComponents<T1, T2, T3, T4>(this GameObject self)
            where T1 : Component where T2 : Component where T3 : Component where T4 : Component {
            self.AddComponents<T1, T2, T3>();
            self.AddComponentIfNotExists<T4>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g��ǉ�����g�����\�b�h
        /// </summary>
        public static GameObject AddComponentIfNotExists<T>(this GameObject self)
            where T : Component {
            // �R���|�[�l���g�����݂��Ȃ��ꍇ�̂ݒǉ�
            if (!self.HasComponent<T>()) {
                self.AddComponent<T>();
            }
            return self;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �R���|�[�l���g�i�擾�j

        /// <summary>
        /// �Ώۂ̃R���|�[�l���g���ꍇ�͂�����擾���C�Ȃ���Βǉ����ĕԂ��g�����\�b�h
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject self)
            where T : Component {
            var component = self.GetComponent<T>();
            return component ?? self.AddComponent<T>();
        }

        /// <summary>
        /// �������g���܂܂Ȃ�GetComponentsInChaidren�̊g�����\�b�h
        /// </summary>
        public static T[] GetComponentsInChildrenWithoutSelf<T>(this GameObject self)
            where T : Component {
            return self.GetComponentsInChildren<T>().Where(c => self != c.gameObject).ToArray();
        }

        /// <summary>
        /// GetComponentInChaildren�̊g�����\�b�h
        /// </summary>
        public static bool TryGetComponentInChildren<T>(this GameObject self, out T component)
            where T : Component {
            // �q�v�f����w��R���|�[�l���g���擾����
            component = self.GetComponentInChildren<T>();
            return component != null;
        }

        /// <summary>
        /// Gets a "target" component within a particular branch (inside the hierarchy). The branch is defined by the "branch root object", which is also defined by the chosen 
        /// "branch root component". The returned component must come from a child of the "branch root object".
        /// </summary>
        public static T2 GetComponentInBranch<T1, T2>(this GameObject self, bool includeInactive = true) 
            where T1 : Component where T2 : Component {
            T1[] entryComponents = self.transform.root.GetComponentsInChildren<T1>(includeInactive);

            if (entryComponents.Length == 0) {
                Debug.LogWarning($"Root component: No objects found with {typeof(T1).Name} component");
                return null;
            }

            foreach(var entry in entryComponents) {

                // ���ړI�Ȑe�q�֌W�ɂȂ��ꍇ�͎���
                if (!self.transform.IsChildOf(entry.transform) && !entry.transform.IsChildOf(self.transform))
                    continue;

                // entry���N�_�ɃR���|�[�l���g��T��
                if (entry.gameObject.TryGetComponentInChildren<T2>(out var targetComponent)) {
                    return targetComponent;
                } 
            }

            return null;
        }

        /// <summary>
        /// Gets a "target" component within a particular branch (inside the hierarchy). The branch is defined by the "branch root object", which is also defined by the chosen 
        /// "branch root component". The returned component must come from a child of the "branch root object".
        /// </summary>
        public static T1 GetComponentInBranch<T1>(this GameObject self, bool includeInactive = true) 
            where T1 : Component {
            return self.GetComponentInBranch<T1, T1>(includeInactive);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �R���|�[�l���g�i�L����ԁj

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g��L��������g�����\�b�h
        /// </summary>
        public static GameObject EnableComponent<T>(this GameObject self)where T : Behaviour {
            if (self.HasComponent<T>()) {
                self.GetComponent<T>().enabled = true;
            }
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃R���|�[�l���g��L��������g�����\�b�h
        /// </summary>
        public static GameObject EnableComponents<T1, T2>(this GameObject self)
            where T1 : Behaviour where T2 : Behaviour {
            self.EnableComponent<T1>();
            self.EnableComponent<T2>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ3�̃R���|�[�l���g��L��������g�����\�b�h
        /// </summary>
        public static GameObject EnableComponents<T1, T2, T3>(this GameObject self)
            where T1 : Behaviour where T2 : Behaviour where T3 : Behaviour {
            self.EnableComponents<T1, T2>();
            self.EnableComponent<T3>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ4�̃R���|�[�l���g��L��������g�����\�b�h
        /// </summary>
        public static GameObject EnableComponents<T1, T2, T3, T4>(this GameObject self)
            where T1 : Behaviour where T2 : Behaviour where T3 : Behaviour where T4 : Behaviour {
            self.EnableComponents<T1, T2, T3>();
            self.EnableComponent<T4>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�R���|�[�l���g���L��������g�����\�b�h
        /// </summary>
        public static GameObject DisableComponent<T>(this GameObject self) where T : Behaviour {
            if (self.HasComponent<T>()) {
                self.GetComponent<T>().enabled = false;
            }
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃R���|�[�l���g�𖳌�������g�����\�b�h
        /// </summary>
        public static GameObject DisableComponents<T1, T2>(this GameObject self)
            where T1 : Behaviour where T2 : Behaviour {
            self.DisableComponent<T1>();
            self.DisableComponent<T2>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ3�̃R���|�[�l���g�𖳌�������g�����\�b�h
        /// </summary>
        public static GameObject DisableComponents<T1, T2, T3>(this GameObject self)
            where T1 : Behaviour where T2 : Behaviour where T3 : Behaviour {
            self.DisableComponents<T1, T2>();
            self.DisableComponent<T3>();
            return self;
        }

        /// <summary>
        /// �w�肳�ꂽ4�̃R���|�[�l���g�𖳌�������g�����\�b�h
        /// </summary>
        public static GameObject DisableComponents<T1, T2, T3, T4>(this GameObject self)
            where T1 : Behaviour where T2 : Behaviour where T3 : Behaviour where T4 : Behaviour {
            self.DisableComponents<T1, T2, T3>();
            self.DisableComponent<T4>();
            return self;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region ����

        /// <summary>
        /// �Ώۂ�GameObject�𕡐�(����)���ĕԂ��g�����\�b�h
        /// </summary>
        public static GameObject Instantiate(this GameObject self) {
            return Object.Instantiate(self);
        }

        /// <summary>
        /// ������ɐe�ƂȂ�Transform���w�肵�āA�Ώۂ�GameObject�𕡐�(����)���ĕԂ��g�����\�b�h
        /// </summary>
        public static GameObject Instantiate(this GameObject self, Transform parent) {
            return Object.Instantiate(self, parent);
        }

        /// <summary>
        /// ������̍��W�y�юp�����w�肵�āA�Ώۂ�GameObject�𕡐�(����)���ĕԂ��g�����\�b�h
        /// </summary>
        public static GameObject Instantiate(this GameObject self, Vector3 pos, Quaternion rot) {
            return Object.Instantiate(self, pos, rot);
        }

        /// <summary>
        /// ������ɐe�ƂȂ�Transform�A�܂�������̍��W�y�юp�����w�肵�āA�Ώۂ�GameObject�𕡐�(����)���ĕԂ��g�����\�b�h
        /// </summary>
        public static GameObject Instantiate(this GameObject self, Vector3 pos, Quaternion rot, Transform parent) {
            return Object.Instantiate(self, pos, rot, parent);
        }

        /// <summary>
        /// ������ɐe�ƂȂ�Transform�A�܂�������̃��[�J�����W���w�肵�āA�Ώۂ�GameObject�𕡐�(����)���ĕԂ��g�����\�b�h
        /// </summary>
        public static GameObject InstantiateWithLocalPosition(this GameObject self, Transform parent, Vector3 localPos) {
            var instance = Object.Instantiate(self, parent);
            instance.transform.localPosition = localPos;
            return instance;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �j��

        /// <summary>
        /// Destroy�̊g�����\�b�h
        /// </summary>
        public static void Destroy(this GameObject self) {
            Object.Destroy(self);
        }

        /// <summary>
        /// DestroyImmediate�̊g�����\�b�h
        /// </summary>
        public static void DestroyImmediate(this GameObject self) {
            Object.DestroyImmediate(self);
        }

        /// <summary>
        /// �q�I�u�W�F�N�g�����ׂĔj�󂷂�g�����\�b�h
        /// </summary>
        public static GameObject DestroyAllChildren(this GameObject self) {
            foreach (Transform child in self.transform) {
                Object.Destroy(child.gameObject);
            }
            return self;
        }

        /// <summary>
        /// DontDestroyOnLoad�̊g�����\�b�h
        /// </summary>
        public static GameObject DontDestroyOnLoad(this GameObject self) {
            Object.DontDestroyOnLoad(self);
            return self;
        }
        #endregion


        /// ----------------------------------------------------------------------------
        // �A�N�e�B�u���

        /*

        /// <summary>
        /// �A�N�e�B�u��Ԃ̐؂�ւ��ݒ���s���g�����\�b�h
        /// </summary>
        public static System.IDisposable SetActiveSelfSource(this GameObject self, System.IObservable<bool> source, bool invert = false) {
            return source
                .Subscribe(x => {
                    x = invert ? !x : x;
                    self.SetActive(x);
                })
                .AddTo(self);
        }

        */


        /// ----------------------------------------------------------------------------
        // ���C���[

        /// <summary>
        /// �Ώۂ̃��C���[�Ɋ܂܂�Ă��邩�𒲂ׂ�g�����\�b�h
        /// </summary>
        public static bool IsInLayerMask(this GameObject self, LayerMask layerMask) {
            int objLayerMask = (1 << self.layer);
            return (layerMask.value & objLayerMask) > 0;
        }

        /// <summary>
        /// ���C���[��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetLayer(this GameObject self, string layerName) {
            self.layer = LayerMask.NameToLayer(layerName);
        }

        /// <summary>
        /// ���C���[��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetLayerRecursively(this GameObject self, int layer) {
            self.layer = layer;

            // �q�̃��C���[�ɂ��ݒ肷��
            foreach (Transform childTransform in self.transform) {
                SetLayerRecursively(childTransform.gameObject, layer);
            }
        }

        /// <summary>
        /// ���C���[��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetLayerRecursively(this GameObject self, string layerName) {
            self.SetLayerRecursively(LayerMask.NameToLayer(layerName));
        }


        /// ----------------------------------------------------------------------------
        // �^�O

        /// <summary>
        /// �w�肵���^�O�Q�Ɋ܂܂�Ă��邩���ׂ�g�����\�b�h
        /// </summary>
        public static bool ContainTag(this GameObject self, in string[] tagArray) {
            // ���^�O���܂܂�Ȃ��ꍇ�Ctrue��Ԃ�
            if (tagArray == null || tagArray.Length == 0) return true;

            for (var i = 0; i < tagArray.Length; i++) {
                if (self.CompareTag(tagArray[i])) return true;
            }

            return false;
        }


        /// ----------------------------------------------------------------------------
        // �}�e���A��

        /// <summary>
        /// �}�e���A���ݒ�
        /// </summary>
        /// <param name="needSetChildrens">�q�ɂ��}�e���A���ݒ���s����</param>
        public static void SetMaterial(this GameObject gameObject, Material setMaterial, bool needSetChildrens = true) {
            if (gameObject == null) {
                return;
            }

            //�����_���[������΂��̃}�e���A����ύX
            if (gameObject.GetComponent<Renderer>()) {
                gameObject.GetComponent<Renderer>().material = setMaterial;
            }

            //�q�ɐݒ肷��K�v���Ȃ��ꍇ�͂����ŏI��
            if (!needSetChildrens) return;

            //�q�̃}�e���A���ɂ��ݒ肷��
            foreach (Transform childTransform in gameObject.transform) {
                SetMaterial(childTransform.gameObject, setMaterial, needSetChildrens);
            }

        }
    }
}