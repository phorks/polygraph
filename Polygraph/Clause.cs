using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygraph
{
    public class Clause
    {
        public HashSet<Literal> literals
        {
            get;
            private set;
        }
        public Tuple<Clause, Clause> parents = null;
        public Clause(params Literal[] literals)
        {
            this.literals = new HashSet<Literal>();
            foreach (Literal l in literals)
                this.literals.Add(l);
        }
        //public Clause(string str)
        //{
        //    this.literals = new List<Literal>();
        //    //str.Split(new string[] { "+" }, StringSplitOptions.None).ToList().ForEach(x => this.literals.Add(Literal.Parse(x)));
        //}
        public void addLiteral(Literal l)
        {
            this.literals.Add(l);
        }
        public bool Resolutionable(Clause c)
        {
            return literals.Any(l1 => c.literals.Any(l2 => l1.name == l2.name && l1.isNegative != l2.isNegative));
        }
        public HashSet<Clause> Resolvent(Clause c)
        {
            HashSet<Clause> _r = new HashSet<Clause>();
            foreach (Literal l in this.literals.Where(l1 => c.literals.Contains(~l1)))
            {
                Clause temp = new Clause();
                //Literal literal = this.literals.First(l1 => c.literals.Any(l2 => l1.name == l2.name && l1.isNegative != l2.isNegative));
                temp.literals = new HashSet<Literal>(this.literals.Union(c.literals).Where(x => x.name != l.name));
                if (temp.literals.Any(x => temp.literals.Contains(~x)))
                    continue;
                temp.parents = new Tuple<Clause, Clause>(this, c);
                _r.Add(temp);
            }
            return _r;
        }
        public const string emptyClauseSymbol = "□";
        public override string ToString()
        {
            if (this.literals.Count == 0)
                return emptyClauseSymbol;
            return "{" + String.Join(", ", this.literals.Select(x => x.ToString()).ToArray()) + "}";
        }
        public static bool operator ==(Clause lhs, object rhs)
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
        public static bool operator !=(Clause lhs, object rhs)
        {
            return !(lhs == rhs);
        }
        public override bool Equals(object obj)
        {
            if(obj is Clause)
            {
                Clause c = obj as Clause;
                return c.literals.Count == this.literals.Count && c.literals.All(l => this.literals.Contains(l));
            }
            else if (obj is int)
            {
                int value = (int)obj;
                if (value == 0)
                {
                    return this.literals.Count == 0 || this.literals.All(l => l == 0);
                }
                return false;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            int curHash;
            int bitOffset = 0;
            // Stores number of occurences so far of each value.
            var valueCounts = new Dictionary<Literal, int>();
            List<Literal> list = this.literals.ToList();
            //this.literals.ToList.ForEach(f => list.Add(f));
            foreach (Literal element in list)
            {
                curHash = EqualityComparer<Literal>.Default.GetHashCode(element);
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
    }
}
