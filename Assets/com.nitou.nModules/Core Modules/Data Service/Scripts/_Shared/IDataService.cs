namespace nitou.SaveSystem{

    /// <summary>
    /// �f�[�^�̕ۑ��E�ǂݍ��݂̎�������S���C���^�[�t�F�[�X�D
    /// </summary>
    public interface IDataService{

        /// <summary>
        /// �f�[�^��ۑ�����D
        /// </summary>
        bool SaveData<T>(string key, T data);

        /// <summary>
        /// �f�[�^��ǂݍ��ށD
        /// </summary>
        T LoadData<T>(string key);
    }
}
