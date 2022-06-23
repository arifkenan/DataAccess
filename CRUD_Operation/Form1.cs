using CRUD_Operation.Context;
using CRUD_Operation.Model.Concrete;

namespace CRUD_Operation
{
    public partial class Form1 : Form
    {
        AppDbContext db = new AppDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AppDbContext sinifindan bir instance alinir
            //AppDbContext db = new AppDbContext()
            {
                //Category nesnesinden bir instance alinir
                //ve property'leri doldurulur
                Category category = new Category();
                category.Name = txtName.Text;
                category.Description = txtDescription.Text;

                //Appdbcontext sinifimizin categorilerine ekleme yapiyoruz
                db.Categories.Add(category);
                //eklenen yeni entity'yi database'e yansitiyoruz
                db.SaveChanges();

                dataGridView1.DataSource = db.Categories
                    .Where(p => p.Status!=Model.Abstract.Status.Passive)
                    .Select(x=> new
                {x.Id, x.Name, x.Description, x.CreateDate}).ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Categories
                .Where(p => p.Status != Model.Abstract.Status.Passive)
                .Select(x => new
            { x.Id, x.Name, x.Description, x.CreateDate }).ToList();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                label3.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           var category= db.Categories.FirstOrDefault(p => p.Id == int.Parse(label3.Text));
            category.Name = txtName.Text;
            category.Description = txtDescription.Text;
            category.UpdateDate = DateTime.Now;
            category.Status = Model.Abstract.Status.Modify;
            db.Categories.Update(category);
            db.SaveChanges();


            dataGridView1.DataSource = db.Categories
                .Where(p => p.Status != Model.Abstract.Status.Passive)
                .Select(x => new
            { x.Id, x.Name, x.Description, x.CreateDate }).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var category = db.Categories.FirstOrDefault(p => p.Id == int.Parse(label3.Text));
            category.DeleteDate = DateTime.Now;
            category.Status = Model.Abstract.Status.Passive;
            db.Categories.Update(category);
            db.SaveChanges();


            dataGridView1.DataSource = db.Categories
                .Where(p => p.Status != Model.Abstract.Status.Passive)
                .Select(x => new
            { x.Id, x.Name, x.Description, x.CreateDate }).ToList();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}