using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEngine;


[InitializeOnLoad]//�G�f�B�^�[�N�����ɃR���X�g���N�^���Ă΂��悤��
public static class RecorderIgniter
{

    //=================================================================================
    //������
    //=================================================================================

    /// <summary>
    /// �R���X�g���N�^(InitializeOnLoad�����ɂ��G�f�B�^�[�N�����ɌĂяo�����)
    /// </summary>
    static RecorderIgniter()
    {
        //playModeStateChanged�C�x���g�Ƀ��\�b�h�o�^
        EditorApplication.playModeStateChanged += OnChangedPlayMode;
    }

    //=================================================================================
    //�v���C���[�h�̕ύX
    //=================================================================================

    //�v���C���[�h���ύX���ꂽ
    private static void OnChangedPlayMode(PlayModeStateChange state)
    {


        //�G�f�B�^�̍Đ��J�n��
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            StartRecording();
        }

    }

    //=================================================================================
    //�^��J�n
    //=================================================================================

    //�^��J�n
    private static void StartRecording()
    {
        //Recorder�̃E�B���h�E�擾
        var recorderWindow = (RecorderWindow)EditorWindow.GetWindow(typeof(RecorderWindow));
        if (recorderWindow == null)
        {
            Debug.LogWarning("RecorderWindow���Ȃ��̂Ŏ����Đ��o���܂���ł���");
            return;
        }

        if (recorderWindow.IsRecording())
        {
            return;
        }
        Debug.Log("�����^��J�n");
        recorderWindow.StartRecording();
    }

    //=================================================================================
    //�t�@�C���̍폜
    //=================================================================================



}