using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// [�Q�l]
//  _: �V���O���g����ScriptableObject���������� https://mackysoft.net/singleton-scriptableobject/
//  qiita: Generics �̃��\�b�h�Ō^�����擾���� https://qiita.com/TsuyoshiUshio@github/items/7b9544fbc338af5807f5
//  github: somedeveloper00/SingletonScriptableObject https://github.com/somedeveloper00/SingletonScriptableObject/blob/master/Runtime/src/Sample.cs

namespace nitou.DesignPattern{

    /// <summary>
    /// ScriptableObject���p�������V���O���g��
    /// </summary>
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T: ScriptableObject {

        // 
        private static T _instance;
        public static T Instance {
            get {
                if (_instance == null) {

                    // Resource�t�H���_����A�Z�b�g���擾
					_instance = Resources.Load<T>(typeof(T).Name);

#if UNITY_EDITOR
                    // Assets�t�H���_������A�Z�b�g���擾
                    if (_instance == null) {
                        _instance = ScriptableObjectUtil.FindScriptableObject<T>();
                    }
#endif

                    // ���݂��Ȃ��ꍇ�̓G���[
                    if (_instance == null) {
                        Debug.LogError(typeof(T) + " �̃A�Z�b�g�̓t�H���_���ɑ��݂��܂���");
                    }
                }
                return _instance;
            }
        }


        /// ----------------------------------------------------------------------------
        // ScriptableObject Method

        protected virtual void Awake() {
            if (!_instance || _instance == this) return;
            Debug.LogError($"{typeof(T).Name} deleted. Another instance is already available.");
#if UNITY_EDITOR
            if (!Application.isPlaying)
                DestroyImmediate(this);
            else
#endif
                Destroy(this);
        }

        protected virtual void OnDestroy() {
            if (_instance == this) {
                Debug.LogWarning($"{typeof(T).Name} instance destroyed. Singleton instance is no longer available.");
            }
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă��邩���ׂ�
        /// </summary>
        protected bool CheckInstance() {
            // ���݂��Ȃ��ior�������g�j�ꍇ
            if (_instance == null) {
                _instance = this as T;
                return true;
            } else if (Instance == this) {
                return true;
            }
            // ���ɑ��݂���ꍇ
            return false;
        }

    }


    /// <summary>
    /// ScriptableObject��ΏۂƂ����ėp���C�u����
    /// </summary>
    public static partial class ScriptableObjectUtil {

#if UNITY_EDITOR

        /// <summary>
        /// Assets�t�H���_����ScriptableObject����������
        /// </summary>
        public static T FindScriptableObject<T>() where T: ScriptableObject{

            // �Ώۂ̃t�@�C�����
            var guid = AssetDatabase.FindAssets("t:" + typeof(T).Name).FirstOrDefault();
            var filePath = AssetDatabase.GUIDToAssetPath(guid);

            if (string.IsNullOrEmpty(filePath)) {
                throw new System.IO.FileNotFoundException(typeof(T).Name + " does not found");

                // Log �o���� return null
                //Debug_.LogWarning("Oh...");
                //return null;
            }

            var asset = AssetDatabase.LoadAssetAtPath<T>(filePath);
            return asset;
        }
#endif

    }
}
