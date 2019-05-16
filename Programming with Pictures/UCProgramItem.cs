using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZ_Builder;

namespace Programming_with_Pictures {

  public partial class UCProgramItem : UserControl {

    public enum ProgramItemEnum {
      NA,
      Forward,
      Left,
      Right,
      Reverse,
      Sleep,
      Start
    }

    public ProgramItemEnum ProgramItem {
      get;
      set;
    }

    public UCProgramItem(ProgramItemEnum programItem) {

      this.Name = DateTime.Now.Ticks.ToString();

      ProgramItem = programItem;

      InitializeComponent();

      lblTitle.Text = programItem.ToString();

      if (programItem == ProgramItemEnum.Forward)
        pictureBox1.Image = ProgramCardImages.Forward;
      else if (programItem == ProgramItemEnum.Left)
        pictureBox1.Image = ProgramCardImages.Left;
      else if (programItem == ProgramItemEnum.Right)
        pictureBox1.Image = ProgramCardImages.Right;
      else if (programItem == ProgramItemEnum.Reverse)
        pictureBox1.Image = ProgramCardImages.Reverse;
      else if (programItem == ProgramItemEnum.Sleep)
        pictureBox1.Image = ProgramCardImages.pause;
    }

    private void lblDelete_Click(object sender, EventArgs e) {

      if (!FormMain._IsRunning)
        Dispose();
    }

    public string GetCode() {

      StringBuilderV2 sb = new StringBuilderV2(false);

      if (ProgramItem == ProgramItemEnum.Forward) {

        sb.AppendLine("Forward()");
        sb.AppendLine("Sleep(2000)");
        sb.AppendLine("Stop()");
      } else if (ProgramItem == ProgramItemEnum.Right) {

        sb.AppendLine("Right()");
        sb.AppendLine("Sleep(2000)");
        sb.AppendLine("Stop()");
      } else if (ProgramItem == ProgramItemEnum.Reverse) {

        sb.AppendLine("Reverse()");
        sb.AppendLine("Sleep(2000)");
        sb.AppendLine("Stop()");
      } else if (ProgramItem == ProgramItemEnum.Left) {

        sb.AppendLine("Left()");
        sb.AppendLine("Sleep(2000)");
        sb.AppendLine("Stop()");
      } else if (ProgramItem == ProgramItemEnum.Sleep) {

        sb.AppendLine("Sleep(2000)");
      }

      return sb.ToString();
    }
  }
}
