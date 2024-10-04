using AndroidCegep2024.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace AndroidCegep2024.DTOs
{
    /// <summary>
    /// Classe de DTO pour le Cégep.
    /// </summary>
    public class CegepDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom du Cégep.
        /// </summary>
        public string Nom { get; private set; }
        /// <summary>
        /// Propriété représentant l'adresse du Cégep.
        /// </summary>
        public string Adresse { get; private set; }
        /// <summary>
        /// Propriété représentant la ville du Cégep.
        /// </summary>
        public string Ville { get; private set; }
        /// <summary>
        /// Propriété représentant la province du Cégep.
        /// </summary>
        public string Province { get; private set; }
        /// <summary>
        /// Propriété représentant le code postal du Cégep.
        /// </summary>
        public string CodePostal { get; private set; }
        /// <summary>
        /// Propriété représenant le téléphone du Cégep.
        /// </summary>
        public string Telephone { get; private set; }
        /// <summary>
        /// Propriété représentant le courriel du Cégep.
        /// </summary>
        public string Courriel { get; private set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="nom">Nom du Cégep.</param>
        /// <param name="adresse">Adresse du Cégep.</param>
        /// <param name="ville">Ville du Cégep.</param>
        /// <param name="province">Province du Cégep.</param>
        /// <param name="codePostal">Code postal du Cégep.</param>
        /// <param name="telephone">Téléphone du Cégep.</param>
        /// <param name="courriel">Courriel du Cégep.</param>
        public CegepDTO(string nom="", string adresse="", string ville="", string province="", string codePostal="", string telephone="", string courriel="")
        {
            Nom = nom;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            CodePostal = codePostal;
            Telephone = telephone;
            Courriel = courriel;
        }

        /// <summary>
        /// Constructeur avec le modèle Cegep en paramètre.
        /// </summary>
        /// <param name="leCegep">L'objet du modèle Cegep.</param>
        public CegepDTO(Cegep leCegep)
        {
            Nom = leCegep.Nom;
            Adresse = leCegep.Adresse;
            Ville = leCegep.Ville;
            Province = leCegep.Province;
            CodePostal = leCegep.CodePostal;
            Telephone = leCegep.Telephone;
            Courriel = leCegep.Courriel;
        }

        #endregion Constructeurs
    }
}
