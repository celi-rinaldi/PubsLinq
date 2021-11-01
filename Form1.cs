using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsPubs.Data;

namespace WindowsPubs
{
    public partial class Form1 : Form
    {
        PubsContext context = new PubsContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTraerTodosAutores_Click(object sender, EventArgs e)
        {
            var lista = (from a in context.authors
                         select a).ToList();
            gridPubs.DataSource = lista; 

        }

        private void btnTraerTodosPublicadores_Click(object sender, EventArgs e)
        {
            var lista = (from p in context.publishers
                         select p).ToList();
            gridPubs.DataSource = lista;
        }

        private void btnTraerAutoresPorCiudad_Click(object sender, EventArgs e)
        {
            string ciudad = "Oakland";
            var lista = (from a in context.authors
                         where a.city == ciudad
                         select a).ToList();
            gridPubs.DataSource = lista; 

        }

        private void btnnTraerAutorPorId_Click(object sender, EventArgs e)
        {
            string id = "274-80-9391";
            var autor = (from a in context.authors
                         where a.au_id == id
                         select a).SingleOrDefault();
            MessageBox.Show(autor.au_fname + " " + autor.au_lname + " id: " + autor.au_id);
        }

        private void btnTraerPublicadorPorNombre_Click(object sender, EventArgs e)
        {
            string nombre = "Scootney Books";
            var publicador = (from p in context.publishers
                              where p.pub_name == nombre
                              select p).SingleOrDefault();
            MessageBox.Show("Nombre: " + publicador.pub_name + ", id: " + publicador.pub_id);
        }

        private void btnTraerListaSalesStores_Click(object sender, EventArgs e)
        {
            var lista = (from s in context.sales
                         join
                         st in context.stores
                         on s.stor_id equals st.stor_id
                         select new
                         {
                             s.stor_id,
                             Id= st.stor_id,
                             NombreTienda = st.stor_name, 
                             Ciudad = st.city, 
                             NroOrden = s.ord_num, 
                             Fecha = s.ord_date, 
                             Cantidad = s.qty, 
                             IdTitulo = s.title_id
                         }).ToList();
            gridPubs.DataSource = lista; 
        }

        private void btnTraerListaEmployeePublishers_Click(object sender, EventArgs e)
        {
            var lista = (from em in context.employees
                         join
                         p in context.publishers
                         on em.pub_id equals p.pub_id
                         select new
                         {
                             Id = p.pub_id,
                             Nombre = em.fname, 
                             Apellido = em.lname, 
                             NombrePublicador = p.pub_name
                         }).ToList();
            gridPubs.DataSource = lista;
        }

        private void btnTraerListaEPPorPais_Click(object sender, EventArgs e)
        {
            string pais = "USA";
            var lista = (from em in context.employees
                         join
                         p in context.publishers
                         on em.pub_id equals p.pub_id
                         where p.country == pais
                         select new
                         {
                             Id = p.pub_id,
                             Nombre = em.fname,
                             Apellido = em.lname,
                             NombrePublicador = p.pub_name,
                             Pais = p.country
                         }).ToList();
            gridPubs.DataSource = lista;
        }
    }
}
