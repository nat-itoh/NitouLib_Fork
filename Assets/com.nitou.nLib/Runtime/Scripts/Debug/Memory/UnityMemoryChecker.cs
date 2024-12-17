using UnityEngine;
using UnityEngine.Profiling;

// [REF]
//  note: �������g�p�ʂ��l���� https://note.com/extrier/n/n2b55ba09856f
//  �R�K�l�u���O: Unity ���m�ۂ����������̎g�p�󋵁iUnity �̎g�p�������j���擾����X�N���v�g https://baba-s.hatenablog.com/entry/2019/03/26/084000#google_vignette
//  UniDoc: Profiler https://docs.unity3d.com/ja/2023.2/ScriptReference/Profiling.Profiler.html
//  UniDoc: Memory Profiler ���W���[�� https://docs.unity3d.com/ja/current/Manual/ProfilerMemory.html

namespace nitou {

    public sealed class UnityMemoryChecker {

        public float Used { get; private set; }
        public float Unused { get; private set; }
        public float Total { get; private set; }

        public string UsedText { get; private set; }
        public string UnusedText { get; private set; }
        public string TotalText { get; private set; }


        public void Update() {
            // Unity �ɂ���Ċ��蓖�Ă�ꂽ������
            Used = (Profiler.GetTotalAllocatedMemoryLong() >> 10) / 1024f;

            // �\��ς݂������蓖�Ă��Ă��Ȃ�������
            Unused = (Profiler.GetTotalUnusedReservedMemoryLong() >> 10) / 1024f;

            // Unity �����݂���я����̊��蓖�Ă̂��߂Ɋm�ۂ��Ă��鑍������
            Total = (Profiler.GetTotalReservedMemoryLong() >> 10) / 1024f;

            UsedText = Used.ToString("0.0") + " MB";
            UnusedText = Unused.ToString("0.0") + " MB";
            TotalText = Total.ToString("0.0") + " MB";
        }
    }
}
