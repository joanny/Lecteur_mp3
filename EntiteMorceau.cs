using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecteur_mp3
{
    class EntiteMorceau
    {
        private strTagMP3 TagsMP3;
        
        public strTagMP3 accTagMP3
        {
            get
            {
                return this.TagsMP3;
            }
            set
            {
                this.TagsMP3.artiste = value.artiste;
                this.TagsMP3.titre = value.titre;
                this.TagsMP3.tagOK = value.tagOK;
                this.TagsMP3.genre = value.genre;
            }
        }

        #region Accesseurs // getteurs
        public string accArtiste
        {
            get
            {
                return this.TagsMP3.artiste;
            }
            set
            {
                this.TagsMP3.artiste = value;
            }
        }



        public string accTitre
        {
            get
            {
                return this.TagsMP3.titre;
            }
            set
            {
                this.TagsMP3.titre = value;
            }
        }

        public short accGenre
        {
            get
            {
                return this.TagsMP3.genre;
            }
            set
            {
                this.TagsMP3.genre = value;
            }
        }

        public string accTagOK
        {
            get
            {
                return this.TagsMP3.tagOK;
            }
            set
            {
                this.TagsMP3.tagOK = value;
            }
        }
        #endregion
    }
}
