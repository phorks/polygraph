using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygraph
{
    public abstract class Formula
    {
        public const string negationSymbol = "¬";

        public bool isNegative
        {
            get;
            protected set;
        }

        public abstract Formula negate();

        public abstract bool contains(string var);

        public bool associativityApplied
        {
            get;
            set;
        }

        public bool demorgansApplied
        {
            get;
            set;
        }

        public string ToString(bool useParantheses, bool useExtraPrantheseForNegation = false)
        {
            if (useParantheses)
            {
                if (useExtraPrantheseForNegation || !this.isNegative)
                    return "(" + this.ToString() + ")";
            }
            return this.ToString();
        }

        public abstract string toImplicationString();

        public static Formula operator ~(Formula f)
        {
            return f.negate();
        }

        public static Disjunction operator |(Formula lhs, Formula rhs)
        {
            return new Disjunction(lhs, rhs);
        }

        public static Conjunction operator &(Formula lhs, Formula rhs)
        {
            return new Conjunction(lhs, rhs);
        }

        public static Disjunction operator %(Formula lhs, Formula rhs)
        {
            Disjunction _r = new Disjunction(~lhs, rhs);
            //_r.isImplication = true;
            return _r;
        }

        public static Conjunction operator /(Formula lhs, Formula rhs)
        {
            return (~lhs | rhs) & (lhs | ~rhs);
        }

        public static bool isLetterOr01(char ch)
        {
            return Char.IsLetter(ch) || ch == '1' || ch == '0';
        }

        public static Formula parse(string str)
        {
            try
            {
                Dictionary<string, string> replaceMap = new Dictionary<string, string>()
                {
                    {"<->", "$" },
                    {Conjunction.equivalenceSymbol, "$"},
                    {"->", ">"},
                    {Disjunction.implicationSymbol, ">"},
                    {"&", "*"},
                    {"^", "*"},
                    {".", "*"},
                    {Conjunction.symbol, "*"},
                    {"|", "+"},
                    {Disjunction.symbol, "+"},
                    {"-", "~"},
                    {"!", "~"},
                    {Formula.negationSymbol, "~"},
                    {" ", ""}
                };
                foreach (var rep in replaceMap)
                    str = str.Replace(rep.Key, rep.Value);
                Stack<string> operators = new Stack<string>();
                Stack<Formula> output = new Stack<Formula>();
                for (int i = 0; i < str.Length; i++)
                {
                    if (isLetterOr01(str[i]))
                        output.Push(Literal.parse(str[i].ToString()));
                    else if (str[i] == '~')
                    {
                        if (isLetterOr01(str[i + 1]))
                        {
                            output.Push(Literal.parse("~" + str[i + 1]));
                            i++;
                        }
                        else if (str[i + 1] == '~') // Double Negation
                        {
                            i++;
                        }
                        else
                        {
                            operators.Push("~");
                        }
                    }
                    else if (str[i] == '*')
                        operators.Push("*");
                    else if (str[i] == '+')
                    {
                        while (operators.Count != 0 && operators.Peek() == "*")
                        {
                            operators.Pop();
                            Formula a2 = output.Pop(), a1 = output.Pop();
                            output.Push(a1 & a2);
                        }
                        operators.Push("+");
                    }
                    else if (str[i] == '>')
                    {
                        while (operators.Count != 0 && (operators.Peek() == "*" || operators.Peek() == "+"))
                        {
                            string op = operators.Pop();
                            Formula a2 = output.Pop(), a1 = output.Pop();
                            if (op == "*")
                                output.Push(a1 & a2);
                            else if (op == "+")
                                output.Push(a1 | a2);
                        }
                        operators.Push(">");
                    }
                    else if (str[i] == '$')
                    {
                        while (operators.Count != 0 && (operators.Peek() == "*" || operators.Peek() == "+" || operators.Peek() == ">"))
                        {
                            string op = operators.Pop();
                            Formula a2 = output.Pop(), a1 = output.Pop();
                            if (op == "*")
                                output.Push(a1 & a2);
                            else if (op == "+")
                                output.Push(a1 | a2);
                            else if (op == ">")
                                output.Push(a1 % a2);
                        }
                        operators.Push("$");
                    }
                    else if (str[i] == ')')
                    {
                        for (string op = operators.Pop(); op != "("; op = operators.Pop())
                        {
                            Formula a2 = output.Pop(), a1 = output.Pop(), a3 = null;
                            if (op == "*")
                                a3 = a1 & a2;
                            else if (op == "+")
                                a3 = a1 | a2;
                            else if (op == ">")
                                a3 = a1 % a2;
                            else if (op == "$")
                                a3 = a1 / a2;
                            output.Push(a3);
                        }
                        if (operators.Count != 0 && operators.Peek() == "~")
                        {
                            operators.Pop();
                            Formula f = output.Pop();
                            f.isNegative = !f.isNegative;
                            output.Push(f);
                        }
                    }
                    else if (str[i] == '(')
                        operators.Push("(");
                }
                while (operators.Count != 0)
                {
                    string op = operators.Pop();
                    Formula a2 = output.Pop(), a1 = output.Pop(), a3 = null;
                    if (op == "*")
                        a3 = a1 & a2;
                    else if (op == "+")
                        a3 = a1 | a2;
                    else if (op == ">")
                        a3 = a1 % a2;
                    else if (op == "$")
                        a3 = a1 / a2;
                    output.Push(a3);
                }
                if (output.Count == 0)
                    return null;
                else if (output.Count != 1 || operators.Count != 0)
                    throw new Exception();
                return output.Pop();
            }
            catch
            {
                throw new Exception("Check your formula! The parser can't recognize it as a correct formula.");
            }
        }

        public virtual Formula applyAssociativity()
        {
            return this;
        }

        public virtual Formula applyDemorgans()
        {
            return this;
        }

        public virtual Formula applyDistribution()
        {
            return this;
        }

        public virtual Formula simplify()
        {
            return this;
        }

        public abstract Conjunction toCNF();

        public abstract Tuple<Conjunction, Conjunction> toPlainAndSimplifiedCNF();

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();

        public static bool operator ==(Formula lhs, Formula rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            if (object.ReferenceEquals(rhs, null))
            {
                return object.ReferenceEquals(lhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator ==(Formula lhs, int rhs)
        {
            if (rhs == 1)
            {
                if (lhs.isLiteral())
                {
                    Literal lhsLiteral = lhs.toLiteral();
                    return (lhsLiteral.name == "1" && lhsLiteral.isNegative == false) || (lhsLiteral.name == "0" && lhsLiteral.isNegative == true);
                }
            }
            else if (rhs == 0)
            {
                if (lhs.isLiteral())
                {
                    Literal lhsLiteral = lhs.toLiteral();
                    return (lhsLiteral.name == "0" && lhsLiteral.isNegative == false) || (lhsLiteral.name == "1" && lhsLiteral.isNegative == true);
                }
            }
            return false;
        }

        public static bool operator !=(Formula lhs, int rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator !=(Formula lhs, Formula rhs)
        {
            return !(lhs == rhs);
        }

        public abstract bool isLiteral();

        public abstract Literal toLiteral();

        public virtual bool isDisjunction()
        {
            return true;
        }

        public virtual bool isConjunction()
        {
            return true;
        }

        public abstract Conjunction toConjunction();

        public abstract Disjunction toDisjunction();

        public abstract List<string> getVarNames();
    }

    public class Literal : Formula
    {
        public string name
        {
            get;
            protected set;
        }

        public Literal(string name, bool isNegative = false)
        {
            this.associativityApplied = true;
            this.demorgansApplied = true;
            this.name = name;
            this.isNegative = isNegative;
        }

        public static implicit operator Literal(string str)
        {
            return Literal.parse(str);
        }

        public override Formula negate()
        {
            return new Literal(this.name, !this.isNegative);
        }

        public override bool contains(string var)
        {
            return this.name == var;
        }

        public static Literal parse(string str)
        {
            bool isNegative = str.StartsWith("~") || str.StartsWith("!") || str.StartsWith(Formula.negationSymbol) || str.StartsWith("-");
            string name = isNegative ? str.Substring(1) : str;
            return new Literal(name, isNegative);
        }

        public override string ToString()
        {
            return (this.isNegative ? Formula.negationSymbol : "") + this.name;
        }

        public override string toImplicationString()
        {
            string first = "", second = "";
            if (this.isNegative)
            {
                first = (~this).ToString(false);
                second = "0";
            }
            else
            {
                first = "1";
                second = this.ToString(false);
            }
            return "(" + first + Disjunction.implicationSymbol + second + ")";
        }

        public override Conjunction toCNF()
        {
            return new Conjunction(this);
        }

        public override bool Equals(object obj)
        {
            if ((obj as Formula).isLiteral())
            {
                Literal rhs = (obj as Formula).toLiteral();
                return rhs.name == this.name && rhs.isNegative == this.isNegative;
            }
            return false;
        }

        public override bool isLiteral()
        {
            return true;
        }

        public override Literal toLiteral()
        {
            return this;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override List<string> getVarNames()
        {
            return new List<string>() { this.name };
        }

        public override Tuple<Conjunction, Conjunction> toPlainAndSimplifiedCNF()
        {
            return new Tuple<Conjunction, Conjunction>(new Conjunction(this), new Conjunction(this));
        }

        public override Conjunction toConjunction()
        {
            return new Conjunction(this);
        }

        public override Disjunction toDisjunction()
        {
            return new Disjunction(this);
        }
    }

    public class Disjunction : Formula
    {
        //public bool isImplication = false;
        public const string symbol = "∨";

        public const string implicationSymbol = "→";
        public List<Formula> formulas;

        public Disjunction(params Formula[] formulas)
        {
            this.associativityApplied = false;
            this.demorgansApplied = false;
            this.formulas = new List<Formula>();
            foreach (Formula f in formulas)
                this.addFormula(f);
        }

        public void addFormula(Formula f)
        {
            //if(f == 1 || this.formulas.Contains(f.negate()))
            //{
            //    this.formulas.Clear();
            //    this.formulas.Add(new Literal("1"));
            //    return;
            //}
            //if (this == 1 || this.formulas.Contains(f) || f == 0)
            //    return;
            if (!this.formulas.Contains(f))
                this.formulas.Add(f);
        }

        public override Formula negate()
        {
            return new Disjunction(this.formulas.ToArray()) { isNegative = !this.isNegative };
        }

        public override bool contains(string var)
        {
            return this.formulas.Any(f => f.contains(var));
        }

        public override string ToString()
        {
            string disjunctionString = String.Join(Disjunction.symbol, this.formulas.Select(x => x.ToString(!(x is Literal))));
            if (this.isNegative)
            {
                if (!(this.formulas.Count == 1 && this.formulas[0] is Literal))
                    disjunctionString = "(" + disjunctionString + ")";
                disjunctionString = Formula.negationSymbol + disjunctionString;
            }
            return disjunctionString;
        }

        public override string toImplicationString()
        {
            //string sign = (this.isNegative) ? Formula.negationSymbol : "";
            string first = String.Join(Conjunction.symbol, this.formulas.Where(f => f.isNegative).Select(x => x.negate().applyDemorgans().ToString())),
                second = String.Join(Conjunction.symbol, this.formulas.Where(f => !f.isNegative).Select(x => x.ToString()));
            //MessageBox.Show(first + ",  " + second);
            first = first == "" ? "1" : first;
            second = second == "" ? "0" : second;
            return "(" + first + Disjunction.implicationSymbol + second + ")";
        }

        public override Formula applyAssociativity()
        {
            if (this.associativityApplied)
                return this;
            Disjunction _r = new Disjunction(), temp;
            _r.isNegative = this.isNegative;
            foreach (Formula f in this.formulas)
            {
                if (f is Literal)
                    _r.addFormula(f);
                else if (f.isDisjunction())
                {
                    if (!f.isNegative)
                    {
                        //if (f is Disjunction)
                        //    temp = f as Disjunction;
                        //else
                        //    temp = (f as Conjunction).formulas[0] as Disjunction;
                        temp = f.toDisjunction();
                        temp = temp.applyAssociativity() as Disjunction;
                        foreach (Formula f1 in temp.formulas)
                            _r.addFormula(f1);
                    }
                    else
                        _r.addFormula(f);
                }
                else if (f is Conjunction)
                    _r.addFormula((f as Conjunction).applyAssociativity());
                else
                    _r.addFormula(f);
            }
            _r.associativityApplied = true;
            _r.demorgansApplied = this.demorgansApplied;
            return _r;
        }

        public override Formula applyDemorgans()
        {
            if (this.demorgansApplied || this.isLiteral())
                return this;
            if (!this.isNegative)
                return new Disjunction(this.formulas.Select(f => f.isLiteral() ? f : f.applyDemorgans()).ToArray()) { demorgansApplied = true };
            else
                return new Conjunction(this.formulas.Select(f => f.negate().applyDemorgans()).ToArray()) { demorgansApplied = true };
        }

        public override Formula applyDistribution()
        {
            Disjunction disj = new Disjunction(this.formulas.ToArray()).applyDemorgans().applyAssociativity() as Disjunction;
            if (disj.formulas.All(f => f.isLiteral()))
                return new Conjunction(disj);
            for (int i = 0; i < disj.formulas.Count; i++)
                if (disj.formulas[i] is Disjunction)
                    disj.formulas[i] = disj.formulas[i].applyDistribution();
            return disj.formulas.Aggregate(new Conjunction(), (res, f) =>
            {
                List<Formula> _r = new List<Formula>();
                if (f is Literal)
                {
                    if (res.formulas.Count == 0)
                        _r.Add(f);
                    else
                        _r = res.formulas.Select(f1 => (f1 | f) as Formula).ToList();
                }
                else if (f is Conjunction)
                {
                    if (res.formulas.Count == 0)
                        (f as Conjunction).formulas.ForEach(f1 => _r.Add(f1));
                    else
                    {
                        foreach (var f1 in res.formulas)
                        {
                            foreach (var f2 in (f as Conjunction).formulas)
                            {
                                Formula fn = (f1 | f2.applyDistribution());
                                //MessageBox.Show(disj + ": " + f + " | " + res + "\r\n" + fn.ToString());
                                _r.Add((f1 | f2.applyDistribution()));
                            }
                        }
                    }
                }
                //MessageBox.Show("cccc");
                //_r.ForEach(x => MessageBox.Show(x.ToString() + " -> " + x.applyDistribution()));
                return new Conjunction(_r.Select(ff => ff.applyDistribution()).ToArray());
            }).applyAssociativity();
        }

        public override Formula simplify()
        {
            Formula form = this.applyDemorgans().applyAssociativity();
            if (form is Conjunction)
                return form.simplify();
            Disjunction disj = form as Disjunction;
            List<Formula> _r = new List<Formula>();
            Formula temp;
            for (int i = 0; i < disj.formulas.Count; i++)
            {
                temp = disj.formulas[i].simplify();
                if (temp == 0 || _r.Contains(temp))
                    continue;
                else if (temp == 1 || _r.Contains(~temp))
                {
                    _r.Clear();
                    _r.Add(new Literal("1"));
                    break;
                }
                else
                    _r.Add(temp);
            }
            if (_r.Count == 0)
                _r.Add(new Literal("0"));
            return new Disjunction(_r.ToArray()) { associativityApplied = true, demorgansApplied = true };
            //Disjunction disj = new Disjunction(this.formulas.Select(f => f.simplify()).Distinct().ToArray());
            //disj.isNegative = this.isNegative;
            //if (disj.formulas.Any(f => disj.formulas.Contains(f.negate())) || disj.formulas.Contains(new Literal("1")) || disj.formulas.Contains(new Literal("0", true)))
            //{
            //    disj.formulas.Clear();
            //    disj.formulas.Add(new Literal("1"));
            //}
            //if(disj.formulas.Count > 1 && disj.formulas.Contains(new Literal("0")))
            //{
            //    disj.formulas.Remove(new Literal("0"));
            //}
            //return disj;
        }

        public override bool isConjunction()
        {
            return (this.formulas.Count == 1 && this.formulas[0].isConjunction());
        }

        public override Conjunction toCNF()
        {
            //Formula desired = this.applyDemorgans().applyAssociativity();
            //if (desired is Conjunction)
            //    return desired as Conjunction;
            //List<Formula> list = new List<Formula>();
            //foreach(Formula f in (desired as Disjunction).formulas)
            //    list.Add(f.toCNF());
            //Conjunction _r = new Conjunction();
            //while(list.Count > 1 && list.Any(f => f is Conjunction && (f as Conjunction).formulas.Count > 1))
            //{
            //}
            //return null;
            return (this.applyDemorgans().applyAssociativity().applyDistribution()) as Conjunction;
        }

        public override Tuple<Conjunction, Conjunction> toPlainAndSimplifiedCNF()
        {
            return new Tuple<Conjunction, Conjunction>((this.applyDemorgans().applyAssociativity().applyDistribution().simplify()) as Conjunction, (this.applyDemorgans().applyAssociativity().applyDistribution()) as Conjunction);
        }

        public override bool Equals(object obj)
        {
            if (obj is Disjunction)
            {
                Disjunction disj = obj as Disjunction;
                if (disj.formulas.Count != this.formulas.Count || disj.isNegative != this.isNegative)
                    return false;
                return this.formulas.All(f => disj.formulas.Contains(f));
            }
            return false;
        }

        public override bool isLiteral()
        {
            if (this.formulas.Count == 1)
                return this.formulas[0] is Literal || this.formulas[0].isLiteral();
            return false;
        }

        public override Literal toLiteral()
        {
            if (!this.isLiteral() || this.formulas.Count != 1)
                throw new Exception("Formula is not a literal.");
            return this.formulas[0] is Literal ? this.formulas[0] as Literal : this.formulas[0].toLiteral();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int curHash;
            int bitOffset = 0;
            // Stores number of occurences so far of each value.
            var valueCounts = new Dictionary<Formula, int>();
            List<Formula> list = new List<Formula>();
            if (this.isNegative)
                list.Add(new Literal("~"));
            list.Add(new Literal("|"));
            this.formulas.ForEach(f => list.Add(f));
            foreach (Formula element in list)
            {
                curHash = EqualityComparer<Formula>.Default.GetHashCode(element);
                if (valueCounts.TryGetValue(element, out bitOffset))
                    valueCounts[element] = bitOffset + 1;
                else
                    valueCounts.Add(element, bitOffset);

                // The current hash code is shifted (with wrapping) one bit
                // further left on each successive recurrence of a certain
                // value to widen the distribution.
                // 37 is an arbitrary low prime number that helps the
                // algorithm to smooth out the distribution.
                hash = unchecked(hash + ((curHash << bitOffset) |
                    (curHash >> (32 - bitOffset))) * 37);
            }
            return hash;
        }

        public override List<string> getVarNames()
        {
            return this.formulas.SelectMany(f => f.getVarNames()).Distinct().ToList();
        }

        public override Conjunction toConjunction()
        {
            if (this.isConjunction())
                return this.formulas[0].toConjunction();
            throw new Exception("The formula \"" + this.ToString() + "\" is not a explicit conjunction.");
        }

        public override Disjunction toDisjunction()
        {
            return this;
        }

        public Clause toClause()
        {
            return new Clause(this.formulas.Select(x => x as Literal).ToArray());
        }
    }

    public class Conjunction : Formula
    {
        public const string symbol = "∧";
        public const string equivalenceSymbol = "↔";
        public List<Formula> formulas;

        public Conjunction(params Formula[] formulas)
        {
            this.associativityApplied = false;
            this.demorgansApplied = false;
            this.formulas = new List<Formula>();
            foreach (Formula f in formulas)
            {
                this.addFormula(f);
            }
        }

        public void addFormula(Formula f)
        {
            //if (f == 0 || this.formulas.Contains(f.negate()))
            //{
            //    this.formulas.Clear();
            //    this.formulas.Add(new Literal("0"));
            //    return;
            //}
            //if (this == 0 || this.formulas.Contains(f) || f == 1)
            //    return;
            if (!this.formulas.Contains(f))
                this.formulas.Add(f);
        }

        public override Formula negate()
        {
            return new Conjunction(this.formulas.ToArray()) { isNegative = !this.isNegative };
        }

        public override bool contains(string var)
        {
            return this.formulas.Any(f => f.contains(var));
        }

        public override string ToString()
        {
            string conjunctionString = String.Join(Conjunction.symbol, this.formulas.Select(x => x.ToString(!(x is Literal))));
            if (this.isNegative)
            {
                if (!(this.formulas.Count == 1 && this.formulas[0] is Literal))
                    conjunctionString = "(" + conjunctionString + ")";
                conjunctionString = Formula.negationSymbol + conjunctionString;
            }
            return conjunctionString;
        }

        public override string toImplicationString()
        {
            if (!this.isHorn())
                throw new Exception("The formula isn't in a horn formula style. If you believe it's a horn one, make sure to convert it to CNF.");
            return String.Join(Conjunction.symbol, this.formulas.Select(f => f.toImplicationString()).ToArray());
        }

        public override Formula applyAssociativity()
        {
            if (this.associativityApplied)
                return this;
            Conjunction _r = new Conjunction(), temp;
            _r.isNegative = this.isNegative;
            foreach (Formula f in this.formulas)
            {
                if (f is Literal)
                    _r.addFormula(f);
                else if (f.isConjunction())
                {
                    if (!f.isNegative)
                    {
                        //if (f is Conjunction)
                        //    temp = f as Conjunction;
                        //else
                        //    temp = (f as Disjunction).formulas[0] as Conjunction;
                        temp = f.toConjunction();
                        temp = temp.applyAssociativity() as Conjunction;
                        foreach (Formula f1 in temp.formulas)
                            _r.addFormula(f1);
                    }
                    else
                        _r.addFormula(f);
                }
                else if (f is Disjunction)
                    _r.addFormula((f as Disjunction).applyAssociativity());
                else
                    _r.addFormula(f);
            }
            _r.associativityApplied = true;
            _r.demorgansApplied = this.demorgansApplied;
            return _r;
        }

        public override Formula applyDemorgans()
        {
            if (this.demorgansApplied)
                return this;
            if (!this.isNegative)
                return new Conjunction(this.formulas.Select(f => f.isLiteral() ? f : f.applyDemorgans()).ToArray()) { demorgansApplied = true };
            else
                return new Disjunction(this.formulas.Select(f => f.negate().applyDemorgans()).ToArray()) { demorgansApplied = true };
        }

        public override Formula simplify()
        {
            //Conjunction conj0 = new Conjunction(this.formulas.Select(f => f.simplify()).Distinct().ToArray());
            //conj0.isNegative = this.isNegative;
            Formula form = this.applyDemorgans().applyAssociativity();
            if (form is Disjunction)
                return form.simplify();
            Conjunction conj = form as Conjunction;
            List<Formula> _r = new List<Formula>();
            Formula temp;
            for (int i = 0; i < conj.formulas.Count; i++)
            {
                temp = conj.formulas[i].simplify();
                if (temp == 1 || _r.Contains(temp))
                    continue;
                else if (temp == 0 || _r.Contains(~temp))
                {
                    _r.Clear();
                    _r.Add(new Literal("0"));
                    break;
                }
                else
                    _r.Add(temp);
            }
            if (_r.Count == 0)
                _r.Add(new Literal("1"));
            return new Conjunction(_r.ToArray()) { associativityApplied = true, demorgansApplied = true };
            //if (conj.formulas.Any(f => conj.formulas.Contains(f.negate())) || conj.formulas.Contains(new Literal("0")) || conj.formulas.Contains(new Literal("1", true)))
            //{
            //    conj.formulas.Clear();
            //    conj.formulas.Add(new Literal("0"));
            //}
            //if (conj.formulas.Count > 1 && conj.formulas.Contains(new Literal("1")))
            //{
            //    conj.formulas.Remove(new Literal("1"));
            //}
            //return conj;
        }

        public override bool isDisjunction()
        {
            return (this.formulas.Count == 1 && this.formulas[0].isDisjunction());
        }

        public override Conjunction toCNF()
        {
            Formula formula = this.applyDemorgans().applyAssociativity();
            if (formula is Disjunction)
                return formula.toCNF();
            Conjunction conj = formula as Conjunction;
            return (new Conjunction(conj.formulas.Select(f => f.toCNF()).ToArray()).applyAssociativity()) as Conjunction;
        }

        public override Tuple<Conjunction, Conjunction> toPlainAndSimplifiedCNF()
        {
            Formula formula = this.applyDemorgans().applyAssociativity();
            if (formula is Disjunction)
                return formula.toPlainAndSimplifiedCNF();
            Conjunction conj = formula as Conjunction;
            return new Tuple<Conjunction, Conjunction>((new Conjunction(conj.formulas.Select(f => f.toCNF()).ToArray()).applyAssociativity().simplify()) as Conjunction, (new Conjunction(conj.formulas.Select(f => f.toPlainAndSimplifiedCNF().Item2).ToArray()).applyAssociativity()) as Conjunction);
        }

        public override bool isLiteral()
        {
            if (this.formulas.Count == 1)
                return this.formulas[0] is Literal || this.formulas[0].isLiteral();
            return false;
        }

        public override Literal toLiteral()
        {
            if (!this.isLiteral() || this.formulas.Count != 1)
                throw new Exception("Formula is not a literal.");
            return this.formulas[0] is Literal ? this.formulas[0] as Literal : this.formulas[0].toLiteral();
        }

        public override bool Equals(object obj)
        {
            if (obj is Conjunction)
            {
                Conjunction conj = obj as Conjunction;
                if (conj.formulas.Count != this.formulas.Count || this.isNegative != conj.isNegative)
                    return false;
                return this.formulas.All(f => conj.formulas.Contains(f));
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int curHash;
            int bitOffset = 0;
            // Stores number of occurences so far of each value.
            var valueCounts = new Dictionary<Formula, int>();
            List<Formula> list = new List<Formula>();
            if (this.isNegative)
                list.Add(new Literal("~"));
            list.Add(new Literal("&"));
            this.formulas.ForEach(f => list.Add(f));
            foreach (Formula element in list)
            {
                curHash = EqualityComparer<Formula>.Default.GetHashCode(element);
                if (valueCounts.TryGetValue(element, out bitOffset))
                    valueCounts[element] = bitOffset + 1;
                else
                    valueCounts.Add(element, bitOffset);

                // The current hash code is shifted (with wrapping) one bit
                // further left on each successive recurrence of a certain
                // value to widen the distribution.
                // 37 is an arbitrary low prime number that helps the
                // algorithm to smooth out the distribution.
                hash = unchecked(hash + ((curHash << bitOffset) |
                    (curHash >> (32 - bitOffset))) * 37);
            }
            return hash;
        }

        public bool isCNF()
        {
            return this.formulas.All(f => f is Literal || ((f is Disjunction) && (f as Disjunction).formulas.All(ff => ff is Literal)));
        }

        public bool isHorn()
        {
            if (!this.isCNF())
                return false;
            return this.formulas.All(f => f is Literal || ((f is Disjunction) && (f as Disjunction).formulas.Count(ff => !ff.isNegative) <= 1));
        }

        public bool performHornSatisficationAlgorithm(Action<string, System.Drawing.Color> log)
        {
            try
            {
                log("[HORN] Checking satisfiability of the formula (" + this.toImplicationString() + "):\r\n", System.Drawing.Color.Black);
                if (!this.isHorn())
                {
                    log("The formula isn't in a horn formula style. If you believe it's a horn one, make sure to convert it to CNF.", System.Drawing.Color.Red);
                    return false;
                }
                Dictionary<string, bool> marked = this.getVarNames().ToDictionary(x => x, x => false);
                //List<Tuple<Formula, bool>> formulasIsUsed = new List<Tuple<Formula, bool>>();
                //this.formulas.ForEach(f => formulasIsUsed.Add(new Tuple<Formula, bool>(f, false)));
                var formulasIsUsed = this.formulas.Select(f => new { formula = f, isUsed = false }).ToList();
                Formula temp;
                Literal l;
                for (int i = 0; i < formulasIsUsed.Count; i++)
                {
                    temp = formulasIsUsed[i].formula;
                    if (temp.isLiteral())
                    {
                        l = temp.toLiteral();
                        if (l == 0)
                        {
                            log("Subformula \"" + temp.toImplicationString() + "\" is a paradox since it is true iff 0 is true :D", System.Drawing.Color.Red);
                            log("The formula is unsatisfiable!", System.Drawing.Color.Gray);
                            return false;
                        }
                        if (!l.isNegative)
                        {
                            log("Subformula \"" + temp.toImplicationString() + "\" forces the literal \"" + l.ToString() + "\" to be true. (marked)", System.Drawing.Color.Black);
                            marked[l.name] = true;
                            formulasIsUsed[i] = new { formula = temp, isUsed = true };
                        }
                    }
                }
                bool changed;
                if (marked.Any(x => x.Value))
                {
                    Disjunction disj;
                    do
                    {
                        changed = false;
                        for (int i = 0; i < formulasIsUsed.Count; i++)
                        {
                            if (formulasIsUsed[i].isUsed)
                                continue;
                            Formula fTemp = formulasIsUsed[i].formula;
                            disj = (formulasIsUsed[i].formula.toDisjunction());
                            if (disj.formulas.Where(f => f.isNegative).All(f =>
                            {
                                return marked[f.toLiteral().name];
                            }))
                            {
                                if (disj.formulas.Any(f => !f.isNegative))
                                {
                                    Literal other = disj.formulas.Where(f => !f.isNegative).First().toLiteral();
                                    if (other == 0)
                                    {
                                        log("Subformula \"" + disj.toImplicationString() + "\" is a paradox since it is true iff 0 is true :D", System.Drawing.Color.Red);
                                        log("The formula is unsatisfiable!", System.Drawing.Color.Gray);
                                        return false;
                                    }
                                    log("We have the implication \"" + disj.toImplicationString() + "\" and all of the left-hand side literals are marked as true hence \"" + other.name + "\" also might be true. (marked)", System.Drawing.Color.Purple);
                                    marked[other.name] = true;
                                    changed = true;
                                    formulasIsUsed[i] = new { formula = fTemp, isUsed = true };
                                }
                                else
                                {
                                    log("We have the implication \"" + disj.toImplicationString() + "\" and all of the left-hand side literals are marked as true hence this implication is unsatisfiable!", System.Drawing.Color.Red);
                                    log("The formula is unsatisfiable!", System.Drawing.Color.Gray);
                                    return false;
                                }
                            }
                        }
                    } while (changed);
                }
                log("The formula is satisfiable!", System.Drawing.Color.DarkGreen);
                return true;
            }
            finally
            {
                log("-------------------------------------------------\r\n", System.Drawing.Color.Black);
            }
        }

        public override List<string> getVarNames()
        {
            return this.formulas.SelectMany(f => f.getVarNames()).Distinct().ToList();
        }

        public override Disjunction toDisjunction()
        {
            if (this.isConjunction())
                return this.formulas[0].toDisjunction();
            throw new Exception("The formula \"" + this.ToString() + "\" is not a explicit disjunction.");
        }

        public override Conjunction toConjunction()
        {
            return this;
        }

        public CNFSet toCNFSet()
        {
            return new CNFSet(this.formulas.Select(x => (x.toDisjunction()).toClause()).ToArray());
        }
    }
}