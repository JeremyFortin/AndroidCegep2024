using Microsoft.Data.SqlClient;
using System.Data;
using AndroidCegep2024.DTOs;
using AndroidCegep2024.Exceptions;

/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace AndroidCegep2024.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'un cours.
    /// </summary>
    public class CoursRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static CoursRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CoursRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CoursRepository();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur privée du repository.
        /// </summary>
        private CoursRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un cours selon ses informatiques uniques.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du Département.</param>
        /// <param name="nomCours">Le nom du cours.</param>
        /// <returns>Le ID du cours.</returns>
        public int ObtenirIdCours(string nomCegep, string nomDepartement, string nomCours)
        {
            SqlCommand command = new SqlCommand(" SELECT Id " +
                                                "   FROM Cours " +
                                                "  WHERE Nom = @nomCours " +
                                                "    AND IdDepartement = @idDepartement", connexion);

            SqlParameter nomCoursParam = new SqlParameter("@nomCours", SqlDbType.VarChar, 100);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            nomCoursParam.Value = nomCours;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(nomCoursParam);
            command.Parameters.Add(idDepartementParam);

            int id;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
                reader.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un id du cours par son nom, sont département et son Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des cours d'un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <returns>Liste des cours.</returns>
        public List<CoursDTO> ObtenirListeCours(string nomCegep, string nomDepartement)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM Cours " +
                                                "  WHERE IdDepartement = @idDepartement", connexion);

            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(idDepartementParam);

            List<CoursDTO> liste = new List<CoursDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    CoursDTO cours = new CoursDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(cours);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des cours par le nom du département et le nom du Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un cours selon ses informations uniques.
        /// </summary>
        /// <param name="nomCegep">Nom du Cégep.</param>
        /// <param name="nomCegep">Nom du département.</param>
        /// <param name="noEmploye">Nom du cours.</param>
        /// <returns>Le DTO du cours.</returns>
        public CoursDTO ObtenirCours(string nomCegep, string nomDepartement, string nomCours)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM Cours " +
                                                " WHERE Nom = @nomCours " +
                                                "   AND IdDepartement = @idDepartement", connexion);

            SqlParameter nomCoursParam = new SqlParameter("@nomCours", SqlDbType.VarChar, 100);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            nomCoursParam.Value = nomCours;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(nomCoursParam);
            command.Parameters.Add(idDepartementParam);

            CoursDTO unCours;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unCours = new CoursDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                reader.Close();
            return unCours;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un cours par son nom, son département et son cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un cours.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du departement.</param>
        /// <param name="coursDTO">Le DTO du cours.</param>
        public void AjouterCours(string nomCegep, string nomDepartement, CoursDTO coursDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO Cours (No, Nom, Description, IDDepartement) " +
                                  " VALUES (@noCours, @nom, @description, @idDepartement) ";

            SqlParameter noCoursParam = new SqlParameter("@noCours", SqlDbType.VarChar, 50);
            SqlParameter nomCoursParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 500);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            noCoursParam.Value = coursDTO.No;
            nomCoursParam.Value = coursDTO.Nom;
            descriptionParam.Value = coursDTO.Description;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(noCoursParam);
            command.Parameters.Add(nomCoursParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(idDepartementParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un cours...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un cours.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <param name="coursDTO">Le DTO du cours.</param>
        public void ModifierCours(string nomCegep, string nomDepartement, CoursDTO coursDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE Cours " +
                                     " SET No = @noCours, " +
                                     "     Description = @description " +
                                   " WHERE Nom = @nomCours " +
                                   "   AND idDepartement = @idDepartement ";

            SqlParameter noCoursParam = new SqlParameter("@noCours", SqlDbType.VarChar, 50);
            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 500);
            SqlParameter nomCoursParam = new SqlParameter("@nomCours", SqlDbType.VarChar, 100);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            noCoursParam.Value = coursDTO.No;
            descriptionParam.Value = coursDTO.Description;
            nomCoursParam.Value = coursDTO.Nom;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(noCoursParam);
            command.Parameters.Add(nomCoursParam);
            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(idDepartementParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'un cours...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un cours.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <param name="coursDTO">Le DTO du cours.</param>
        public void SupprimerCours(string nomCegep, string nomDepartement, CoursDTO coursDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM Cours " +
                                   " WHERE Id = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdCours(nomCegep, nomDepartement, coursDTO.Nom);

            command.Parameters.Add(idParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un cours...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
