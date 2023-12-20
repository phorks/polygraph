using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygraph
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //Formula.Literal f1 = "A", f2 = "-B", f3 = "!A", f4 = "B";
            //Formula.Disjunction d = (f1 * f2) + (f3 * f4);
            //MessageBox.Show(Formula.parse("(A+-B)*(-C+-A+-D)*-(-A+-B)*D*-E").applyDemorgans().applyAssociativity().ToString());
            //MessageBox.Show(Formula.parse("a|(a&b)|(a&(b|c)&c)|d").applyDistribution().applyAssociativity().ToString());
            //MessageBox.Show(Formula.parse("(a*b)>b").ToString());
            //MessageBox.Show(Formula.parse("a|(a&b)|(a&-(b>c)&c)|d").ToString());
            //MessageBox.Show(Formula.parse("a|(a&b)|(a&(b>c)&c)|d").applyDistribution().applyAssociativity().ToString());
            //MessageBox.Show(Formula.parse("a|(a&b)|(a&(b>c)&c)|d").applyDistribution().applyAssociativity().simplify().ToString());
            //MessageBox.Show(Formula.parse("a&(a|b|c)&(-a|-b|-c)").applyAssociativity().ToString() + "\r\n" +
            //    Formula.parse("a&(a|b|c)&(-a&-b&-c)").applyAssociativity().simplify().ToString());
        }

        private void btnNegate_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += Formula.negationSymbol;
            this.txtFormulaFocus();
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += Conjunction.symbol;
            this.txtFormulaFocus();
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += Disjunction.symbol;
            this.txtFormulaFocus();
        }

        private void btnImplicates_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += Disjunction.implicationSymbol;
            this.txtFormulaFocus();
        }
        private void btnEquivalence_Click(object sender, EventArgs e)
        {
            this.txtFormula.Text += Conjunction.equivalenceSymbol;
            this.txtFormulaFocus();
        }
        private void txtFormulaFocus()
        {
            this.txtFormula.Focus();
            this.txtFormula.DeselectAll();
            this.txtFormula.SelectionStart = this.txtFormula.Text.Length;
            this.txtFormula.SelectionLength = 0;
        }
        private Formula _formula = null;
        private Formula formula
        {
            get
            {
                if (this._formula == null)
                    this._formula = Formula.parse(this.txtFormula.Text);
                return this._formula;
            }
            set
            {
                this._formula = value;
            }
        }

        private void btnDemorgans_Click(object sender, EventArgs e)
        {
            this.txtDemorgans.Text = formula.applyDemorgans().ToString();
        }

        private void btnAssociativity_Click(object sender, EventArgs e)
        {
            this.txtAssociativity.Text = formula.applyAssociativity().ToString();
        }
        private void btnCleanUp_Click(object sender, EventArgs e)
        {
            this.txtCleanUp.Text = formula.simplify().ToString();
        }
        private Conjunction CNF;

        private void btnCNF_Click(object sender, EventArgs e)
        {
            Conjunction cnf = formula.toCNF();
            this.CNF = cnf;
            this.activateResolution();
            if (this.CNF.isHorn())
                this.activateHorn();
            else
                this.deactivateHorn();
            this.txtPlainCNF.Text = cnf.ToString();
            //this.txtCNF.Text = this.CNF.ToString();
        }
        private void activateHorn()
        {
            this.grpHorn.Enabled = true;
            this.chkIsHorn.Checked = true;
            this.txtHornImplication.Text = this.CNF.toImplicationString();
        }
        private void deactivateHorn()
        {
            this.grpHorn.Enabled = false;
            this.chkIsHorn.Checked = false;
            this.txtHornImplication.Text = "";
        }
        private void activateResolution()
        {
            this.grpResolution.Enabled = true;
            this.txtCNFSet.Text = this.CNF.toCNFSet().ToString();
        }

        private void btnCopyDemorgans_Click(object sender, EventArgs e)
        {
            this.formula = this.formula.applyDemorgans();
            this.txtFormula.Text = this.formula.ToString();
        }

        private void btnCopyAssociativity_Click(object sender, EventArgs e)
        {
            this.formula = this.formula.applyAssociativity();
            this.txtFormula.Text = this.formula.ToString();
        }

        private void btnCopyCleanUp_Click(object sender, EventArgs e)
        {
            this.formula = this.formula.simplify();
            this.txtFormula.Text = this.formula.ToString();
        }

        private void btnCopyCNF_Click(object sender, EventArgs e)
        {
            this.formula = this.formula.toCNF();
            this.txtFormula.Text = this.formula.ToString();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            this.formula = Formula.parse(txtFormula.Text);
            this.txtParsed.Text = this.formula.ToString();
        }

        private void log(string text, Color color)
        {
            string newLine = "\r\n", start = ">>> ";
            if(text.StartsWith("-----"))
            {
                newLine = "";
                text = text.Substring(5);
            }
            else if(text.StartsWith(">>>>>"))
            {
                start = "";
                text = text.Substring(5);
            }
            this.richTextBox1.AppendText(start + text + newLine, color);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CNF.performHornSatisficationAlgorithm(this.log);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.CNF.toCNFSet().performSAT(this.log);
        }
    }
    public static class ext
    {
        public static Font sans = new Font("Microsoft Sans Serif", 9);
        public static void AppendText(this MyRichTextBox box, string text, Color color)
        {
            text = text.Replace(Conjunction.symbol, " & ");
            text = text.Replace(Disjunction.implicationSymbol, " -> ");
            //text = text.Replace(Formula.negationSymbol, "~");
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.SelectionFont = sans;
            box.setText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
