using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lecteur_mp3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class DialogueIHMLecteur : Window
    {
        private ControleLecture controleur_de_lecture = null;
        private ControleEditeurTags controleur_de_edition = null;
        public DialogueIHMLecteur()
        {
            InitializeComponent();
            this.controleur_de_lecture = new ControleLecture();
        }

       
        public void btnLecture_click(object sender, EventArgs e)
        {
            this.controleur_de_lecture._lire();
        }

        public void btnPause_click(object sender, EventArgs e)
        {
            this.controleur_de_lecture._interrompre();
        }

        public void btnArret_Click(object sender, EventArgs e)
        {
            this.controleur_de_lecture._arreter();
        }
        
        public void btnParcourir_Click(object sender, EventArgs e)
        {
            try
            {
                var file_name = this.controleur_de_lecture._ouvrir(typeFichier.musique);
                int size = file_name.Split('\\').Length;
                lTitre.Content = file_name.Split('\\')[size - 1];
            }
            catch (Exception ex)
            {

            }
        }

        public void btnImg_Click(object sender, EventArgs e)
        { 

            try
            {
                BitmapImage l = new BitmapImage();
                l.BeginInit();
                l.UriSource = new Uri(this.controleur_de_lecture._ouvrir(typeFichier.image));
                l.EndInit();

                imgAlbum.Source = l;


            }
            catch (Exception ex)
            {

            }
        }
        public void btnOk_Click(object sender, EventArgs e)
        {
            try{
                controleur_de_edition.EditerTag(stckPEditeur, this.controleur_de_lecture._ouvrir(typeFichier.musique));
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
