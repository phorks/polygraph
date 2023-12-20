using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygraph
{
    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    public class MyRichTextBox : System.Windows.Forms.RichTextBox
    {

        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

        public MyRichTextBox()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReadOnlyRichTextBox_Mouse);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ReadOnlyRichTextBox_Mouse);
            base.ReadOnly = true;
            base.TabStop = false;
            base.BorderStyle = BorderStyle.None;
            base.TabStop = false;
            base.SetStyle(ControlStyles.Selectable, false);
            base.SetStyle(ControlStyles.UserMouse, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //base.BackColor = System.Drawing.Color.White;
            HideCaret(this.Handle);
        }


        protected override void OnGotFocus(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        protected override void OnEnter(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        [DefaultValue(true)]
        public new bool ReadOnly
        {
            get { return true; }
            set { }
        }

        [DefaultValue(false)]
        public new bool TabStop
        {
            get { return false; }
            set { }
        }

        private void ReadOnlyRichTextBox_Mouse(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HideCaret(this.Handle);
        }

        private void InitializeComponent()
        {
            //
            // ReadOnlyRichTextBox
            //
            this.Resize += new System.EventHandler(this.ReadOnlyRichTextBox_Resize);

        }

        private void ReadOnlyRichTextBox_Resize(object sender, System.EventArgs e)
        {
            HideCaret(this.Handle);

        }
        public void setText(string text)
        {
            //this.Text = "";
            bool isSuperScript = false, isSubScript = false, right = false;
            int lastSet = 0, lastRight = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '^')
                {
                    if (isSuperScript)
                        this.addSuperScriptText(text.Substring(lastSet, i - lastSet), right);
                    else
                        this.addNormalText(text.Substring(lastSet, i - lastSet), right);
                    lastSet = i + 1;
                    isSuperScript = !isSuperScript;
                }
                else if (text[i] == '_')
                {
                    if (isSubScript)
                        this.addSubScriptText(text.Substring(lastSet, i - lastSet), right);
                    else
                        this.addNormalText(text.Substring(lastSet, i - lastSet), right);
                    lastSet = i + 1;
                    isSubScript = !isSubScript;
                }
            }
            if (lastSet < text.Length)
                this.addNormalText(text.Substring(lastSet), right);
        }
        private void addNormalText(string text, bool right)
        {
            base.SelectionCharOffset = 0;
            base.SelectionFont = normalFont;
            base.SelectionAlignment = right ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            base.SelectedText = text.Replace("$", "");
        }
        private void addSuperScriptText(string text, bool right)
        {
            base.SelectionCharOffset = 7;
            base.SelectionFont = smallFont;
            base.SelectionAlignment = right ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            base.SelectedText = text.Replace("$", "");
        }
        private static System.Drawing.Font smallFont = new System.Drawing.Font("Microsoft Sans Serif", 10);
        private static System.Drawing.Font normalFont = new System.Drawing.Font("Microsoft Sans Serif", 12);
        private void addSubScriptText(string text, bool right)
        {
            base.SelectionCharOffset = -3;
            base.SelectionFont = smallFont;
            base.SelectionAlignment = right ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            base.SelectedText = text.Replace("$", "");
        }
    }
}
