
namespace nitou.Tools.ProjectWindow {

    /// <summary>
    /// OutGame�p�̃X�N���v�g�t�H���_�\��
    /// </summary>
    [System.Serializable]
    public class ScriptsDirectoryFlags : IFlagContainer {
        public bool Composition = true;
        public bool Model = true;
        public bool UseCase = false;
        public bool View = true;
        public bool Presentation = true;
        public bool Foundation = true;
        public bool APIGateway = false;
    }

}
