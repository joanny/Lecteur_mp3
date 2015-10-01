using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Windows.Controls;

namespace Lecteur_mp3
{
    public class ControleLecture
    {
        public Audio Lecteur;
        public void _lire()
        {
            if (Lecteur != null)
            {
                Lecteur.Play();
            }
        }

        public string _ouvrir(typeFichier tf)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (tf == typeFichier.musique)
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                ofd.Filter = "mp3 files (*.mp3)|*.mp3";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.OpenFile() != null)
                    {
                        try
                        {
                            Lecteur = new Audio(ofd.FileName, false);
                           
                        }
                        catch (Exception esx)
                        {
                            MessageBox.Show("Fichier non reconnu." + esx.HResult);
                            return null;
                        }

                        return ofd.FileName;

                    }
                }
                return null;
            }
            else if (tf == typeFichier.image)
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                ofd.Filter = "JPG (*.jpg)|*.jpg";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (ofd.OpenFile() != null)// On attribue le chemin du fichier à lire au 
                        {

                            return ofd.FileName;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                        return null;
                    }
                }
                return null;

            }
            return null;
        }
        public void _arreter()
        {
            if (Lecteur != null)
                Lecteur.Stop();
        }
        public void _interrompre()
        {
            if (Lecteur != null)
                Lecteur.Pause();
        }


    }
}
