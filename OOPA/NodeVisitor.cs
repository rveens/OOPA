﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class NodeVisitor
    {
        //public virtual void visit(Node node) { }

        public virtual void visit(LogicNode node) { }
        public virtual void visit(Input node) { }

        public virtual void visit(Probe node) { }
    }
}
