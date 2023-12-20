using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygraph
{
    public class CNFSet
    {
        private HashSet<Clause> clauses = new HashSet<Clause>();

        public CNFSet(params Clause[] clauses)
        {
            foreach (Clause c in clauses)
                this.clauses.Add(c);
        }

        //public CNFSet(string str)
        //{
        //    str.Replace("(", "").Replace(")", "").Split(new string[] { "^", "." }, StringSplitOptions.None).ToList().ForEach(x => this.clauses.Add(new Clause(x)));
        //}
        public void addClause(Clause c)
        {
            this.clauses.Add(c);
        }

        //public CNFSet resolvent(ref bool changed)
        //{
        //    List<Clause> list = this.clauses.ToList();

        //}
        public bool performSAT(Action<string, Color> log)
        {
            try
            {
                log("[Resolution] Checking satisfiability of the formula " + this.ToString() + ":\r\n", Color.Black);
                bool changed = false;
                List<Clause> list = this.clauses.ToList(), temp = new List<Clause>();
                Clause emptySet = null;
                if (list.Any(c => c == 0))
                {
                    emptySet = list.First(c => c == 0);
                    goto END;
                }
                do
                {
                    changed = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = i + 1; j < list.Count; j++)
                        {
                            var res = list[i].Resolvent(list[j]);
                            if (res.Count == 0)
                                continue;
                            foreach (var c in res)
                            {
                                if (c == 0)
                                {
                                    emptySet = c;
                                    goto END;
                                }
                                if (!list.Contains(c))
                                {
                                    temp.Add(c);
                                    changed = true;
                                }
                            }
                        }
                    }
                    foreach (Clause c in temp.Where(x => !list.Contains(x)))
                    {
                        list.Add(c);
                    }
                    temp.Clear();
                } while (changed);
            END:
                if (emptySet == null)
                {
                    log("The formula is satisfiable.", Color.DarkGreen);
                    return true;
                }
                else
                {
                    log("The formula is unsatisfiable, since the empty clause can be derived by the following sequence (i.e. " + Clause.emptyClauseSymbol + " is in Res*(F)):", Color.Red);
                    List<Info> res = this.getList(emptySet);
                    res.Reverse();
                    for (int i = 0; i < res.Count; i++)
                    {
                        int nt1 = Math.Max(res[i].nt1, res[i].nt2), nt2 = Math.Min(res[i].nt1, res[i].nt2);
                        string parents = res[i].nt1 == -1 ? "   (clause in F)" : String.Format("   (resolvent of C_{0}_, C_{1}_)", i + 1 - nt1, i + 1 - nt2);
                        log("-----" + "C_" + (i + 1) + "_ = " + res[i].value, Color.Purple);
                        log(">>>>>" + parents, Color.Gray);
                    }
                    return false;
                }
            }
            finally
            {
                log("-------------------------------------------------\r\n", Color.Black);
            }
        }

        public class Info
        {
            public string value;
            public int nt1 = -1;
            public int nt2 = -1;

            public Info(string value, int nt1 = -1, int nt2 = -1)
            {
                this.value = value;
                this.nt1 = nt1;
                this.nt2 = nt2;
            }
        }

        public List<Info> getList(Clause c, Clause p = null)
        {
            List<Info> _r = new List<Info>();
            List<Info> t1 = null, t2 = null;
            int nt1 = -1, nt2 = -1;
            if (c.parents != null)
            {
                Clause first = c.parents.Item1;
                Clause second = c.parents.Item2;
                if (first.parents == null)
                {
                    t1 = getList(first);
                    t2 = getList(second);
                }
                else
                {
                    t1 = getList(second);
                    t2 = getList(first);
                }
                nt1 = 1;
                nt2 = t1.Count + 1;
            }
            _r.Add(new Info(c.ToString(), nt1, nt2));
            if (t1 != null)
            {
                t1.ForEach(x => _r.Add(x));
                t2.ForEach(x => _r.Add(x));
            }
            //_r.Reverse();
            return _r;
        }

        public override string ToString()
        {
            return "{" + String.Join(", ", this.clauses.Select(x => x.ToString())) + "}";
        }
    }
}