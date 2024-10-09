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
            start();            
        }
        void start()
        {
            db = new dbhandler();
            readInfo();


            addButton.Click += addButtonClick;
            deleteButton.Click += deleteButtonClick;
            alldeleteButton.Click += deleteAllButtonClick;
        }
        void addButtonClick(object s, EventArgs e)
        {
            kifli oneNewkifli = new kifli();
            oneNewkifli.nameKifli = guna2TextBox1.Text;
            oneNewkifli.quantity = Convert.ToInt32(guna2TextBox3.Text);
            db.addOne(oneNewkifli);
            readInfo();
        }

        void deleteButtonClick(object s , EventArgs e)
        {
            int temp = listBox1.SelectedIndex;   
            if (temp < 0)
            {
                return;
            }
            db.deleteOnekifli(kifli.kiflik[temp]);
            kifli.kiflik.RemoveAt(temp);
            readInfo();
        }

        void deleteAllButtonClick(object s,EventArgs e)
        {
            db.deleteAll();
            readInfo();
        }

        void readInfo()
        {
            db.readAll();
            listBox1.Items.Clear();
            foreach (kifli item in kifli.kiflik)
            {
                listBox1.Items.Add($"Kiflik : {item.nameKifli}, Mennyiség : {item.quantity}");
            }
        }

    }
}
