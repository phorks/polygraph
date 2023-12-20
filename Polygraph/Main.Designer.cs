namespace Polygraph
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.txtAssociativity = new System.Windows.Forms.TextBox();
            this.txtDemorgans = new System.Windows.Forms.TextBox();
            this.btnNegate = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnImplicates = new System.Windows.Forms.Button();
            this.lblFormula = new System.Windows.Forms.Label();
            this.txtCleanUp = new System.Windows.Forms.TextBox();
            this.btnDemorgans = new System.Windows.Forms.Button();
            this.btnCopyDemorgans = new System.Windows.Forms.Button();
            this.btnCopyAssociativity = new System.Windows.Forms.Button();
            this.btnAssociativity = new System.Windows.Forms.Button();
            this.btnCopyCleanUp = new System.Windows.Forms.Button();
            this.btnCleanUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParsed = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpHorn = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkIsHorn = new System.Windows.Forms.CheckBox();
            this.lblHornImplication = new System.Windows.Forms.Label();
            this.txtHornImplication = new System.Windows.Forms.TextBox();
            this.btnEquivalence = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new Polygraph.MyRichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.grpResolution = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCNFSet = new System.Windows.Forms.TextBox();
            this.grpAbout = new System.Windows.Forms.GroupBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyCNF = new System.Windows.Forms.Button();
            this.btnCNF = new System.Windows.Forms.Button();
            this.txtPlainCNF = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.grpHorn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpResolution.SuspendLayout();
            this.grpAbout.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFormula
            // 
            this.txtFormula.Location = new System.Drawing.Point(81, 12);
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(384, 20);
            this.txtFormula.TabIndex = 0;
            // 
            // txtAssociativity
            // 
            this.txtAssociativity.Location = new System.Drawing.Point(87, 78);
            this.txtAssociativity.Name = "txtAssociativity";
            this.txtAssociativity.ReadOnly = true;
            this.txtAssociativity.Size = new System.Drawing.Size(384, 20);
            this.txtAssociativity.TabIndex = 1;
            // 
            // txtDemorgans
            // 
            this.txtDemorgans.Location = new System.Drawing.Point(87, 52);
            this.txtDemorgans.Name = "txtDemorgans";
            this.txtDemorgans.ReadOnly = true;
            this.txtDemorgans.Size = new System.Drawing.Size(384, 20);
            this.txtDemorgans.TabIndex = 2;
            // 
            // btnNegate
            // 
            this.btnNegate.Location = new System.Drawing.Point(475, 10);
            this.btnNegate.Name = "btnNegate";
            this.btnNegate.Size = new System.Drawing.Size(35, 23);
            this.btnNegate.TabIndex = 3;
            this.btnNegate.Text = "¬";
            this.btnNegate.UseVisualStyleBackColor = true;
            this.btnNegate.Click += new System.EventHandler(this.btnNegate_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(516, 10);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(35, 23);
            this.btnAnd.TabIndex = 4;
            this.btnAnd.Text = "∧";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(557, 10);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(35, 23);
            this.btnOr.TabIndex = 5;
            this.btnOr.Text = "∨";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnImplicates
            // 
            this.btnImplicates.Location = new System.Drawing.Point(598, 10);
            this.btnImplicates.Name = "btnImplicates";
            this.btnImplicates.Size = new System.Drawing.Size(35, 23);
            this.btnImplicates.TabIndex = 6;
            this.btnImplicates.Text = "→";
            this.btnImplicates.UseVisualStyleBackColor = true;
            this.btnImplicates.Click += new System.EventHandler(this.btnImplicates_Click);
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(28, 15);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(47, 13);
            this.lblFormula.TabIndex = 7;
            this.lblFormula.Text = "Formula:";
            // 
            // txtCleanUp
            // 
            this.txtCleanUp.Location = new System.Drawing.Point(87, 104);
            this.txtCleanUp.Name = "txtCleanUp";
            this.txtCleanUp.ReadOnly = true;
            this.txtCleanUp.Size = new System.Drawing.Size(384, 20);
            this.txtCleanUp.TabIndex = 9;
            // 
            // btnDemorgans
            // 
            this.btnDemorgans.Location = new System.Drawing.Point(477, 50);
            this.btnDemorgans.Name = "btnDemorgans";
            this.btnDemorgans.Size = new System.Drawing.Size(75, 23);
            this.btnDemorgans.TabIndex = 10;
            this.btnDemorgans.Text = "Apply";
            this.btnDemorgans.UseVisualStyleBackColor = true;
            this.btnDemorgans.Click += new System.EventHandler(this.btnDemorgans_Click);
            // 
            // btnCopyDemorgans
            // 
            this.btnCopyDemorgans.Location = new System.Drawing.Point(558, 50);
            this.btnCopyDemorgans.Name = "btnCopyDemorgans";
            this.btnCopyDemorgans.Size = new System.Drawing.Size(97, 23);
            this.btnCopyDemorgans.TabIndex = 11;
            this.btnCopyDemorgans.Text = "Set as Formula";
            this.btnCopyDemorgans.UseVisualStyleBackColor = true;
            this.btnCopyDemorgans.Click += new System.EventHandler(this.btnCopyDemorgans_Click);
            // 
            // btnCopyAssociativity
            // 
            this.btnCopyAssociativity.Location = new System.Drawing.Point(558, 76);
            this.btnCopyAssociativity.Name = "btnCopyAssociativity";
            this.btnCopyAssociativity.Size = new System.Drawing.Size(97, 23);
            this.btnCopyAssociativity.TabIndex = 13;
            this.btnCopyAssociativity.Text = "Set as Formula";
            this.btnCopyAssociativity.UseVisualStyleBackColor = true;
            this.btnCopyAssociativity.Click += new System.EventHandler(this.btnCopyAssociativity_Click);
            // 
            // btnAssociativity
            // 
            this.btnAssociativity.Location = new System.Drawing.Point(477, 76);
            this.btnAssociativity.Name = "btnAssociativity";
            this.btnAssociativity.Size = new System.Drawing.Size(75, 23);
            this.btnAssociativity.TabIndex = 12;
            this.btnAssociativity.Text = "Apply";
            this.btnAssociativity.UseVisualStyleBackColor = true;
            this.btnAssociativity.Click += new System.EventHandler(this.btnAssociativity_Click);
            // 
            // btnCopyCleanUp
            // 
            this.btnCopyCleanUp.Location = new System.Drawing.Point(558, 102);
            this.btnCopyCleanUp.Name = "btnCopyCleanUp";
            this.btnCopyCleanUp.Size = new System.Drawing.Size(97, 23);
            this.btnCopyCleanUp.TabIndex = 15;
            this.btnCopyCleanUp.Text = "Set as Formula";
            this.btnCopyCleanUp.UseVisualStyleBackColor = true;
            this.btnCopyCleanUp.Click += new System.EventHandler(this.btnCopyCleanUp_Click);
            // 
            // btnCleanUp
            // 
            this.btnCleanUp.Location = new System.Drawing.Point(477, 102);
            this.btnCleanUp.Name = "btnCleanUp";
            this.btnCleanUp.Size = new System.Drawing.Size(75, 23);
            this.btnCleanUp.TabIndex = 14;
            this.btnCleanUp.Text = "Apply";
            this.btnCleanUp.UseVisualStyleBackColor = true;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "De Morgan\'s:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtParsed);
            this.groupBox1.Controls.Add(this.btnParse);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAssociativity);
            this.groupBox1.Controls.Add(this.txtDemorgans);
            this.groupBox1.Controls.Add(this.btnCopyCleanUp);
            this.groupBox1.Controls.Add(this.txtCleanUp);
            this.groupBox1.Controls.Add(this.btnCleanUp);
            this.groupBox1.Controls.Add(this.btnDemorgans);
            this.groupBox1.Controls.Add(this.btnCopyAssociativity);
            this.groupBox1.Controls.Add(this.btnCopyDemorgans);
            this.groupBox1.Controls.Add(this.btnAssociativity);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 133);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apply Rules";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Formula:";
            // 
            // txtParsed
            // 
            this.txtParsed.Location = new System.Drawing.Point(87, 24);
            this.txtParsed.Name = "txtParsed";
            this.txtParsed.ReadOnly = true;
            this.txtParsed.Size = new System.Drawing.Size(384, 20);
            this.txtParsed.TabIndex = 22;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(477, 22);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 23;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(558, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Set as Formula";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Simplify:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Associativity:";
            // 
            // grpHorn
            // 
            this.grpHorn.Controls.Add(this.button1);
            this.grpHorn.Controls.Add(this.chkIsHorn);
            this.grpHorn.Controls.Add(this.lblHornImplication);
            this.grpHorn.Controls.Add(this.txtHornImplication);
            this.grpHorn.Enabled = false;
            this.grpHorn.Location = new System.Drawing.Point(12, 248);
            this.grpHorn.Name = "grpHorn";
            this.grpHorn.Size = new System.Drawing.Size(662, 77);
            this.grpHorn.TabIndex = 26;
            this.grpHorn.TabStop = false;
            this.grpHorn.Text = "Horn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Check Satisfiability";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkIsHorn
            // 
            this.chkIsHorn.AutoSize = true;
            this.chkIsHorn.Enabled = false;
            this.chkIsHorn.Location = new System.Drawing.Point(9, 19);
            this.chkIsHorn.Name = "chkIsHorn";
            this.chkIsHorn.Size = new System.Drawing.Size(115, 17);
            this.chkIsHorn.TabIndex = 26;
            this.chkIsHorn.Text = "Is a Horn Formula?";
            this.chkIsHorn.UseVisualStyleBackColor = true;
            // 
            // lblHornImplication
            // 
            this.lblHornImplication.AutoSize = true;
            this.lblHornImplication.Location = new System.Drawing.Point(6, 47);
            this.lblHornImplication.Name = "lblHornImplication";
            this.lblHornImplication.Size = new System.Drawing.Size(112, 13);
            this.lblHornImplication.TabIndex = 25;
            this.lblHornImplication.Text = "In implication notation:";
            // 
            // txtHornImplication
            // 
            this.txtHornImplication.Location = new System.Drawing.Point(124, 44);
            this.txtHornImplication.Name = "txtHornImplication";
            this.txtHornImplication.ReadOnly = true;
            this.txtHornImplication.Size = new System.Drawing.Size(531, 20);
            this.txtHornImplication.TabIndex = 22;
            // 
            // btnEquivalence
            // 
            this.btnEquivalence.Location = new System.Drawing.Point(639, 10);
            this.btnEquivalence.Name = "btnEquivalence";
            this.btnEquivalence.Size = new System.Drawing.Size(35, 23);
            this.btnEquivalence.TabIndex = 27;
            this.btnEquivalence.Text = "↔";
            this.btnEquivalence.UseVisualStyleBackColor = true;
            this.btnEquivalence.Click += new System.EventHandler(this.btnEquivalence_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(680, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 398);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(578, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(586, 347);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(477, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "Check Satisfiaility";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // grpResolution
            // 
            this.grpResolution.Controls.Add(this.label7);
            this.grpResolution.Controls.Add(this.txtCNFSet);
            this.grpResolution.Controls.Add(this.button4);
            this.grpResolution.Enabled = false;
            this.grpResolution.Location = new System.Drawing.Point(12, 331);
            this.grpResolution.Name = "grpResolution";
            this.grpResolution.Size = new System.Drawing.Size(662, 77);
            this.grpResolution.TabIndex = 29;
            this.grpResolution.TabStop = false;
            this.grpResolution.Text = "Resolution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "In CNF Set Notation:";
            // 
            // txtCNFSet
            // 
            this.txtCNFSet.Location = new System.Drawing.Point(124, 44);
            this.txtCNFSet.Name = "txtCNFSet";
            this.txtCNFSet.ReadOnly = true;
            this.txtCNFSet.Size = new System.Drawing.Size(531, 20);
            this.txtCNFSet.TabIndex = 28;
            // 
            // grpAbout
            // 
            this.grpAbout.Controls.Add(this.lblAbout);
            this.grpAbout.Location = new System.Drawing.Point(12, 414);
            this.grpAbout.Name = "grpAbout";
            this.grpAbout.Size = new System.Drawing.Size(1257, 55);
            this.grpAbout.TabIndex = 30;
            this.grpAbout.TabStop = false;
            this.grpAbout.Text = "About";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(6, 26);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(1251, 13);
            this.lblAbout.TabIndex = 0;
            this.lblAbout.Text = resources.GetString("lblAbout.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnCopyCNF);
            this.groupBox3.Controls.Add(this.btnCNF);
            this.groupBox3.Controls.Add(this.txtPlainCNF);
            this.groupBox3.Location = new System.Drawing.Point(12, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(662, 52);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CNF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "CNF:";
            // 
            // btnCopyCNF
            // 
            this.btnCopyCNF.Location = new System.Drawing.Point(558, 16);
            this.btnCopyCNF.Name = "btnCopyCNF";
            this.btnCopyCNF.Size = new System.Drawing.Size(97, 22);
            this.btnCopyCNF.TabIndex = 24;
            this.btnCopyCNF.Text = "Set as Formula";
            this.btnCopyCNF.UseVisualStyleBackColor = true;
            this.btnCopyCNF.Click += new System.EventHandler(this.btnCopyCNF_Click);
            // 
            // btnCNF
            // 
            this.btnCNF.Location = new System.Drawing.Point(477, 16);
            this.btnCNF.Name = "btnCNF";
            this.btnCNF.Size = new System.Drawing.Size(75, 22);
            this.btnCNF.TabIndex = 23;
            this.btnCNF.Text = "Convert";
            this.btnCNF.UseVisualStyleBackColor = true;
            this.btnCNF.Click += new System.EventHandler(this.btnCNF_Click);
            // 
            // txtPlainCNF
            // 
            this.txtPlainCNF.Location = new System.Drawing.Point(87, 18);
            this.txtPlainCNF.Name = "txtPlainCNF";
            this.txtPlainCNF.ReadOnly = true;
            this.txtPlainCNF.Size = new System.Drawing.Size(384, 20);
            this.txtPlainCNF.TabIndex = 22;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 481);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpAbout);
            this.Controls.Add(this.grpResolution);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnEquivalence);
            this.Controls.Add(this.grpHorn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.btnImplicates);
            this.Controls.Add(this.btnOr);
            this.Controls.Add(this.btnAnd);
            this.Controls.Add(this.btnNegate);
            this.Controls.Add(this.txtFormula);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygraph";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpHorn.ResumeLayout(false);
            this.grpHorn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpResolution.ResumeLayout(false);
            this.grpResolution.PerformLayout();
            this.grpAbout.ResumeLayout(false);
            this.grpAbout.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.TextBox txtAssociativity;
        private System.Windows.Forms.TextBox txtDemorgans;
        private System.Windows.Forms.Button btnNegate;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnImplicates;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.TextBox txtCleanUp;
        private System.Windows.Forms.Button btnDemorgans;
        private System.Windows.Forms.Button btnCopyDemorgans;
        private System.Windows.Forms.Button btnCopyAssociativity;
        private System.Windows.Forms.Button btnAssociativity;
        private System.Windows.Forms.Button btnCopyCleanUp;
        private System.Windows.Forms.Button btnCleanUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtParsed;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpHorn;
        private System.Windows.Forms.CheckBox chkIsHorn;
        private System.Windows.Forms.Label lblHornImplication;
        private System.Windows.Forms.TextBox txtHornImplication;
        private System.Windows.Forms.Button btnEquivalence;
        private System.Windows.Forms.GroupBox groupBox2;
        private MyRichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox grpResolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCNFSet;
        private System.Windows.Forms.GroupBox grpAbout;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopyCNF;
        private System.Windows.Forms.Button btnCNF;
        private System.Windows.Forms.TextBox txtPlainCNF;
    }
}

