using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EZ_B.AVM;
using EZ_Builder;
using EZ_Builder.Config.Sub;

namespace Programming_with_Pictures {

  public partial class FormMain : EZ_Builder.UCForms.FormPluginMaster {

    public CvAssociativeMemory32S       AssociativeMemory = new CvAssociativeMemory32S();
    EZ_Builder.UCForms.FormCameraDevice _cameraControl;
    bool                                _isClosing = false;
    EZ_B.AVM.TrainedObjectsContainer    _trainedObjects;
    EZ_Builder.Scripting.Executor       _executor;
    int                                 _currentRunningIndex;

    public static bool _IsRunning = false;

    public FormMain() {

      InitializeComponent();

      _executor = new EZ_Builder.Scripting.Executor("Programming with Pictures");
      _executor.OnCmdExec += _executor_OnCmdExec;
      _executor.OnDone += _executor_OnDone;
      _executor.OnStart += _executor_OnStart;
    }

    private void FormMain_Load(object sender, EventArgs e) {

      detach();

      string trainedObjectDataFile = EZ_Builder.Common.CombinePath(
        EZ_Builder.Constants.PLUGINS_FOLDER,
        _cf._pluginGUID,
        "Trained Object Data.xml");

      if (!File.Exists(trainedObjectDataFile)) {

        MessageBox.Show("Unable to find the trained object data file required for this plugin. Closing...");

        Close();

        return;
      }

      try {

        using (FileStream fs = new FileStream(trainedObjectDataFile, FileMode.Open, FileAccess.Read)) {

          System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(EZ_B.AVM.TrainedObjectsContainer));

          _trainedObjects = (EZ_B.AVM.TrainedObjectsContainer)xs.Deserialize(fs);

          AssociativeMemory.ReadPackedData(_trainedObjects.Data);
        }
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, "Error loading trained object data: {0}", ex);
      }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {

      _isClosing = true;

      detach();
    }

    public override void SetConfiguration(PluginV1 cf) {

      base.SetConfiguration(cf);
    }

    void detach() {

      if (_cameraControl != null) {

        if (!_isClosing)
          EZ_Builder.EZBManager.Log("Detaching from {0}", _cameraControl.Text);

        _cameraControl.Camera.OnNewFrame -= Camera_OnNewFrame;

        _cameraControl = null;
      }

      if (!_isClosing) {

        Invokers.SetEnabled(btnAttachCamera, true);
        Invokers.SetText(btnAttachCamera, "Attach Camera");
      }
    }

    void attach() {

      detach();

      Control[] cameras = EZ_Builder.EZBManager.FormMain.GetControlByType(typeof(EZ_Builder.UCForms.FormCameraDevice));

      if (cameras.Length == 0) {

        MessageBox.Show("There are no camera controls in this project.");

        return;
      }

      foreach (EZ_Builder.UCForms.FormCameraDevice camera in cameras)
        if (camera.Camera.IsActive) {

          this.Invoke(new Action(() => {

            pictureBox1.Image = new Bitmap(camera.Camera.CaptureWidth, camera.Camera.CaptureHeight, EZ_B.Camera.PixelFormat);

            _cameraControl = camera;

            Invokers.SetAppendText(tbLog, true, "Attached to: {0}", _cameraControl.Text);

            btnAttachCamera.Enabled = true;

            btnAttachCamera.Text = "Detach Camera";

            _cameraControl.Camera.OnNewFrame += Camera_OnNewFrame;
          }));

          return;
        }

      MessageBox.Show("There are no active cameras in this project. This control will connect to the first active camera that it detects in the project");
    }

    UCProgramItem.ProgramItemEnum GetDetectedImage(Bitmap image) {

      if (AssociativeMemory.GetTotalABases() <= 1)
        return UCProgramItem.ProgramItemEnum.NA;

      AssociativeMemory.SetImage(ref image);

      CvObjDsr32S[] SeqObjDsr = AssociativeMemory.ObjectTracking(false, 0.54, 0.45);

      List<int> foundIds = new List<int>();

      for (int i = 0; SeqObjDsr != null && i < SeqObjDsr.Length; i++) {

        CvObjDsr32S ObjDsr = SeqObjDsr[i];

        if (foundIds.Contains(ObjDsr.Data))
          continue;

        foundIds.Add(ObjDsr.Data);

        using (Graphics g = Graphics.FromImage(image))
          g.DrawRectangle(Pens.Pink, ObjDsr.ObjRect);

        string foundName = _trainedObjects.Objects[ObjDsr.Data].Name;

        if (foundName == "Forward")
          return UCProgramItem.ProgramItemEnum.Forward;
        else if (foundName == "Right")
          return UCProgramItem.ProgramItemEnum.Right;
        else if (foundName == "Reverse")
          return UCProgramItem.ProgramItemEnum.Reverse;
        else if (foundName == "Left")
          return UCProgramItem.ProgramItemEnum.Left;
        else if (foundName == "Pause")
          return UCProgramItem.ProgramItemEnum.Sleep;
        else if (foundName == "Start")
          return UCProgramItem.ProgramItemEnum.Start;
      }

      return UCProgramItem.ProgramItemEnum.NA;
    }

    UCProgramItem.ProgramItemEnum _lastDetectedItem = UCProgramItem.ProgramItemEnum.NA;

    void say(string strToSay) {

      if (EZBManager.EZBs[0].IsConnected)
        using (MemoryStream s = EZBManager.EZBs[0].SpeechSynth.SayToStream(strToSay))
          EZBManager.EZBs[0].SoundV4.PlayData(s);
      else
        EZBManager.EZBs[0].SpeechSynth.Say(strToSay);
    }

    void Camera_OnNewFrame() {

      if (_isClosing)
        return;

      try {

        Bitmap image = _cameraControl.Camera.GetCurrentBitmap;

        var found = GetDetectedImage(image);

        if (found == UCProgramItem.ProgramItemEnum.NA) {

        } else if (_lastDetectedItem != found && found == UCProgramItem.ProgramItemEnum.Start) {

          say("Running your program");

          _currentRunningIndex = 0;

          flowLayoutPanel1.Invoke(new Action(() => {

            var item = (UCProgramItem)flowLayoutPanel1.Controls[_currentRunningIndex];

            item.BackColor = Color.Green;

            _executor.StartScriptASync(item.GetCode());
          }));

        } else if (_lastDetectedItem != found) {

          flowLayoutPanel1.Invoke(new Action(() => Invokers.AddControl(flowLayoutPanel1, new UCProgramItem(found))));

          say(string.Format("Added {0} command", found));
        }

        _lastDetectedItem = found;

        // Rather than creating a new bitmap for the picturebox, we simply overwrite the bitmap data with the bmTmp data
        // This way, when the bmpTmp is destroyed from the using, the picturebox has the brand new image data
        pictureBox1.Invoke(new Action(() => EZ_B.Camera.CopyBitmapMemory(image, (Bitmap)pictureBox1.Image)));

        Invokers.SetRefresh(pictureBox1);
      } catch (Exception ex) {

        Invokers.SetAppendText(tbLog, true, ex.ToString());

        Invokers.SetEnabled(btnAttachCamera, true);
      }
    }

    public override void SendCommand(string windowCommand, params string[] values) {

      if (windowCommand.Equals("learn", StringComparison.InvariantCultureIgnoreCase)) {

      } else if (windowCommand.Equals("detach", StringComparison.InvariantCultureIgnoreCase))
        detach();
      else if (windowCommand.Equals("attach", StringComparison.InvariantCultureIgnoreCase))
        attach();
      else
        base.SendCommand(windowCommand, values);
    }

    public override object[] GetSupportedControlCommands() {

      List<string> cmds = new List<string>();

      cmds.Add("Attach");
      cmds.Add("Learn");
      cmds.Add("Learn, \"Object Name\"");
      cmds.Add("Detach");

      return cmds.ToArray();
    }

    private void button1_Click(object sender, EventArgs e) {

      if (_cameraControl == null)
        attach();
      else
        detach();
    }

    private void btnClear_Click(object sender, EventArgs e) {

      if (!_IsRunning)
        flowLayoutPanel1.Controls.Clear();
    }

    private void _executor_OnStart(string compilerName) {

      _IsRunning = true;
    }

    private void _executor_OnDone(string compilerName, TimeSpan timeTook) {

      _currentRunningIndex++;

      flowLayoutPanel1.Invoke(new Action(() => {

        var previousItem = (UCProgramItem)flowLayoutPanel1.Controls[_currentRunningIndex - 1];
        previousItem.BackColor = Color.White;
      }));

      if (_currentRunningIndex == flowLayoutPanel1.Controls.Count) {

        _IsRunning = false;

        say("Program completed");

        return;
      }

      flowLayoutPanel1.Invoke(new Action(() => {

        var item = (UCProgramItem)flowLayoutPanel1.Controls[_currentRunningIndex];

        item.BackColor = Color.Green;

        _executor.StartScriptASync(item.GetCode());
      }));
    }

    private void _executor_OnCmdExec(string compilerName, int lineNumber, string execTxt) {

      Invokers.SetAppendText(tbLog, true, execTxt);
    }
  }
}
