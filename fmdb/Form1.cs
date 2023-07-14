using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace fmdb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\alnaseem\documents\visual studio 2012\Projects\fmdb\fmdb\Database1.mdf;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("هذا البرنامج يقدم اختبار اولي للكشف عن المصابين بفيروس كورونا");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (r12.Checked) result += 5;
            else if (r13.Checked) result += 12;
            else if (r14.Checked) result += 20;

            if (r22.Checked) result += 5;
            else if (r23.Checked) result += 12;
            else if (r24.Checked) result += 20;


            if (r32.Checked) result += 5;
            else if (r33.Checked) result += 12;
            else if (r34.Checked) result += 20;


            if (r42.Checked) result += 5;
            else if (r43.Checked) result += 12;
            else if (r44.Checked) result += 20;


            if (r52.Checked) result += 5;
            else if (r53.Checked) result += 12;
            else if (r54.Checked) result += 20;

            sc.Open();
            int has = result >= 50 ? 1 : 0;
            SqlCommand cmd = new SqlCommand("insert into dt values('" + name.Text + "'," + age.Text + "," + has + "," +result+ ")",sc);
            cmd.ExecuteNonQuery();
            sc.Close();
            name.Clear();
            age.Clear();

            r11.Checked = false;
            r12.Checked = false;
            r13.Checked = false;
            r14.Checked = false;

            r21.Checked = false;
            r22.Checked = false;
            r23.Checked = false;
            r24.Checked = false;

            r31.Checked = false;
            r32.Checked = false;
            r33.Checked = false;
            r34.Checked = false;

            r41.Checked = false;
            r42.Checked = false;
            r43.Checked = false;
            r44.Checked = false;

            r51.Checked = false;
            r52.Checked = false;
            r53.Checked = false;
            r54.Checked = false;
      }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sc.Open();
                SqlCommand cmd = new SqlCommand("select has from dt where name = '" + nameForSearch.Text + "'", sc);
                int num = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                MessageBox.Show(num == 0 ? "سليم" : "مصاب");
                sc.Close();
                nameForSearch.Clear();

            }
            catch {
                MessageBox.Show("لم يتم العثور على الاسم");
            }
          
        }

    }
}
