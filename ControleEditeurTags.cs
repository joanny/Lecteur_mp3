using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Lecteur_mp3
{
    class ControleEditeurTags
    {
        private EntiteMorceau Morceau = null; 

        public bool PossedeTag(String fichier)
        {
            FileStream f = new FileStream(fichier, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            f.Seek(-128, SeekOrigin.End);
            
            BinaryReader br = new BinaryReader(f);

            byte[] tagArray = br.ReadBytes(3);

            string tag = System.Text.Encoding.Default.GetString(tagArray);

            br.Close();

            return (tag.CompareTo("TAG").Equals(0));

        }

        public EntiteMorceau OuvrirFichier(String fichier)
        {
            if (fichier != null)
            {
                Morceau = new EntiteMorceau();
                Morceau.accTagOK = "TAG";
                Morceau.accTitre = "";
                Morceau.accArtiste = "";
                Morceau.accGenre = -1;

                FileStream f = new FileStream(fichier, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                f.Seek(-128, SeekOrigin.End);

                BinaryReader br = new BinaryReader(f);

                char charsToTrim = '/';

                Morceau.accTagOK = System.Text.Encoding.Default.GetString(br.ReadBytes(3));
                Morceau.accTitre = System.Text.Encoding.Default.GetString(br.ReadBytes(30));
                Morceau.accTitre = Morceau.accTitre.TrimEnd(charsToTrim);
                Morceau.accArtiste = System.Text.Encoding.Default.GetString(br.ReadBytes(30));
                Morceau.accArtiste = Morceau.accArtiste.TrimEnd(charsToTrim);
                Morceau.accGenre = (short)br.PeekChar();
			    int[] genre_tab =  {8,9,13,15,18,32};

                var g = from un_genre in genre_tab
                        where un_genre.Equals(Morceau.accGenre)
                        select un_genre;

                if (g == null)
                {
                    Morceau.accGenre = 0;
                }

                br.Close();

                return Morceau;
            }
            else
            {
                return null;
            }
        }
        public void EcrireTag(String fichier)
        {
            FileStream f = new FileStream(fichier, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

            if (PossedeTag(fichier))
                f.Seek(-128, SeekOrigin.End);
            else
                f.Seek(0, SeekOrigin.End);

            BinaryWriter bw = new BinaryWriter(f);
            bw.Write(System.Text.Encoding.Default.GetBytes(Morceau.accTagOK));

            bw.Write(System.Text.Encoding.Default.GetBytes(Morceau.accTitre));
            for (int i = 0; i < 30 - Morceau.accTitre.Length; i++) bw.Write((char)'/');

            bw.Write(System.Text.Encoding.Default.GetBytes(Morceau.accArtiste));
            for (int i = 0; i < 30 - Morceau.accTitre.Length; i++) bw.Write((char)'/');

            bw.Write((short) Morceau.accGenre);

            bw.Close();

        }


        public void EditerTag(StackPanel objStckPan, string fichierATagger)
        {
            if (Morceau != null)
            {
                Morceau.accTitre = ((TextBox)objStckPan.FindName("txtbTitre")).Text;
                Morceau.accArtiste = ((TextBox)objStckPan.FindName("txtbAuteur")).Text;
                Morceau.accGenre = short.Parse(((ComboBox)objStckPan.FindName("cbxType")).SelectedValue.ToString());

            }

            EcrireTag(fichierATagger);
        }
        

        
    }
}
