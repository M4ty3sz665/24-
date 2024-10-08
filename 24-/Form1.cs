using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_
{
    public partial class Form1 : Form
    {
        dbhandler db;
        public Form1()
        {
            InitializeComponent();
            db = new dbhandler();
            db.readAll();
            kifli onekifli = new kifli();
            onekifli.nameKifli = "fokhagymas";
            onekifli.quantity = 3;
            onekifli.id = 1;
            db.addOne(onekifli);
            db.deleteOnekifli(onekifli);
        }
    }
}
