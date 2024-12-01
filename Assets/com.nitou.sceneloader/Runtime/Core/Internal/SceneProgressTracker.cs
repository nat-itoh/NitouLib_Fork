
namespace Unity.SceneManagement.Internal {

    /// <summary>
    /// A class that observes the progress of scene handles.
    /// </summary>
    internal class SceneProgressTracker {

        private readonly SceneHandleManager _handleManager;

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public SceneProgressTracker(SceneHandleManager handleManager) {
            _handleManager = handleManager;
        }

        /// <summary>
        /// True if a loading operation is in progress.
        /// </summary>
        public bool HasProgress => _handleManager.OperationCount != 0;

        /// <summary>
        /// The progress of the loading operation.
        /// </summary>
        /// <returns>Progress value</returns>
        public float Progress() {
            float progress = 0;
            foreach (var handle in _handleManager.OperationHandles)
                progress += handle.PercentComplete;

            return progress / _handleManager.OperationCount;
        }
    }
}