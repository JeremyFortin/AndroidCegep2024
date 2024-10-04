using AndroidCegep2024.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace AndroidCegep2024.DTOs
{
    /// <summary>
    /// Classe de DTO pour un enseignant.
    /// </summary>
    public class EnseignantDTO
    {
        #region Proprietes

        /// <summary>
        /// No de l'enseignant.
        /// </summary>
        public int NoEmploye { get; private set; }
        /// <summary>
        /// Nom de l'enseignant.
        /// </summary>
        public string Nom { get; private set; }
        /// <summary>
        /// Prénom de l'enseignant.
        /// </summary>
        public string Prenom { get; private set; }
        /// <summary>
        /// Adresse de l'enseignant.
        /// </summary>
        public string Adresse { get; private set; }
        /// <summary>
        /// Ville de l'enseignant.
        /// </summary>
        public string Ville { get; private set; }
        /// <summary>
        /// Province de l'enseignant.
        /// </summary>
        public string Province { get; private set; }
        /// <summary>
        /// Code postal de l'enseignant.
        /// </summary>
        public string CodePostal { get; private set; }
        /// <summary>
        /// Telephone de l'enseignant.
        /// </summary>
        public string Telephone { get; private set; }
        /// <summary>
        /// Courriel de l'enseignant.
        /// </summary>
        public string Courriel { get; private set; }
        /// <summary>
        /// Date d'embauche de l'enseignant.
        /// </summary>
        public string DateEmbauche { get; private set; }
        /// <summary>
        /// Date d'arrêt de l'enseignant.
        /// </summary>
        public string DateArret { get; private set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="no">No d'employé de l'enseignant.</param>
        /// <param name="nom">Nom de l'enseignant.</param>
        /// <param name="prenom">Prénom de l'enseignant.</param>
        /// <param name="adresse">Adresse de l'enseignant.</param>
        /// <param name="ville">Ville de l'enseignant.</param>
        /// <param name="province">Province de l'enseignant.</param>
        /// <param name="codePostal">Code Postal de l'enseignant.</param>
        /// <param name="telephone">Telephone de l'enseignant.</param>
        /// <param name="courriel">Courriel de l'enseignant.</param>
        /// <param name="dateEmbauche">Date d'embauche de l'enseignant.</param>
        /// <param name="dateArret">Date d'arrêt de l'enseignant.</param>
        public EnseignantDTO(int no=0000000, string nom="", string prenom="", string adresse="", string ville="", string province="", string codePostal="", string telephone="", string courriel="")
        {
            NoEmploye = no;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            CodePostal = codePostal;
            Telephone = telephone;
            Courriel = courriel;
        }

        /// <summary>
        /// Constructeur avec modèle.
        /// </summary>
        /// <param name="lenseignant">Modèle de l'enseignant.</param>
        public EnseignantDTO(Enseignant lenseignant)
        {
            NoEmploye = lenseignant.NoEmploye;
            Nom = lenseignant.Nom;
            Prenom = lenseignant.Prenom;
            Adresse = lenseignant.Adresse;
            Ville = lenseignant.Ville;
            Province = lenseignant.Province;
            CodePostal = lenseignant.CodePostal;
            Telephone = lenseignant.Telephone;
            Courriel = lenseignant.Courriel;
        }

        #endregion Constructeurs
    }
}
