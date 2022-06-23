using BookDatabase.Context;
using BookDatabase.Model.Concrete;

namespace BookDatabase
{

    public partial class Form1 : Form
    {
        SqlDbContext db = new SqlDbContext();
        PostgreDbContext pdb = new PostgreDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Books
                
                .Select(x => new
                { x.Id, x.bookName, x.genre, x.writerName }).ToList();
        }

        private void bookNameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.bookName = bookNameTxt.Text;
            book.writerName = WriterTxt.Text;
            book.genre = GenreTxt.Text;

            
            db.Books.Add(book);
            db.SaveChanges();

            pdb.Books.Add(book);
            pdb.SaveChanges();
            dataGridView1.DataSource = db.Books
                
                .Select(x => new
                { x.Id, x.bookName, x.genre, x.writerName }).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                GenreTxt.Text = row.Cells[0].Value.ToString();
                bookNameTxt.Text = row.Cells[1].Value.ToString();
                WriterTxt.Text = row.Cells[2].Value.ToString();


            }
        }

        private void GenreTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void WriterTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}