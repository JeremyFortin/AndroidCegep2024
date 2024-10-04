using AndroidCegep2024.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace AndroidCegep2024.DTOs
{
    /// <summary>
    /// Classe de DTO pour un département.
    /// </summary>
    public class DepartementDTO
    {
        #region Proprietes

        /// <summary>
        /// Propriété représentant le numéro du département.
        /// </summary>
        public string No { get; private set; }
        /// <summary>
        /// Propriété représentant le nom du département.
        /// </summary>
        public string Nom { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; private set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="no">Le numéro du département.</param>
        /// <param name="nom">Le nom du département.</param>
        /// <param name="description">La description du département.</param>
        public DepartementDTO(string no="", string nom="", string description="")
        {
            No = no;
            Nom = nom;
            Description = description;
        }

        /// <summary>
        /// Constructeur avec un modèle.
        /// </summary>
        /// <param name="leDepartement">Le modèle du département.</param>
        public DepartementDTO(Departement leDepartement)
        {
            No = leDepartement.No;
            Nom = leDepartement.Nom;
            Description = leDepartement.Description;
        }

        #endregion Constructeurs
    }
}
