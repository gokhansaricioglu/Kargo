using Kargo.Classes;
using Kargo.Classes.CrudFacade;
using Kargo.Classes.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kargo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Gonderen entity = new Gonderen(textBox1.Text);
             DbFactory.GonderenKargoCrud.Insert(entity);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KargoContext db = new KargoContext();
            var kisi = db.Gonderenler.FirstOrDefault(x => x.Id == textBox2.Text);
            if (kisi != null)
            {
                try
                {
                    db.Gonderenler.Remove(kisi);
                    db.SaveChanges();
                    MessageBox.Show("Silindi");
                }
                catch (Exception)
                {
                    MessageBox.Show("Silienemedi");
                }

            }
            else
            {
                MessageBox.Show("Id Hatalı");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var oldEntity = DbFactory.GonderenKargoCrud.Find(textBox3.Text);
            var newEntity = new Gonderen(textBox4.Text);
            newEntity.Id = oldEntity.Id;
            DbFactory.GonderenKargoCrud.Update(oldEntity, newEntity);
        }
    }
}
