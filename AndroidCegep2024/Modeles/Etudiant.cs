
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace AndroidCegep2024.Modeles
{
    /// <summary>
    /// 
    /// </summary>
    public class Etudiant : Personne
    {
        /// <summary>
        /// 
        /// </summary>
        private int noDA;
        /// <summary>
        /// 
        /// </summary>
        public int NoDA
        {
            get { return noDA; }
            set { noDA = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime dateInscription;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateInscription
        {
            get { return dateInscription; }
            set { dateInscription = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool actif;
        /// <summary>
        /// 
        /// </summary>
        public bool Actif
        {
            get { return actif; }
            set { actif = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Etudiant(){}

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNoDA">le no d'étudiant</param>
        /// <param name="unPrenom">le prénom de l'étudiant</param>
        /// <param name="unNom">le nom de l'étudiant</param>
        /// <param name="uneAdresse">l'adresse de l'étudiant</param>
        /// <param name="uneVille">la ville de l'étudiant</param>
        /// <param name="uneProvince">la province de l'étudiant</param>
        /// <param name="unCodePostal">le code postal de l'étudiant</param>
        /// <param name="unTelephone">le téléphone de l'étudiant</param>
        /// <param name="unCourriel">le courriel de l'étudiant</param>
        /// <param name="uneDateInscription">la date d'inscription de l'étudiant</param>
        /// <param name="unEtat">L'état de l'étudiant s'il est actif au cégep ou non</param>
        public Etudiant(int unNoDA=0000000, string unPrenom="", string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="", DateTime? uneDateInscription=null, bool unEtat=true)
        {
            NoDA = unNoDA;
            Prenom = unPrenom;
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
            DateInscription = DateTime.Parse(uneDateInscription.ToString());
            Actif = unEtat;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString pour l'affichage d'un étudiant
        /// </summary>
        /// <returns>la chaine de caractère qui sera affiché</returns>
        public override string ToString()
        {
            return Prenom + " " + Nom +  "    " + NoDA;
        }

        /// <summary>
        /// Redéfinition de la méthode Equals qui se fait à partir du NoDA
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Etudiant) && NoDA.Equals((obj as Etudiant).NoDA);
        }

        /// <summary>
        /// Redéfinition de la méthode GetHashCode à partir du numéro de demande d'admission (no étudiant)
        /// </summary>
        /// <returns>le no généré par la méthode GetHashCode à partir du noDA</returns>
        public override int GetHashCode()
        {
            return NoDA.GetHashCode();
        }
    }
}
