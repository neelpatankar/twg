using System;
namespace TWG.CellModel
{
    public class CellDeginsModel
    {
        private string _name;
        private string _var;
        private string _b;
        private string _dt;
        private string _gt;
        private string _nt;
        private string _bx;
        private string _mog;

        public string Name { get => _name; set => _name = value; }
        public string Var { get => "Var #:" + _var; set => _var = value; }
        public string B { get => "B #:" + _b; set => _b = value; }
        public string DT { get => "DT #:" + _dt; set => _dt = value; }
        public string GT { get => "GT :" + _gt; set => _gt = value; }
        public string NT { get => "NT :" + _nt; set => _nt = value; }
        public string BX { get => "BX :" + _bx; set => _bx = value; }
        public string MOG { get => "MOG :" + _mog + "%"; set => _mog = value; }
    }
}
